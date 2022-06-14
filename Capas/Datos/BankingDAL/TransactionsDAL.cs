using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class TransactionsDAL
{
    Connection dbm = new Connection();
    TransactionsDAL transactionsDAL = null;

	private long transactionID;
	private int branchID;
	private decimal amount;
	private int shiftID;
	private DateTime date;
	private int transactionStatusID;
	private int userID;
	private decimal commission;
	private decimal partnerCommission;
	private int totalGainAmount;
    private string branchName;
    private string shiftName;
    private string transactionStatusName;
    private string userName;
    private DateTime startTime;
    private DateTime endTime;
    private int errorCode;
    private string errorDescription;
    private bool allowTransaction;
    private string playTypeName;
    private string numbers;
    private string lotteryName;
    private bool existCombination;
    private int customerID;
    private decimal totalAmount;
    private int availableAmount;
    private int lotteryID;
    private string ticketID;
    private bool isMobil;
    private decimal totalCommission;
    private decimal discount;
    private decimal totalDiscount;

    public decimal TotalDiscount
    {
        get { return totalDiscount; }
        set { totalDiscount = value; }
    }

    public decimal Discount
    {
        get { return discount; }
        set { discount = value; }
    }
    public decimal TotalCommission
    {
        get { return totalCommission; }
        set { totalCommission = value; }
    }

    public bool IsMobil
    {
        get { return isMobil; }
        set { isMobil = value; }
    }

    public string TicketID
    {
        get { return ticketID; }
        set { ticketID = value; }
    }

    public int LotteryID
    {
        get { return lotteryID; }
        set { lotteryID = value; }
    }


    public int AvailableAmount
    {
        get { return availableAmount; }
        set { availableAmount = value; }
    }

    public decimal TotalAmount
    {
        get { return totalAmount; }
        set { totalAmount = value; }
    }

    public int CustomerID
    {
        get { return customerID; }
        set { customerID = value; }
    }

    public bool ExistCombination
    {
        get { return existCombination; }
        set { existCombination = value; }
    }


    public string LotteryName
    {
        get { return lotteryName; }
        set { lotteryName = value; }
    }
    public string Numbers
    {
        get { return numbers; }
        set { numbers = value; }
    }

    public string PlayTypeName
    {
        get { return playTypeName; }
        set { playTypeName = value; }
    }

    public bool AllowTransaction
    {
        get { return allowTransaction; }
        set { allowTransaction = value; }
    }


    public DateTime EndTime
    {
        get { return endTime; }
        set { endTime = value; }
    }

    public DateTime StartTime
    {
        get { return startTime; }
        set { startTime = value; }
    }

    public string BranchName
    {
        get { return branchName; }
        set { branchName = value; }
    }

    public string ShiftName
    {
        get { return shiftName; }
        set { shiftName = value; }
    }

    public string TransactionStatusName
    {
        get { return transactionStatusName; }
        set { transactionStatusName = value; }
    }

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
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

	public long TransactionID
	{
		get { return transactionID; }
		set { transactionID = value; }
	}
	public int BranchID
	{
		get { return branchID; }
		set { branchID = value; }
	}
	public decimal Amount
	{
		get { return amount; }
		set { amount = value; }
	}
	public int ShiftID
	{
		get { return shiftID; }
		set { shiftID = value; }
	}
	public DateTime Date
	{
		get { return date; }
		set { date = value; }
	}
	public int TransactionStatusID
	{
		get { return transactionStatusID; }
		set { transactionStatusID = value; }
	}
	public int UserID
	{
		get { return userID; }
		set { userID = value; }
	}
	public decimal Commission
	{
		get { return commission; }
		set { commission = value; }
	}
	public decimal PartnerCommission
	{
		get { return partnerCommission; }
		set { partnerCommission = value; }
	}
	public int TotalGainAmount
	{
		get { return totalGainAmount; }
		set { totalGainAmount = value; }
	}

	public void Transactions(){ }

	public Boolean Insert()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
        SqlDataReader dr = null;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("TransactionsInsert", con);
			parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
			parametros.Value = Amount;
			parametros = cmd.Parameters.Add("@ShiftName", SqlDbType.VarChar);
			parametros.Value = ShiftName;
            parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
            parametros.Value = LotteryName + " " + ShiftName;
			parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
			parametros.Value = UserName;
            parametros = cmd.Parameters.Add("@Lottery", SqlDbType.VarChar);
            parametros.Value = LotteryName;
            parametros = cmd.Parameters.Add("@TicketID", SqlDbType.VarChar);
            parametros.Value = TicketID;
            if (CustomerID != 0)
            {
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = CustomerID;
            }
            if(!string.IsNullOrEmpty(TransactionStatusName))
            {
                parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                parametros.Value = TransactionStatusName;
            }
			cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));
                res = true;
            }

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
            SqlCommand cmd = new SqlCommand("TransactionsUpdate", con);
			parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
			parametros.Value = TransactionID;
			parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
			parametros.Value = BranchID;
			parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
			parametros.Value = Amount;
			parametros = cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
			parametros.Value = ShiftID;
			parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
			parametros.Value = Date;
			parametros = cmd.Parameters.Add("@TransactionStatusID", SqlDbType.Int);
			parametros.Value = TransactionStatusID;
			parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
			parametros.Value = UserID;
			parametros = cmd.Parameters.Add("@Commission", SqlDbType.Decimal);
			parametros.Value = Commission;
			parametros = cmd.Parameters.Add("@PartnerCommission", SqlDbType.Decimal);
			parametros.Value = PartnerCommission;
			parametros = cmd.Parameters.Add("@TotalGainAmount", SqlDbType.Int);
			parametros.Value = TotalGainAmount;
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
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("spTransactions_E", con);
			parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
			parametros.Value = TransactionID;
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


    public List<TransactionsDAL> Search(bool usedDate = false)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionsDAL> transactionsList = new List<TransactionsDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionsSearch", con);

            if (TransactionID > 0)
            {
                parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.Int);
                parametros.Value = TransactionID;
            }
            if (!string.IsNullOrEmpty(UserName))
            {
                parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
                parametros.Value = UserName;
            }
            if (BranchID > 0)
            {
                parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
                parametros.Value = BranchID;
            }
            if (transactionStatusID > 0)
            {
                parametros = cmd.Parameters.Add("@transactionStatusID", SqlDbType.Int);
                parametros.Value = transactionStatusID;
            }
            if (LotteryID > 0)
            {
                parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
                parametros.Value = LotteryID;
            }

        
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = CustomerID;

                if (usedDate)
                {
                    parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                    parametros.Value = StartTime;
                }
                else 
                {
                    parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                    parametros.Value = Convert.ToDateTime(StartTime.ToShortDateString() + " 00:00:00");
                }
           
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(EndTime.ToShortDateString() + " 23:59:59");

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    transactionsDAL = new TransactionsDAL();
                    transactionsDAL.transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));
                    transactionsDAL.branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                    transactionsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    transactionsDAL.shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                    transactionsDAL.date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    transactionsDAL.transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                    transactionsDAL.userID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    transactionsDAL.commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                    transactionsDAL.partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                    transactionsDAL.totalGainAmount = dr.GetInt32(dr.GetOrdinal("TotalGainAmount"));
                    transactionsDAL.branchName = dr.GetString(dr.GetOrdinal("BranchName"));
                    transactionsDAL.transactionStatusName = dr.GetString(dr.GetOrdinal("TransactionStatusName"));
                    transactionsDAL.shiftName = dr.GetString(dr.GetOrdinal("ShiftName"));
                    transactionsDAL.userName = dr.GetString(dr.GetOrdinal("UserName"));
                    transactionsDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                    transactionsDAL.ticketID = dr.GetString(dr.GetOrdinal("TicketID"));
                    transactionsDAL.discount = dr.GetDecimal(dr.GetOrdinal("Discount"));
                    transactionsList.Add(transactionsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionsList;
	}

    public List<TransactionsDAL> SearchStadistic()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionsDAL> transactionsList = new List<TransactionsDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionsStadistic", con);

           
            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(StartTime.ToShortDateString() + " 00:00:00");
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(EndTime.ToShortDateString() + " 23:59:59");

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    transactionsDAL = new TransactionsDAL();
                    transactionsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    transactionsDAL.userName = dr.GetString(dr.GetOrdinal("UserName"));

                    transactionsList.Add(transactionsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionsList;
    }


	public Boolean GetByKey()
	{
        bool res = false;
		SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionsGetByKey", con);
            parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
            parametros.Value = TransactionID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));
                branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                date = dr.GetDateTime(dr.GetOrdinal("Date"));
                transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                userID = dr.GetInt32(dr.GetOrdinal("UserID"));
                commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                totalGainAmount = dr.GetInt32(dr.GetOrdinal("TotalGainAmount"));

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

    public Boolean ValidateLimitsForCombinations()
    {
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("ValidateLimitsForCombinations", con);
            parametros = cmd.Parameters.Add("@PlayTypeName", SqlDbType.VarChar);
            parametros.Value = PlayTypeName;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = Amount;
            parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
            parametros.Value = Numbers;
            parametros = cmd.Parameters.Add("@startDate", SqlDbType.DateTime);
            parametros.Value = DateTime.Now.ToShortDateString() + " 00:00:00";
            parametros = cmd.Parameters.Add("@endDate", SqlDbType.DateTime);
            parametros.Value = DateTime.Now.ToShortDateString() + " 23:59:59";
            parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
            parametros.Value = LotteryName;
            parametros = cmd.Parameters.Add("@ShiftName", SqlDbType.VarChar);
            parametros.Value = ShiftName;

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                AllowTransaction = dr.GetBoolean(dr.GetOrdinal("Allow"));
                ExistCombination = dr.GetBoolean(dr.GetOrdinal("ExistCombination"));
                AvailableAmount = dr.GetInt32(dr.GetOrdinal("AvailableAmount"));

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


    public Boolean ValidateLimitsForPlayTypes()
    {
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("ValidateLimitsForPlayTypes", con);
            parametros = cmd.Parameters.Add("@PlayTypeName", SqlDbType.VarChar);
            parametros.Value = PlayTypeName;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            parametros.Value = Amount;
            parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
            parametros.Value = Numbers;
            parametros = cmd.Parameters.Add("@startDate", SqlDbType.DateTime);
            parametros.Value = DateTime.Now.ToShortDateString() + " 00:00:00";
            parametros = cmd.Parameters.Add("@endDate", SqlDbType.DateTime);
            parametros.Value = DateTime.Now.ToShortDateString() + " 23:59:59";
            parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
            parametros.Value = LotteryName;
            parametros = cmd.Parameters.Add("@ShiftName", SqlDbType.VarChar);
            parametros.Value = ShiftName;

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                AllowTransaction = dr.GetBoolean(dr.GetOrdinal("Allow"));
                AvailableAmount = dr.GetInt32(dr.GetOrdinal("AvailableAmount"));
                ExistCombination = dr.GetBoolean(dr.GetOrdinal("ExistLimit"));

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

    public Boolean CancelTicket()
    {
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {

            
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CancelTicket", con);
            parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
            parametros.Value = TransactionID;
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;
            parametros = cmd.Parameters.Add("@IsMobil", SqlDbType.Bit);
            parametros.Value = IsMobil;

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                res = dr.GetBoolean(dr.GetOrdinal("ISCANCEL"));
                errorDescription = dr.GetString(dr.GetOrdinal("MESSAGE"));
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

    public Boolean GetLastIDByUser()
    {
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetLastIDByUser", con);
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));

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

    public Boolean GetTransactionTotal()
    {
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("getTotalTransactions", con);
            parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
            parametros.Value = LotteryName;
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;

            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(StartTime.ToShortDateString() + " 00:00:00");
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(EndTime.ToShortDateString() + " 23:59:59");
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                totalAmount = dr.GetDecimal(dr.GetOrdinal("totalAmount"));
                totalCommission = dr.GetDecimal(dr.GetOrdinal("totalCommission"));

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

    public Boolean SetAvailableAmount()
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
            SqlCommand cmd = new SqlCommand("SetAvailableAmountTransactions", con);
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;
            parametros = cmd.Parameters.Add("@AvailableAmount", SqlDbType.Int);
            parametros.Value = AvailableAmount;
            parametros = cmd.Parameters.Add("@Commission", SqlDbType.Decimal);
            parametros.Value = Commission;

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

    public List<ReportEntity> SearchSummaryGroup()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<ReportEntity> reportEntityList = new List<ReportEntity>();
        ReportEntity reportEntity = new ReportEntity();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionsSearchSummaryGroup", con);

        
            if (BranchID > 0)
            {
                parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
                parametros.Value = BranchID;
            }
           
            
            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(StartTime.ToShortDateString() + " 00:00:00");
            
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(EndTime.ToShortDateString() + " 23:59:59");

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    reportEntity = new ReportEntity();
                    reportEntity.brancheName = dr.GetString(dr.GetOrdinal("brancheName"));
                    reportEntity.amount = dr.GetDecimal(dr.GetOrdinal("amount"));
                    reportEntity.commission = dr.GetDecimal(dr.GetOrdinal("commission"));
                    reportEntity.gainAmount = dr.GetInt32(dr.GetOrdinal("gainAmount"));
                    reportEntity.total = reportEntity.amount - (reportEntity.commission + reportEntity.gainAmount);

                    reportEntityList.Add(reportEntity);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return reportEntityList;
    }

}
