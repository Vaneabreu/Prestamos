using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using LoansDAL;
using System.IO;

public class TransactionDetailsDAL
{
    public Connection dbm = new Connection();
    TransactionDetailsDAL transactionDetailsDAL = null;

    private long transactionDetailID;
    private long transactionID;
    private int playTypeID;
    private string numbers;
    private int transactionStatusID;
    private decimal amount;
    private decimal commission;
    private decimal partnerCommission;
    private int gainAmount;
    private string playTypeName;
    private string transactionStatusName;
    private int errorCode;
    private string errorDescription;
    private string shiftName;
    private string lotteryName;
    private string userName;
    private int newCreditAmount;
    private DateTime startTime;
    private DateTime endTime;
    private DateTime date;
    private string branchName;
    private string ticketDetailID;
    private string ticketID;
    private int userID;
    private DateTime lastPaymentDate;
    private DateTime lastCommissionDate;

    public DateTime LastCommissionDate
    {
        get { return lastCommissionDate; }
        set { lastCommissionDate = value; }
    }

    public DateTime LastPaymentDate
    {
        get { return lastPaymentDate; }
        set { lastPaymentDate = value; }
    }

    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public string TicketID
    {
        get { return ticketID; }
        set { ticketID = value; }
    }

    public string TicketDetailID
    {
        get { return ticketDetailID; }
        set { ticketDetailID = value; }
    }

    public string BranchName
    {
        get { return branchName; }
        set { branchName = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
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

    public int NewCreditAmount
    {
        get { return newCreditAmount; }
        set { newCreditAmount = value; }
    }

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public string LotteryName
    {
        get { return lotteryName; }
        set { lotteryName = value; }
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

    public string PlayTypeName
    {
        get { return playTypeName; }
        set { playTypeName = value; }
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

    public long TransactionDetailID
    {
        get { return transactionDetailID; }
        set { transactionDetailID = value; }
    }
    public long TransactionID
    {
        get { return transactionID; }
        set { transactionID = value; }
    }
    public int PlayTypeID
    {
        get { return playTypeID; }
        set { playTypeID = value; }
    }
    public string Numbers
    {
        get { return numbers; }
        set { numbers = value; }
    }
    public int TransactionStatusID
    {
        get { return transactionStatusID; }
        set { transactionStatusID = value; }
    }
    public decimal Amount
    {
        get { return amount; }
        set { amount = value; }
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
    public int GainAmount
    {
        get { return gainAmount; }
        set { gainAmount = value; }
    }

    public void TransactionDetails() { }

    public Boolean Insert(LoginDAL loginDAL)
    {

        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            //EscribirError("TransactionDetailsInsert @TransactionID="+ TransactionID+ ", @PlayTypeName='"+ PlayTypeName+ "', @Numbers='"+ Numbers+ "', @Amount="+Amount+ ", @ShiftName='"+ ShiftName+ "', @LotteryName='"+ LotteryName+ "',@TicketDetailID='"+ TicketDetailID+"'");
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionDetailsInsert", con);
            parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
            parametros.Value = TransactionID;
            parametros = cmd.Parameters.Add("@PlayTypeName", SqlDbType.VarChar);
            parametros.Value = PlayTypeName;
            parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
            parametros.Value = Numbers;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Int);
            parametros.Value = Amount;
            parametros = cmd.Parameters.Add("@ShiftName", SqlDbType.VarChar);
            parametros.Value = ShiftName;
            parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
            parametros.Value = LotteryName;
            parametros = cmd.Parameters.Add("@TicketDetailID", SqlDbType.VarChar);
            TicketDetailID = "";
            parametros.Value = TicketDetailID;
            cmd.CommandType = CommandType.StoredProcedure;

            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            else
                errorDescription = "ExecuteNonQuery retorno 0 o menor";
                //EscribirError("ExecuteNonQuery retorno 0 o menor");
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            //EscribirError(errorDescription);
            errorCode = 0001;
        }
        return res;
    }


    public Boolean Edit(LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("spTransactiondetails_M", con);
            parametros = cmd.Parameters.Add("@TransactionDetailID", SqlDbType.BigInt);
            parametros.Value = TransactionDetailID;
            parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
            parametros.Value = TransactionID;
            parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
            parametros.Value = PlayTypeID;
            parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
            parametros.Value = Numbers;
            parametros = cmd.Parameters.Add("@TransactionStatusID", SqlDbType.Int);
            parametros.Value = TransactionStatusID;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Int);
            parametros.Value = Amount;
            parametros = cmd.Parameters.Add("@Commission", SqlDbType.Decimal);
            parametros.Value = Commission;
            parametros = cmd.Parameters.Add("@PartnerCommission", SqlDbType.Decimal);
            parametros.Value = PartnerCommission;
            parametros = cmd.Parameters.Add("@GainAmount", SqlDbType.Int);
            parametros.Value = GainAmount;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (SqlException e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        return res;
    }


    public Boolean Delete(LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("spTransactiondetails_E", con);
            parametros = cmd.Parameters.Add("@TransactionDetailID", SqlDbType.BigInt);
            parametros.Value = TransactionDetailID;
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


    public List<TransactionDetailsDAL> Search(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionDetailsDAL> transactionDetailsList = new List<TransactionDetailsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionDetailsSearch", con);

            if (TransactionID > 0)
            {
                parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.Int);
                parametros.Value = TransactionID;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.transactionDetailID = dr.GetInt64(dr.GetOrdinal("TransactionDetailID"));
                    transactionDetailsDAL.transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));
                    transactionDetailsDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    transactionDetailsDAL.numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                    transactionDetailsDAL.transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                    transactionDetailsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    transactionDetailsDAL.commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                    transactionDetailsDAL.partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                    transactionDetailsDAL.gainAmount = dr.GetInt32(dr.GetOrdinal("GainAmount"));
                    transactionDetailsDAL.playTypeName = dr.GetString(dr.GetOrdinal("PlayTypeName"));
                    transactionDetailsDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                    transactionDetailsDAL.transactionStatusName = dr.GetString(dr.GetOrdinal("TransactionStatusName"));
                    transactionDetailsDAL.branchName = dr.GetString(dr.GetOrdinal("BranchName"));
                    transactionDetailsDAL.ticketDetailID = dr.GetString(dr.GetOrdinal("TicketDetailID"));
                    transactionDetailsList.Add(transactionDetailsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionDetailsList;
    }

    public List<TransactionDetailsDAL> SearchReport(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionDetailsDAL> transactionDetailsList = new List<TransactionDetailsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionDetailsSearchReport", con);

            parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            parametros.Value = Date;

            parametros = cmd.Parameters.Add("@userName", SqlDbType.VarChar);
            parametros.Value = userName;

            parametros = cmd.Parameters.Add("@lotteryName", SqlDbType.VarChar);
            parametros.Value = lotteryName;

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.transactionDetailID = dr.GetInt64(dr.GetOrdinal("TransactionDetailID"));
                    transactionDetailsDAL.transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));
                    transactionDetailsDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    transactionDetailsDAL.numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                    transactionDetailsDAL.transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                    transactionDetailsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    transactionDetailsDAL.commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                    transactionDetailsDAL.partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                    transactionDetailsDAL.gainAmount = dr.GetInt32(dr.GetOrdinal("GainAmount"));
                    transactionDetailsDAL.playTypeName = dr.GetString(dr.GetOrdinal("PlayTypeName"));
                    transactionDetailsDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                    transactionDetailsDAL.transactionStatusName = dr.GetString(dr.GetOrdinal("TransactionStatusName"));
                    transactionDetailsList.Add(transactionDetailsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionDetailsList;
    }

    public Boolean GetByKey(LoginDAL loginDAL)
    {
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("spTransactionDetail_TT", con);
            parametros = cmd.Parameters.Add("@TransactionDetailID", SqlDbType.BigInt);
            parametros.Value = TransactionDetailID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                transactionDetailID = dr.GetInt64(dr.GetOrdinal("TransactionDetailID"));
                transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));
                playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                amount = dr.GetInt32(dr.GetOrdinal("Amount"));
                commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                gainAmount = dr.GetInt32(dr.GetOrdinal("GainAmount"));

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


    public Boolean PaidTicket(LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("PaidTicket", con);
            parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
            parametros.Value = TransactionID;
            parametros = cmd.Parameters.Add("@TransactionDetailID", SqlDbType.BigInt);
            parametros.Value = TransactionDetailID;
            parametros = cmd.Parameters.Add("@GainAmount", SqlDbType.Int);
            parametros.Value = GainAmount;
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;
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


    public Boolean PaidCredit(int customerID, int gAmount, string user, LoginDAL loginDAL)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        SqlDataReader dr = null;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("PaidCredit", con);
            parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            parametros.Value = customerID;
            parametros = cmd.Parameters.Add("@GainAmount", SqlDbType.Int);
            parametros.Value = gAmount;
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = user;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                GainAmount = dr.GetInt32(dr.GetOrdinal("GainAmount"));
                NewCreditAmount = dr.GetInt32(dr.GetOrdinal("NewCreditAmount"));

                res = true;
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }
        return res;
    }

    public List<TransactionDetailsDAL> VerifyTicketPaid(bool isReport, LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlConnection conDetail = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        SqlParameter parametrosDetail;
        SqlDataReader drDetail = null;
        List<TransactionDetailsDAL> transactionDetailsList = new List<TransactionDetailsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            conDetail = dbm.getConexion(dbm);
            conDetail.Open();
            SqlCommand cmd = new SqlCommand("TransactionDetailsSearch", con);

            if (TransactionID > 0)
            {
                parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
                parametros.Value = TransactionID;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.transactionDetailID = dr.GetInt64(dr.GetOrdinal("TransactionDetailID"));
                    transactionDetailsDAL.transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));
                    transactionDetailsDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    transactionDetailsDAL.numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                    transactionDetailsDAL.transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatus"));
                    transactionDetailsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    transactionDetailsDAL.commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                    transactionDetailsDAL.partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                    transactionDetailsDAL.gainAmount = dr.GetInt32(dr.GetOrdinal("GainAmount"));
                    transactionDetailsDAL.playTypeName = dr.GetString(dr.GetOrdinal("PlayTypeName"));
                    transactionDetailsDAL.transactionStatusName = dr.GetString(dr.GetOrdinal("TransactionStatusName"));
                    transactionDetailsDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));

                    SqlCommand cmdDetail = new SqlCommand("VerifyTicketPaid", conDetail);
                    parametrosDetail = cmdDetail.Parameters.Add("@TransactionID", SqlDbType.BigInt);
                    parametrosDetail.Value = TransactionID;
                    parametrosDetail = cmdDetail.Parameters.Add("@TransactionDetailID", SqlDbType.BigInt);
                    parametrosDetail.Value = transactionDetailsDAL.transactionDetailID;
                    parametrosDetail = cmdDetail.Parameters.Add("@Numbers", SqlDbType.VarChar);
                    parametrosDetail.Value = transactionDetailsDAL.numbers;
                    parametrosDetail = cmdDetail.Parameters.Add("@IsReport", SqlDbType.Bit);
                    parametrosDetail.Value = isReport;
                    parametrosDetail = cmdDetail.Parameters.Add("@transactionStatusID", SqlDbType.Int);
                    parametrosDetail.Value = transactionDetailsDAL.transactionStatusID;



                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    drDetail = cmdDetail.ExecuteReader();
                    if (drDetail.HasRows)
                    {
                        if (drDetail.Read())
                        {
                            if (drDetail.GetBoolean(drDetail.GetOrdinal("IsWinner")))
                            {

                                transactionDetailsDAL.gainAmount = drDetail.GetInt32(drDetail.GetOrdinal("GainAmount"));
                                transactionDetailsDAL.date = drDetail.GetDateTime(drDetail.GetOrdinal("TransactionDate"));
                                transactionDetailsDAL.ticketDetailID = drDetail.GetString(drDetail.GetOrdinal("TicketDetailID"));
                                transactionDetailsDAL.userName = drDetail.GetString(drDetail.GetOrdinal("UserName"));
                                transactionDetailsDAL.ticketID = drDetail.GetString(drDetail.GetOrdinal("TicketID"));
                                transactionDetailsDAL.userID = drDetail.GetInt32(drDetail.GetOrdinal("UserID"));
                                transactionDetailsDAL.lastPaymentDate = drDetail.GetDateTime(drDetail.GetOrdinal("LastPaymentDate"));
                                transactionDetailsDAL.lastCommissionDate = drDetail.GetDateTime(drDetail.GetOrdinal("LastCommissionDate"));
                                transactionDetailsList.Add(transactionDetailsDAL);
                            }

                        }
                    }
                    drDetail.Close();
                    parametrosDetail = null;

                }
            }
            con.Close();
            conDetail.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionDetailsList;
    }

    public List<TransactionDetailsDAL> GetDetailsCountNumbers(DateTime StartTime, DateTime EndTime, LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionDetailsDAL> transactionDetailsList = new List<TransactionDetailsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetDetailsCountNumbers", con);


            parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
            parametros.Value = LotteryName;
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
                    transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                    transactionDetailsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    transactionDetailsList.Add(transactionDetailsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionDetailsList;
    }

    public List<TransactionDetailsDAL> TransactionReport(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionDetailsDAL> transactionDetailsList = new List<TransactionDetailsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionSearchReport", con);


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
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.transactionDetailID = dr.GetInt64(dr.GetOrdinal("TransactionDetailID"));
                    transactionDetailsDAL.transactionID = dr.GetInt64(dr.GetOrdinal("TransactionID"));
                    transactionDetailsDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    transactionDetailsDAL.numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                    transactionDetailsDAL.transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                    transactionDetailsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                    transactionDetailsDAL.commission = dr.GetDecimal(dr.GetOrdinal("Commission"));
                    transactionDetailsDAL.partnerCommission = dr.GetDecimal(dr.GetOrdinal("PartnerCommission"));
                    transactionDetailsDAL.gainAmount = dr.GetInt32(dr.GetOrdinal("GainAmount"));
                    // transactionDetailsDAL.playTypeName = dr.GetString(dr.GetOrdinal("PlayTypeName"));
                    transactionDetailsDAL.transactionStatusName = dr.GetString(dr.GetOrdinal("TransactionStatusName"));
                    transactionDetailsList.Add(transactionDetailsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionDetailsList;
    }

    public Boolean SetAvailableAmount(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("SetAvailableAmountTransactions", con);
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;
            parametros = cmd.Parameters.Add("@AvailableAmount", SqlDbType.Int);
            parametros.Value = GainAmount;

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

    public List<TransactionDetailsDAL> TransactionDetailReportNumber(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionDetailsDAL> transactionDetailsList = new List<TransactionDetailsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionDetailsReportNumber", con);

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    transactionDetailsDAL = new TransactionDetailsDAL();
                    transactionDetailsDAL.numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                    transactionDetailsDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                    transactionDetailsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));

                    transactionDetailsList.Add(transactionDetailsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionDetailsList;
    }


    public void EscribirError(string ex)
    {

        string fecha = DateTime.Now.ToString();
        String contenido = LeerError();
        try
        {


            string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"error\registro.txt");
            //fijamos dondevamos a crear el archivo
            StreamWriter escrito = File.CreateText(filepath);
            contenido = contenido + fecha.ToString() + " Error:" + ex.ToString();
            //escribimos.
            escrito.WriteLine(contenido.ToString());
            escrito.Flush();
            //Cerramos
            escrito.Close();



        }
        catch (Exception ext)
        {

        }



    }
    public string LeerError()
    {

        string conetinodLeido;
        try
        {
            string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"error\registro.txt");
            StreamReader leido = File.OpenText(filepath);
            conetinodLeido = leido.ReadToEnd();
            leido.Close();

        }
        catch (Exception)
        {
            conetinodLeido = "N";
        }
        return conetinodLeido;
    }


}
