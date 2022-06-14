using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class CompanyPaymentsModel
{
    CompanyPaymentsDAL companyPaymentsDAL = new CompanyPaymentsDAL();
    private List<CompanyPaymentsDAL> companyPaymentsListDAL = null;

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

    public List<CompanyPaymentsDAL> CompanyPaymentsListDAL
    {
        get { return companyPaymentsListDAL; }
        set { companyPaymentsListDAL = value; }
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

	public Boolean Insert(string user)
	{
        bool result = false;
         companyPaymentsDAL.CompanyID = CompanyID;
         companyPaymentsDAL.Amount = Amount;
         //companyPaymentsDAL.Commission = Commission;
         //companyPaymentsDAL.PartnerCommission = PartnerCommission;
        // companyPaymentsDAL.TransactionStatusID = TransactionStatusID;
         companyPaymentsDAL.UserID = UserID;
         companyPaymentsDAL.Reference = Reference;

         result = companyPaymentsDAL.Insert(user);

         errorCode = companyPaymentsDAL.ErrorCode;
         errorDescription = companyPaymentsDAL.ErrorDescription;

        return result;
	}


	public Boolean Edit()
	{
        bool result = false;

        companyPaymentsDAL.CompanyPaymentID = CompanyPaymentID;
        companyPaymentsDAL.CompanyID = CompanyID;
        companyPaymentsDAL.Amount = Amount;
        companyPaymentsDAL.Commission = Commission;
        companyPaymentsDAL.PartnerCommission = PartnerCommission;
        companyPaymentsDAL.TransactionStatusID = TransactionStatusID;
        companyPaymentsDAL.UserID = UserID;

        result = companyPaymentsDAL.Edit();

        errorCode = companyPaymentsDAL.ErrorCode;
        errorDescription = companyPaymentsDAL.ErrorDescription;

        return result;
	}

    public Boolean ChangeStatus(string status)
    {
        bool result = false;

        companyPaymentsDAL.CompanyPaymentID = CompanyPaymentID;
      //  companyPaymentsDAL.TransactionStatusID = TransactionStatusID;

        result = companyPaymentsDAL.ChangeStatus(status);

        errorCode = companyPaymentsDAL.ErrorCode;
        errorDescription = companyPaymentsDAL.ErrorDescription;

        return result;
    }

	public Boolean Delete()
	{
        bool result = false;

        companyPaymentsDAL.CompanyPaymentID = CompanyPaymentID;

        result = companyPaymentsDAL.Delete();

        errorCode = companyPaymentsDAL.ErrorCode;
        errorDescription = companyPaymentsDAL.ErrorDescription;

        return result;
	}


    public List<CompanyPaymentsDAL> Search()
	{
        companyPaymentsDAL.clearFields();

        if (CompanyID > 0)
            companyPaymentsDAL.CompanyID = CompanyID;

        companyPaymentsDAL.StartTime = StartTime;
        companyPaymentsDAL.EndTime = EndTime;

        companyPaymentsListDAL = new List<CompanyPaymentsDAL>();

        companyPaymentsListDAL = companyPaymentsDAL.Search();

        errorCode = companyPaymentsDAL.ErrorCode;
        errorDescription = companyPaymentsDAL.ErrorDescription;

        return companyPaymentsListDAL;
	}


	public Boolean GetByKey()
	{
        bool result = false;

        companyPaymentsDAL.CompanyID = CompanyID;

        if (companyPaymentsDAL.GetByKey()) 
        {
            //CompanyID = companyPaymentsDAL.CompanyID;
            //Name = companyPaymentsDAL.Name;
            //Description = companyPaymentsDAL.Description;
            //CommissionPercent = companyPaymentsDAL.CommissionPercent;
            //PartnerCommissionPercent = companyPaymentsDAL.PartnerCommissionPercent;
            //ImageName = companyPaymentsDAL.ImageName;
            //Enabled = companyPaymentsDAL.Enabled;

            result = true;
        }

        errorCode = companyPaymentsDAL.ErrorCode;
        errorDescription = companyPaymentsDAL.ErrorDescription;

        return result;
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
