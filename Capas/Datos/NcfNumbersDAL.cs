using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Loans.Entity;
using LoansDAL;

public class NcfNumbersDAL
{
    public Connection dbm = new Connection();
    List<NcfNumbersEntity> ncfNumbersEntityList = new List<NcfNumbersEntity>();
    public string errorDescription = "";

    public NcfNumbersDAL(){ }

    public Boolean Insert(NcfNumbersEntity ncfNumbersEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("NcfNumbersInsert", con);
			parametros = cmd.Parameters.Add("@NcfNumber", SqlDbType.VarChar);
            parametros.Value = ncfNumbersEntity.NcfNumber;
            //parametros = cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
            //parametros.Value = RegistrationDate;
			parametros = cmd.Parameters.Add("@UsedDate", SqlDbType.DateTime);
            parametros.Value = ncfNumbersEntity.UsedDate;
			parametros = cmd.Parameters.Add("@NcfType", SqlDbType.VarChar);
            parametros.Value = ncfNumbersEntity.NcfType;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
            parametros.Value = ncfNumbersEntity.Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
		return res;
	}


    public Boolean Edit(NcfNumbersEntity ncfNumbersEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("NcfNumbersUpdate", con);
			parametros = cmd.Parameters.Add("@NcfNumber", SqlDbType.VarChar);
            parametros.Value = ncfNumbersEntity.NcfNumber;
			parametros = cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
            parametros.Value = ncfNumbersEntity.RegistrationDate;
			parametros = cmd.Parameters.Add("@UsedDate", SqlDbType.DateTime);
            parametros.Value = ncfNumbersEntity.UsedDate;
			parametros = cmd.Parameters.Add("@NcfType", SqlDbType.VarChar);
            parametros.Value = ncfNumbersEntity.NcfType;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
            parametros.Value = ncfNumbersEntity.Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
		return res;
	}


    public Boolean Delete(NcfNumbersEntity ncfNumbersEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("NcfNumbersDelete", con);
            parametros = cmd.Parameters.Add("@NcfNumber", SqlDbType.VarChar);
            parametros.Value = ncfNumbersEntity.NcfNumber;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
		return res;
	}


    public List<NcfNumbersEntity> Search(NcfNumbersEntity ncfNumbersEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
        List<NcfNumbersEntity> NcfNumbersEntityList = new List<NcfNumbersEntity>();
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("NcfNumbersSearch", con);
			cmd.CommandType = CommandType.StoredProcedure;
			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
					while (dr.Read())
					{
                        ncfNumbersEntity = new NcfNumbersEntity();
                        ncfNumbersEntity.NcfCode = dr.GetString(dr.GetOrdinal("NcfCode"));
                        ncfNumbersEntity.Description = dr.GetString(dr.GetOrdinal("Description"));
                        ncfNumbersEntity.NcfNumber = dr.GetString(dr.GetOrdinal("NcfNumber"));
                        ncfNumbersEntity.CurrentSequence = dr.GetInt64(dr.GetOrdinal("CurrentSequence"));
                        ncfNumbersEntity.FinalSequence = dr.GetInt64(dr.GetOrdinal("FinalSequence"));
                        ncfNumbersEntity.Enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                        NcfNumbersEntityList.Add(ncfNumbersEntity);

					}
			}
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }

        return NcfNumbersEntityList;
	}

    public List<NcfNumbersEntity> LoadCombo(NcfNumbersEntity ncfNumbersEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<NcfNumbersEntity> NcfNumbersEntityList = new List<NcfNumbersEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("NcfNumbersSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ncfNumbersEntity = new NcfNumbersEntity();
                    ncfNumbersEntity.NcfCode = dr.GetString(dr.GetOrdinal("NcfCode"));
                    ncfNumbersEntity.Description = dr.GetString(dr.GetOrdinal("Description"));
                    NcfNumbersEntityList.Add(ncfNumbersEntity);
                }
            }
            con.Close();
        }
        catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
        catch (Exception e) { Console.WriteLine("Error :" + e.Message); }

        return NcfNumbersEntityList;
    }

    public List<NcfNumbersEntity> GetNCF(NcfNumbersEntity ncfNumbersEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        ncfNumbersEntityList = new List<NcfNumbersEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetNCF", con);
            cmd.CommandType = CommandType.StoredProcedure;
            parametros = cmd.Parameters.Add("@NcfCode", SqlDbType.VarChar);
            parametros.Value = ncfNumbersEntity.NcfCode;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ncfNumbersEntity = new NcfNumbersEntity();
                    ncfNumbersEntity.NcfNumber = dr.GetString(dr.GetOrdinal("NCF"));
                    ncfNumbersEntity.CurrentSequence = dr.GetInt64(dr.GetOrdinal("CURRENTSEQUENCE"));
                    ncfNumbersEntity.FinalSequence = dr.GetInt64(dr.GetOrdinal("FINALSEQUENCE"));
                    ncfNumbersEntity.Description = dr.GetString(dr.GetOrdinal("DESCRIPTION"));
                    ncfNumbersEntityList.Add(ncfNumbersEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) 
        {
            errorDescription = "Error :" + e.Message; 
        }

        return ncfNumbersEntityList;
    }

    public Boolean UpdateSecuence(NcfNumbersEntity ncfNumbersEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("NcfNumbersUpdateSequence", con);
            parametros = cmd.Parameters.Add("@NcfCode", SqlDbType.VarChar);
            parametros.Value = ncfNumbersEntity.NcfCode;
            if (ncfNumbersEntity.CurrentSequence > 0)
            {
                parametros = cmd.Parameters.Add("@CurrentSequence", SqlDbType.BigInt);
                parametros.Value = ncfNumbersEntity.CurrentSequence;
            }
            if (ncfNumbersEntity.FinalSequence > 0)
            {
                parametros = cmd.Parameters.Add("@FinalSequence", SqlDbType.BigInt);
                parametros.Value = ncfNumbersEntity.FinalSequence;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
        catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
        return res;
    }


}
