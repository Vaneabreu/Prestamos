using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class TransactionStatusDAL
{
    Connection dbm = new Connection();
    TransactionStatusDAL transactionStatusDAL = null;

	private int transactionStatusID;
	private string name;
	private string description;
	private bool enabled;

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

	public int TransactionStatusID
	{
		get { return transactionStatusID; }
		set { transactionStatusID = value; }
	}
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public string Description
	{
		get { return description; }
		set { description = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void TransactionStatus(){ }

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
            SqlCommand cmd = new SqlCommand("TransactionStatusInsert", con);
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
			parametros.Value = Description;
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
            SqlCommand cmd = new SqlCommand("TransactionStatusUpdate", con);
			parametros = cmd.Parameters.Add("@TransactionStatusID", SqlDbType.Int);
			parametros.Value = TransactionStatusID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
			parametros.Value = Description;
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
            SqlCommand cmd = new SqlCommand("TransactionStatusDelete", con);
			parametros = cmd.Parameters.Add("@TransactionStatusID", SqlDbType.Int);
			parametros.Value = TransactionStatusID;
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


    public List<TransactionStatusDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionStatusDAL> transactionStatusList = new List<TransactionStatusDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionStatusSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    transactionStatusDAL = new TransactionStatusDAL();
                    transactionStatusDAL.transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                    transactionStatusDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    transactionStatusDAL.description = dr.GetString(dr.GetOrdinal("Description"));
                    transactionStatusDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    transactionStatusList.Add(transactionStatusDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionStatusList;
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
            SqlCommand cmd = new SqlCommand("TransactionStatusGetByKey", con);
            parametros = cmd.Parameters.Add("@TransactionStatusID", SqlDbType.Int);
            parametros.Value = TransactionStatusID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                description = dr.GetString(dr.GetOrdinal("Description"));
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


    public List<TransactionStatusDAL> LoadCombo()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<TransactionStatusDAL> transactionStatusList = new List<TransactionStatusDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("TransactionStatusSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                transactionStatusDAL = new TransactionStatusDAL();
                transactionStatusDAL.TransactionStatusID = -1;
                transactionStatusDAL.Description = "-- Seleccione --";
                transactionStatusList.Add(transactionStatusDAL);
                while (dr.Read())
                {
                    transactionStatusDAL = new TransactionStatusDAL();
                    transactionStatusDAL.transactionStatusID = dr.GetInt32(dr.GetOrdinal("TransactionStatusID"));
                    transactionStatusDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    transactionStatusDAL.description = dr.GetString(dr.GetOrdinal("Description"));
                    transactionStatusDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    transactionStatusList.Add(transactionStatusDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return transactionStatusList;
	}
}
