using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using LoansDAL;

public class BranchesDAL
{
	public Connection dbm = new Connection();
    BranchesDAL branches = null;

	private int branchID;
	private int customerID;
	private string name;
	private string address;
	private string coordinateX;
	private string coordinateY;
	private decimal availableAmount;
	private bool enabled;
    private string customerName;
    private int employeeID;
    private string printerName;
    private string phone;
    private string userName;
    private string employeeName;
    private string currency;
    private decimal limitAmount;
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

    private int errorCode = 0;
    private string errorDescription = "successful";

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
    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
    }

	public void Branches(){ }

	public Boolean Insert(LoginDAL loginDAL)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;

            con = dbm.getConexion(dbm);
			con.Open();
            SqlCommand cmd = new SqlCommand("BranchesInsert", con);
            parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            parametros.Value = CustomerID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
			parametros.Value = Address;
			parametros = cmd.Parameters.Add("@CoordinateX", SqlDbType.VarChar);
			parametros.Value = CoordinateX;
			parametros = cmd.Parameters.Add("@CoordinateY", SqlDbType.VarChar);
			parametros.Value = CoordinateY;
			parametros = cmd.Parameters.Add("@AvailableAmount", SqlDbType.Decimal);
			parametros.Value = AvailableAmount;
            parametros = cmd.Parameters.Add("@PrinterName", SqlDbType.VarChar);
            parametros.Value = PrinterName;
            parametros = cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
            parametros.Value = Phone;
            parametros = cmd.Parameters.Add("@Currency", SqlDbType.VarChar);
            parametros.Value = Currency;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
            parametros = cmd.Parameters.Add("@LimitAmount", SqlDbType.Decimal);
            parametros.Value = LimitAmount;
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


	public Boolean Edit(LoginDAL loginDAL)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
			con.Open();
            SqlCommand cmd = new SqlCommand("BranchesUpdate", con);
			parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
			parametros.Value = BranchID;
			parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
			parametros.Value = CustomerID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
			parametros.Value = Address;
			parametros = cmd.Parameters.Add("@CoordinateX", SqlDbType.VarChar);
			parametros.Value = CoordinateX;
			parametros = cmd.Parameters.Add("@CoordinateY", SqlDbType.VarChar);
			parametros.Value = CoordinateY;
			parametros = cmd.Parameters.Add("@AvailableAmount", SqlDbType.Decimal);
			parametros.Value = AvailableAmount;
            parametros = cmd.Parameters.Add("@PrinterName", SqlDbType.VarChar);
            parametros.Value = PrinterName;
            parametros = cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
            parametros.Value = Phone;
            parametros = cmd.Parameters.Add("@Currency", SqlDbType.VarChar);
            parametros.Value = Currency;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
            parametros = cmd.Parameters.Add("@LimitAmount", SqlDbType.Decimal);
            parametros.Value = LimitAmount;
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


	public Boolean Delete(LoginDAL loginDAL)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
			con.Open();
            SqlCommand cmd = new SqlCommand("BranchesDelete", con);
			parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
			parametros.Value = BranchID;
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


    public List<BranchesDAL> Search(LoginDAL loginDAL)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<BranchesDAL> branchesList = new List<BranchesDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("BranchesSearch", con);

            if (BranchID > 0)
            {
                parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
                parametros.Value = BranchID;
            }
            if (!string.IsNullOrEmpty(Name))
            {
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = Name;
            }
            if (CustomerID > 0)
            {
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = CustomerID;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    branches = new BranchesDAL();
                    branches.branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                    branches.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    branches.name = dr.GetString(dr.GetOrdinal("Name"));
                    branches.address = dr.GetString(dr.GetOrdinal("Address"));
                    branches.coordinateX = dr.GetString(dr.GetOrdinal("coordinateX"));
                    branches.coordinateY = dr.GetString(dr.GetOrdinal("CoordinateY"));
                    branches.availableAmount = dr.GetDecimal(dr.GetOrdinal("AvailableAmount"));
                    branches.printerName = dr.GetString(dr.GetOrdinal("PrinterName"));
                    branches.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                    branches.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    branches.customerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    branches.currency = dr.GetString(dr.GetOrdinal("Currency"));
                    branches.limitAmount = dr.GetDecimal(dr.GetOrdinal("LimitAmount"));
                    branchesList.Add(branches);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return branchesList;
	}


	public Boolean GetByKey(LoginDAL loginDAL)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("BranchesGetByKey", con);
            parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
            parametros.Value = BranchID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                address = dr.GetString(dr.GetOrdinal("Address"));
                coordinateX = dr.GetString(dr.GetOrdinal("coordinateX"));
                coordinateY = dr.GetString(dr.GetOrdinal("CoordinateY"));
                availableAmount = dr.GetDecimal(dr.GetOrdinal("AvailableAmount"));
                printerName = dr.GetString(dr.GetOrdinal("PrinterName"));
                Phone = dr.GetString(dr.GetOrdinal("Phone"));
                currency = dr.GetString(dr.GetOrdinal("Currency"));
                enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                limitAmount = dr.GetDecimal(dr.GetOrdinal("LimitAmount"));
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

    public List<BranchesDAL> LoadCombo(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<BranchesDAL> branchesList = new List<BranchesDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("BranchesSearch", con);

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                branches = new BranchesDAL();
                branches.branchID = -1;
                branches.Name = "-- Seleccione --";
                branchesList.Add(branches);
                while (dr.Read())
                {
                    branches = new BranchesDAL();
                    branches.branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                    branches.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    branches.name = dr.GetString(dr.GetOrdinal("Name"));
                    branches.address = dr.GetString(dr.GetOrdinal("Address"));
                    branches.coordinateX = dr.GetString(dr.GetOrdinal("coordinateX"));
                    branches.coordinateY = dr.GetString(dr.GetOrdinal("CoordinateY"));
                    branches.availableAmount = dr.GetDecimal(dr.GetOrdinal("AvailableAmount"));
                    branches.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    branchesList.Add(branches);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return branchesList;
    }

    public List<BranchesDAL> LoadComboBranches(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<BranchesDAL> branchesList = new List<BranchesDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("BranchesSearch", con);
            // if (EmployeeID > 0)
            // {
            parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            parametros.Value = EmployeeID;
            //}

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                branches = new BranchesDAL();
                branches.branchID = -1;
                branches.Name = "-- Seleccione --";
                branchesList.Add(branches);
                while (dr.Read())
                {
                    branches = new BranchesDAL();
                    branches.branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                    branches.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    branches.name = dr.GetString(dr.GetOrdinal("Name"));
                    branches.address = dr.GetString(dr.GetOrdinal("Address"));
                    branches.coordinateX = dr.GetString(dr.GetOrdinal("coordinateX"));
                    branches.coordinateY = dr.GetString(dr.GetOrdinal("CoordinateY"));
                    branches.availableAmount = dr.GetDecimal(dr.GetOrdinal("AvailableAmount"));
                    branches.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    branchesList.Add(branches);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return branchesList;
    }
    public Boolean GetByUserName(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("BranchesGetByUserName", con);
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = UserName;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                branchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                address = dr.GetString(dr.GetOrdinal("Address"));
                coordinateX = dr.GetString(dr.GetOrdinal("coordinateX"));
                coordinateY = dr.GetString(dr.GetOrdinal("CoordinateY"));
                availableAmount = dr.GetDecimal(dr.GetOrdinal("AvailableAmount"));
                printerName = dr.GetString(dr.GetOrdinal("PrinterName"));
                Phone = dr.GetString(dr.GetOrdinal("Phone"));
                currency = dr.GetString(dr.GetOrdinal("Currency"));
                EmployeeName = dr.GetString(dr.GetOrdinal("EmployeName"));
                enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                limitAmount = dr.GetDecimal(dr.GetOrdinal("LimitAmount"));
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

    public Boolean ValidateLicense(string keyValue, LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetLicense", con);
            parametros = cmd.Parameters.Add("@KeyValue", SqlDbType.VarChar);
            parametros.Value = keyValue;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
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


    public Boolean SetAvailableAmount(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;
            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("SetAvailableAmountBranches", con);
            parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
            parametros.Value = BranchID;
            parametros = cmd.Parameters.Add("@AvailableAmount", SqlDbType.Decimal);
            parametros.Value = AvailableAmount;
            parametros = cmd.Parameters.Add("@IsRedAmount", SqlDbType.Bit);
            parametros.Value = IsRedAmount;
     
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


}
