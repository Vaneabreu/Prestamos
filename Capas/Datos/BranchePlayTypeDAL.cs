using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class BranchePlayTypeDAL
{
	Connection dbm = new Connection();
    BranchePlayTypeDAL branchePlayTypeDAL = null;

    private long branchePlayTypeID;
    private int branchID;
    private int playTypeID;
    private decimal percent;
    private string branchName;
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

    public string PlayTypeName
    {
        get { return playTypeName; }
        set { playTypeName = value; }
    }

    public string BranchName
    {
        get { return branchName; }
        set { branchName = value; }
    }


    private int errorCode = 0;
    private string errorDescription = "successful";

    public string ErrorDescription
    {
        get { return errorDescription; }
        set { errorDescription = value; }
    }

    public int ErrorCode
    {
        get { return errorCode; }
        set { errorCode = value; }
    }

    public long BranchePlayTypeID
    {
        get { return branchePlayTypeID; }
        set { branchePlayTypeID = value; }
    }
    public int BranchID
    {
        get { return branchID; }
        set { branchID = value; }
    }
    public int PlayTypeID
    {
        get { return playTypeID; }
        set { playTypeID = value; }
    }
    public decimal Percent
    {
        get { return percent; }
        set { percent = value; }
    }

	public BranchePlayTypeDAL(){ }

	public Boolean Insert()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("BrancheplaytypeInsert", con);
			parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
			parametros.Value = BranchID;
			parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			parametros.Value = PlayTypeID;
			parametros = cmd.Parameters.Add("@Percent", SqlDbType.Decimal);
			parametros.Value = Percent;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public Boolean Edit()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("BrancheplaytypeUpdate", con);
			parametros = cmd.Parameters.Add("@BranchePlayTypeID", SqlDbType.BigInt);
			parametros.Value = BranchePlayTypeID;
			parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
			parametros.Value = BranchID;
			parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			parametros.Value = PlayTypeID;
			parametros = cmd.Parameters.Add("@Percent", SqlDbType.Decimal);
			parametros.Value = Percent;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public Boolean Delete()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("BrancheplaytypeDelete", con);
			parametros = cmd.Parameters.Add("@BranchePlayTypeID", SqlDbType.BigInt);
			parametros.Value = BranchePlayTypeID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public List<BranchePlayTypeDAL> Search()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
        List<BranchePlayTypeDAL> branchePlayTypeList = new List<BranchePlayTypeDAL>();
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("BrancheplaytypeSearch", con);
          
            if (BranchID > 0)
            {
                parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
                parametros.Value = BranchID;
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
                        branchePlayTypeDAL = new BranchePlayTypeDAL();
                        branchePlayTypeDAL.BranchePlayTypeID = dr.GetInt64(dr.GetOrdinal("BranchePlayTypeID"));
                        branchePlayTypeDAL.BranchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                        branchePlayTypeDAL.PlayTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                        branchePlayTypeDAL.Percent = dr.GetDecimal(dr.GetOrdinal("Percent"));
                        branchePlayTypeDAL.BranchName = dr.GetString(dr.GetOrdinal("BranchName"));
                        branchePlayTypeDAL.PlayTypeName = dr.GetString(dr.GetOrdinal("PlayTypeName"));
                        branchePlayTypeDAL.LotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                        branchePlayTypeDAL.ShiftName = dr.GetString(dr.GetOrdinal("ShiftName"));
                        branchePlayTypeList.Add(branchePlayTypeDAL); 
						}
			}
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
        return branchePlayTypeList;
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
            SqlCommand cmd = new SqlCommand("BranchePlayTypeGetByKey", con);
            parametros = cmd.Parameters.Add("@BranchePlayTypeID", SqlDbType.BigInt);
            parametros.Value = BranchePlayTypeID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                BranchePlayTypeID = dr.GetInt64(dr.GetOrdinal("BranchePlayTypeID"));
                BranchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                PlayTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                Percent = dr.GetDecimal(dr.GetOrdinal("Percent"));
                BranchName = dr.GetString(dr.GetOrdinal("BranchName"));
                PlayTypeName = dr.GetString(dr.GetOrdinal("PlayTypeName"));
                LotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                ShiftName = dr.GetString(dr.GetOrdinal("ShiftName"));

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
        BranchePlayTypeID = 0;
        BranchID = 0;
        PlayTypeID = 0;
        Percent = 0;
        BranchName = "";
        PlayTypeName = "";
    }
}
