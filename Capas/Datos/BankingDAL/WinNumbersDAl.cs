using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class WinNumbersDAL
{
    Connection dbm = new Connection();
    WinNumbersDAL winNumbersDAL = null;

	private int winNumberID;
	private int lotteryID;
	private string first;
	private string second;
	private string third;
	private DateTime date;
    private DateTime startDate;
    private DateTime endDate;
    private string lotteryName;
    private string shiftName;
    private int errorCode;
    private string errorDescription;

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

    public DateTime EndDate
    {
        get { return endDate; }
        set { endDate = value; }
    }

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
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

	public int WinNumberID
	{
		get { return winNumberID; }
		set { winNumberID = value; }
	}
	public int LotteryID
	{
		get { return lotteryID; }
		set { lotteryID = value; }
	}
	public string First
	{
		get { return first; }
		set { first = value; }
	}
	public string Second
	{
		get { return second; }
		set { second = value; }
	}
	public string Third
	{
		get { return third; }
		set { third = value; }
	}
	public DateTime Date
	{
		get { return date; }
		set { date = value; }
	}

    public void WinNumbers() { }

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
            SqlCommand cmd = new SqlCommand("WinNumbersInsert", con);
			parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
			parametros.Value = LotteryID;
			parametros = cmd.Parameters.Add("@First", SqlDbType.VarChar);
			parametros.Value = First;
			parametros = cmd.Parameters.Add("@Second", SqlDbType.VarChar);
			parametros.Value = Second;
			parametros = cmd.Parameters.Add("@Third", SqlDbType.VarChar);
			parametros.Value = Third;
			parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
			parametros.Value = Date;
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
            SqlCommand cmd = new SqlCommand("WinNumbersUpdate", con);
			parametros = cmd.Parameters.Add("@WinNumberID", SqlDbType.Int);
			parametros.Value = WinNumberID;
			parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
			parametros.Value = LotteryID;
			parametros = cmd.Parameters.Add("@First", SqlDbType.VarChar);
			parametros.Value = First;
			parametros = cmd.Parameters.Add("@Second", SqlDbType.VarChar);
			parametros.Value = Second;
			parametros = cmd.Parameters.Add("@Third", SqlDbType.VarChar);
			parametros.Value = Third;
			parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
			parametros.Value = Date;
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
            SqlCommand cmd = new SqlCommand("WinNumbersDelete", con);
			parametros = cmd.Parameters.Add("@WinNumberID", SqlDbType.Int);
			parametros.Value = WinNumberID;
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


    public List<WinNumbersDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<WinNumbersDAL> winNumbersList = new List<WinNumbersDAL>();

        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("WinNumbersSearch", con);

            if (winNumberID > 0)
            {
                parametros = cmd.Parameters.Add("@WinNumberID", SqlDbType.Int);
                parametros.Value = WinNumberID;
            }
            if (LotteryID > 0)
            {
                parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.VarChar);
                parametros.Value = LotteryID;
            }
            //if (StartDate != null)
            //{
            //    parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            //    parametros.Value = StartDate;
            //}
            //if (EndDate != null)
            //{
            //    parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            //    parametros.Value = EndDate;
            //}

            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(StartDate.ToShortDateString() + " 00:00:00");
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(EndDate.ToShortDateString() + " 23:59:59");

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    winNumbersDAL = new WinNumbersDAL();
                    winNumbersDAL.winNumberID = dr.GetInt32(dr.GetOrdinal("WinNumberID"));
                    winNumbersDAL.lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                    winNumbersDAL.first = dr.GetString(dr.GetOrdinal("First"));
                    winNumbersDAL.second = dr.GetString(dr.GetOrdinal("Second"));
                    winNumbersDAL.third = dr.GetString(dr.GetOrdinal("Third"));
                    winNumbersDAL.date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    winNumbersDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                    winNumbersDAL.shiftName = dr.GetString(dr.GetOrdinal("shiftName"));
                    winNumbersList.Add(winNumbersDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return winNumbersList;
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
            SqlCommand cmd = new SqlCommand("WinNumbersGetByKey", con);
            parametros = cmd.Parameters.Add("@WinNumberID", SqlDbType.Int);
            parametros.Value = WinNumberID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                winNumberID = dr.GetInt32(dr.GetOrdinal("WinNumberID"));
                lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                first = dr.GetString(dr.GetOrdinal("First"));
                second = dr.GetString(dr.GetOrdinal("Second"));
                third = dr.GetString(dr.GetOrdinal("Third"));
                date = dr.GetDateTime(dr.GetOrdinal("Date"));

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
        WinNumberID = 0;
        LotteryID = 0;
        First = "";
        Second = "";
        Third = "";
    }
}
