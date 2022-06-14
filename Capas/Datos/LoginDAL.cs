using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using LoansDAL;
using SoftLoans.Datos;

public class LoginDAL
{
    ConexionD dbm = new ConexionD();
    LoginDAL loginDAL = null;

    public int UserID { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public string DataBaseName { get; set; }
    public string DataSource { get; set; }
    public DateTime CreationDate { get; set; }
    public int LicenseID { get; set; }
    public bool IsAdministrator { get; set; }
    public bool AllowCancelTransaction { get; set; }
    public DateTime LastLoginDate { get; set; }
    public bool Enabled { get; set; }
    public string DeviceID { get; set; }

    private int errorCode;
    private string errorDescription;
    public string Company { get; set; }
    public string Phone { get; set; }

    public string Contract { get; set; }

    public string ContractTitle { get; set; }
    public int ErrorCode
    {
        get { return errorCode; }
        set { errorCode = value; }
    }

    public string ErrorDescription
    {
        get { return errorDescription; }
        set { errorDescription = value; }
    }


    public void Login() { }

    public bool UpadetDeviceID() 
    {
        bool respuesta = false;
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        try
        {
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersUpdateDeviceID", con);

            parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
            parametros.Value = UserID;

            parametros = cmd.Parameters.Add("@DeviceID", SqlDbType.VarChar);
            parametros.Value = DeviceID;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteReader();
            con.Close();
            respuesta = true;
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }

        return respuesta;

    }
    public bool LiberarDeviceID()
    {
        bool respuesta = false;
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        try
        {
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersLiberar", con);

            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;

            parametros = cmd.Parameters.Add("@DeviceID", SqlDbType.VarChar);
            parametros.Value = DeviceID;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteReader();
            con.Close();
            respuesta = true;
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }

        return respuesta;

    }
    public bool CerrarDeviceID()
    {
        bool respuesta = false;
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        try
        {
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersCerrar", con);

            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;

            parametros = cmd.Parameters.Add("@DeviceID", SqlDbType.VarChar);
            parametros.Value = DeviceID;


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteReader();
            con.Close();
            respuesta = true;
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }

        return respuesta;

    }


    public List<LoginDAL> Search()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoginDAL> LoginList = new List<LoginDAL>();
        try
        {
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("UserSearch", con);

            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;


            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loginDAL = new LoginDAL();
                    loginDAL.UserID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    loginDAL.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    loginDAL.UserPassword = dr.GetString(dr.GetOrdinal("UserPassword"));
                    loginDAL.DataSource = dr.GetString(dr.GetOrdinal("DataSource"));
                    loginDAL.DataBaseName = dr.GetString(dr.GetOrdinal("DataBaseName"));
                    loginDAL.CreationDate = dr.GetDateTime(dr.GetOrdinal("CreationDate"));
                    loginDAL.LicenseID = dr.GetInt32(dr.GetOrdinal("LicenseID"));
                    loginDAL.IsAdministrator = dr.GetBoolean(dr.GetOrdinal("IsAdministrator"));
                    loginDAL.AllowCancelTransaction = dr.GetBoolean(dr.GetOrdinal("AllowCancelTransaction"));
                    loginDAL.LastLoginDate = dr.GetDateTime(dr.GetOrdinal("LastLoginDate"));
                    loginDAL.Enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    loginDAL.DeviceID = dr.GetString(dr.GetOrdinal("DeviceID"));
                    loginDAL.Company = dr.GetString(dr.GetOrdinal("Company"));
                    loginDAL.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                    loginDAL.Contract = dr.GetString(dr.GetOrdinal("Contract"));
                    loginDAL.ContractTitle = dr.GetString(dr.GetOrdinal("ContractTitle"));
                    LoginList.Add(loginDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }

        return LoginList;
    }

  


}
