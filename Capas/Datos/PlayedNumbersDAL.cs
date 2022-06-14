using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class PlayedNumbersDAL
{
	Connection dbm = new Connection();
    PlayedNumbersDAL playedNumbersDAL = null;

	private int playedNumberID;
	private DateTime date;
	private string lotteryName;
	private decimal totalAmount;
	private int ticketID;
	private decimal commision;
	private bool enabled;
    private int errorCode = 0;
    private string errorDescription = "successful";
    private string ticketImage;
    public decimal identityID; 

    public string TicketImage
    {
        get { return ticketImage; }
        set { ticketImage = value; }
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

	public int PlayedNumberID
	{
		get { return playedNumberID; }
		set { playedNumberID = value; }
	}
	public DateTime Date
	{
		get { return date; }
		set { date = value; }
	}
	public string LotteryName
	{
		get { return lotteryName; }
		set { lotteryName = value; }
	}
	public decimal TotalAmount
	{
		get { return totalAmount; }
		set { totalAmount = value; }
	}
	public int TicketID
	{
		get { return ticketID; }
		set { ticketID = value; }
	}
	public decimal Commision
	{
		get { return commision; }
		set { commision = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public PlayedNumbersDAL(){ }

	public Boolean Insert()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
        SqlDataReader dr = null;
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("PlayedNumbersInsert", con);
            //parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            //parametros.Value = Date;
			parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
			parametros.Value = LotteryName;
			parametros = cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
			parametros.Value = TotalAmount;
            if (TicketID > 0)
            {
			    parametros = cmd.Parameters.Add("@TicketID", SqlDbType.Int);
			    parametros.Value = TicketID;
            }
            if (Commision > 0)
            {
                parametros = cmd.Parameters.Add("@Commision", SqlDbType.Decimal);
                parametros.Value = Commision;
            }
            if (string.IsNullOrEmpty(TicketImage))
            {
                parametros = cmd.Parameters.Add("@TicketImage", SqlDbType.VarChar);
                parametros.Value = TicketImage;
            }
			cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    identityID = dr.GetDecimal(dr.GetOrdinal("PlayedNumberID"));
                    res = true;
                }
            }
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
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
			SqlCommand cmd = new SqlCommand("PlayednumbersUpdate", con);
			parametros = cmd.Parameters.Add("@PlayedNumberID", SqlDbType.Int);
			parametros.Value = PlayedNumberID;
            //parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            //parametros.Value = Date;
			parametros = cmd.Parameters.Add("@LotteryName", SqlDbType.VarChar);
			parametros.Value = LotteryName;
			parametros = cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
			parametros.Value = TotalAmount;
			parametros = cmd.Parameters.Add("@TicketID", SqlDbType.Int);
			parametros.Value = TicketID;
			parametros = cmd.Parameters.Add("@Commision", SqlDbType.Decimal);
			parametros.Value = Commision;
            parametros = cmd.Parameters.Add("@TicketImage", SqlDbType.VarChar);
            parametros.Value = TicketImage;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
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
			SqlCommand cmd = new SqlCommand("PlayedNumbersDelete", con);
			parametros = cmd.Parameters.Add("@PlayedNumberID", SqlDbType.Int);
			parametros.Value = PlayedNumberID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
		return res;
	}


	public List<PlayedNumbersDAL> Search()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
		List<PlayedNumbersDAL> PlayedNumbersList = new List<PlayedNumbersDAL>();
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("PlayedNumbersSearch", con);
            if (playedNumberID > 0)
            {
                parametros = cmd.Parameters.Add("@PlayedNumberID", SqlDbType.Int);
                parametros.Value = playedNumberID;
            }
			cmd.CommandType = CommandType.StoredProcedure;
			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
					while (dr.Read())
					{
						playedNumbersDAL = new PlayedNumbersDAL();
                        playedNumbersDAL.playedNumberID = dr.GetInt32(dr.GetOrdinal("PlayedNumberID"));
                        playedNumbersDAL.date = dr.GetDateTime(dr.GetOrdinal("Date"));
                        playedNumbersDAL.lotteryName = dr.GetString(dr.GetOrdinal("LotteryName"));
                        playedNumbersDAL.totalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                        playedNumbersDAL.ticketID = dr.GetInt32(dr.GetOrdinal("TicketID"));
                        playedNumbersDAL.commision = dr.GetDecimal(dr.GetOrdinal("Commision"));
                        playedNumbersDAL.ticketImage = dr.GetString(dr.GetOrdinal("TicketImage"));
                        playedNumbersDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                        PlayedNumbersList.Add(playedNumbersDAL);

					}
			}
			con.Close();
		}
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

		 return PlayedNumbersList;
	}


}
