using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class WinNumbersModel
{

    WinNumbersDAL winNumbersDAL = new WinNumbersDAL();
    private List<WinNumbersDAL> winNumbersListDAL = null;

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

    public List<WinNumbersDAL> WinNumbersListDAL
    {
        get { return winNumbersListDAL; }
        set { winNumbersListDAL = value; }
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
        bool result = false;

        winNumbersDAL.LotteryID = LotteryID;
        winNumbersDAL.First = First;
        winNumbersDAL.Second = Second;
        winNumbersDAL.Third = Third;
        winNumbersDAL.Date = Date;

        result = winNumbersDAL.Insert();

        errorCode = winNumbersDAL.ErrorCode;
        errorDescription = winNumbersDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        winNumbersDAL.WinNumberID = WinNumberID;
        winNumbersDAL.LotteryID = LotteryID;
        winNumbersDAL.First = First;
        winNumbersDAL.Second = Second;
        winNumbersDAL.Third = Third;
        winNumbersDAL.Date = Date;

        result = winNumbersDAL.Edit();

        errorCode = winNumbersDAL.ErrorCode;
        errorDescription = winNumbersDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        winNumbersDAL.WinNumberID = WinNumberID;

        result = winNumbersDAL.Delete();

        errorCode = winNumbersDAL.ErrorCode;
        errorDescription = winNumbersDAL.ErrorDescription;

        return result;
    }


    public List<WinNumbersDAL> Search()
    {
        winNumbersListDAL = new List<WinNumbersDAL>();
        winNumbersDAL.clearFields();

        if (WinNumberID > 0)
            winNumbersDAL.WinNumberID = WinNumberID;
        if (LotteryID > 0)
            winNumbersDAL.LotteryID = LotteryID;
        if (StartDate != null)
            winNumbersDAL.StartDate = StartDate;
        if (EndDate != null)
            winNumbersDAL.EndDate = EndDate;

        winNumbersListDAL = winNumbersDAL.Search();

        errorCode = winNumbersDAL.ErrorCode;
        errorDescription = winNumbersDAL.ErrorDescription;

        return winNumbersListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        winNumbersDAL.WinNumberID = WinNumberID;

        if (winNumbersDAL.GetByKey()) 
        {
            WinNumberID = winNumbersDAL.WinNumberID;
            LotteryID = winNumbersDAL.LotteryID;
            First = winNumbersDAL.First;
            Second = winNumbersDAL.Second;
            Third = winNumbersDAL.Third;
            Date = winNumbersDAL.Date;

            result = true;
        }

        errorCode = winNumbersDAL.ErrorCode;
        errorDescription = winNumbersDAL.ErrorDescription;

        return result;
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
