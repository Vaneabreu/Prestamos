using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class TransactionDetailsModel
{

    TransactionDetailsDAL transactionDetailsDAL = new TransactionDetailsDAL();
    private List<TransactionDetailsDAL> transactionDetailsListDAL = null;

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

    public List<TransactionDetailsDAL> TransactionDetailsListDAL
    {
        get { return transactionDetailsListDAL; }
        set { transactionDetailsListDAL = value; }
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

	public void TransactionDetails(){ }

    public Boolean Insert()
    {
        bool result = false;

        transactionDetailsDAL.TransactionID = TransactionID;
        transactionDetailsDAL.PlayTypeName = PlayTypeName;
        transactionDetailsDAL.Numbers = Numbers;
        transactionDetailsDAL.Amount = Amount;
        transactionDetailsDAL.LotteryName = LotteryName;
        transactionDetailsDAL.ShiftName = ShiftName;

        result = transactionDetailsDAL.Insert();

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        transactionDetailsDAL.TransactionDetailID = TransactionDetailID;
        transactionDetailsDAL.TransactionID = TransactionID;
        transactionDetailsDAL.PlayTypeID = PlayTypeID;
        transactionDetailsDAL.Numbers = Numbers;
        transactionDetailsDAL.TransactionStatusID = TransactionStatusID;
        transactionDetailsDAL.Amount = Amount;
        transactionDetailsDAL.Commission = Commission;
        transactionDetailsDAL.PartnerCommission = PartnerCommission;
        transactionDetailsDAL.GainAmount = GainAmount;

        result = transactionDetailsDAL.Edit();

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        transactionDetailsDAL.TransactionDetailID = TransactionDetailID;

        result = transactionDetailsDAL.Delete();

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return result;
    }


    public List<TransactionDetailsDAL> Search()
    {
        transactionDetailsListDAL = new List<TransactionDetailsDAL>();

        transactionDetailsDAL.TransactionID = TransactionID;

        transactionDetailsListDAL = transactionDetailsDAL.Search();

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return transactionDetailsListDAL;
    }

    public List<TransactionDetailsDAL> SearchReport()
    {
        transactionDetailsListDAL = new List<TransactionDetailsDAL>();

        transactionDetailsDAL.TransactionID = TransactionID;
        transactionDetailsDAL.Date = Date;
        transactionDetailsDAL.UserName = userName;
        transactionDetailsDAL.LotteryName = lotteryName;

        transactionDetailsListDAL = transactionDetailsDAL.SearchReport();

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return transactionDetailsListDAL;
    }

    public Boolean GetByKey()
    {
        bool result = false;

        transactionDetailsDAL.TransactionDetailID = TransactionDetailID;

        if (transactionDetailsDAL.GetByKey()) 
        {
            TransactionDetailID = transactionDetailsDAL.TransactionDetailID;
            TransactionID = transactionDetailsDAL.TransactionID;
            PlayTypeID = transactionDetailsDAL.PlayTypeID;
            Numbers = transactionDetailsDAL.Numbers;
            TransactionStatusID = transactionDetailsDAL.TransactionStatusID;
            Amount = transactionDetailsDAL.Amount;
            Commission = transactionDetailsDAL.Commission;
            PartnerCommission = transactionDetailsDAL.PartnerCommission;
            GainAmount = transactionDetailsDAL.GainAmount;

            result = true;
        }

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return result;
    }


    public List<TransactionDetailsDAL> VerifyTicketPaid(bool isReport)
    {
        transactionDetailsListDAL = new List<TransactionDetailsDAL>();

        transactionDetailsDAL.TransactionID = TransactionID;

        transactionDetailsListDAL = transactionDetailsDAL.VerifyTicketPaid(isReport);

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return transactionDetailsListDAL;
    }

    public Boolean PaidTicket()
    {
        bool result = false;

        transactionDetailsDAL.TransactionID = TransactionID;
        transactionDetailsDAL.TransactionDetailID = TransactionDetailID;
        transactionDetailsDAL.GainAmount = GainAmount;
        transactionDetailsDAL.UserName = UserName;

        result = transactionDetailsDAL.PaidTicket();

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return result;
    }

    public Boolean PaidCredit(int customerID, int gainAmount, string userName)
    {
        bool result = false;

        result = transactionDetailsDAL.PaidCredit(customerID, gainAmount, userName);

        if (result)
        {
            GainAmount = transactionDetailsDAL.GainAmount;
            NewCreditAmount = transactionDetailsDAL.NewCreditAmount;
        }

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return result;
    }

    public List<TransactionDetailsDAL> GetDetailsCountNumbers(DateTime StartTime, DateTime EndTime)
    {
        transactionDetailsListDAL = new List<TransactionDetailsDAL>();

        transactionDetailsDAL.LotteryName = LotteryName;

        transactionDetailsListDAL = transactionDetailsDAL.GetDetailsCountNumbers(StartTime, EndTime);

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return transactionDetailsListDAL;
    }

    public List<TransactionDetailsDAL> TransactionReport()
    {
        transactionDetailsListDAL = new List<TransactionDetailsDAL>();

        transactionDetailsDAL.LotteryName = LotteryName;
        transactionDetailsDAL.UserName = UserName;
        transactionDetailsDAL.StartTime = StartTime;
        transactionDetailsDAL.EndTime = EndTime;

        transactionDetailsListDAL = transactionDetailsDAL.TransactionReport();

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return transactionDetailsListDAL;
    }


    public Boolean SetAvailableAmount()
    {
        bool result = false;

        transactionDetailsDAL.UserName = UserName;
        transactionDetailsDAL.GainAmount = GainAmount*-1;


        result = transactionDetailsDAL.SetAvailableAmount();

        errorCode = transactionDetailsDAL.ErrorCode;
        errorDescription = transactionDetailsDAL.ErrorDescription;

        return result;
    }
}
