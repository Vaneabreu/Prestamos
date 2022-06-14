using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class LimitNumbersDAL
{
    Connection dbm = new Connection();
    LimitNumbersDAL limitNumbersDAL = null;

	private int limitNumberID;
	private int playTypeID;
	private string numbers;
	private int limitAmount;
	private bool enabled;
    private string playTypeLotteryName;

    private int errorCode;
    private string errorDescription;

    public string PlayTypeLotteryName
    {
        get { return playTypeLotteryName; }
        set { playTypeLotteryName = value; }
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

	public int LimitNumberID
	{
		get { return limitNumberID; }
		set { limitNumberID = value; }
	}
	public int PlayTypeID
	{
		get { return playTypeID; }
		set { playTypeID = value; }
	}
	public string Numbers
	{
		get { return numbers; }
		set { numbers = value; }
	}
	public int LimitAmount
	{
		get { return limitAmount; }
		set { limitAmount = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

    public void LimitNumbers() { }

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
            SqlCommand cmd = new SqlCommand("LimitNumbersInsert", con);
			parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			parametros.Value = PlayTypeID;
			parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
			parametros.Value = Numbers;
			parametros = cmd.Parameters.Add("@LimitAmount", SqlDbType.Int);
			parametros.Value = LimitAmount;
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
            SqlCommand cmd = new SqlCommand("LimitNumbersUpdate", con);
			parametros = cmd.Parameters.Add("@LimitNumberID", SqlDbType.Int);
			parametros.Value = LimitNumberID;
			parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			parametros.Value = PlayTypeID;
			parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
			parametros.Value = Numbers;
			parametros = cmd.Parameters.Add("@LimitAmount", SqlDbType.Int);
			parametros.Value = LimitAmount;
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
            SqlCommand cmd = new SqlCommand("LimitNumbersDelete", con);
			parametros = cmd.Parameters.Add("@LimitNumberID", SqlDbType.Int);
			parametros.Value = LimitNumberID;
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


    public List<LimitNumbersDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LimitNumbersDAL> LimitNumbersList = new List<LimitNumbersDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("LimitNumbersSearch", con);
            if (LimitNumberID > 0)
            {
                parametros = cmd.Parameters.Add("@LimitNumberID", SqlDbType.Int);
                parametros.Value = LimitNumberID;
            }
            if (!string.IsNullOrEmpty(Numbers))
            {
                parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
                parametros.Value = Numbers;
            }
            if (PlayTypeID > 0)
            {
                parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
                parametros.Value = PlayTypeID;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    limitNumbersDAL = new LimitNumbersDAL();
                    limitNumbersDAL.limitNumberID = dr.GetInt32(dr.GetOrdinal("LimitNumberID"));
                    limitNumbersDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    limitNumbersDAL.numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                    limitNumbersDAL.limitAmount = dr.GetInt32(dr.GetOrdinal("LimitAmount"));
                    limitNumbersDAL.playTypeLotteryName = dr.GetString(dr.GetOrdinal("PlayTypeLotteryName"));
                    limitNumbersDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));              
                    LimitNumbersList.Add(limitNumbersDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return LimitNumbersList;
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
            SqlCommand cmd = new SqlCommand("LimitNumbersGetByKey", con);
            parametros = cmd.Parameters.Add("@LimitNumberID", SqlDbType.Int);
            parametros.Value = LimitNumberID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                limitNumberID = dr.GetInt32(dr.GetOrdinal("LimitNumberID"));
                playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                numbers = dr.GetString(dr.GetOrdinal("Numbers"));
                limitAmount = dr.GetInt32(dr.GetOrdinal("LimitAmount"));
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

    public void clearFields()
    {
        playTypeID = 0;
        limitNumberID = 0;
        numbers = "";
        limitAmount = 0;
        Enabled = false;
    }
}
