using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class CustomersCreditModel
{
    CustomersCreditDAL customersCreditDAL = new CustomersCreditDAL();
    private List<CustomersCreditDAL> customersCreditListDAL = null; 

	private int customerCreditID;
	private int documentTypeID;
	private string documentNumber;
	private string name;
	private string lastName;
	private string phoneNumber;
	private string mobile;
    private int amountLimit;
	private bool enabled;
    private int availableAmount;
    private string address;

    public int AmountLimit
    {
        get { return amountLimit; }
        set { amountLimit = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public int AvailableAmount
    {
        get { return availableAmount; }
        set { availableAmount = value; }
    }

    private int errorCode;
    private string errorDescription;

    public List<CustomersCreditDAL> CustomersCreditListDAL
    {
        get { return customersCreditListDAL; }
        set { customersCreditListDAL = value; }
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

	public int CustomerCreditID
	{
		get { return customerCreditID; }
		set { customerCreditID = value; }
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
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Customers(){ }

    public Boolean Insert()
    {
        bool result = false;

        customersCreditDAL.DocumentNumber = DocumentNumber;
        customersCreditDAL.Name = Name;
        customersCreditDAL.LastName = LastName;
        customersCreditDAL.PhoneNumber = PhoneNumber;
        customersCreditDAL.Mobile = Mobile;
        customersCreditDAL.AmountLimit = AmountLimit;
        customersCreditDAL.AvailableAmount = AvailableAmount;
        customersCreditDAL.Address = Address;
        customersCreditDAL.Enabled = Enabled;

        result = customersCreditDAL.Insert();

        errorCode = customersCreditDAL.ErrorCode;
        errorDescription = customersCreditDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        customersCreditDAL.CustomerCreditID = CustomerCreditID;
        customersCreditDAL.DocumentNumber = DocumentNumber;
        customersCreditDAL.Name = Name;
        customersCreditDAL.LastName = LastName;
        customersCreditDAL.PhoneNumber = PhoneNumber;
        customersCreditDAL.Mobile = Mobile;
        customersCreditDAL.AmountLimit = AmountLimit;
        customersCreditDAL.AvailableAmount = AvailableAmount;
        customersCreditDAL.Address = Address;
        customersCreditDAL.Enabled = Enabled;

        result = customersCreditDAL.Edit();

        errorCode = customersCreditDAL.ErrorCode;
        errorDescription = customersCreditDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        customersCreditDAL.CustomerCreditID = CustomerCreditID;

        result = customersCreditDAL.Delete();

        errorCode = customersCreditDAL.ErrorCode;
        errorDescription = customersCreditDAL.ErrorDescription;

        return result;
    }


    public List<CustomersCreditDAL> Search()
    {
        customersCreditDAL.clearFields();

        if (CustomerCreditID > 0)
            customersCreditDAL.CustomerCreditID = CustomerCreditID;
        if (!string.IsNullOrEmpty(Name))
            customersCreditDAL.Name = Name;
        if (!string.IsNullOrEmpty(LastName))
            customersCreditDAL.LastName = LastName;
        if (!string.IsNullOrEmpty(DocumentNumber))
            customersCreditDAL.DocumentNumber = DocumentNumber;


        CustomersCreditListDAL = new List<CustomersCreditDAL>();

        CustomersCreditListDAL = customersCreditDAL.Search();

        errorCode = customersCreditDAL.ErrorCode;
        errorDescription = customersCreditDAL.ErrorDescription;

        return CustomersCreditListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        customersCreditDAL.CustomerCreditID = CustomerCreditID;

        if (customersCreditDAL.GetByKey())
        {
            CustomerCreditID = customersCreditDAL.CustomerCreditID;
            DocumentNumber = customersCreditDAL.DocumentNumber;
            Name = customersCreditDAL.Name;
            LastName = customersCreditDAL.LastName;
            PhoneNumber = customersCreditDAL.PhoneNumber;
            Mobile = customersCreditDAL.Mobile;
            amountLimit = customersCreditDAL.AmountLimit;
            availableAmount = customersCreditDAL.AvailableAmount;
            address = customersCreditDAL.Address;
            Enabled = customersCreditDAL.Enabled;

            result = true;
        }
        else
        {
            errorCode = customersCreditDAL.ErrorCode;
            errorDescription = customersCreditDAL.ErrorDescription;
        }

        return result;
    }

    public List<CustomersCreditDAL> LoadCombo()
    {
        CustomersCreditListDAL = new List<CustomersCreditDAL>();

        CustomersCreditListDAL = customersCreditDAL.LoadCombo();

        errorCode = customersCreditDAL.ErrorCode;
        errorDescription = customersCreditDAL.ErrorDescription;

        return CustomersCreditListDAL;
    }


    public Boolean ValidateCustomerAmountLimit(decimal amount)
    {
        bool result = false;

        customersCreditDAL.CustomerCreditID = CustomerCreditID;

        if (customersCreditDAL.ValidateCustomerAmountLimit(amount))
        {
            CustomerCreditID = customersCreditDAL.CustomerCreditID;
            DocumentNumber = customersCreditDAL.DocumentNumber;
            Name = customersCreditDAL.Name;
            LastName = customersCreditDAL.LastName;
            PhoneNumber = customersCreditDAL.PhoneNumber;
            Mobile = customersCreditDAL.Mobile;
            amountLimit = customersCreditDAL.AmountLimit;
            availableAmount = customersCreditDAL.AvailableAmount;
            address = customersCreditDAL.Address;
            Enabled = customersCreditDAL.Enabled;

            if (availableAmount + Convert.ToInt32(amount) > amountLimit)
            {
                result = false;
                errorDescription = "El cliente no tiene credito suficiente para esta jugada";
                errorCode = 1;
            }
            else
                result = true;
        }
        else
        {
            errorCode = customersCreditDAL.ErrorCode;
            errorDescription = customersCreditDAL.ErrorDescription;
        }

        return result;
    }


    public Boolean GetCustomerByTransactionID(long transactionID)
    {
        bool result = false;

        if (customersCreditDAL.GetCustomerByTransactionID(transactionID))
        {
            CustomerCreditID = customersCreditDAL.CustomerCreditID;
            DocumentNumber = customersCreditDAL.DocumentNumber;
            Name = customersCreditDAL.Name;
            LastName = customersCreditDAL.LastName;
            PhoneNumber = customersCreditDAL.PhoneNumber;
            Mobile = customersCreditDAL.Mobile;
            amountLimit = customersCreditDAL.AmountLimit;
            availableAmount = customersCreditDAL.AvailableAmount;
            address = customersCreditDAL.Address;
            Enabled = customersCreditDAL.Enabled;

            result = true;
        }
        else
        {
            errorCode = customersCreditDAL.ErrorCode;
            errorDescription = customersCreditDAL.ErrorDescription;
        }

        return result;
    }

    public Boolean PayCustomerCredit(string userName)
    {
        bool result = false;

        customersCreditDAL.CustomerCreditID = CustomerCreditID;
        customersCreditDAL.AvailableAmount = AvailableAmount;

        result = customersCreditDAL.PayCustomerCredit(userName);

        errorCode = customersCreditDAL.ErrorCode;
        errorDescription = customersCreditDAL.ErrorDescription;

        return result;
    }

    public void clearFields()
    {
        CustomerCreditID = 0;
        DocumentNumber = "";
        Name= "";
        LastName = "";
        PhoneNumber = "";
        Mobile = "";
        AmountLimit = 0;
        AvailableAmount = 0;
        Address = "";
        Enabled = false;
    }


}
