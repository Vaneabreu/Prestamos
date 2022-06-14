using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankingDAL;

namespace BankingModel
{
   public class DailyReportModel
    {
        	
    DailyReportDAL dailyReportDAL = new DailyReportDAL();
    private List<DailyReportDAL> dailyReportListDAL = null;


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
    public List<DailyReportDAL> DailyReportListDAL
    {
      get { return dailyReportListDAL; }
      set { dailyReportListDAL = value; }
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

	public DailyReportModel(){ }

	public Boolean Insert()
	{
		 bool result = false;


	dailyReportDAL.ReportType = reportType;
    dailyReportDAL.Date = date;
	dailyReportDAL.BeforeAmount = beforeAmount;
	dailyReportDAL.Debit = debit;
	dailyReportDAL.Credit = credit;
	dailyReportDAL.Balance = balance;
    dailyReportDAL.BranchID = branchID;

         result = dailyReportDAL.Insert();

         //errorCode = dailyReportDAL.ErrorCode;
         //errorDescription = dailyReportDAL.ErrorDescription;

        return result;
	}


	public Boolean Edit()
	{
        bool result = false;

        dailyReportDAL.DailyReportID = dailyReportID;
        dailyReportDAL.ReportType = reportType;
        dailyReportDAL.Date = date;
        dailyReportDAL.BeforeAmount = beforeAmount;
        dailyReportDAL.Debit = debit;
        dailyReportDAL.Credit = credit;
        dailyReportDAL.Balance = balance;
        dailyReportDAL.BranchID = branchID;

        result = dailyReportDAL.Edit();

        //errorCode = dailyReportDAL.ErrorCode;
        //errorDescription = dailyReportDAL.ErrorDescription;

        return result;
		
	}


	public Boolean Delete()
	{
        bool result = false;

        dailyReportDAL.DailyReportID = dailyReportID;


        result = dailyReportDAL.Delete();

        //errorCode = dailyReportDAL.ErrorCode;
        //errorDescription = dailyReportDAL.ErrorDescription;

        return result;
	}


	public List<DailyReportDAL> Search()
	{

        dailyReportListDAL = new List<DailyReportDAL>();

        if (branchID > 0)
            dailyReportDAL.BranchID = branchID;
        if (dailyReportID > 0)
            dailyReportDAL.DailyReportID = dailyReportID;

        dailyReportDAL.StartTime = startTime;
        dailyReportDAL.EndTime = endTime;

        dailyReportListDAL = dailyReportDAL.Search();

        //errorCode = dailyReportDAL.ErrorCode;
        //errorDescription = dailyReportDAL.ErrorDescription;

        return dailyReportListDAL;
	}
    }
}
