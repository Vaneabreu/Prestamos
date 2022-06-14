using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class CompanyPaymentsDAL
{
	Connection dbm = new Connection();
    CompanyPaymentsDAL companyPaymentsDAL = null;

    private long companyPaymentID;
    private int companyID;
    private decimal amount;
    private DateTime date;
    private decimal commission;
    private decimal partnerCommission;
    private int transactionStatusID;
    private int userID;
    private DateTime startTime;
    private DateTime endTime;
    

    private string errorDescription = "successful";
    private int errorCode = 0;
    private string reference;
    private string statusName;
    private string companyName;

    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }

    public string StatusName
    {
        get { return statusName; }
        set { statusName = value; }
    }

    public string Reference
    {
        get { return reference; }
        set { reference = value; }
    }

    public DateTime StartTime
    {
        get { return startTime; }
        set { startTime = value; }
    }
    public DateTime EndTime
    {
        get { return endTime; }
        set { endTime = value; }
    }

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
    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public int TransactionStatusID
    {
        get { return transactionStatusID; }
        set { transactionStatusID = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public decimal Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public long CompanyPaymentID
    {
        get { return companyPaymentID; }
        set { companyPaymentID = value; }
    }
    public decimal PartnerCommission
    {
        get { return partnerCommission; }
        set { partnerCommission = value; }
    }

    public decimal Commission
    {
        get { return commission; }
        set { commission = value; }
    }

    public int CompanyID
    {
        get { return companyID; }
        set { companyID = value; }
    }

	public Boolean Insert(string User)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{

			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("CompanyPaymentInsert", con);
			parametros = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			parametros.Value = CompanyID;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
			parametros.Value = Amount;
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = User;
            parametros = cmd.Parameters.Add("@Reference", SqlDbType.VarChar);
            parametros.Value = Reference;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) 
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }
		return res;
	}


	public Boolean Edit()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyPaymentUpdate", con);
            parametros = cmd.Parameters.Add("@CompanyPaymentID", SqlDbType.BigInt);
            parametros.Value = CompanyPaymentID;
            parametros = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
            parametros.Value = CompanyID;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = Amount;
            parametros = cmd.Parameters.Add("@Commission", SqlDbType.Decimal);
            parametros.Value = Commission;
            parametros = cmd.Parameters.Add("@Commission", SqlDbType.Decimal);
            parametros.Value = PartnerCommission;
            parametros = cmd.Parameters.Add("@TransactionStatusID", SqlDbType.Int);
            parametros.Value = TransactionStatusID;
            parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
            parametros.Value = UserID;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        return res;
	}

    public Boolean ChangeStatus(string status)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyPaymentChangeStatus", con);
            parametros = cmd.Parameters.Add("@CompanyPaymentID", SqlDbType.BigInt);
            parametros.Value = CompanyPaymentID;
            parametros = cmd.Parameters.Add("@TransactionStatus", SqlDbType.VarChar);
            parametros.Value = status;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        return res;
    }

	public Boolean Delete()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("CompanyPaymentDelete", con);
            parametros = cmd.Parameters.Add("@CompanyPaymentID", SqlDbType.BigInt);
			parametros.Value = CompanyPaymentID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        return res;
	}


    public List<CompanyPaymentsDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<CompanyPaymentsDAL> companyPaymentList = new List<CompanyPaymentsDAL>();
        try
        {

            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyPaymentSearch", con);

            if (CompanyID > 0)
            {
                parametros = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                parametros.Value = CompanyID;
            }
            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(StartTime.ToShortDateString() + " 00:00:00");
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(EndTime.ToShortDateString() + " 23:59:59");

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {

                    companyPaymentsDAL = new CompanyPaymentsDAL();
                    companyPaymentsDAL.companyPaymentID = dr.GetInt64(dr.GetOrdinal("CompanyPaymentID"));
                    companyPaymentsDAL.companyID = dr.GetInt32(dr.GetOrdinal("CompanyID"));
                    companyPaymentsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    companyPaymentsDAL.date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    companyPaymentsDAL.commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                    companyPaymentsDAL.partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                    companyPaymentsDAL.transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                    companyPaymentsDAL.userID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    companyPaymentsDAL.reference = dr.GetString(dr.GetOrdinal("Reference"));
                    companyPaymentsDAL.statusName = dr.GetString(dr.GetOrdinal("StatusName"));
                    companyPaymentsDAL.companyName = dr.GetString(dr.GetOrdinal("CompanyName"));
                    companyPaymentList.Add(companyPaymentsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return companyPaymentList;
	}


	public Boolean GetByKey()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyPaymentGetByKey", con);
            parametros = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
            parametros.Value = CompanyID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                companyPaymentID = dr.GetInt64(dr.GetOrdinal("CompanyPaymentID"));
                companyID = dr.GetInt32(dr.GetOrdinal("CompanyID"));
                amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                date = dr.GetDateTime(dr.GetOrdinal("Date"));
                commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                userID = dr.GetInt32(dr.GetOrdinal("UserID"));

                res = true;
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
            res = false;
        }

        return res;
	}

    public void clearFields()
    {
        companyPaymentID = 0;
        companyID = 0;
        amount = 0;
        commission = 0;
        partnerCommission = 0;
        transactionStatusID = 0;
        userID = 0;
    }


}
