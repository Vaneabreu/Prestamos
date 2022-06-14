using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Loans.Entity;
using LoansDAL;

public class GuarantorDAL
{
    public Connection dbm = new Connection();
    public string errorDescription = string.Empty;


    public GuarantorDAL() { }

    public Boolean Insert(GuarantorEntity guarantorEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("GuarantorInsert", con);
            parametros = cmd.Parameters.Add("@IdentificationType", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.IdentificationType;
            parametros = cmd.Parameters.Add("@IdentificationNumber", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.IdentificationNumber;
            parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Name;
            parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.LastName;
            parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Address;
            parametros = cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Phone;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Status;
            parametros = cmd.Parameters.Add("@Age", SqlDbType.Int);
            parametros.Value = guarantorEntity.Age;
            parametros = cmd.Parameters.Add("@Position", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Position;
            parametros = cmd.Parameters.Add("@WorkPlace", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.WorkPlace;
            parametros = cmd.Parameters.Add("@Salary", SqlDbType.Decimal);
            parametros.Value = guarantorEntity.Salary;
            parametros = cmd.Parameters.Add("@OtherSalary", SqlDbType.Decimal);
            parametros.Value = guarantorEntity.OtherSalary;
            parametros = cmd.Parameters.Add("@TimeInWork", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.TimeInWork;
            parametros = cmd.Parameters.Add("@FatherName", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.FatherName;
            parametros = cmd.Parameters.Add("@MotherName", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.MotherName;
            parametros = cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
            parametros.Value = guarantorEntity.RegistrationDate;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public Boolean Edit(GuarantorEntity guarantorEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("GuarantorUpdate", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = guarantorEntity.ID;
            parametros = cmd.Parameters.Add("@IdentificationType", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.IdentificationType;
            parametros = cmd.Parameters.Add("@IdentificationNumber", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.IdentificationNumber;
            parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Name;
            parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.LastName;
            parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Address;
            parametros = cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Phone;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Status;
            parametros = cmd.Parameters.Add("@Age", SqlDbType.Int);
            parametros.Value = guarantorEntity.Age;
            parametros = cmd.Parameters.Add("@Position", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Position;
            parametros = cmd.Parameters.Add("@WorkPlace", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.WorkPlace;
            parametros = cmd.Parameters.Add("@Salary", SqlDbType.Decimal);
            parametros.Value = guarantorEntity.Salary;
            parametros = cmd.Parameters.Add("@OtherSalary", SqlDbType.Decimal);
            parametros.Value = guarantorEntity.OtherSalary;
            parametros = cmd.Parameters.Add("@TimeInWork", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.TimeInWork;
            parametros = cmd.Parameters.Add("@FatherName", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.FatherName;
            parametros = cmd.Parameters.Add("@MotherName", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.MotherName;
            parametros = cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
            parametros.Value = guarantorEntity.RegistrationDate;
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
            SqlCommand cmd = new SqlCommand("GuarantorDelete", con);
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


    public List<GuarantorEntity> Search(GuarantorEntity guarantorEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<GuarantorEntity> guarantorList = new List<GuarantorEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("GuarantorSearch", con);
            if (guarantorEntity.ID > 0)
            {
                parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
                parametros.Value = guarantorEntity.ID;
            }
            parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.Name;
            parametros = cmd.Parameters.Add("@IdentificationNumber", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.IdentificationNumber;
            parametros = cmd.Parameters.Add("@IdentificationType", SqlDbType.VarChar);
            parametros.Value = guarantorEntity.IdentificationType;

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    guarantorEntity = new GuarantorEntity();
                    guarantorEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    guarantorEntity.IdentificationType = dr.GetString(dr.GetOrdinal("IdentificationType"));
                    guarantorEntity.IdentificationNumber = dr.GetString(dr.GetOrdinal("IdentificationNumber"));
                    guarantorEntity.Name = dr.GetString(dr.GetOrdinal("Name"));
                    guarantorEntity.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                    guarantorEntity.Address = dr.GetString(dr.GetOrdinal("Address"));
                    guarantorEntity.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                    guarantorEntity.Status = dr.GetString(dr.GetOrdinal("Status"));
                    guarantorEntity.Age = dr.GetInt32(dr.GetOrdinal("Age"));
                    guarantorEntity.Position = dr.GetString(dr.GetOrdinal("Position"));
                    guarantorEntity.WorkPlace = dr.GetString(dr.GetOrdinal("WorkPlace"));
                    guarantorEntity.Salary = dr.GetDecimal(dr.GetOrdinal("Salary"));
                    guarantorEntity.OtherSalary = dr.GetDecimal(dr.GetOrdinal("OtherSalary"));
                    guarantorEntity.TimeInWork = dr.GetString(dr.GetOrdinal("TimeInWork"));
                    guarantorEntity.FatherName = dr.GetString(dr.GetOrdinal("FatherName"));
                    guarantorEntity.MotherName = dr.GetString(dr.GetOrdinal("MotherName"));
                    guarantorEntity.RegistrationDate = dr.GetDateTime(dr.GetOrdinal("RegistrationDate"));
                    guarantorList.Add(guarantorEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return guarantorList;
    }


}
