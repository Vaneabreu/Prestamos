using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class LotteriesModel
{

    LotteriesDAL lotteriesDAL = new LotteriesDAL();
    private List<LotteriesDAL> lotteriesListDAL = null;

   

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
    public List<LotteriesDAL> LotteriesListDAL
    {
        get { return lotteriesListDAL; }
        set { lotteriesListDAL = value; }
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
        bool result = false;

        lotteriesDAL.Name = name;
        lotteriesDAL.ShiftID = shiftID;
        lotteriesDAL.Description = description;
        lotteriesDAL.ClosingTime = closingTime;
        lotteriesDAL.SundayClosingTime = sundayClosingTime;
        lotteriesDAL.Enabled = enabled;
        
       result = lotteriesDAL.Insert();

       errorCode = lotteriesDAL.ErrorCode;
       errorDescription = lotteriesDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        lotteriesDAL.LotteryID = lotteryID;
        lotteriesDAL.Name = name;
        lotteriesDAL.ShiftID = shiftID;
        lotteriesDAL.Description = description;
        lotteriesDAL.ClosingTime = closingTime;
        lotteriesDAL.SundayClosingTime = sundayClosingTime;
        lotteriesDAL.Enabled = enabled;

        result = lotteriesDAL.Edit();

        errorCode = lotteriesDAL.ErrorCode;
        errorDescription = lotteriesDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        lotteriesDAL.LotteryID = lotteryID;

        result = lotteriesDAL.Delete();

        errorCode = lotteriesDAL.ErrorCode;
        errorDescription = lotteriesDAL.ErrorDescription;

        return result;
    }


    public List<LotteriesDAL> Search()
    {
        lotteriesListDAL = new List<LotteriesDAL>();

        lotteriesDAL.clearFields();

        if (lotteryID > 0)
            lotteriesDAL.LotteryID = lotteryID;
        if (!string.IsNullOrEmpty(Name))
            lotteriesDAL.Name = Name;
        if (ShiftID > 0)
            lotteriesDAL.ShiftID = shiftID;

        lotteriesListDAL = lotteriesDAL.Search();

        errorCode = lotteriesDAL.ErrorCode;
        errorDescription = lotteriesDAL.ErrorDescription;

        return lotteriesListDAL;
    }

    public List<LotteriesDAL> LoadCombo()
    {
        lotteriesListDAL = new List<LotteriesDAL>();

        lotteriesListDAL = lotteriesDAL.LoadCombo();

        errorCode = lotteriesDAL.ErrorCode;
        errorDescription = lotteriesDAL.ErrorDescription;

        return lotteriesListDAL;
    }

    public List<LotteriesDAL> LoadCombo2()
    {
        lotteriesListDAL = new List<LotteriesDAL>();

        lotteriesListDAL = lotteriesDAL.LoadCombo2();

        errorCode = lotteriesDAL.ErrorCode;
        errorDescription = lotteriesDAL.ErrorDescription;

        return lotteriesListDAL;
    }




    public Boolean GetByKey()
    {
        bool result = false;

        lotteriesDAL.LotteryID = lotteryID;

        if (lotteriesDAL.GetByKey())
        {
            lotteryID = lotteriesDAL.LotteryID;
            name =  lotteriesDAL.Name;
            shiftID = lotteriesDAL.ShiftID;
            description =  lotteriesDAL.Description;
            closingTime = lotteriesDAL.ClosingTime;
            sundayClosingTime = lotteriesDAL.SundayClosingTime;
            enabled = lotteriesDAL.Enabled;
            
            result = true;
        }

        errorCode = lotteriesDAL.ErrorCode;
        errorDescription = lotteriesDAL.ErrorDescription;

        return result;
    }

    public Boolean GetByName()
    {
        bool result = false;

        lotteriesDAL.Name = Name;

        if (!string.IsNullOrEmpty(ShiftName))
            lotteriesDAL.ShiftName = ShiftName;
        

        if (lotteriesDAL.GetByName())
        {
            lotteryID = lotteriesDAL.LotteryID;
            name = lotteriesDAL.Name;
            shiftID = lotteriesDAL.ShiftID;
            description = lotteriesDAL.Description;  
            closingTime = lotteriesDAL.ClosingTime;
            enabled = lotteriesDAL.Enabled;
            shiftName = lotteriesDAL.ShiftName;

            result = true;
        }

        errorCode = lotteriesDAL.ErrorCode;
        errorDescription = lotteriesDAL.ErrorDescription;

        return result;
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
