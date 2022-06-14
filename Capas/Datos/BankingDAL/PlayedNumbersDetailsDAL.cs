using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class PlayedNumbersDetailsDAL
{
	Connection dbm = new Connection();
     PlayedNumbersDetailsDAL playedNumbersDetailsDAL = null;

	private long playedNumberDetailID;
	private int playedNumberID;
	private string playTypeName;
	private string numbers;
	private decimal amount;
     private int errorCode = 0;
    private string errorDescription = "successful";

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

	public long PlayedNumberDetailID
	{
		get { return playedNumberDetailID; }
		set { playedNumberDetailID = value; }
	}
	public int PlayedNumberID
	{
		get { return playedNumberID; }
		set { playedNumberID = value; }
	}
	public string PlayTypeName
	{
		get { return playTypeName; }
		set { playTypeName = value; }
	}
	public string Numbers
	{
		get { return numbers; }
		set { numbers = value; }
	}
	public decimal Amount
	{
		get { return amount; }
		set { amount = value; }
	}

	public PlayedNumbersDetailsDAL(){ }

	public Boolean Insert()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("PlayedNumbersDetailsInsert", con);
			parametros = cmd.Parameters.Add("@PlayedNumberID", SqlDbType.Int);
			parametros.Value = PlayedNumberID;
			parametros = cmd.Parameters.Add("@PlayTypeName", SqlDbType.VarChar);
			parametros.Value = PlayTypeName;
			parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
			parametros.Value = Numbers;
			parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
			parametros.Value = Amount;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
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
			SqlCommand cmd = new SqlCommand("PlayedNumbersDetailsUpdate", con);
			parametros = cmd.Parameters.Add("@PlayedNumberDetailID", SqlDbType.BigInt);
			parametros.Value = PlayedNumberDetailID;
			parametros = cmd.Parameters.Add("@PlayedNumberID", SqlDbType.Int);
			parametros.Value = PlayedNumberID;
			parametros = cmd.Parameters.Add("@PlayTypeName", SqlDbType.VarChar);
			parametros.Value = PlayTypeName;
			parametros = cmd.Parameters.Add("@Numbers", SqlDbType.VarChar);
			parametros.Value = Numbers;
			parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
			parametros.Value = Amount;
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
			SqlCommand cmd = new SqlCommand("PlayedNumbersDetailsDelete", con);
			parametros = cmd.Parameters.Add("@PlayedNumberDetailID", SqlDbType.BigInt);
			parametros.Value = PlayedNumberDetailID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
		return res;
	}


	public List<PlayedNumbersDetailsDAL> Search()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
        int n = 0;
        List<PlayedNumbersDetailsDAL> playedNumbersDetailsList = new List<PlayedNumbersDetailsDAL>();
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("PlayedNumbersDetailsSearch", con);
            if (playedNumberDetailID > 0)
            {
                parametros = cmd.Parameters.Add("@PlayedNumberDetailID", SqlDbType.BigInt);
                parametros.Value = PlayedNumberDetailID;
            }
            if (playedNumberID > 0)
            {
                parametros = cmd.Parameters.Add("@PlayedNumberID", SqlDbType.Int);
                parametros.Value = PlayedNumberID;
            }
			cmd.CommandType = CommandType.StoredProcedure;
			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
					while (dr.Read())
					{
						playedNumbersDetailsDAL = new PlayedNumbersDetailsDAL();
                        playedNumbersDetailsDAL.playedNumberDetailID = dr.GetInt64(dr.GetOrdinal("PlayedNumberDetailID"));
                        playedNumbersDetailsDAL.playedNumberID = dr.GetInt32(dr.GetOrdinal("PlayedNumberID"));
                        playedNumbersDetailsDAL.playTypeName = dr.GetString(dr.GetOrdinal("PlayTypeName"));
                        n = dr.GetInt32(dr.GetOrdinal("Numbers"));
                        playedNumbersDetailsDAL.numbers = n.ToString();
                        playedNumbersDetailsDAL.amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                        playedNumbersDetailsList.Add(playedNumbersDetailsDAL);
					}
			}
			con.Close();
		}
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

		 return playedNumbersDetailsList;
	}


}
