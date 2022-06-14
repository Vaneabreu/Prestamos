using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class TransactionStatusModel
{

    TransactionStatusDAL transactionStatusDAL = new TransactionStatusDAL();
    private List<TransactionStatusDAL> transactionStatusListDAL = null;



	private int transactionStatusID;
	private string name;
	private string description;
	private bool enabled;

    private int errorCode;
    private string errorDescription;

    public List<TransactionStatusDAL> TransactionStatusListDAL
    {
        get { return transactionStatusListDAL; }
        set { transactionStatusListDAL = value; }
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

	public int TransactionStatusID
	{
		get { return transactionStatusID; }
		set { transactionStatusID = value; }
	}
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public string Description
	{
		get { return description; }
		set { description = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void TransactionStatus(){ }

    public Boolean Insert()
    {
        bool result = false;

        transactionStatusDAL.Name = Name;
        transactionStatusDAL.Description = Description;
        transactionStatusDAL.Enabled = Enabled;

        result = transactionStatusDAL.Insert();

        errorCode = transactionStatusDAL.ErrorCode;
        errorDescription = transactionStatusDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        transactionStatusDAL.TransactionStatusID = TransactionStatusID;
        transactionStatusDAL.Name = Name;
        transactionStatusDAL.Description = Description;
        transactionStatusDAL.Enabled = Enabled;

        result = transactionStatusDAL.Edit();

        errorCode = transactionStatusDAL.ErrorCode;
        errorDescription = transactionStatusDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        transactionStatusDAL.TransactionStatusID = TransactionStatusID;

        result = transactionStatusDAL.Delete();

        errorCode = transactionStatusDAL.ErrorCode;
        errorDescription = transactionStatusDAL.ErrorDescription;

        return result;
    }


    public List<TransactionStatusDAL> Search()
    {
        transactionStatusListDAL = new List<TransactionStatusDAL>();

        transactionStatusListDAL = transactionStatusDAL.Search();

        errorCode = transactionStatusDAL.ErrorCode;
        errorDescription = transactionStatusDAL.ErrorDescription;

        return transactionStatusListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        transactionStatusDAL.TransactionStatusID = TransactionStatusID;

        if (transactionStatusDAL.GetByKey()) 
        {
            TransactionStatusID = transactionStatusDAL.TransactionStatusID;
            Name = transactionStatusDAL.Name;
            Description = transactionStatusDAL.Description;
            Enabled = transactionStatusDAL.Enabled;

            result = true;
        }

        errorCode = transactionStatusDAL.ErrorCode;
        errorDescription = transactionStatusDAL.ErrorDescription;

        return result;
    }

    public List<TransactionStatusDAL> LoadCombo()
    {
        transactionStatusListDAL = new List<TransactionStatusDAL>();

        transactionStatusListDAL = transactionStatusDAL.LoadCombo();

        errorCode = transactionStatusDAL.ErrorCode;
        errorDescription = transactionStatusDAL.ErrorDescription;

        return transactionStatusListDAL;
    }

}
