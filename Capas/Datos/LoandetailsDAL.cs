using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Loans.Entity;
using System.Configuration;
using LoansDAL;

public class LoandetailsDAL
{
    public Connection dbm = new Connection();
    public string errorDescription = string.Empty;


    public LoandetailsDAL() { }

    public Boolean Insert(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoandetailsInsert", con);
            parametros = cmd.Parameters.Add("@LoandID", SqlDbType.Int);
            parametros.Value = loandetailsEntity.LoandID;
            parametros = cmd.Parameters.Add("@Capital", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.Capital;
            parametros = cmd.Parameters.Add("@Interest", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.Interest;
            parametros = cmd.Parameters.Add("@DelayAmount", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.DelayAmount;
            parametros = cmd.Parameters.Add("@CapitalBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.CapitalBalance;
            parametros = cmd.Parameters.Add("@InterestBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.InterestBalance;
            parametros = cmd.Parameters.Add("@DelayBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.DelayBalance;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.Bit);
            parametros.Value = loandetailsEntity.Status;
            parametros = cmd.Parameters.Add("@QuotaNumber", SqlDbType.Int);
            parametros.Value = loandetailsEntity.QuotaNumber;
            parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = loandetailsEntity.Date;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public Boolean Edit(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoandetailsUpdate", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
            parametros.Value = loandetailsEntity.ID;
            parametros = cmd.Parameters.Add("@LoandID", SqlDbType.Int);
            parametros.Value = loandetailsEntity.LoandID;
            parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = loandetailsEntity.Date;
            parametros = cmd.Parameters.Add("@Capital", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.Capital;
            parametros = cmd.Parameters.Add("@Interest", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.Interest;
            parametros = cmd.Parameters.Add("@DelayAmount", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.DelayAmount;
            parametros = cmd.Parameters.Add("@CapitalBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.CapitalBalance;
            parametros = cmd.Parameters.Add("@InterestBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.InterestBalance;
            parametros = cmd.Parameters.Add("@DelayBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.DelayBalance;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.Bit);
            parametros.Value = loandetailsEntity.Status;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public Boolean Delete(long ID, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoandetailsDelete", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
            parametros.Value = ID;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }

    public Boolean LoanDetailPay(long ID, decimal amount, string comment, string type, string ncf, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsPay", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
            parametros.Value = ID;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = amount;
            parametros = cmd.Parameters.Add("@Comment", SqlDbType.VarChar);
            parametros.Value = comment;
            parametros = cmd.Parameters.Add("@Type", SqlDbType.VarChar);
            parametros.Value = type;

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public List<LoandetailsEntity> Search(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoandetailsEntity> loandetailsList = new List<LoandetailsEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoandetailsSearch", con);

            if (loandetailsEntity.LoandID > 0)
            {
                parametros = cmd.Parameters.Add("@LoandID", SqlDbType.Int);
                parametros.Value = loandetailsEntity.LoandID;
            }

            if (loandetailsEntity.FilterDate)
            {
                if (loandetailsEntity.StartDate != null)
                {
                    parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                    parametros.Value = loandetailsEntity.StartDate.ToShortDateString() + " 00:00:00";
                }

                if (loandetailsEntity.EndDate != null)
                {
                    parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
                    parametros.Value = loandetailsEntity.EndDate.ToShortDateString() + " 23:59:58";
                }
            }



            if (loandetailsEntity.RouteID > 0)
            {
                parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                parametros.Value = loandetailsEntity.RouteID;
            }

            if (loandetailsEntity.UserID > 0)
            {
                parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
                parametros.Value = loandetailsEntity.UserID;
            }

            if (loandetailsEntity.StatusInt > 0)
            {
                if (loandetailsEntity.StatusInt == 1)
                {
                    parametros = cmd.Parameters.Add("@Status", SqlDbType.Int);
                    parametros.Value = true;
                }
                else
                {
                    parametros = cmd.Parameters.Add("@Status", SqlDbType.Int);
                    parametros.Value = false;
                }
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loandetailsEntity = new LoandetailsEntity();
                    loandetailsEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                    loandetailsEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    loandetailsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loandetailsEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loandetailsEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));
                    loandetailsEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    loandetailsEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    loandetailsEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    loandetailsEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    loandetailsEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    loandetailsEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    loandetailsEntity.LateAmount = dr.GetDecimal(dr.GetOrdinal("LateAmount"));
                    loandetailsEntity.AmountType = dr.GetString(dr.GetOrdinal("AmountType"));
                    loandetailsEntity.LastDateDelayAmount = dr.GetDateTime(dr.GetOrdinal("LastDateDelayAmount"));
                    loandetailsEntity.ForQuota = dr.GetBoolean(dr.GetOrdinal("ForQuota"));
                    loandetailsEntity.PercentInterest = dr.GetDecimal(dr.GetOrdinal("PercentInterest"));
                    loandetailsEntity.Frequency = dr.GetString(dr.GetOrdinal("Frequency"));
                    loandetailsEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    loandetailsEntity.PayDate = dr.GetDateTime(dr.GetOrdinal("PayDate"));
                    loandetailsEntity.TotalDueAmount = loandetailsEntity.CapitalBalance + loandetailsEntity.InterestBalance + loandetailsEntity.DelayBalance;
                    loandetailsList.Add(loandetailsEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loandetailsList;
    }

    public List<LoandetailsEntity> SearchActive(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoandetailsEntity> loandetailsList = new List<LoandetailsEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoandetailsSearchActive", con);

            if (loandetailsEntity.LoandID > 0)
            {
                parametros = cmd.Parameters.Add("@LoandID", SqlDbType.Int);
                parametros.Value = loandetailsEntity.LoandID;
            }

            if (loandetailsEntity.FilterDate)
            {
                if (loandetailsEntity.StartDate != null)
                {
                    parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                    parametros.Value = loandetailsEntity.StartDate.ToShortDateString() + " 00:00:00";
                }

                if (loandetailsEntity.EndDate != null)
                {
                    parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
                    parametros.Value = loandetailsEntity.EndDate.ToShortDateString() + " 23:59:58";
                }
            }



            if (loandetailsEntity.RouteID > 0)
            {
                parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                parametros.Value = loandetailsEntity.RouteID;
            }

            if (loandetailsEntity.UserID > 0)
            {
                parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
                parametros.Value = loandetailsEntity.UserID;
            }

            if (loandetailsEntity.StatusInt > 0)
            {
                if (loandetailsEntity.StatusInt == 1)
                {
                    parametros = cmd.Parameters.Add("@Status", SqlDbType.Int);
                    parametros.Value = true;
                }
                else
                {
                    parametros = cmd.Parameters.Add("@Status", SqlDbType.Int);
                    parametros.Value = false;
                }
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loandetailsEntity = new LoandetailsEntity();
                    loandetailsEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                    loandetailsEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    loandetailsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loandetailsEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loandetailsEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));
                    loandetailsEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    loandetailsEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    loandetailsEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    loandetailsEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    loandetailsEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    loandetailsEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    loandetailsEntity.LateAmount = dr.GetDecimal(dr.GetOrdinal("LateAmount"));
                    loandetailsEntity.AmountType = dr.GetString(dr.GetOrdinal("AmountType"));
                    loandetailsEntity.LastDateDelayAmount = dr.GetDateTime(dr.GetOrdinal("LastDateDelayAmount"));
                    loandetailsEntity.ForQuota = dr.GetBoolean(dr.GetOrdinal("ForQuota"));
                    loandetailsEntity.PercentInterest = dr.GetDecimal(dr.GetOrdinal("PercentInterest"));
                    loandetailsEntity.Frequency = dr.GetString(dr.GetOrdinal("Frequency"));
                    loandetailsEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    loandetailsEntity.PayDate = dr.GetDateTime(dr.GetOrdinal("PayDate"));
                    loandetailsEntity.TotalQuota = dr.GetInt32(dr.GetOrdinal("TotalQuota"));
                    loandetailsEntity.TotalDueAmount = loandetailsEntity.CapitalBalance + loandetailsEntity.InterestBalance + loandetailsEntity.DelayBalance;

                    if (loandetailsEntity.Status)
                        loandetailsEntity.PayStatus = "No Pagado";
                    else
                        loandetailsEntity.PayStatus = loandetailsEntity.PayDate.ToString("dd/MM/yyyy");

                    loandetailsList.Add(loandetailsEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loandetailsList;
    }

    public List<LoandetailsEntity> SearchPending(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoandetailsEntity> loandetailsList = new List<LoandetailsEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsSearchPending", con);

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loandetailsEntity = new LoandetailsEntity();
                    loandetailsEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                    loandetailsEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    loandetailsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loandetailsEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loandetailsEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));
                    loandetailsEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    loandetailsEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    loandetailsEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    loandetailsEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    loandetailsEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    loandetailsEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    loandetailsEntity.LateAmount = dr.GetDecimal(dr.GetOrdinal("LateAmount"));

                    loandetailsEntity.AmountType = dr.GetString(dr.GetOrdinal("AmountType"));
                    loandetailsEntity.LastDateDelayAmount = dr.GetDateTime(dr.GetOrdinal("LastDateDelayAmount"));
                    loandetailsEntity.ForQuota = dr.GetBoolean(dr.GetOrdinal("ForQuota"));
                    loandetailsEntity.PercentInterest = dr.GetDecimal(dr.GetOrdinal("PercentInterest"));
                    loandetailsEntity.Frequency = dr.GetString(dr.GetOrdinal("Frequency"));
                    loandetailsList.Add(loandetailsEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loandetailsList;
    }

    public List<LoandetailsEntity> SearchReport(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoandetailsEntity> loandetailsList = new List<LoandetailsEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsSearchReport", con);
            parametros = cmd.Parameters.Add("@LoandID", SqlDbType.Int);
            parametros.Value = loandetailsEntity.LoandID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loandetailsEntity = new LoandetailsEntity();
                    loandetailsEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                    loandetailsEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    loandetailsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loandetailsEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loandetailsEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));
                    loandetailsEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    loandetailsEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    loandetailsEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    loandetailsEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    loandetailsEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    loandetailsEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    loandetailsEntity.LateAmount = dr.GetDecimal(dr.GetOrdinal("LateAmount"));
                    loandetailsEntity.AmountType = dr.GetString(dr.GetOrdinal("AmountType"));
                    loandetailsEntity.LastDateDelayAmount = dr.GetDateTime(dr.GetOrdinal("LastDateDelayAmount"));
                    loandetailsEntity.ForQuota = dr.GetBoolean(dr.GetOrdinal("ForQuota"));
                    loandetailsEntity.PercentInterest = dr.GetDecimal(dr.GetOrdinal("PercentInterest"));
                    loandetailsEntity.Frequency = dr.GetString(dr.GetOrdinal("Frequency"));
                    loandetailsEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    loandetailsEntity.Day = loandetailsEntity.Date.Day.ToString();
                    loandetailsEntity.TotalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                    loandetailsList.Add(loandetailsEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loandetailsList;
    }

    public List<LoandetailsEntity> SearchDesc(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoandetailsEntity> loandetailsList = new List<LoandetailsEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoandetailsSearchDesc", con);
            parametros = cmd.Parameters.Add("@LoandID", SqlDbType.Int);
            parametros.Value = loandetailsEntity.LoandID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loandetailsEntity = new LoandetailsEntity();
                    loandetailsEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                    loandetailsEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    loandetailsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loandetailsEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loandetailsEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));
                    loandetailsEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    loandetailsEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    loandetailsEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    loandetailsEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    loandetailsEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    loandetailsEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    loandetailsEntity.LateAmount = dr.GetDecimal(dr.GetOrdinal("LateAmount"));
                    loandetailsEntity.AmountType = dr.GetString(dr.GetOrdinal("AmountType"));
                    loandetailsEntity.LastDateDelayAmount = dr.GetDateTime(dr.GetOrdinal("LastDateDelayAmount"));
                    loandetailsList.Add(loandetailsEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loandetailsList;
    }


    public List<LoandetailsEntity> SearchDueDate(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoandetailsEntity> loandetailsList = new List<LoandetailsEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsDueDateSearch", con);

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loandetailsEntity = new LoandetailsEntity();
                    loandetailsEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                    loandetailsEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    loandetailsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loandetailsEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loandetailsEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));
                    loandetailsEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    loandetailsEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    loandetailsEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    loandetailsEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    loandetailsEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    loandetailsEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    loandetailsEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    loandetailsEntity.LastDateDelayAmount = dr.GetDateTime(dr.GetOrdinal("LastDateDelayAmount"));
                    loandetailsList.Add(loandetailsEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loandetailsList;
    }

    public List<LoandetailsEntity> SearchAssign(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LoandetailsEntity> loandetailsList = new List<LoandetailsEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsAssignSearch", con);


            if (loandetailsEntity.UserMobileID > 0)
            {
                parametros = cmd.Parameters.Add("@UserMobileID", SqlDbType.Int);
                parametros.Value = loandetailsEntity.UserMobileID;
            }

            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(loandetailsEntity.StartDate.ToShortDateString());


            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    loandetailsEntity = new LoandetailsEntity();
                    loandetailsEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                    loandetailsEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    loandetailsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loandetailsEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loandetailsEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));
                    loandetailsEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    loandetailsEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    loandetailsEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    loandetailsEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    loandetailsEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    loandetailsEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    loandetailsEntity.CustomerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    loandetailsEntity.LastDateDelayAmount = dr.GetDateTime(dr.GetOrdinal("LastDateDelayAmount"));
                    loandetailsEntity.UserMobileID = dr.GetInt32(dr.GetOrdinal("UserMobileID"));
                    loandetailsEntity.UserMobileName = dr.GetString(dr.GetOrdinal("UserMobileName"));
                    loandetailsEntity.Employee = dr.GetString(dr.GetOrdinal("EmployeeName"));
                    loandetailsEntity.CustomerAddress = dr.GetString(dr.GetOrdinal("CustomerAddress"));
                    loandetailsEntity.CustomerPhone = dr.GetString(dr.GetOrdinal("CustomerPhone"));
                    loandetailsEntity.CustomerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    loandetailsEntity.TotalQuota = dr.GetInt32(dr.GetOrdinal("TotalQuota"));
                    loandetailsList.Add(loandetailsEntity);
                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loandetailsList;
    }

    public Boolean UpdateDelayAmount(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsUpdateAmountDelayWeb", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
            parametros.Value = loandetailsEntity.ID;
            parametros = cmd.Parameters.Add("@DelayBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.DelayBalance;

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public List<LoandetailsEntity> SearchAll(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        string date = "";
        List<LoandetailsEntity> loandetailsList = new List<LoandetailsEntity>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoandetailsSearchAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    loandetailsEntity = new LoandetailsEntity();
                    loandetailsEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                    loandetailsEntity.LoandID = dr.GetInt32(dr.GetOrdinal("LoandID"));
                    loandetailsEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    loandetailsEntity.Capital = dr.GetDecimal(dr.GetOrdinal("Capital"));
                    loandetailsEntity.Interest = dr.GetDecimal(dr.GetOrdinal("Interest"));
                    loandetailsEntity.DelayAmount = dr.GetDecimal(dr.GetOrdinal("DelayAmount"));
                    loandetailsEntity.CapitalBalance = dr.GetDecimal(dr.GetOrdinal("CapitalBalance"));
                    loandetailsEntity.InterestBalance = dr.GetDecimal(dr.GetOrdinal("InterestBalance"));
                    loandetailsEntity.DelayBalance = dr.GetDecimal(dr.GetOrdinal("DelayBalance"));
                    loandetailsEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                    loandetailsEntity.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                    loandetailsEntity.LateAmount = dr.GetDecimal(dr.GetOrdinal("LateAmount"));
                    loandetailsEntity.AmountType = dr.GetString(dr.GetOrdinal("AmountType"));
                    loandetailsEntity.LastDateDelayAmount = dr.GetDateTime(dr.GetOrdinal("LastDateDelayAmount"));
                    loandetailsEntity.ActOfSale = dr.GetDecimal(dr.GetOrdinal("ActOfSale"));
                    loandetailsEntity.Lawyer = dr.GetDecimal(dr.GetOrdinal("Lawyer"));
                    loandetailsEntity.Opposition = dr.GetDecimal(dr.GetOrdinal("Opposition"));
                    loandetailsEntity.Transfer = dr.GetDecimal(dr.GetOrdinal("Transfer"));
                    loandetailsEntity.SafeAmount = dr.GetDecimal(dr.GetOrdinal("SafeAmount"));
                    loandetailsEntity.TotalExpenses = dr.GetDecimal(dr.GetOrdinal("TotalExpenses"));
                    loandetailsList.Add(loandetailsEntity);

                }
            }
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return loandetailsList;
    }


    public Boolean UpdateAmounts(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsUpdateAmounts", con);

            parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
            parametros.Value = loandetailsEntity.ID;
            parametros = cmd.Parameters.Add("@Capital", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.Capital;
            parametros = cmd.Parameters.Add("@CapitalBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.CapitalBalance;
            parametros = cmd.Parameters.Add("@Interest", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.Interest;
            parametros = cmd.Parameters.Add("@InterestBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.InterestBalance;
            parametros = cmd.Parameters.Add("@DelayAmount", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.DelayAmount;
            parametros = cmd.Parameters.Add("@DelayBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.DelayBalance;
            parametros = cmd.Parameters.Add("@LastDateDelayAmount", SqlDbType.DateTime);
            parametros.Value = loandetailsEntity.LastDateDelayAmount;

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }


    public Boolean UpdateDetailStatus(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsUpdateStatus", con);

            parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
            parametros.Value = loandetailsEntity.ID;
            parametros = cmd.Parameters.Add("@Status", SqlDbType.Bit);
            parametros.Value = loandetailsEntity.Status;

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }

    public Boolean EditAmountDelay(LoandetailsEntity loandetailsEntity, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoanDetailsEditAmount", con);
            parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
            parametros.Value = loandetailsEntity.ID;
            parametros = cmd.Parameters.Add("@NewAmount", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.DelayBalance;
            parametros = cmd.Parameters.Add("@InterestBalance", SqlDbType.Decimal);
            parametros.Value = loandetailsEntity.InterestBalance;

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }

    public Boolean FixAmount(int loandID, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("LoandetailsFixAmount", con);
            parametros = cmd.Parameters.Add("@LoandID", SqlDbType.Int);
            parametros.Value = loandID;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e) { errorDescription = e.Message; }
        return res;
    }

}
