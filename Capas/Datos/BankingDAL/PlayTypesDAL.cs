using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class PlayTypesDAL
{
    Connection dbm = new Connection();
    PlayTypesDAL playTypesDAL = null;

	private int playTypeID;
	private int lotteryID;
	private int customerID;
	private string name;
	private decimal commissionPercent;
	private decimal partnerCommissionPercent;
	private bool enabled;
    private string lotteryName;
    private string customerName;
    private int errorCode;
    private string errorDescription;
    private string shiftName;

    public string ShiftName
    {
        get { return shiftName; }
        set { shiftName = value; }
    }

    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
    }
    public string LotteryName
    {
        get { return lotteryName; }
        set { lotteryName = value; }
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

	public int PlayTypeID
	{
		get { return playTypeID; }
		set { playTypeID = value; }
	}
	public int LotteryID
	{
		get { return lotteryID; }
		set { lotteryID = value; }
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
	public decimal CommissionPercent
	{
		get { return commissionPercent; }
		set { commissionPercent = value; }
	}
	public decimal PartnerCommissionPercent
	{
		get { return partnerCommissionPercent; }
		set { partnerCommissionPercent = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void PlayTypes(){ }

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
            SqlCommand cmd = new SqlCommand("PlayTypesInsert", con);
			parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
			parametros.Value = LotteryID;
			parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
			parametros.Value = CustomerID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@CommissionPercent", SqlDbType.Decimal);
			parametros.Value = CommissionPercent;
			parametros = cmd.Parameters.Add("@PartnerCommissionPercent", SqlDbType.Decimal);
			parametros.Value = PartnerCommissionPercent;
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
            SqlCommand cmd = new SqlCommand("PlayTypesUpdate", con);
			parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			parametros.Value = PlayTypeID;
			parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
			parametros.Value = LotteryID;
			parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
			parametros.Value = CustomerID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@CommissionPercent", SqlDbType.Decimal);
			parametros.Value = CommissionPercent;
			parametros = cmd.Parameters.Add("@PartnerCommissionPercent", SqlDbType.Decimal);
			parametros.Value = PartnerCommissionPercent;
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
            SqlCommand cmd = new SqlCommand("PlayTypesDelete", con);
			parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
			parametros.Value = PlayTypeID;
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


    public List<PlayTypesDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<PlayTypesDAL> playTypesList = new List<PlayTypesDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("PlayTypesSearch", con);
            if (playTypeID > 0)
            {
                parametros = cmd.Parameters.Add("@playTypeID", SqlDbType.Int);
                parametros.Value = playTypeID;
            }
            if (!string.IsNullOrEmpty(Name))
            {
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = Name;
            }
            if (CustomerID > 0)
            {
                parametros = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                parametros.Value = CustomerID;
            }
            if (LotteryID > 0)
            {
                parametros = cmd.Parameters.Add("@LotteryID", SqlDbType.Int);
                parametros.Value = LotteryID;
            }
   
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    playTypesDAL = new PlayTypesDAL();
                    playTypesDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    playTypesDAL.lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                    playTypesDAL.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    playTypesDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    playTypesDAL.customerName = dr.GetString(dr.GetOrdinal("CustomerName"));
                    playTypesDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                    playTypesDAL.commissionPercent = dr.GetDecimal(dr.GetOrdinal("CommissionPercent"));
                    playTypesDAL.partnerCommissionPercent = dr.GetDecimal(dr.GetOrdinal("PartnerCommissionPercent"));
                    playTypesDAL.shiftName = dr.GetString(dr.GetOrdinal("ShiftName"));
                    playTypesDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    playTypesList.Add(playTypesDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return playTypesList;
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
            SqlCommand cmd = new SqlCommand("PlayTypesGetByKey", con);
            parametros = cmd.Parameters.Add("@PlayTypeID", SqlDbType.Int);
            parametros.Value = PlayTypeID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                commissionPercent = dr.GetDecimal(dr.GetOrdinal("CommissionPercent"));
                partnerCommissionPercent = dr.GetDecimal(dr.GetOrdinal("PartnerCommissionPercent"));
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

    public List<PlayTypesDAL> LoadCombo()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<PlayTypesDAL> playTypesList = new List<PlayTypesDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("PlayTypesSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                playTypesDAL = new PlayTypesDAL();
                playTypesDAL.playTypeID = -1;
                playTypesDAL.Name = "-- Seleccione --";
                playTypesList.Add(playTypesDAL);
                while (dr.Read())
                {
                    playTypesDAL = new PlayTypesDAL();
                    playTypesDAL.playTypeID = dr.GetInt32(dr.GetOrdinal("PlayTypeID"));
                    playTypesDAL.lotteryID = dr.GetInt32(dr.GetOrdinal("LotteryID"));
                    playTypesDAL.customerID = dr.GetInt32(dr.GetOrdinal("CustomerID"));
                    playTypesDAL.name = dr.GetString(dr.GetOrdinal("Name")) + " - " + dr.GetString(dr.GetOrdinal("LotteryName"))+" - "+dr.GetString(dr.GetOrdinal("ShiftName"));
                    playTypesDAL.commissionPercent = dr.GetDecimal(dr.GetOrdinal("CommissionPercent"));
                    playTypesDAL.partnerCommissionPercent = dr.GetDecimal(dr.GetOrdinal("PartnerCommissionPercent"));
                    playTypesDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    playTypesList.Add(playTypesDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return playTypesList;
    }

    public void clearFields()
    {
        playTypeID = 0;
        lotteryID = 0;
        CustomerID = 0;
        Name = "";
        CommissionPercent = 0;
        PartnerCommissionPercent = 0;
        Enabled = false;
    }

}
