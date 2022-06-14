using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Loans.Entity;
using LoansDAL;

public class PaysDAL
{
    public Connection dbm = new Connection();
    public string errorDescription = string.Empty;


    public PaysDAL() { }

    public Boolean Insert(PaysEntity paysEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("PaysInsert", con);
            parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = paysEntity.Date;
            parametros = cmd.Parameters.Add("@LoanDetailsID", SqlDbType.BigInt);
            parametros.Value = paysEntity.LoanDetailsID;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = paysEntity.Amount;
            parametros = cmd.Parameters.Add("@Comment", SqlDbType.VarChar);
            parametros.Value = paysEntity.Comment;
            parametros = cmd.Parameters.Add("@Type", SqlDbType.VarChar);
            parametros.Value = paysEntity.Type;
            parametros = cmd.Parameters.Add("@NcfNumber", SqlDbType.VarChar);
            parametros.Value = paysEntity.NcfNumber;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }

    public Boolean InsertCapital(PaysEntity paysEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("PaysInsertCapital", con);
            parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = paysEntity.Date;
            parametros = cmd.Parameters.Add("@LoanDetailsID", SqlDbType.BigInt);
            parametros.Value = paysEntity.LoanDetailsID;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = paysEntity.Amount;
            parametros = cmd.Parameters.Add("@Comment", SqlDbType.VarChar);
            parametros.Value = paysEntity.Comment;
            parametros = cmd.Parameters.Add("@Type", SqlDbType.VarChar);
            parametros.Value = paysEntity.Type;
            parametros = cmd.Parameters.Add("@NcfNumber", SqlDbType.VarChar);
            parametros.Value = paysEntity.NcfNumber;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public Boolean Edit(PaysEntity paysEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("PaysUpdate", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = paysEntity.ID;
            parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = paysEntity.Date;
            parametros = cmd.Parameters.Add("@LoanDetailsID", SqlDbType.BigInt);
            parametros.Value = paysEntity.LoanDetailsID;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = paysEntity.Amount;
            parametros = cmd.Parameters.Add("@Comment", SqlDbType.VarChar);
            parametros.Value = paysEntity.Comment;
            parametros = cmd.Parameters.Add("@Type", SqlDbType.VarChar);
            parametros.Value = paysEntity.Type;
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
            SqlCommand cmd = new SqlCommand("PaysDelete", con);
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


    public List<PaysEntity> Search(PaysEntity paysEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<PaysEntity> paysList = new List<PaysEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("PaysSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (paysEntity.ID > 0)
            {
                parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
                parametros.Value = paysEntity.ID;
            }
            if (paysEntity.RouteID > 0)
            {
                parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                parametros.Value = paysEntity.RouteID;
            }
            if (paysEntity.CustomerID > 0)
            {
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = paysEntity.CustomerID;
            }
            parametros = cmd.Parameters.Add("@TimeStart", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(paysEntity.TimeStart.ToShortDateString() + " 00:00:01");
            //parametros.Value = paysEntity.TimeStart;

            parametros = cmd.Parameters.Add("@TimeEnd", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(paysEntity.TimeEnd.ToShortDateString() + " 23:59:58");

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    paysEntity = new PaysEntity();
                    paysEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    paysEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    paysEntity.LoanDetailsID = dr.GetInt64(dr.GetOrdinal("LoanDetailsID"));
                    paysEntity.Amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    paysEntity.Comment = dr.GetString(dr.GetOrdinal("Comment"));
                    paysEntity.Type = dr.GetString(dr.GetOrdinal("Type"));
                    paysEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    paysEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    paysEntity.NcfNumber = dr.GetString(dr.GetOrdinal("NcfNumber"));
                    paysEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    paysEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    paysEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    paysEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    paysEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    paysEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    paysEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));

                    paysEntity.CapitalPay = dr.GetDecimal(dr.GetOrdinal("CapitalPay"));
                    paysEntity.InterestPay = dr.GetDecimal(dr.GetOrdinal("InterestPay"));
                    paysEntity.DelayPay = dr.GetDecimal(dr.GetOrdinal("DelayPay"));
                    paysEntity.RouteName = dr.GetString(dr.GetOrdinal("RouteName"));
                    paysEntity.RouteID = dr.GetInt32(dr.GetOrdinal("RouteID"));
                    paysEntity.DetailDate = dr.GetDateTime(dr.GetOrdinal("DetailDate"));

                    paysList.Add(paysEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return paysList;
    }



}
