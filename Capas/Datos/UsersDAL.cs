using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Loans.Entity;
using System.Text;
using System.Security.Cryptography;
using LoansDAL;

public class UsersDAL
{
    public Connection dbm = new Connection();
    public string errorDescription = string.Empty;

    


    public UsersDAL() { }

    public Boolean Insert(UsersEntity usersEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersInsert", con);
            parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            parametros.Value = usersEntity.Name;
            //parametros = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            //         parametros.Value = EncryptKey(usersEntity.Password);
            parametros = cmd.Parameters.Add("@IsAdministrator", SqlDbType.Bit);
            parametros.Value = usersEntity.IsAdministrator;
            parametros = cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
            parametros.Value = usersEntity.RegistrationDate;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.Bit);
            parametros.Value = usersEntity.Status;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public Boolean Edit(UsersEntity usersEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersUpdate", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = usersEntity.ID;
            parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            parametros.Value = usersEntity.Name;
            //parametros = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            //parametros.Value = EncryptKey(usersEntity.Password);
            parametros = cmd.Parameters.Add("@IsAdministrator", SqlDbType.Bit);
            parametros.Value = usersEntity.IsAdministrator;
            parametros = cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
            parametros.Value = usersEntity.RegistrationDate;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.Bit);
            parametros.Value = usersEntity.Status;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public Boolean Delete(int ID, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersDelete", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = ID;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public List<UsersEntity> Search(UsersEntity usersEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<UsersEntity> usersList = new List<UsersEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersSearch", con);
            if (usersEntity.ID > 0)
            {
                parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
                parametros.Value = usersEntity.ID;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usersEntity = new UsersEntity();
                    usersEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    usersEntity.Name = dr.GetString(dr.GetOrdinal("Name"));
                    usersEntity.RegistrationDate = dr.GetDateTime(dr.GetOrdinal("RegistrationDate"));
                    usersEntity.Password = Decrypt(dr.GetString(dr.GetOrdinal("Password")));
                    usersEntity.IsAdministrator = dr.GetBoolean(dr.GetOrdinal("IsAdministrator"));
                    usersEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    usersList.Add(usersEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return usersList;
    }

    public List<UsersEntity> LoadCombo(UsersEntity usersEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<UsersEntity> usersList = new List<UsersEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersSearch", con);
            if (usersEntity.ID > 0)
            {
                parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
                parametros.Value = usersEntity.ID;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                usersEntity = new UsersEntity();
                usersEntity.ID = -1;
                usersEntity.Name = "--- Todos ---";
                usersList.Add(usersEntity);

                while (dr.Read())
                {
                    usersEntity = new UsersEntity();
                    usersEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    usersEntity.Name = dr.GetString(dr.GetOrdinal("Name"));
                    // usersEntity.Password = Decrypt(dr.GetString(dr.GetOrdinal("Password")));
                    usersEntity.IsAdministrator = dr.GetBoolean(dr.GetOrdinal("IsAdministrator"));
                    usersEntity.RegistrationDate = dr.GetDateTime(dr.GetOrdinal("RegistrationDate"));
                    usersEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    usersList.Add(usersEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return usersList;
    }



    public bool ValidateUser(ref UsersEntity usersEntity, LoginDAL loginDAL)
    {

        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("ValidateUser", con);
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = usersEntity.Name;
            //parametros = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            //parametros.Value = EncryptKey(usersEntity.Password);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usersEntity.IsUser = Convert.ToBoolean(dr.GetInt32(dr.GetOrdinal("isUser")));
                usersEntity.IsAdministrator = dr.GetBoolean(dr.GetOrdinal("isAdministrator"));
                res = true;
            }
            con.Close();
        }
        catch (Exception e)
        {
            res = false;
        }

        return res;
    }

    public string EncryptKey(string texto, LoginDAL loginDAL)
    {
        //arreglo de bytes donde guardaremos la llave
        byte[] keyArray;
        //arreglo de bytes donde guardaremos el texto
        //que vamos a encriptar
        byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

        //se utilizan las clases de encriptación
        //provistas por el Framework
        //Algoritmo MD5
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //se guarda la llave para que se le realice
        //hashing
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("J"));

        hashmd5.Clear();

        //Algoritmo 3DAS
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        //se empieza con la transformación de la cadena
        ICryptoTransform cTransform = tdes.CreateEncryptor();

        //arreglo de bytes donde se guarda la
        //cadena cifrada
        byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

        tdes.Clear();

        //se regresa el resultado en forma de una cadena
        return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
    }

    public string Decrypt(string textoEncriptado)
    {
        byte[] keyArray;
        //convierte el texto en una secuencia de bytes
        byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

        //se llama a las clases que tienen los algoritmos
        //de encriptación se le aplica hashing
        //algoritmo MD5
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("J"));

        hashmd5.Clear();

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateDecryptor();

        byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

        tdes.Clear();
        //se regresa en forma de cadena
        return UTF8Encoding.UTF8.GetString(resultArray);
    }

}
