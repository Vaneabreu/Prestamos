using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class EmployeeDAL
{
    Connection dbm = new Connection();
    EmployeeDAL employeeDAL = null;

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

    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
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
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeInsert", con);
            parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar);
            parametros.Value = CustomerID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
			parametros.Value = LastName;
			parametros = cmd.Parameters.Add("@DocumentNumber", SqlDbType.VarChar);
			parametros.Value = DocumentNumber;
			parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
			parametros.Value = Address;
			parametros = cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar);
			parametros.Value = PhoneNumber;
			parametros = cmd.Parameters.Add("@Mobile", SqlDbType.VarChar);
			parametros.Value = Mobile;
			parametros = cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime);
			parametros.Value = BirthDate;
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
            SqlCommand cmd = new SqlCommand("EmployeeUpdate", con);
			parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
			parametros.Value = EmployeeID;
            parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar);
            parametros.Value = CustomerID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
			parametros.Value = LastName;
			parametros = cmd.Parameters.Add("@DocumentNumber", SqlDbType.VarChar);
			parametros.Value = DocumentNumber;
			parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
			parametros.Value = Address;
			parametros = cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar);
			parametros.Value = PhoneNumber;
			parametros = cmd.Parameters.Add("@Mobile", SqlDbType.VarChar);
			parametros.Value = Mobile;
			parametros = cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime);
			parametros.Value = BirthDate;
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
            SqlCommand cmd = new SqlCommand("EmployeeDelete", con);
			parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
			parametros.Value = EmployeeID;
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


    public List<EmployeeDAL> Search()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<EmployeeDAL> EmployeeList = new List<EmployeeDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeSearch", con);

            if (EmployeeID > 0)
            {
                parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                parametros.Value = EmployeeID;
            }
            if (CustomerID > 0)
            {
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = CustomerID;
            }
            if (!string.IsNullOrEmpty(Name))
            {
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = Name;
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
                parametros.Value = LastName;
            }
            if (!string.IsNullOrEmpty(DocumentNumber))
            {
                parametros = cmd.Parameters.Add("@DocumentNumber", SqlDbType.VarChar);
                parametros.Value = DocumentNumber;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employeeDAL = new EmployeeDAL();
                    employeeDAL.employeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID"));
                    employeeDAL.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    employeeDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    employeeDAL.lastName = dr.GetString(dr.GetOrdinal("LastName"));
                    employeeDAL.documentNumber = dr.GetString(dr.GetOrdinal("DocumentNumber"));
                    employeeDAL.address = dr.GetString(dr.GetOrdinal("Address"));
                    employeeDAL.phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                    employeeDAL.mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                    employeeDAL.birthDate = dr.GetDateTime(dr.GetOrdinal("birthDate"));
                    employeeDAL.registerDate = dr.GetDateTime(dr.GetOrdinal("registerDate"));
                    employeeDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    employeeDAL.customerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    EmployeeList.Add(employeeDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return EmployeeList;
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
            SqlCommand cmd = new SqlCommand("EmployeeGetByKey", con);
            parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            parametros.Value = EmployeeID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                employeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID"));
                customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                lastName = dr.GetString(dr.GetOrdinal("LastName"));
                documentNumber = dr.GetString(dr.GetOrdinal("DocumentNumber"));
                address = dr.GetString(dr.GetOrdinal("Address"));
                phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                birthDate = dr.GetDateTime(dr.GetOrdinal("birthDate"));
                registerDate = dr.GetDateTime(dr.GetOrdinal("registerDate"));
                enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));

                res = true;
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
            res = false;
        }

        return res;
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
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<EmployeeDAL> EmployeeList = new List<EmployeeDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("EmployeeSearch", con);

            if (EmployeeID > 0)
            {
                parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                parametros.Value = EmployeeID;
            }
            if (CustomerID > 0)
            {
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = CustomerID;
            }
            if (!string.IsNullOrEmpty(Name))
            {
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = Name;
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
                parametros.Value = LastName;
            }
            if (!string.IsNullOrEmpty(DocumentNumber))
            {
                parametros = cmd.Parameters.Add("@DocumentNumber", SqlDbType.VarChar);
                parametros.Value = DocumentNumber;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                employeeDAL = new EmployeeDAL();
                employeeDAL.EmployeeID = -1;
                employeeDAL.Name = "-- Seleccione --";
                EmployeeList.Add(employeeDAL);
                while (dr.Read())
                {
                    employeeDAL = new EmployeeDAL();
                    employeeDAL.employeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID"));
                    employeeDAL.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    employeeDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    employeeDAL.lastName = dr.GetString(dr.GetOrdinal("LastName"));
                    employeeDAL.documentNumber = dr.GetString(dr.GetOrdinal("DocumentNumber"));
                    employeeDAL.address = dr.GetString(dr.GetOrdinal("Address"));
                    employeeDAL.phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                    employeeDAL.mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                    employeeDAL.birthDate = dr.GetDateTime(dr.GetOrdinal("birthDate"));
                    employeeDAL.registerDate = dr.GetDateTime(dr.GetOrdinal("registerDate"));
                    employeeDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    employeeDAL.customerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    EmployeeList.Add(employeeDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return EmployeeList;
    }

}
