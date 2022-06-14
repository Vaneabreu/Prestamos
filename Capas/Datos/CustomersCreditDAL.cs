using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class CustomersCreditDAL
{
    Connection dbm = new Connection();
    CustomersCreditDAL customersCreditDAL = null;

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
	public int AmountLimit
	{
		get { return amountLimit; }
		set { amountLimit = value; }
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
            SqlCommand cmd = new SqlCommand("CustomersCreditInsert", con);

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
			parametros = cmd.Parameters.Add("@AmountLimit", SqlDbType.Int);
			parametros.Value = AmountLimit;
            parametros = cmd.Parameters.Add("@AvailableAmount", SqlDbType.Int);
            parametros.Value = AvailableAmount;
            parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            parametros.Value = Address;
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
            SqlCommand cmd = new SqlCommand("CustomersCreditUpdate", con);
			parametros = cmd.Parameters.Add("@CustomerCreditID", SqlDbType.Int);
			parametros.Value = CustomerCreditID;
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
            parametros = cmd.Parameters.Add("@AmountLimit", SqlDbType.Int);
            parametros.Value = AmountLimit;
            parametros = cmd.Parameters.Add("@AvailableAmount", SqlDbType.Int);
            parametros.Value = AvailableAmount;
            parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            parametros.Value = Address;
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
            SqlCommand cmd = new SqlCommand("CustomersCreditDelete", con);
			parametros = cmd.Parameters.Add("@CustomerCreditID", SqlDbType.Int);
			parametros.Value = CustomerCreditID;
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


    public List<CustomersCreditDAL> Search()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<CustomersCreditDAL> CustomersCreditList = new List<CustomersCreditDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CustomersCreditSearch", con);

            if (CustomerCreditID > 0)
            {
                parametros = cmd.Parameters.Add("@CustomerCreditID", SqlDbType.Int);
                parametros.Value = CustomerCreditID;
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
                    customersCreditDAL = new CustomersCreditDAL();
                    customersCreditDAL.customerCreditID = dr.GetInt32(dr.GetOrdinal("CustomerCreditID"));
                    customersCreditDAL.documentNumber = dr.GetString(dr.GetOrdinal("documentNumber"));
                    customersCreditDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    customersCreditDAL.lastName = dr.GetString(dr.GetOrdinal("LastName"));
                    customersCreditDAL.phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                    customersCreditDAL.mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                    customersCreditDAL.amountLimit = dr.GetInt32(dr.GetOrdinal("amountLimit"));
                    customersCreditDAL.availableAmount = dr.GetInt32(dr.GetOrdinal("availableAmount"));
                    customersCreditDAL.address = dr.GetString(dr.GetOrdinal("address"));
                    customersCreditDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    CustomersCreditList.Add(customersCreditDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }

        return CustomersCreditList;
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
            SqlCommand cmd = new SqlCommand("CustomersCreditGetByKey", con);
            parametros = cmd.Parameters.Add("@CustomerCreditID", SqlDbType.Int);
            parametros.Value = CustomerCreditID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                customerCreditID = dr.GetInt32(dr.GetOrdinal("CustomerCreditID"));
                documentNumber = dr.GetString(dr.GetOrdinal("documentNumber"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                lastName = dr.GetString(dr.GetOrdinal("LastName"));
                phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                amountLimit = dr.GetInt32(dr.GetOrdinal("AmountLimit"));
                availableAmount = dr.GetInt32(dr.GetOrdinal("availableAmount"));
                address = dr.GetString(dr.GetOrdinal("Address"));
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

    public List<CustomersCreditDAL> LoadCombo()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<CustomersCreditDAL> CustomersCreditList = new List<CustomersCreditDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CustomersCreditSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                customersCreditDAL = new CustomersCreditDAL();
                customersCreditDAL.customerCreditID = -1;
                customersCreditDAL.Name = "-- Seleccione --";
                CustomersCreditList.Add(customersCreditDAL);
                while (dr.Read())
                {
                    customersCreditDAL = new CustomersCreditDAL();
                    customersCreditDAL.customerCreditID = dr.GetInt32(dr.GetOrdinal("CustomerCreditID"));
                    customersCreditDAL.documentNumber = dr.GetString(dr.GetOrdinal("documentNumber"));
                    customersCreditDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    customersCreditDAL.lastName = dr.GetString(dr.GetOrdinal("LastName"));
                    customersCreditDAL.phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                    customersCreditDAL.mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                    customersCreditDAL.amountLimit = dr.GetInt32(dr.GetOrdinal("AmountLimit"));
                    customersCreditDAL.availableAmount = dr.GetInt32(dr.GetOrdinal("AvailableAmount"));
                    customersCreditDAL.address = dr.GetString(dr.GetOrdinal("Address"));
                    customersCreditDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    CustomersCreditList.Add(customersCreditDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }

        return CustomersCreditList;
    }

    public Boolean ValidateCustomerAmountLimit(decimal amount)
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
            SqlCommand cmd = new SqlCommand("CustomersCreditGetByKey", con);
            parametros = cmd.Parameters.Add("@CustomerCreditID", SqlDbType.Int);
            parametros.Value = CustomerCreditID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                customerCreditID = dr.GetInt32(dr.GetOrdinal("CustomerCreditID"));
                documentNumber = dr.GetString(dr.GetOrdinal("documentNumber"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                lastName = dr.GetString(dr.GetOrdinal("LastName"));
                phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                amountLimit = dr.GetInt32(dr.GetOrdinal("AmountLimit"));
                availableAmount = dr.GetInt32(dr.GetOrdinal("availableAmount"));
                address = dr.GetString(dr.GetOrdinal("Address"));
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

    public Boolean GetCustomerByTransactionID(long transactionID)
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
            SqlCommand cmd = new SqlCommand("GetCustomerByTransactionID", con);
            parametros = cmd.Parameters.Add("@TransactionID", SqlDbType.BigInt);
            parametros.Value = transactionID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                customerCreditID = dr.GetInt32(dr.GetOrdinal("CustomerCreditID"));
                documentNumber = dr.GetString(dr.GetOrdinal("documentNumber"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                lastName = dr.GetString(dr.GetOrdinal("LastName"));
                phoneNumber = dr.GetString(dr.GetOrdinal("PhoneNumber"));
                mobile = dr.GetString(dr.GetOrdinal("Mobile"));
                amountLimit = dr.GetInt32(dr.GetOrdinal("AmountLimit"));
                availableAmount = dr.GetInt32(dr.GetOrdinal("availableAmount"));
                address = dr.GetString(dr.GetOrdinal("Address"));
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

    public Boolean PayCustomerCredit(string userName)
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
            SqlCommand cmd = new SqlCommand("CustomersCreditPay", con);
            parametros = cmd.Parameters.Add("@CustomerCreditID", SqlDbType.Int);
            parametros.Value = CustomerCreditID;
            parametros = cmd.Parameters.Add("@Amount", SqlDbType.Int);
            parametros.Value = AvailableAmount;
            parametros = cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            parametros.Value = userName;
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
        CustomerCreditID = 0;
        DocumentNumber = "";
        Name = "";
        LastName = "";
        PhoneNumber = "";
        Mobile = "";
        amountLimit = 0;
        availableAmount = 0;
        Address = "";
        Enabled = false;
    }

}
