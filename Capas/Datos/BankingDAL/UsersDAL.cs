using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class UsersDAL
{
    Connection dbm = new Connection();
    UsersDAL usersDAL = null;

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

    public string EmployeeName
    {
        get { return employeeName; }
        set { employeeName = value; }
    }

    public bool IsUser
    {
        get { return isUser; }
        set { isUser = value; }
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
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("UsersInsert", con);
			parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
			parametros.Value = EmployeeID;
            parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
            parametros.Value = BranchID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
			parametros.Value = Password;
			parametros = cmd.Parameters.Add("@IsAdministrator", SqlDbType.Bit);
			parametros.Value = IsAdministrator;
            parametros = cmd.Parameters.Add("@AllowCancelTransaction", SqlDbType.Bit);
            parametros.Value = AllowCancelTransaction;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
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


	public Boolean Edit()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("UsersUpdate", con);
			parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
			parametros.Value = UserID;
			parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
			parametros.Value = EmployeeID;
            parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
            parametros.Value = BranchID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
			parametros.Value = Password;
			parametros = cmd.Parameters.Add("@IsAdministrator", SqlDbType.Bit);
			parametros.Value = IsAdministrator;
            parametros = cmd.Parameters.Add("@AllowCancelTransaction", SqlDbType.Bit);
            parametros.Value = AllowCancelTransaction;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
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


	public Boolean Delete()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("UsersDelete", con);
			parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
			parametros.Value = UserID;
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


    public List<UsersDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<UsersDAL> usersList = new List<UsersDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersSearch", con);

            if (UserID > 0)
            {
                parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
                parametros.Value = UserID;
            }
            if (!string.IsNullOrEmpty(Name))
            {
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = Name;
            }
            if (EmployeeID > 0)
            {
                parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                parametros.Value = EmployeeID;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usersDAL = new UsersDAL();
                    usersDAL.userID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    usersDAL.employeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID"));
                    usersDAL.branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                    usersDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    usersDAL.employeeName = dr.GetString(dr.GetOrdinal("EmployeeName"));
                    usersDAL.password = dr.GetString(dr.GetOrdinal("Password"));
                    usersDAL.isAdministrator = dr.GetBoolean(dr.GetOrdinal("IsAdministrator"));
                    usersDAL.allowCancelTransaction = dr.GetBoolean(dr.GetOrdinal("AllowCancelTransaction"));
                    usersDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    usersDAL.lastLoginDate = dr.GetDateTime(dr.GetOrdinal("LastLoginDate"));
                    usersDAL.lastPaymentDate = dr.GetDateTime(dr.GetOrdinal("LastPaymentDate"));
                    usersDAL.lastCommissionDate = dr.GetDateTime(dr.GetOrdinal("lastCommissionDate"));
                    usersList.Add(usersDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return usersList;
	}


	public Boolean GetByKey()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersGetByKey", con);
            parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
            parametros.Value = UserID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userID = dr.GetInt32(dr.GetOrdinal("UserID"));
                employeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID"));
                branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                password = dr.GetString(dr.GetOrdinal("Password"));
                isAdministrator = dr.GetBoolean(dr.GetOrdinal("IsAdministrator"));
                allowCancelTransaction = dr.GetBoolean(dr.GetOrdinal("AllowCancelTransaction"));
                enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                lastLoginDate = dr.GetDateTime(dr.GetOrdinal("LastLoginDate"));
                lastPaymentDate = dr.GetDateTime(dr.GetOrdinal("LastPaymentDate"));

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

    public List<UsersDAL> LoadCombo()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<UsersDAL> usersList = new List<UsersDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersSearchByCustomer", con);

            if (CustomerID > 0)
            {
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = CustomerID;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                usersDAL = new UsersDAL();
                usersDAL.userID = -1;
                usersDAL.Name = "-- Seleccione --";
                usersList.Add(usersDAL);
                while (dr.Read())
                {
                    usersDAL = new UsersDAL();
                    usersDAL.userID = dr.GetInt32(dr.GetOrdinal("UserID"));
                    usersDAL.employeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID"));
                    usersDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    usersDAL.employeeName = dr.GetString(dr.GetOrdinal("EmployeeName"));
                    usersDAL.password = dr.GetString(dr.GetOrdinal("Password"));
                    usersDAL.isAdministrator = dr.GetBoolean(dr.GetOrdinal("IsAdministrator"));
                    usersDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    usersList.Add(usersDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return usersList;
    }

    public bool ValidateUser()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("ValidateUser", con);
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = Name;
            parametros = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            parametros.Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                isUser = Convert.ToBoolean(dr.GetInt32(dr.GetOrdinal("isUser")));
                isAdministrator = dr.GetBoolean(dr.GetOrdinal("isAdministrator"));
                partnerShip = dr.GetString(dr.GetOrdinal("partnerShip"));
                maxPale = dr.GetInt32(dr.GetOrdinal("maxPale"));
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


    public bool GetAmountForUser()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAmountForUser", con);
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = Name;
            parametros = cmd.Parameters.Add("@startDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString()+" 00:00:00");
            parametros = cmd.Parameters.Add("@endDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59:59");
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                gainAmount = dr.GetInt32(dr.GetOrdinal("GAINAMOUNT"));
                saleAmount = dr.GetInt32(dr.GetOrdinal("SALEAMOUNT"));
                creditAmount = dr.GetInt32(dr.GetOrdinal("CREDITAMOUNT"));
                companyAmount = dr.GetDecimal(dr.GetOrdinal("COMPANYAMOUNT"));
                availableAmount = dr.GetDecimal(dr.GetOrdinal("AVAILABLEAMOUNT"));
                userCommision = dr.GetDecimal(dr.GetOrdinal("USERCOMMISION"));
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


    public Boolean AllowCancel()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = true;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetUserByName", con);
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = Name;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userID = dr.GetInt32(dr.GetOrdinal("UserID"));
                employeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID"));
                branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                password = dr.GetString(dr.GetOrdinal("Password"));
                isAdministrator = dr.GetBoolean(dr.GetOrdinal("IsAdministrator"));
                allowCancelTransaction = dr.GetBoolean(dr.GetOrdinal("AllowCancelTransaction"));
                enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));

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

    public Boolean UpdateLastPaymentDate()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("UsersUpdateLastPaymentDate", con);
            parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
            parametros.Value = UserID;  
            parametros = cmd.Parameters.Add("@LastPaymentDate", SqlDbType.DateTime);
            parametros.Value = LastPaymentDate;
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


    public void clearFields()
    {
        UserID = 0;
        EmployeeID = 0;
        Name = "";
        isAdministrator = false;
        Enabled = false;
    }

}
