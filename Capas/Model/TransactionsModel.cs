using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class TransactionsModel
{

    TransactionsDAL transactionsDAL = new TransactionsDAL();
    private List<TransactionsDAL> transactionsListDAL = null;

 

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
    private int customerID;
    private DateTime startTime;
    private DateTime endTime;

    private int errorCode;
    private string errorDescription;
    private bool allowTransaction;
    private string playTypeName;
    private string numbers;
    private string lotteryName;
    private bool existCombination;
    private decimal totalAmount;
    private int availableAmount;
    private int lotteryID;
    private bool isMobil;
    private decimal totalCommission;

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

    public string PlayTypeName
    {
        get { return playTypeName; }
        set { playTypeName = value; }
    }
    public string Numbers
    {
        get { return numbers; }
        set { numbers = value; }
    }
    public string LotteryName
    {
        get { return lotteryName; }
        set { lotteryName = value; }
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

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public List<TransactionsDAL> TransactionsListDAL
    {
        get { return transactionsListDAL; }
        set { transactionsListDAL = value; }
    }

    public string TransactionStatusName
    {
        get { return transactionStatusName; }
        set { transactionStatusName = value; }
    }

    public string ShiftName
    {
        get { return shiftName; }
        set { shiftName = value; }
    }

    public string BranchName
    {
        get { return branchName; }
        set { branchName = value; }
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
        bool result = false;

        transactionsDAL.Amount = Amount;
        transactionsDAL.ShiftName = ShiftName;
        transactionsDAL.LotteryName = LotteryName;
        transactionsDAL.UserName = UserName;
        transactionsDAL.CustomerID = CustomerID;
        

        result = transactionsDAL.Insert();

        if (result)
            transactionID = transactionsDAL.TransactionID;

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        transactionsDAL.TransactionID = TransactionID;
        transactionsDAL.BranchID = BranchID;
        transactionsDAL.Amount = Amount;
        transactionsDAL.ShiftID = ShiftID;
        transactionsDAL.Date = Date;
        transactionsDAL.TransactionStatusID = TransactionStatusID;
        transactionsDAL.UserID = UserID;
        transactionsDAL.Commission = Commission;
        transactionsDAL.PartnerCommission = PartnerCommission;
        transactionsDAL.TotalGainAmount = TotalGainAmount;

        result = transactionsDAL.Edit();

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        transactionsDAL.TransactionID = TransactionID;

        result = transactionsDAL.Delete();

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }


    public List<TransactionsDAL> Search()
    {
        transactionsListDAL = new List<TransactionsDAL>();

        if (TransactionID > 0)
            transactionsDAL.TransactionID = TransactionID;
        if (!string.IsNullOrEmpty(UserName))
            transactionsDAL.UserName = UserName;
        if (BranchID > 0)
            transactionsDAL.BranchID = BranchID;
        if (TransactionStatusID > 0)
            transactionsDAL.TransactionStatusID = TransactionStatusID;
        if (LotteryID > 0)
            transactionsDAL.LotteryID = LotteryID;

            transactionsDAL.CustomerID = CustomerID;

        transactionsDAL.StartTime = StartTime;
        transactionsDAL.EndTime = EndTime;

        transactionsListDAL = transactionsDAL.Search();

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return transactionsListDAL;
    }

    public List<TransactionsDAL> SearchStadistic()
    {
        transactionsListDAL = new List<TransactionsDAL>();


        transactionsDAL.StartTime = StartTime;
        transactionsDAL.EndTime = EndTime;

        transactionsListDAL = transactionsDAL.SearchStadistic();

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return transactionsListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        transactionsDAL.TransactionID = TransactionID;

        if (transactionsDAL.GetByKey()) 
        {
            TransactionID = transactionsDAL.TransactionID;
            BranchID = transactionsDAL.BranchID;
            Amount = transactionsDAL.Amount;
            ShiftID = transactionsDAL.ShiftID;
            Date = transactionsDAL.Date;
            TransactionStatusID = transactionsDAL.TransactionStatusID;
            UserID = transactionsDAL.UserID;
            Commission = transactionsDAL.Commission;
            PartnerCommission = transactionsDAL.PartnerCommission;
            TotalGainAmount = transactionsDAL.TotalGainAmount;

            result = true;
        }

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }


    public Boolean ValidateLimitsForCombinations()
    {
        bool result = false;

        transactionsDAL.PlayTypeName = PlayTypeName;
        transactionsDAL.Amount = Amount;
        transactionsDAL.Numbers = Numbers;
        transactionsDAL.LotteryName = LotteryName;
        transactionsDAL.ShiftName = ShiftName;

        if (transactionsDAL.ValidateLimitsForCombinations())
        {
            AllowTransaction = transactionsDAL.AllowTransaction;
            ExistCombination = transactionsDAL.ExistCombination;
            AvailableAmount = transactionsDAL.AvailableAmount;

            result = AllowTransaction;
        }

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }


    public Boolean ValidateLimitsForPlayTypes()
    {
        bool result = false;

        transactionsDAL.PlayTypeName = PlayTypeName;
        transactionsDAL.Amount = Amount;
        transactionsDAL.Numbers = Numbers;
        transactionsDAL.LotteryName = LotteryName;
        transactionsDAL.ShiftName = ShiftName;

        if (transactionsDAL.ValidateLimitsForPlayTypes())
        {
            AllowTransaction = transactionsDAL.AllowTransaction;
            AvailableAmount = transactionsDAL.AvailableAmount;
            ExistCombination = transactionsDAL.ExistCombination;

            result = AllowTransaction;
        }

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }

    public Boolean CancelTicket()
    {
        bool result = false;

        transactionsDAL.TransactionID = TransactionID;
        transactionsDAL.UserName = UserName;

        if (transactionsDAL.CancelTicket())
        {
            result = true;
        }

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }

    public Boolean GetLastIDByUser()
    {
        bool result = false;

        transactionsDAL.UserName = UserName;

        if (transactionsDAL.GetLastIDByUser())
        {
            TransactionID = transactionsDAL.TransactionID;
           
            result = true;
        }

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }

    public Boolean GetTransactionTotal()
    {
        bool result = false;

        transactionsDAL.LotteryName = LotteryName;
        transactionsDAL.UserName = UserName;
        transactionsDAL.StartTime = StartTime;
        transactionsDAL.EndTime = EndTime;

        if (transactionsDAL.GetTransactionTotal())
        {
            totalAmount = transactionsDAL.TotalAmount;
            totalCommission = transactionsDAL.TotalCommission;
            result = true;
        }

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }

    public Boolean SetAvailableAmount()
    {
        bool result = false;

        transactionsDAL.UserName = UserName;
        transactionsDAL.AvailableAmount = AvailableAmount;
        transactionsDAL.Commission = Commission;


        result = transactionsDAL.SetAvailableAmount();

        errorCode = transactionsDAL.ErrorCode;
        errorDescription = transactionsDAL.ErrorDescription;

        return result;
    }


}
