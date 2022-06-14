using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Loans.Entity;
using LoansDAL;

public class LogsDAL
{
    public Connection dbm = new Connection();
    public string errorDescription = string.Empty;

	

	public LogsDAL(){ }

	public Boolean Insert(LogsEntity logsEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("LogsInsertar", con);
			parametros = cmd.Parameters.Add("@Action", SqlDbType.VarChar);
            parametros.Value = logsEntity.Action;
			parametros = cmd.Parameters.Add("@Detail", SqlDbType.VarChar);
            parametros.Value = logsEntity.Detail;
			parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = logsEntity.Date;
			parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = logsEntity.UserName;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public Boolean Edit(LogsEntity logsEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("LogsEditar", con);
			parametros = cmd.Parameters.Add("@LogID", SqlDbType.BigInt);
            parametros.Value = logsEntity.LogID;
			parametros = cmd.Parameters.Add("@Action", SqlDbType.VarChar);
            parametros.Value = logsEntity.Action;
			parametros = cmd.Parameters.Add("@Detail", SqlDbType.VarChar);
            parametros.Value = logsEntity.Detail;
			parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = logsEntity.Date;
			parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = logsEntity.UserName;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public Boolean Delete(long LogID, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("LogsBorrar", con);
			parametros = cmd.Parameters.Add("@LogID", SqlDbType.BigInt);
			parametros.Value = LogID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public List<LogsEntity> Search(LogsEntity logsEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
		List<LogsEntity> logsList = new List<LogsEntity>();
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("LogsBuscar", con);

            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = logsEntity.StartDate;
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = logsEntity.EndDate;

            if (!string.IsNullOrEmpty(logsEntity.UserName))
            {
                parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
                parametros.Value = logsEntity.UserName;
            }

			cmd.CommandType = CommandType.StoredProcedure;
			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
					while (dr.Read())
					{
						logsEntity = new LogsEntity();
						logsEntity.LogID = dr.GetInt64(dr.GetOrdinal("LogID"));
						logsEntity.Action = dr.GetString(dr.GetOrdinal("Action"));
						logsEntity.Detail = dr.GetString(dr.GetOrdinal("Detail"));
						logsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
						logsEntity.UserName = dr.GetString(dr.GetOrdinal("UserName"));
						logsList.Add(logsEntity); 
						}
			}
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		 return logsList;
	}


}
