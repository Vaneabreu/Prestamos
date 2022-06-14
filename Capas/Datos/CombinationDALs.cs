using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using LoansDAL;

public class CombinationsDAL
{
    public Connection dbm = new Connection();
    CombinationsDAL combinationsDAL = null;

    private int combinationID;
	private int playTypeID;
	private int combination;
	private int gainAmount;
	private bool enabled;
    private string playTypeName;
    private string lotteryName;
    private string shiftName;

    public string ShiftName
    {
        get { return shiftName; }
        set { shiftName = value; }
    }

    public string LotteryName
    {
        get { return lotteryName; }
        set { lotteryName = value; }
    }


    private int errorCode = 0;
    private string errorDescription = "Successful";

    public string PlayTypeName
    {
        get { return playTypeName; }
        set { playTypeName = value; }
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

	public int CombinationID
	{
		get { return combinationID; }
		set { combinationID = value; }
	}
	public int PlayTypeID
	{
		get { return playTypeID; }
		set { playTypeID = value; }
	}
	public int Combination
	{
		get { return combination; }
		set { combination = value; }
	}
	public int GainAmount
	{
		get { return gainAmount; }
		set { gainAmount = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Combinations(){ }

	public Boolean Insert(LoginDAL loginDAL)
	{
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
            SqlCommand cmd = new SqlCommand("CombinationsInsert", con);
			parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			parametros.Value = PlayTypeID;
			parametros = cmd.Parameters.Add("@Combination", SqlDbType.Int);
			parametros.Value = Combination;
			parametros = cmd.Parameters.Add("@GainAmount", SqlDbType.Int);
			parametros.Value = GainAmount;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
        catch (SqlException e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
		return res;
	}

    public Boolean Update(LoginDAL loginDAL)
    {
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
            SqlCommand cmd = new SqlCommand("CombinationsUpdate", con);
            parametros = cmd.Parameters.Add("@CombinationID", SqlDbType.Int);
            parametros.Value = CombinationID;
            parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
            parametros.Value = PlayTypeID;
            parametros = cmd.Parameters.Add("@Combination", SqlDbType.Int);
            parametros.Value = Combination;
            parametros = cmd.Parameters.Add("@GainAmount", SqlDbType.Int);
            parametros.Value = GainAmount;
            parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
            parametros.Value = Enabled;
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                res = true;
            con.Close();
        }
        catch (SqlException e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
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
            SqlCommand cmd = new SqlCommand("CombinationsUpdate", con);
			parametros = cmd.Parameters.Add("@CombinationID", SqlDbType.Int);
			parametros.Value = CombinationID;
			parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			parametros.Value = PlayTypeID;
			parametros = cmd.Parameters.Add("@Combination", SqlDbType.Int);
			parametros.Value = Combination;
			parametros = cmd.Parameters.Add("@GainAmount", SqlDbType.Int);
			parametros.Value = GainAmount;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
        catch (SqlException e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
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
            SqlCommand cmd = new SqlCommand("CombinationsDelete", con);
			parametros = cmd.Parameters.Add("@CombinationID", SqlDbType.Int);
			parametros.Value = CombinationID;
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


    public List<CombinationsDAL> Search(LoginDAL loginDAL)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<CombinationsDAL> combinationsList = new List<CombinationsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource;
            dbm.DataBase = loginDAL.DataBaseName;
            dbm.User = loginDAL.UserName;
            dbm.Password = loginDAL.UserPassword;

            con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("CombinationsSearch", con);
            if (combinationID > 0)
            {
                parametros = cmd.Parameters.Add("@CombinationID", SqlDbType.Int);
                parametros.Value = combinationID;
            }
            if (playTypeID > 0)
            {
                parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
                parametros.Value = playTypeID;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                
                while (dr.Read())
                {
                    combinationsDAL = new CombinationsDAL();
                    combinationsDAL.combinationID = dr.GetInt32(dr.GetOrdinal("CombinationID"));
                    combinationsDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    combinationsDAL.playTypeName = dr.GetString(dr.GetOrdinal("playTypeName"));
                    combinationsDAL.combination = dr.GetInt32(dr.GetOrdinal("Combination"));
                    combinationsDAL.gainAmount = dr.GetInt32(dr.GetOrdinal("GainAmount"));
                    combinationsDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                    combinationsDAL.shiftName = dr.GetString(dr.GetOrdinal("ShiftName"));
                    combinationsDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    combinationsList.Add(combinationsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return combinationsList;
	}


	public Boolean GetByKey(LoginDAL loginDAL)
	{
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
            SqlCommand cmd = new SqlCommand("CombinationsGetByKey", con);
            parametros = cmd.Parameters.Add("@CombinationID", SqlDbType.Int);
            parametros.Value = CombinationID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                combinationID = dr.GetInt32(dr.GetOrdinal("CombinationID"));
                playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                combination = dr.GetInt32(dr.GetOrdinal("Combination"));
                gainAmount = dr.GetInt32(dr.GetOrdinal("GainAmount"));
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
        CombinationID = 0;
        Combination = 0;
        playTypeID = 0;
        GainAmount = 0;
        Enabled = false;
    }

}
