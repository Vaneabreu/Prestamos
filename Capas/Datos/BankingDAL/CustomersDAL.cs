using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class CustomersDAL
{
    Connection dbm = new Connection();
    CustomersDAL customersDAL = null;

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
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("CustomersInsert", con);

			parametros = cmd.Parameters.Add("@DocumentNumber", SqlDbType.VarChar);
			parametros.Value = DocumentNumber;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
			parametros.Value = LastName;
			parametros = cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar);
			parametros.Value = PhoneNumber;
			parametros = cmd.Parameters.Add("@Mobile", SqlDbType.VarChar);
			parametros.Value = Mobile;
			parametros = cmd.Parameters.Add("@TimeLimit", SqlDbType.Int);
			parametros.Value = TimeLimit;
            parametros = cmd.Parameters.Add("@PartnerShip", SqlDbType.VarChar);
            parametros.Value = PartnerShip;
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
			SqlCommand cmd = new SqlCommand("CustomersUpdate", con);
			parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
			parametros.Value = CustomerID;
			parametros = cmd.Parameters.Add("@DocumentNumber", SqlDbType.VarChar);
			parametros.Value = DocumentNumber;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
			parametros.Value = LastName;
			parametros = cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar);
			parametros.Value = PhoneNumber;
			parametros = cmd.Parameters.Add("@Mobile", SqlDbType.VarChar);
			parametros.Value = Mobile;
			parametros = cmd.Parameters.Add("@TimeLimit", SqlDbType.Int);
			parametros.Value = TimeLimit;
            parametros = cmd.Parameters.Add("@PartnerShip", SqlDbType.VarChar);
            parametros.Value = PartnerShip;
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
            SqlCommand cmd = new SqlCommand("CustomersDelete", con);
			parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
			parametros.Value = CustomerID;
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


    public List<CustomersDAL> Search()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<CustomersDAL> CustomersList = new List<CustomersDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CustomersSearch", con);

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
                    customersDAL = new CustomersDAL();
                    customersDAL.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    customersDAL.documentNumber = dr.GetString(dr.GetOrdinal("documentNumber"));
                    customersDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    customersDAL.lastName = dr.GetString(dr.GetOrdinal("LastName"));
                    customersDAL.phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                    customersDAL.mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                    customersDAL.timeLimit = dr.GetInt32(dr.GetOrdinal("TimeLimit"));
                    customersDAL.partnerShip = dr.GetString(dr.GetOrdinal("PartnerShip"));
                    customersDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    CustomersList.Add(customersDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }

        return CustomersList;
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
            SqlCommand cmd = new SqlCommand("CustomersGetByKey", con);
            parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            parametros.Value = CustomerID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                documentNumber = dr.GetString(dr.GetOrdinal("documentNumber"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                lastName = dr.GetString(dr.GetOrdinal("LastName"));
                phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                timeLimit = dr.GetInt32(dr.GetOrdinal("TimeLimit"));
                partnerShip = dr.GetString(dr.GetOrdinal("PartnerShip"));
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

    public List<CustomersDAL> LoadCombo()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<CustomersDAL> CustomersList = new List<CustomersDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CustomersSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                customersDAL = new CustomersDAL();
                customersDAL.customerID = -1;
                customersDAL.Name = "-- Seleccione --";
                CustomersList.Add(customersDAL);
                while (dr.Read())
                {
                    customersDAL = new CustomersDAL();
                    customersDAL.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    customersDAL.documentNumber = dr.GetString(dr.GetOrdinal("documentNumber"));
                    customersDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    customersDAL.lastName = dr.GetString(dr.GetOrdinal("LastName"));
                    customersDAL.phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                    customersDAL.mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                    customersDAL.timeLimit = dr.GetInt32(dr.GetOrdinal("TimeLimit"));
                    customersDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    CustomersList.Add(customersDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }

        return CustomersList;
    }


    public void clearFields()
    {
        CustomerID = 0;
        DocumentNumber = "";
        Name = "";
        LastName = "";
        PhoneNumber = "";
        Mobile = "";
        TimeLimit = 0;
        Enabled = false;
    }

}
