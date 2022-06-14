using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class LotteriesDAL
{
    Connection dbm = new Connection();
    LotteriesDAL lotteriesDAL = null;

	private int lotteryID;
	private string name;
	private int shiftID;
	private string description;
	private string closingTime;
	private bool enabled;
    private string shiftName;
    private string sundayClosingTime;
    private int errorCode;
    private string errorDescription;
    private DateTime lastReportDate;

    public DateTime LastReportDate
    {
        get { return lastReportDate; }
        set { lastReportDate = value; }
    }

    public string SundayClosingTime
    {
        get { return sundayClosingTime; }
        set { sundayClosingTime = value; }
    }

    public string ShiftName
    {
        get { return shiftName; }
        set { shiftName = value; }
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

	public int LotteryID
	{
		get { return lotteryID; }
		set { lotteryID = value; }
	}
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public int ShiftID
	{
		get { return shiftID; }
		set { shiftID = value; }
	}
	public string Description
	{
		get { return description; }
		set { description = value; }
	}
	public string ClosingTime
	{
		get { return closingTime; }
		set { closingTime = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

    public void Lotteries() { }

	public Boolean Insert()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("LotteriesInsert", con);
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
			parametros.Value = ShiftID;
			parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
			parametros.Value = Description;
			parametros = cmd.Parameters.Add("@ClosingTime", SqlDbType.VarChar);
			parametros.Value = ClosingTime;
            parametros = cmd.Parameters.Add("@SundayClosingTime", SqlDbType.VarChar);
            parametros.Value = SundayClosingTime;
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


	public Boolean Edit()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("LotteriesUpdate", con);
			parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
			parametros.Value = LotteryID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
			parametros.Value = ShiftID;
			parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
			parametros.Value = Description;
			parametros = cmd.Parameters.Add("@ClosingTime", SqlDbType.VarChar);
			parametros.Value = ClosingTime;
            parametros = cmd.Parameters.Add("@SundayClosingTime", SqlDbType.VarChar);
            parametros.Value = SundayClosingTime;
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


	public Boolean Delete()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("LotteriesDelete", con);
			parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
			parametros.Value = LotteryID;
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


    public List<LotteriesDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LotteriesDAL> LotteriesList = new List<LotteriesDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("LotteriesSearch", con);
            if (lotteryID > 0)
            {
                parametros = cmd.Parameters.Add("@lotteryID", SqlDbType.Int);
                parametros.Value = lotteryID;
            }
            if (!string.IsNullOrEmpty(Name))
            {
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = Name;
            }
            if (shiftID > 0)
            {
                parametros = cmd.Parameters.Add("@shiftID", SqlDbType.Int);
                parametros.Value = shiftID;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lotteriesDAL = new LotteriesDAL();
                    lotteriesDAL.lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                    lotteriesDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    lotteriesDAL.shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                    lotteriesDAL.description = dr.GetString(dr.GetOrdinal("Description"));
                    lotteriesDAL.closingTime = dr.GetString(dr.GetOrdinal("ClosingTime"));
                    lotteriesDAL.sundayClosingTime = dr.GetString(dr.GetOrdinal("SundayClosingTime"));
                    lotteriesDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    lotteriesDAL.shiftName = dr.GetString(dr.GetOrdinal("ShiftName"));
                    lotteriesDAL.lastReportDate = dr.GetDateTime(dr.GetOrdinal("LastReportDate"));
                    LotteriesList.Add(lotteriesDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return LotteriesList;
	}

    public List<LotteriesDAL> LoadCombo()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LotteriesDAL> LotteriesList = new List<LotteriesDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("LotteriesSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                lotteriesDAL = new LotteriesDAL();
                lotteriesDAL.lotteryID = -1;
                lotteriesDAL.Name = "-- Seleccione --";
                LotteriesList.Add(lotteriesDAL);

                while (dr.Read())
                {
                    lotteriesDAL = new LotteriesDAL();
                    lotteriesDAL.lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                    lotteriesDAL.name = dr.GetString(dr.GetOrdinal("Name")) + " - " + dr.GetString(dr.GetOrdinal("ShiftName"));
                    lotteriesDAL.shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                    lotteriesDAL.description = dr.GetString(dr.GetOrdinal("Description"));
                    lotteriesDAL.closingTime = dr.GetString(dr.GetOrdinal("ClosingTime"));
                    lotteriesDAL.sundayClosingTime = dr.GetString(dr.GetOrdinal("SundayClosingTime"));
                    lotteriesDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    lotteriesDAL.shiftName = dr.GetString(dr.GetOrdinal("ShiftName"));
                    LotteriesList.Add(lotteriesDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return LotteriesList;
    }

    public List<LotteriesDAL> LoadCombo2()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<LotteriesDAL> LotteriesList = new List<LotteriesDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("LotteriesSearchCombo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                lotteriesDAL = new LotteriesDAL();
                lotteriesDAL.lotteryID = -1;
                lotteriesDAL.Name = "-- Seleccione --";
                LotteriesList.Add(lotteriesDAL);

                while (dr.Read())
                {
                    lotteriesDAL = new LotteriesDAL();
                    lotteriesDAL.lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                    lotteriesDAL.name = dr.GetString(dr.GetOrdinal("Name")) + " " + dr.GetString(dr.GetOrdinal("ShiftName"));
                    lotteriesDAL.shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                    lotteriesDAL.description = dr.GetString(dr.GetOrdinal("Description"));
                    lotteriesDAL.closingTime = dr.GetString(dr.GetOrdinal("ClosingTime"));
                    lotteriesDAL.sundayClosingTime = dr.GetString(dr.GetOrdinal("SundayClosingTime"));
                    lotteriesDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    lotteriesDAL.shiftName = dr.GetString(dr.GetOrdinal("ShiftName"));
                    LotteriesList.Add(lotteriesDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return LotteriesList;
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
            SqlCommand cmd = new SqlCommand("LotteriesGetByKey", con);
            parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
            parametros.Value = LotteryID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                description = dr.GetString(dr.GetOrdinal("Description"));
                closingTime = dr.GetString(dr.GetOrdinal("ClosingTime"));
                sundayClosingTime = dr.GetString(dr.GetOrdinal("SundayClosingTime"));
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

    public Boolean GetByName()
    {
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("LotteriesGetByName", con);
            parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
            parametros.Value = Name;

            if (!string.IsNullOrEmpty(ShiftName))
            {
                parametros = cmd.Parameters.Add("@ShiftName", SqlDbType.VarChar);
                parametros.Value = ShiftName;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                description = dr.GetString(dr.GetOrdinal("Description"));
                closingTime = dr.GetString(dr.GetOrdinal("ClosingTime"));
                enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                shiftName = dr.GetString(dr.GetOrdinal("ShiftName"));


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


    public Boolean UpdateLastReportDate(int lottID)
    {
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        Boolean res = false;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("LotteriesUpdateLastReportDate", con);
            parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
            parametros.Value = lottID;
           
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

    public void clearFields()
    {
        lotteryID = 0;
        Name = "";
        Description = "";
        ShiftID = 0;
        Enabled = false;
    }


}
