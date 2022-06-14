using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Loans.Entity;
using LoansDAL;

public class CashierDAL
{
    public Connection dbm = new Connection();
    public string errorDescription = string.Empty;

	

	public CashierDAL(){ }

	public Boolean Insert(CashierEntity cashierEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("CashierInsert", con);
			parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = cashierEntity.Amount;
			parametros = cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime);
            parametros.Value = cashierEntity.LastUpdate;
            parametros = cmd.Parameters.Add("@Type", SqlDbType.VarChar);
            parametros.Value = cashierEntity.Type;
            parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
            parametros.Value = cashierEntity.Description;
            parametros = cmd.Parameters.Add("@Operation", SqlDbType.VarChar);
            parametros.Value = cashierEntity.Operation;
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = cashierEntity.UserName;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public Boolean Edit(CashierEntity cashierEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("CashierUpdate", con);
			parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = cashierEntity.ID;
			parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = cashierEntity.Amount;
			parametros = cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime);
            parametros.Value = cashierEntity.LastUpdate;
            parametros = cmd.Parameters.Add("@Type", SqlDbType.VarChar);
            parametros.Value = cashierEntity.Type;
            parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
            parametros.Value = cashierEntity.Description;
            parametros = cmd.Parameters.Add("@Operation", SqlDbType.VarChar);
            parametros.Value = cashierEntity.Operation;
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = cashierEntity.UserName;
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
            dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("CashierDelete", con);
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


	public List<CashierEntity> Search(CashierEntity cashierEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
		List<CashierEntity> cashierList = new List<CashierEntity>();
		try
		{
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("CashierSearch", con);
			cmd.CommandType = CommandType.StoredProcedure;

            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = cashierEntity.StartDate;
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = cashierEntity.EndDate;

			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
					while (dr.Read())
					{
						cashierEntity = new CashierEntity();
						cashierEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
						cashierEntity.Amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
						cashierEntity.LastUpdate = dr.GetDateTime(dr.GetOrdinal("LastUpdate"));
                        cashierEntity.Type = dr.GetString(dr.GetOrdinal("Type"));
                        cashierEntity.Description = dr.GetString(dr.GetOrdinal("Description"));
                        cashierEntity.Operation = dr.GetString(dr.GetOrdinal("Operation"));
                        cashierEntity.UserName = dr.GetString(dr.GetOrdinal("UserName"));
						cashierList.Add(cashierEntity); 
						}
			}
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		 return cashierList;
	}


}
