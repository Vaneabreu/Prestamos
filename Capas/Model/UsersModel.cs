using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;
using Model;

public class UsersModel
{
    UsersDAL usersDAL = new UsersDAL();
    Encrypt encrypt = new Encrypt();
    private List<UsersDAL> usersListDAL = null;


	private int userID;
	private int employeeID;
	private string name;
	private string password;
	private bool isAdministrator;
	private bool enabled;
    private string employeeName;
    private bool isUser;
    private int gainAmount;
    private int saleAmount;
    private decimal availableAmount;
    private int errorCode;
    private string errorDescription;
    private int customerID;
    private int branchID;
    private bool allowCancelTransaction;
    private int creditAmount;
    private decimal companyAmount;
    private string partnerShip;
    private DateTime lastLoginDate;
    private decimal userCommision;
    private int maxPale;
    private DateTime lastPaymentDate;

    public DateTime LastPaymentDate
    {
        get { return lastPaymentDate; }
        set { lastPaymentDate = value; }
    }

    public int MaxPale
    {
        get { return maxPale; }
        set { maxPale = value; }
    }

    public decimal UserCommision
    {
        get { return userCommision; }
        set { userCommision = value; }
    }

    public DateTime LastLoginDate
    {
        get { return lastLoginDate; }
        set { lastLoginDate = value; }
    }

    public string PartnerShip
    {
        get { return partnerShip; }
        set { partnerShip = value; }
    }


    public int CreditAmount
    {
        get { return creditAmount; }
        set { creditAmount = value; }
    }
    public decimal CompanyAmount
    {
        get { return companyAmount; }
        set { companyAmount = value; }
    }


    public bool AllowCancelTransaction
    {
        get { return allowCancelTransaction; }
        set { allowCancelTransaction = value; }
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


    public decimal AvailableAmount
    {
        get { return availableAmount; }
        set { availableAmount = value; }
    }

    public int SaleAmount
    {
        get { return saleAmount; }
        set { saleAmount = value; }
    }

    public int GainAmount
    {
        get { return gainAmount; }
        set { gainAmount = value; }
    }

    public bool IsUser
    {
        get { return isUser; }
        set { isUser = value; }
    }

    public string EmployeeName
    {
        get { return employeeName; }
        set { employeeName = value; }
    }

    public List<UsersDAL> UsersListDAL
    {
        get { return usersListDAL; }
        set { usersListDAL = value; }
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
	public int EmployeeID
	{
		get { return employeeID; }
		set { employeeID = value; }
	}
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public string Password
	{
		get { return password; }
		set { password = value; }
	}
	public bool IsAdministrator
	{
		get { return isAdministrator; }
		set { isAdministrator = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Users(){ }

    public Boolean Insert()
    {
        bool result = false;

        usersDAL.EmployeeID = EmployeeID;
        usersDAL.BranchID = BranchID;
        usersDAL.Name = Name;
        usersDAL.Password = encrypt.EncryptKey(Password);
        usersDAL.IsAdministrator = IsAdministrator;
        usersDAL.AllowCancelTransaction = AllowCancelTransaction;
        usersDAL.Enabled = Enabled;

        result = usersDAL.Insert();

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        usersDAL.UserID = UserID;
        usersDAL.EmployeeID = EmployeeID;
        usersDAL.BranchID = BranchID;
        usersDAL.Name = Name;
        usersDAL.Password = encrypt.EncryptKey(Password);
        usersDAL.IsAdministrator = IsAdministrator;
        usersDAL.AllowCancelTransaction = AllowCancelTransaction;
        usersDAL.Enabled = Enabled;

        result = usersDAL.Edit();

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        usersDAL.UserID = UserID;

        result = usersDAL.Delete();

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return result;
    }


    public List<UsersDAL> Search()
    {
        usersListDAL = new List<UsersDAL>();

        if (UserID > 0)
            usersDAL.UserID = UserID;
        if (!string.IsNullOrEmpty(Name))
            usersDAL.Name = Name;
        if (EmployeeID > 0)
            usersDAL.EmployeeID = EmployeeID;

        usersListDAL = usersDAL.Search();

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return usersListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        usersDAL.UserID = UserID;

        if (usersDAL.GetByKey())
        {
            UserID = usersDAL.UserID;
            EmployeeID =  usersDAL.EmployeeID;
            BranchID = usersDAL.BranchID;
            Name = usersDAL.Name;
            IsAdministrator = usersDAL.IsAdministrator;
            AllowCancelTransaction = usersDAL.AllowCancelTransaction;
            Enabled = usersDAL.Enabled;
            LastLoginDate = usersDAL.LastLoginDate;
            LastPaymentDate = usersDAL.LastPaymentDate;

            try
            {
                Password = encrypt.Decrypt(usersDAL.Password);
            }
            catch (Exception ex)
            {
                Password = usersDAL.Password;
            }

            result = true;
        }

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return result;
    }

    public List<UsersDAL> LoadCombo()
    {
        usersListDAL = new List<UsersDAL>();

        if (CustomerID > 0)
            usersDAL.CustomerID = CustomerID;

        usersListDAL = usersDAL.LoadCombo();

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return usersListDAL;
    }

    public bool ValidateUser()
    {
        bool result = false;

        usersDAL.Name = Name;
        usersDAL.Password = encrypt.EncryptKey(Password);

        if (usersDAL.ValidateUser())
        {

            IsAdministrator = usersDAL.IsAdministrator;
            IsUser = usersDAL.IsUser;
            PartnerShip = usersDAL.PartnerShip;
            MaxPale = usersDAL.MaxPale;

            result = true;
        }

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return result;
    }

    public bool GetAmountForUser()
    {
        bool result = false;

        usersDAL.Name = Name;

        if (usersDAL.GetAmountForUser())
        {
            gainAmount = usersDAL.GainAmount;
            saleAmount = usersDAL.SaleAmount;
            creditAmount = usersDAL.CreditAmount;
            companyAmount = usersDAL.CompanyAmount;
            availableAmount = usersDAL.AvailableAmount;
            userCommision = usersDAL.UserCommision;

            result = true;
        }

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return result;
    }


    public Boolean AllowCancel()
    {
        bool result = true;

        usersDAL.Name = Name;

        if (usersDAL.AllowCancel())
        {
            UserID = usersDAL.UserID;
            EmployeeID = usersDAL.EmployeeID;
            BranchID = usersDAL.BranchID;
            Name = usersDAL.Name;
            IsAdministrator = usersDAL.IsAdministrator;
            AllowCancelTransaction = usersDAL.AllowCancelTransaction;
            Enabled = usersDAL.Enabled;

            try
            {
                Password = encrypt.Decrypt(usersDAL.Password);
            }
            catch (Exception ex)
            {
                Password = usersDAL.Password;
            }

            result = AllowCancelTransaction;
        }

        errorCode = usersDAL.ErrorCode;
        errorDescription = usersDAL.ErrorDescription;

        return result;
    }


    public void clearFields()
    {
        UserID = 0;
        EmployeeID = 0;
        Name = "";
        isAdministrator = false;
        Enabled = false;
    }

}
