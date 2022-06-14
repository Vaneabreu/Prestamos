using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class LimitsPlayTypesDAL
{
    Connection dbm = new Connection();
    LimitsPlayTypesDAL limitsPlayTypesDAL = null;

	private int limitPlayTypeID;
	private int playTypeID;
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

	public int LimitPlayTypeID
	{
		get { return limitPlayTypeID; }
		set { limitPlayTypeID = value; }
	}
	public int PlayTypeID
	{
		get { return playTypeID; }
		set { playTypeID = value; }
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

	public void LimitsPlayTypes(){ }

    

	public Boolean Insert()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter Parameters;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("LimitsPlayTypesInsert", con);
			Parameters = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			Parameters.Value = PlayTypeID;
			Parameters = cmd.Parameters.Add("@LimitAmount", SqlDbType.Int);
			Parameters.Value = LimitAmount;
			Parameters = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			Parameters.Value = Enabled;
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
        SqlParameter Parameters;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("LimitsPlayTypesUpdate", con);
            Parameters = cmd.Parameters.Add("@LimitPlayTypeID", SqlDbType.Int);
            Parameters.Value = LimitPlayTypeID;
            Parameters = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
            Parameters.Value = PlayTypeID;
            Parameters = cmd.Parameters.Add("@LimitAmount", SqlDbType.Int);
            Parameters.Value = LimitAmount;
            Parameters = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
            Parameters.Value = Enabled;
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
            SqlCommand cmd = new SqlCommand("LimitsPlayTypesDelete", con);
			parametros = cmd.Parameters.Add("@LimitPlayTypeID", SqlDbType.Int);
			parametros.Value = LimitPlayTypeID;
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


    public List<LimitsPlayTypesDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LimitsPlayTypesDAL> limitsPlayTypesList = new List<LimitsPlayTypesDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("LimitsPlayTypesSearch", con);

            if (LimitPlayTypeID > 0)
            {
                parametros = cmd.Parameters.Add("@LimitPlayTypeID", SqlDbType.Int);
                parametros.Value = LimitPlayTypeID;
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
                    limitsPlayTypesDAL = new LimitsPlayTypesDAL();
                    limitsPlayTypesDAL.limitPlayTypeID = dr.GetInt32(dr.GetOrdinal("LimitPlayTypeID"));
                    limitsPlayTypesDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    limitsPlayTypesDAL.limitAmount = dr.GetInt32(dr.GetOrdinal("LimitAmount"));
                    limitsPlayTypesDAL.playTypeLotteryName = dr.GetString(dr.GetOrdinal("PlayTypeLotteryName"));
                    limitsPlayTypesDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    limitsPlayTypesList.Add(limitsPlayTypesDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return limitsPlayTypesList;

    }


	public Boolean GetByKey()
	{
        bool res = false;
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
        SqlDataReader dr = null;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("LimitsPlayTypesGetByKey", con);
			parametros = cmd.Parameters.Add("@LimitPlayTypeID", SqlDbType.Int);
			parametros.Value = LimitPlayTypeID;
			cmd.CommandType = CommandType.StoredProcedure;
		    dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                limitPlayTypeID = dr.GetInt32(dr.GetOrdinal("LimitPlayTypeID"));
                playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                limitAmount = dr.GetInt32(dr.GetOrdinal("LimitAmount"));
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
        LimitPlayTypeID = 0;
        playTypeID = 0;
        limitAmount = 0;
        Enabled = false;
    }
}
