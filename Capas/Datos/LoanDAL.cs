using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Loans.Entity;
using LoansDAL;

public class LoanDAL
{
    public Connection dbm = new Connection();
    public string errorDescription = string.Empty;



    public LoanDAL() { }

    public Boolean Insert(LoansEntity loansEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoansInsert", con);
            parametros = cmd.Parameters.Add("@Capital", SqlDbType.Decimal);
            parametros.Value = loansEntity.Capital;
            parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            parametros.Value = loansEntity.CustomerID;
            parametros = cmd.Parameters.Add("@Frequency", SqlDbType.VarChar);
            parametros.Value = loansEntity.Frequency;
            parametros = cmd.Parameters.Add("@PercentInterest", SqlDbType.Decimal);
            parametros.Value = loansEntity.PercentInterest;
            parametros = cmd.Parameters.Add("@InterestAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.InterestAmount;
            parametros = cmd.Parameters.Add("@FixedInterest", SqlDbType.Bit);
            parametros.Value = loansEntity.FixedInterest;
            parametros = cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.TotalAmount;
            parametros = cmd.Parameters.Add("@ForQuota", SqlDbType.Bit);
            parametros.Value = loansEntity.ForQuota;
            parametros = cmd.Parameters.Add("@DueAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.DueAmount;
            parametros = cmd.Parameters.Add("@DueTime", SqlDbType.Int);
            parametros.Value = loansEntity.DueTime;
            parametros = cmd.Parameters.Add("@SafeAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.SafeAmount;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
            parametros.Value = loansEntity.Status;
            parametros = cmd.Parameters.Add("@Lawyer", SqlDbType.Decimal);
            parametros.Value = loansEntity.Lawyer;
            parametros = cmd.Parameters.Add("@ActOfSale", SqlDbType.Decimal);
            parametros.Value = loansEntity.ActOfSale;
            parametros = cmd.Parameters.Add("@Opposition", SqlDbType.Decimal);
            parametros.Value = loansEntity.Opposition;
            parametros = cmd.Parameters.Add("@Transfer", SqlDbType.Decimal);
            parametros.Value = loansEntity.Transfer;
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    loansEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    res = true;
                }
            }

            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public Boolean Edit(LoansEntity loansEntity, LoginDAL loginDAL)
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
            SqlCommand cmd = new SqlCommand("LoansUpdate", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = loansEntity.ID;
            parametros = cmd.Parameters.Add("@Capital", SqlDbType.Decimal);
            parametros.Value = loansEntity.Capital;
            parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = loansEntity.Date;
            parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            parametros.Value = loansEntity.CustomerID;
            parametros = cmd.Parameters.Add("@Frequency", SqlDbType.VarChar);
            parametros.Value = loansEntity.Frequency;
            parametros = cmd.Parameters.Add("@PercentInterest", SqlDbType.Decimal);
            parametros.Value = loansEntity.PercentInterest;
            parametros = cmd.Parameters.Add("@InterestAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.InterestAmount;
            parametros = cmd.Parameters.Add("@FixedInterest", SqlDbType.Bit);
            parametros.Value = loansEntity.FixedInterest;
            parametros = cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.TotalAmount;
            parametros = cmd.Parameters.Add("@ForQuota", SqlDbType.Bit);
            parametros.Value = loansEntity.ForQuota;
            parametros = cmd.Parameters.Add("@DueAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.DueAmount;
            parametros = cmd.Parameters.Add("@DueTime", SqlDbType.Int);
            parametros.Value = loansEntity.DueTime;
            parametros = cmd.Parameters.Add("@SafeAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.SafeAmount;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
            parametros.Value = loansEntity.Status;
            parametros = cmd.Parameters.Add("@Lawyer", SqlDbType.Decimal);
            parametros.Value = loansEntity.Lawyer;
            parametros = cmd.Parameters.Add("@ActOfSale", SqlDbType.Decimal);
            parametros.Value = loansEntity.ActOfSale;
            parametros = cmd.Parameters.Add("@Opposition", SqlDbType.Decimal);
            parametros.Value = loansEntity.Opposition;
            parametros = cmd.Parameters.Add("@Transfer", SqlDbType.Decimal);
            parametros.Value = loansEntity.Transfer;
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
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoansDelete", con);
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


    public List<LoansEntity> Search(LoansEntity loansEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();

        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoansEntity> loansList = new List<LoansEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoansSearch", con);

            if (loansEntity.ID > 0)
            {
                parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
                parametros.Value = loansEntity.ID;
            }

            if (loansEntity.CustomerID > 0)
            {
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = loansEntity.CustomerID;
            }

            if (!string.IsNullOrEmpty(loansEntity.Status))
            {
                parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                parametros.Value = loansEntity.Status;
            }

            if (!string.IsNullOrEmpty(loansEntity.CustomerName))
            {
                parametros = cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar);
                parametros.Value = loansEntity.CustomerName;
            }

            if (!string.IsNullOrEmpty(loansEntity.IdentificationNumber))
            {
                parametros = cmd.Parameters.Add("@IdentificationNumber", SqlDbType.VarChar);
                parametros.Value = loansEntity.IdentificationNumber;
            }

            //parametros = cmd.Parameters.Add("@TimeStart", SqlDbType.DateTime);
            //parametros.Value = loansEntity.TimeStart.ToShortDateString() +" 00:00:00";

            //parametros = cmd.Parameters.Add("@TimeEnd", SqlDbType.DateTime);
            //parametros.Value = loansEntity.TimeEnd.ToShortDateString() + " 23:59:58";


            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loansEntity = new LoansEntity();
                    loansEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    loansEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loansEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loansEntity.CustomerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    loansEntity.Frequency = dr.GetString(dr.GetOrdinal("Frequency"));
                    loansEntity.PercentInterest = dr.GetDecimal(dr.GetOrdinal("PercentInterest"));
                    loansEntity.InterestAmount = dr.GetDecimal(dr.GetOrdinal("InterestAmount"));
                    loansEntity.FixedInterest = dr.GetBoolean(dr.GetOrdinal("FixedInterest"));
                    loansEntity.TotalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                    loansEntity.ForQuota = dr.GetBoolean(dr.GetOrdinal("ForQuota"));
                    loansEntity.DueAmount = dr.GetDecimal(dr.GetOrdinal("DueAmount"));
                    loansEntity.DueTime = dr.GetInt32(dr.GetOrdinal("DueTime"));
                    loansEntity.SafeAmount = dr.GetDecimal(dr.GetOrdinal("SafeAmount"));
                    loansEntity.Status = dr.GetString(dr.GetOrdinal("Status"));
                    loansEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    loansEntity.Lawyer = dr.GetDecimal(dr.GetOrdinal("Lawyer"));
                    loansEntity.ActOfSale = dr.GetDecimal(dr.GetOrdinal("ActOfSale"));
                    loansEntity.Opposition = dr.GetDecimal(dr.GetOrdinal("Opposition"));
                    loansEntity.Transfer = dr.GetDecimal(dr.GetOrdinal("Transfer"));
                    loansEntity.RouteID = dr.GetInt32(dr.GetOrdinal("RouteID"));
                    loansList.Add(loansEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loansList;
    }


    public List<LoansEntity> DueLoanSearch(LoansEntity loansEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();

        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoansEntity> loansList = new List<LoansEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("DueLoansSearch", con);


            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loansEntity = new LoansEntity();
                    loansEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    loansEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loansEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loansEntity.CustomerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    loansEntity.Frequency = dr.GetString(dr.GetOrdinal("Frequency"));
                    loansEntity.PercentInterest = dr.GetDecimal(dr.GetOrdinal("PercentInterest"));
                    loansEntity.InterestAmount = dr.GetDecimal(dr.GetOrdinal("InterestAmount"));
                    loansEntity.FixedInterest = dr.GetBoolean(dr.GetOrdinal("FixedInterest"));
                    loansEntity.TotalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                    loansEntity.ForQuota = dr.GetBoolean(dr.GetOrdinal("ForQuota"));
                    loansEntity.DueAmount = dr.GetDecimal(dr.GetOrdinal("DueAmount"));
                    loansEntity.DueTime = dr.GetInt32(dr.GetOrdinal("DueTime"));
                    loansEntity.SafeAmount = dr.GetDecimal(dr.GetOrdinal("SafeAmount"));
                    loansEntity.Status = dr.GetString(dr.GetOrdinal("Status"));
                    loansEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    loansList.Add(loansEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loansList;
    }


    public Boolean UpdateLoanStatus(LoansEntity loansEntity, LoginDAL loginDAL)
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
            SqlCommand cmd = new SqlCommand("LoansUpdateStatus", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = loansEntity.ID;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
            parametros.Value = loansEntity.Status;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }

    public List<LoansEntity> SearchAll(LoansEntity loansEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();

        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoansEntity> loansList = new List<LoansEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoansSearchAll", con);


            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loansEntity = new LoansEntity();
                    loansEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    loansEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loansEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loansEntity.CustomerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    loansEntity.Frequency = dr.GetString(dr.GetOrdinal("Frequency"));
                    loansEntity.PercentInterest = dr.GetDecimal(dr.GetOrdinal("PercentInterest"));
                    loansEntity.InterestAmount = dr.GetDecimal(dr.GetOrdinal("InterestAmount"));
                    loansEntity.FixedInterest = dr.GetBoolean(dr.GetOrdinal("FixedInterest"));
                    loansEntity.TotalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                    loansEntity.ForQuota = dr.GetBoolean(dr.GetOrdinal("ForQuota"));
                    loansEntity.DueAmount = dr.GetDecimal(dr.GetOrdinal("DueAmount"));
                    loansEntity.DueTime = dr.GetInt32(dr.GetOrdinal("DueTime"));
                    loansEntity.SafeAmount = dr.GetDecimal(dr.GetOrdinal("SafeAmount"));
                    loansEntity.Status = dr.GetString(dr.GetOrdinal("Status"));
                    loansEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    loansEntity.Lawyer = dr.GetDecimal(dr.GetOrdinal("Lawyer"));
                    loansEntity.ActOfSale = dr.GetDecimal(dr.GetOrdinal("ActOfSale"));
                    loansEntity.Opposition = dr.GetDecimal(dr.GetOrdinal("Opposition"));
                    loansEntity.Transfer = dr.GetDecimal(dr.GetOrdinal("Transfer"));
                    loansList.Add(loansEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loansList;
    }

    public Boolean UpdateAmounts(LoansEntity loansEntity, LoginDAL loginDAL)
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
            SqlCommand cmd = new SqlCommand("LoansUpdateAmounts", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = loansEntity.ID;
            parametros = cmd.Parameters.Add("@SafeAmount", SqlDbType.Decimal);
            parametros.Value = loansEntity.SafeAmount;
            parametros = cmd.Parameters.Add("@Lawyer", SqlDbType.Decimal);
            parametros.Value = loansEntity.Lawyer;
            parametros = cmd.Parameters.Add("@ActOfSale", SqlDbType.Decimal);
            parametros.Value = loansEntity.ActOfSale;
            parametros = cmd.Parameters.Add("@Opposition", SqlDbType.Decimal);
            parametros.Value = loansEntity.Opposition;
            parametros = cmd.Parameters.Add("@Transfer", SqlDbType.Decimal);
            parametros.Value = loansEntity.Transfer;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }

}
