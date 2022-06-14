using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class EmployeeModel
{

    EmployeeDAL employeeDAL = new EmployeeDAL();
    private List<EmployeeDAL> employeeListDAL = null;

  
	private int employeeID;
    private int customerID;
	private string name;
	private string lastName;
	private int documentTypeID;
	private string documentNumber;
	private string address;
	private string phoneNumber;
	private string mobile;
	private DateTime birthDate;
	private DateTime registerDate;
	private bool enabled;
    private string customerName;


    private int errorCode;
    private string errorDescription;

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

    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
    }


    public List<EmployeeDAL> EmployeeListDAL
    {
        get { return employeeListDAL; }
        set { employeeListDAL = value; }
    }


	public int EmployeeID
	{
		get { return employeeID; }
		set { employeeID = value; }
	}
    public int CustomerID
    {
        get { return customerID; }
        set { customerID = value; }
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
	public string Address
	{
		get { return address; }
		set { address = value; }
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
	public DateTime BirthDate
	{
		get { return birthDate; }
		set { birthDate = value; }
	}
	public DateTime RegisterDate
	{
		get { return registerDate; }
		set { registerDate = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Employee(){ }

    public Boolean Insert()
    {
        bool result = false;

        employeeDAL.CustomerID = CustomerID;
        employeeDAL.Name = Name;
        employeeDAL.LastName = LastName;
        employeeDAL.DocumentTypeID = DocumentTypeID;
        employeeDAL.DocumentNumber = DocumentNumber;
        employeeDAL.Address = Address;
        employeeDAL.PhoneNumber = PhoneNumber;
        employeeDAL.Mobile = Mobile;
        employeeDAL.BirthDate = BirthDate;
        employeeDAL.RegisterDate = RegisterDate;
        employeeDAL.Enabled = Enabled;

        result = employeeDAL.Insert();

        errorCode = employeeDAL.ErrorCode;
        errorDescription = employeeDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;


        employeeDAL.EmployeeID = EmployeeID;
        employeeDAL.CustomerID = CustomerID;
        employeeDAL.Name = Name;
        employeeDAL.LastName = LastName;
        employeeDAL.DocumentTypeID = DocumentTypeID;
        employeeDAL.DocumentNumber = DocumentNumber;
        employeeDAL.Address = Address;
        employeeDAL.PhoneNumber = PhoneNumber;
        employeeDAL.Mobile = Mobile;
        employeeDAL.BirthDate = BirthDate;
        employeeDAL.RegisterDate = RegisterDate;
        employeeDAL.Enabled = Enabled;

        result = employeeDAL.Edit();

        errorCode = employeeDAL.ErrorCode;
        errorDescription = employeeDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        employeeDAL.EmployeeID = EmployeeID;

       result = employeeDAL.Delete();

       errorCode = employeeDAL.ErrorCode;
       errorDescription = employeeDAL.ErrorDescription;

        return result;
    }


    public List<EmployeeDAL> Search()
    {
        employeeDAL.clearFields();

        if (EmployeeID > 0)
            employeeDAL.EmployeeID = EmployeeID;
        if (CustomerID > 0)
            employeeDAL.CustomerID = CustomerID;
        if (!string.IsNullOrEmpty(Name))
            employeeDAL.Name = Name;
        if (!string.IsNullOrEmpty(LastName))
            employeeDAL.LastName = LastName;
        if (!string.IsNullOrEmpty(DocumentNumber))
            employeeDAL.DocumentNumber = DocumentNumber;


        employeeListDAL = new List<EmployeeDAL>();

        employeeListDAL = employeeDAL.Search();

        errorCode = employeeDAL.ErrorCode;
        errorDescription = employeeDAL.ErrorDescription;

        return employeeListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        employeeDAL.EmployeeID = EmployeeID;

        if(employeeDAL.GetByKey())
        {
            EmployeeID = employeeDAL.EmployeeID;
            CustomerID = employeeDAL.CustomerID;
            Name = employeeDAL.Name;
            LastName = employeeDAL.LastName;
            DocumentNumber = employeeDAL.DocumentNumber;
            Address = employeeDAL.Address;
            PhoneNumber = employeeDAL.PhoneNumber;
            Mobile = employeeDAL.Mobile;
            BirthDate = employeeDAL.BirthDate;
            RegisterDate = employeeDAL.RegisterDate;
            Enabled = employeeDAL.Enabled;

            result = true;
        }
        errorCode = employeeDAL.ErrorCode;
        errorDescription = employeeDAL.ErrorDescription;

        return result;
    }

    public void clearFields()
    {
        EmployeeID = 0;
        CustomerID = 0;
        Name = "";
        LastName = "";
        DocumentNumber = "";
        Address = "";
        PhoneNumber = "";
        Mobile = "";
        Enabled = false;
    }

    public List<EmployeeDAL> LoadCombo()
    {
        employeeDAL.clearFields();

        //if (EmployeeID > 0)
        //    employeeDAL.EmployeeID = EmployeeID;
        //if (CustomerID > 0)
        //    employeeDAL.CustomerID = CustomerID;
        //if (!string.IsNullOrEmpty(Name))
        //    employeeDAL.Name = Name;
        //if (!string.IsNullOrEmpty(LastName))
        //    employeeDAL.LastName = LastName;
        //if (!string.IsNullOrEmpty(DocumentNumber))
        //    employeeDAL.DocumentNumber = DocumentNumber;


        employeeListDAL = new List<EmployeeDAL>();

        employeeListDAL = employeeDAL.LoadCombo();

        errorCode = employeeDAL.ErrorCode;
        errorDescription = employeeDAL.ErrorDescription;

        return employeeListDAL;
    }

    
}
