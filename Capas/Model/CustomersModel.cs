using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class CustomersModel
{
    CustomersDAL customersDAL = new CustomersDAL();
    private List<CustomersDAL> customersListDAL = null; 

	private int customerID;
	private int documentTypeID;
	private string documentNumber;
	private string name;
	private string lastName;
	private string phoneNumber;
	private string mobile;
	private int timeLimit;
	private bool enabled;
    private string partnerShip;

    public string PartnerShip
    {
        get { return partnerShip; }
        set { partnerShip = value; }
    }

    private int errorCode;
    private string errorDescription;

    public List<CustomersDAL> CustomersListDAL
    {
        get { return customersListDAL; }
        set { customersListDAL = value; }
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

	public int CustomerID
	{
		get { return customerID; }
		set { customerID = value; }
	}
	public int DocumentTypeID
	{
		get { return documentTypeID; }
		set { documentTypeID = value; }
	}
	public string DocumentNumber
	{
		get { return documentNumber; }
		set { documentNumber = value; }
	}
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public string LastName
	{
		get { return lastName; }
		set { lastName = value; }
	}
	public string PhoneNumber
	{
		get { return phoneNumber; }
		set { phoneNumber = value; }
	}
	public string Mobile
	{
		get { return mobile; }
		set { mobile = value; }
	}
	public int TimeLimit
	{
		get { return timeLimit; }
		set { timeLimit = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Customers(){ }

    public Boolean Insert()
    {
        bool result = false;

        customersDAL.DocumentNumber = DocumentNumber;
        customersDAL.Name = Name;
        customersDAL.LastName = LastName;
        customersDAL.PhoneNumber = PhoneNumber;
        customersDAL.Mobile = Mobile;
        customersDAL.TimeLimit = TimeLimit;
        customersDAL.PartnerShip = partnerShip;
        customersDAL.Enabled = Enabled;

        result = customersDAL.Insert();

        errorCode = customersDAL.ErrorCode;
        errorDescription = customersDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        customersDAL.CustomerID = CustomerID;
        customersDAL.DocumentNumber = DocumentNumber;
        customersDAL.Name = Name;
        customersDAL.LastName = LastName;
        customersDAL.PhoneNumber = PhoneNumber;
        customersDAL.Mobile = Mobile;
        customersDAL.TimeLimit = TimeLimit;
        customersDAL.PartnerShip = partnerShip;
        customersDAL.Enabled = Enabled;

        result = customersDAL.Edit();

        errorCode = customersDAL.ErrorCode;
        errorDescription = customersDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        customersDAL.CustomerID = CustomerID;

        result = customersDAL.Delete();

        errorCode = customersDAL.ErrorCode;
        errorDescription = customersDAL.ErrorDescription;

        return result;
    }


    public List<CustomersDAL> Search()
    {
        customersDAL.clearFields();

        if (CustomerID > 0)
            customersDAL.CustomerID = CustomerID;
        if (!string.IsNullOrEmpty(Name))
            customersDAL.Name = Name;
        if (!string.IsNullOrEmpty(LastName))
            customersDAL.LastName = LastName;
        if (!string.IsNullOrEmpty(DocumentNumber))
            customersDAL.DocumentNumber = DocumentNumber;


        CustomersListDAL = new List<CustomersDAL>();

        CustomersListDAL = customersDAL.Search();

        errorCode = customersDAL.ErrorCode;
        errorDescription = customersDAL.ErrorDescription;

        return CustomersListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        customersDAL.CustomerID = CustomerID;

        if (customersDAL.GetByKey())
        {
            CustomerID = customersDAL.CustomerID;
            DocumentNumber = customersDAL.DocumentNumber;
            Name = customersDAL.Name;
            LastName = customersDAL.LastName;
            PhoneNumber = customersDAL.PhoneNumber;
            Mobile = customersDAL.Mobile;
            TimeLimit = customersDAL.TimeLimit;
            PartnerShip = customersDAL.PartnerShip;
            Enabled = customersDAL.Enabled;

            result = true;
        }
        else
        {
            errorCode = customersDAL.ErrorCode;
            errorDescription = customersDAL.ErrorDescription;
        }

        return result;
    }

    public List<CustomersDAL> LoadCombo()
    {
        CustomersListDAL = new List<CustomersDAL>();

        CustomersListDAL = customersDAL.LoadCombo();

        errorCode = customersDAL.ErrorCode;
        errorDescription = customersDAL.ErrorDescription;

        return CustomersListDAL;
    }


    public void clearFields()
    {
        CustomerID = 0;
        DocumentNumber = "";
        Name= "";
        LastName = "";
        PhoneNumber = "";
        Mobile = "";
        TimeLimit = 0;
        Enabled = false;
    }


}
