using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class DailyReportDAL
{
	Connection dbm = new Connection();
    DailyReportDAL dailyreportDAL = null;

	private int dailyReportID;
	private string reportType;
	private DateTime date;
	private decimal beforeAmount;
	private decimal debit;
	private decimal credit;
	private decimal balance;
	private int branchID;
     private DateTime startTime;
    private DateTime endTime;
    private string branchName;
    private decimal winned;
    private decimal deposited;
    private decimal userCommission;
    private decimal redAmount;

    public decimal RedAmount
    {
        get { return redAmount; }
        set { redAmount = value; }
    }

    public decimal UserCommission
    {
        get { return userCommission; }
        set { userCommission = value; }
    }

    public decimal Deposited
    {
        get { return deposited; }
        set { deposited = value; }
    }

    public decimal Winned
    {
        get { return winned; }
        set { winned = value; }
    }


    public string BranchName
    {
        get { return branchName; }
        set { branchName = value; }
    }

    public DateTime EndTime
    {
        get { return endTime; }
        set { endTime = value; }
    }

    public DateTime StartTime
    {
        get { return startTime; }
        set { startTime = value; }
    }

	public int DailyReportID
	{
		get { return dailyReportID; }
		set { dailyReportID = value; }
	}
	public string ReportType
	{
		get { return reportType; }
		set { reportType = value; }
	}
	public DateTime Date
	{
		get { return date; }
		set { date = value; }
	}
	public decimal BeforeAmount
	{
		get { return beforeAmount; }
		set { beforeAmount = value; }
	}
	public decimal Debit
	{
		get { return debit; }
		set { debit = value; }
	}
	public decimal Credit
	{
		get { return credit; }
		set { credit = value; }
	}
	public decimal Balance
	{
		get { return balance; }
		set { balance = value; }
	}
	public int BranchID
	{
		get { return branchID; }
		set { branchID = value; }
	}

	public DailyReportDAL(){ }

	public Boolean Insert()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("DailyReportInsert", con);
			parametros = cmd.Parameters.Add("@ReportType", SqlDbType.VarChar);
			parametros.Value = ReportType;
			parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
			parametros.Value = Date;
			parametros = cmd.Parameters.Add("@BeforeAmount", SqlDbType.Decimal);
			parametros.Value = BeforeAmount;
			parametros = cmd.Parameters.Add("@Debit", SqlDbType.Decimal);
			parametros.Value = Debit;
			parametros = cmd.Parameters.Add("@Credit", SqlDbType.Decimal);
			parametros.Value = Credit;
			parametros = cmd.Parameters.Add("@Balance", SqlDbType.Decimal);
			parametros.Value = Balance;
			parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
			parametros.Value = BranchID;
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
			SqlCommand cmd = new SqlCommand("DailyEeportUpdate", con);
			parametros = cmd.Parameters.Add("@DailyReportID", SqlDbType.Int);
			parametros.Value = DailyReportID;
			parametros = cmd.Parameters.Add("@ReportType", SqlDbType.VarChar);
			parametros.Value = ReportType;
			parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
			parametros.Value = Date;
			parametros = cmd.Parameters.Add("@BeforeAmount", SqlDbType.Decimal);
			parametros.Value = BeforeAmount;
			parametros = cmd.Parameters.Add("@Debit", SqlDbType.Decimal);
			parametros.Value = Debit;
			parametros = cmd.Parameters.Add("@Credit", SqlDbType.Decimal);
			parametros.Value = Credit;
			parametros = cmd.Parameters.Add("@Balance", SqlDbType.Decimal);
			parametros.Value = Balance;
			parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
			parametros.Value = BranchID;
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
			SqlCommand cmd = new SqlCommand("DailyReportDelete", con);
			parametros = cmd.Parameters.Add("@DailyReportID", SqlDbType.Int);
			parametros.Value = DailyReportID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
		return res;
	}


	public List<DailyReportDAL> Search()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
		List<DailyReportDAL> DailyreportList = new List<DailyReportDAL>();
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("DailyReportSearch", con);
             if (BranchID > 0)
            {
                parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
                parametros.Value = BranchID;
            }
              if (DailyReportID > 0)
            {
                parametros = cmd.Parameters.Add("@DailyReportID", SqlDbType.Int);
                parametros.Value = DailyReportID;
            }

            parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(StartTime.ToShortDateString() + " 00:00:00");
            parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
            parametros.Value = Convert.ToDateTime(EndTime.ToShortDateString() + " 23:59:59");
			cmd.CommandType = CommandType.StoredProcedure;
			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
					while (dr.Read())
					{
						dailyreportDAL = new DailyReportDAL();
                        dailyreportDAL.DailyReportID = dr.GetInt32(dr.GetOrdinal("DailyReportID"));
                        dailyreportDAL.ReportType = dr.GetString(dr.GetOrdinal("ReportType"));
                        dailyreportDAL.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                        dailyreportDAL.BeforeAmount = dr.GetDecimal(dr.GetOrdinal("BeforeAmount"));
                        dailyreportDAL.Debit = dr.GetDecimal(dr.GetOrdinal("Debit"));//venta
                        dailyreportDAL.Credit = dr.GetDecimal(dr.GetOrdinal("Credit"));//retiro
                        dailyreportDAL.Balance = dr.GetDecimal(dr.GetOrdinal("Balance"));
                        dailyreportDAL.BranchID = dr.GetInt32(dr.GetOrdinal("BranchID"));
                        dailyreportDAL.BranchName = dr.GetString(dr.GetOrdinal("BranchName"));
                        dailyreportDAL.Winned = dr.GetDecimal(dr.GetOrdinal("Winned"));
                        dailyreportDAL.Deposited = dr.GetDecimal(dr.GetOrdinal("Deposited"));
                        dailyreportDAL.UserCommission = dr.GetDecimal(dr.GetOrdinal("UserCommission"));
                        dailyreportDAL.RedAmount = dr.GetDecimal(dr.GetOrdinal("RedAmount"));
                        DailyreportList.Add(dailyreportDAL);
				    }
			}
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }

		 return DailyreportList;
	}


}
