using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;
using Model;

public class BranchesModel
{

    BranchesDAL branchesDAL = new BranchesDAL();
    private List<BranchesDAL> branchesListDAL = null;

	private int branchID;
	private int customerID;
	private string name;
	private string address;
	private string coordinateX;
	private string coordinateY;
	private decimal availableAmount;
	private bool enabled;
    private decimal limitAmount;


    private int errorCode;
    private string errorDescription;
    private int employeeID;
    private string printerName;
    private string phone;
    private string userName;
    private string employeeName;
    private string currency;
    private bool isRedAmount;

    public bool IsRedAmount
    {
        get { return isRedAmount; }
        set { isRedAmount = value; }
    }


    public decimal LimitAmount
    {
        get { return limitAmount; }
        set { limitAmount = value; }
    }
    public string Currency
    {
        get { return currency; }
        set { currency = value; }
    }

    public string EmployeeName
    {
        get { return employeeName; }
        set { employeeName = value; }
    }

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public string PrinterName
    {
        get { return printerName; }
        set { printerName = value; }
    }

    public int EmployeeID
    {
        get { return employeeID; }
        set { employeeID = value; }
    }

    public List<BranchesDAL> BranchesListDAL
    {
        get { return branchesListDAL; }
        set { branchesListDAL = value; }
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

	public int BranchID
	{
		get { return branchID; }
		set { branchID = value; }
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
	public string Address
	{
		get { return address; }
		set { address = value; }
	}
	public string CoordinateX
	{
		get { return coordinateX; }
		set { coordinateX = value; }
	}
	public string CoordinateY
	{
		get { return coordinateY; }
		set { coordinateY = value; }
	}
	public decimal AvailableAmount
	{
		get { return availableAmount; }
		set { availableAmount = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Branches(){ }

	public Boolean Insert()
	{
        bool result = false;

	     branchesDAL.CustomerID = CustomerID;
         branchesDAL.Name = Name;
         branchesDAL.Address = Address;
         branchesDAL.CoordinateX = CoordinateX;
         branchesDAL.CoordinateY = CoordinateY;
         branchesDAL.AvailableAmount = AvailableAmount;
         branchesDAL.PrinterName = PrinterName;
         branchesDAL.Phone = Phone;
         branchesDAL.Currency = Currency;
         branchesDAL.Enabled = Enabled;
         branchesDAL.LimitAmount = LimitAmount;

         result = branchesDAL.Insert();

         errorCode = branchesDAL.ErrorCode;
         errorDescription = branchesDAL.ErrorDescription;

        return result;
	}


	public Boolean Edit()
	{
        bool result = false;

        branchesDAL.BranchID = BranchID;
        branchesDAL.CustomerID = CustomerID;
        branchesDAL.Name = Name;
        branchesDAL.Address = Address;
        branchesDAL.CoordinateX = CoordinateX;
        branchesDAL.CoordinateY = CoordinateY;
        branchesDAL.AvailableAmount = AvailableAmount;
        branchesDAL.PrinterName = PrinterName;
        branchesDAL.Phone = Phone;
        branchesDAL.Currency = Currency;
        branchesDAL.Enabled = Enabled;
        branchesDAL.LimitAmount = LimitAmount;

        result = branchesDAL.Edit();

        errorCode = branchesDAL.ErrorCode;
        errorDescription = branchesDAL.ErrorDescription;

        return result;
	}


	public Boolean Delete()
	{
        bool result = false;

        branchesDAL.BranchID = BranchID;

        result = branchesDAL.Delete();

        errorCode = branchesDAL.ErrorCode;
        errorDescription = branchesDAL.ErrorDescription;

        return result;
	}


    public List<BranchesDAL> Search()
	{
        branchesDAL.clearFields();

        if (BranchID > 0)
            branchesDAL.BranchID = BranchID;
        if (!string.IsNullOrEmpty(Name))
            branchesDAL.Name = Name;
        if (CustomerID > 0)
            branchesDAL.CustomerID = CustomerID;

        branchesListDAL = new List<BranchesDAL>();

        branchesListDAL = branchesDAL.Search();

        errorCode = branchesDAL.ErrorCode;
        errorDescription = branchesDAL.ErrorDescription;

        return branchesListDAL;
	}


	public Boolean GetByKey()
	{
        bool result = false;

        branchesDAL.BranchID = BranchID;

        if (branchesDAL.GetByKey()) 
        {
            BranchID = branchesDAL.BranchID;
            CustomerID = branchesDAL.CustomerID;
            Name = branchesDAL.Name;
            Address = branchesDAL.Address;
            CoordinateX = branchesDAL.CoordinateX;
            CoordinateY = branchesDAL.CoordinateY;
            AvailableAmount = branchesDAL.AvailableAmount;
            PrinterName = branchesDAL.PrinterName;
            Phone = branchesDAL.Phone;
            Currency = branchesDAL.Currency;
            Enabled = branchesDAL.Enabled;
            LimitAmount = branchesDAL.LimitAmount;

            result = true;
        }


        errorCode = branchesDAL.ErrorCode;
        errorDescription = branchesDAL.ErrorDescription;

        return result;
	}

    public List<BranchesDAL> LoadCombo()
    {

        branchesListDAL = new List<BranchesDAL>();

        branchesListDAL = branchesDAL.LoadCombo();

        errorCode = branchesDAL.ErrorCode;
        errorDescription = branchesDAL.ErrorDescription;

        return branchesListDAL;
    }

    public List<BranchesDAL> LoadComboBranches()
    {

        branchesListDAL = new List<BranchesDAL>();

       // if (EmployeeID > 0)
            branchesDAL.EmployeeID = EmployeeID;

            branchesListDAL = branchesDAL.LoadComboBranches();

            errorCode = branchesDAL.ErrorCode;
            errorDescription = branchesDAL.ErrorDescription;

        return branchesListDAL;
    }

    public void clearFields()
    {
        BranchID = 0;
        Name = "";
        CustomerID = 0;
        AvailableAmount = 0;
        Address = "";
        CoordinateX = "";
        CoordinateY = "";
        Enabled = false;
    }

    public Boolean GetByUserName()
    {
        bool result = false;

        branchesDAL.UserName = UserName;

        if (branchesDAL.GetByUserName())
        {
            BranchID = branchesDAL.BranchID;
            CustomerID = branchesDAL.CustomerID;
            Name = branchesDAL.Name;
            Address = branchesDAL.Address;
            CoordinateX = branchesDAL.CoordinateX;
            CoordinateY = branchesDAL.CoordinateY;
            AvailableAmount = branchesDAL.AvailableAmount;
            PrinterName = branchesDAL.PrinterName;
            Phone = branchesDAL.Phone;
            Currency = branchesDAL.Currency;
            EmployeeName = branchesDAL.EmployeeName;
            Enabled = branchesDAL.Enabled;
            LimitAmount = branchesDAL.LimitAmount;


            result = true;
        }

        errorCode = branchesDAL.ErrorCode;
        errorDescription = branchesDAL.ErrorDescription;

        return result;
    }


    public Boolean ValidateLicense(string keyValue)
    {
        bool result = false;
        Encrypt encrypt = new Encrypt();

        if (branchesDAL.ValidateLicense(encrypt.EncryptKey(keyValue)))
        {
            result = true;
        }
        errorCode = branchesDAL.ErrorCode;
        errorDescription = branchesDAL.ErrorDescription;
        encrypt = null;

        return result;
    }



    public Boolean SetAvailableAmount()
    {
        bool result = false;

        branchesDAL.BranchID = BranchID;
        branchesDAL.AvailableAmount = AvailableAmount;
        branchesDAL.IsRedAmount = IsRedAmount;


        result = branchesDAL.SetAvailableAmount();

        errorCode = branchesDAL.ErrorCode;
        errorDescription = branchesDAL.ErrorDescription;

        return result;
    }


}
