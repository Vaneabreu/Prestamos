using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class LimitNumbersModel
{

    LimitNumbersDAL limitNumbersDAL = new LimitNumbersDAL();
    private List<LimitNumbersDAL> limitNumbersListDAL = null;

 
	private int limitNumberID;
	private int playTypeID;
	private string numbers;
	private int limitAmount;
	private bool enabled;
    private string playTypeLotteryName;

    private int errorCode;
    private string errorDescription;

    public string PlayTypeLotteryName
    {
        get { return playTypeLotteryName; }
        set { playTypeLotteryName = value; }
    }
    public List<LimitNumbersDAL> LimitNumbersListDAL
    {
        get { return limitNumbersListDAL; }
        set { limitNumbersListDAL = value; }
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

	public int LimitNumberID
	{
		get { return limitNumberID; }
		set { limitNumberID = value; }
	}
	public int PlayTypeID
	{
		get { return playTypeID; }
		set { playTypeID = value; }
	}
	public string Numbers
	{
		get { return numbers; }
		set { numbers = value; }
	}
	public int LimitAmount
	{
		get { return limitAmount; }
		set { limitAmount = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

    public void LimitNumbers() { }

    public Boolean Insert()
    {
        bool result = false;

       
        limitNumbersDAL.PlayTypeID = PlayTypeID;
        limitNumbersDAL.Numbers = Numbers;
        limitNumbersDAL.LimitAmount = LimitAmount;
        limitNumbersDAL.Enabled = Enabled;

        result = limitNumbersDAL.Insert();

        errorCode = limitNumbersDAL.ErrorCode;
        errorDescription = limitNumbersDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        limitNumbersDAL.LimitNumberID = LimitNumberID;
        limitNumbersDAL.PlayTypeID = PlayTypeID;
        limitNumbersDAL.Numbers = Numbers;
        limitNumbersDAL.LimitAmount = LimitAmount;
        limitNumbersDAL.Enabled = Enabled;

        result = limitNumbersDAL.Edit();

        errorCode = limitNumbersDAL.ErrorCode;
        errorDescription = limitNumbersDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        limitNumbersDAL.LimitNumberID = LimitNumberID;

        result = limitNumbersDAL.Delete();

        errorCode = limitNumbersDAL.ErrorCode;
        errorDescription = limitNumbersDAL.ErrorDescription;

        return result;
    }


    public List<LimitNumbersDAL> Search()
    {
        limitNumbersListDAL = new List<LimitNumbersDAL>();

        limitNumbersDAL.clearFields();

        if (LimitNumberID > 0)
            limitNumbersDAL.LimitNumberID = LimitNumberID;
        if (!string.IsNullOrEmpty(Numbers))
            limitNumbersDAL.Numbers = Numbers;
        if (PlayTypeID > 0)
            limitNumbersDAL.PlayTypeID = PlayTypeID;

        limitNumbersListDAL = limitNumbersDAL.Search();

        errorCode = limitNumbersDAL.ErrorCode;
        errorDescription = limitNumbersDAL.ErrorDescription;

        return limitNumbersListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        limitNumbersDAL.LimitNumberID = LimitNumberID;

        if(limitNumbersDAL.GetByKey())
        {
            LimitNumberID = limitNumbersDAL.LimitNumberID;
            PlayTypeID = limitNumbersDAL.PlayTypeID;
            Numbers = limitNumbersDAL.Numbers;
            LimitAmount = limitNumbersDAL.LimitAmount;
            Enabled =  limitNumbersDAL.Enabled;

            result = true;
        }

        errorCode = limitNumbersDAL.ErrorCode;
        errorDescription = limitNumbersDAL.ErrorDescription;

        return result;
    }

    public void clearFields()
    {
        playTypeID = 0;
        limitNumberID = 0;
        numbers = "";
        limitAmount = 0;
        Enabled = false;
    }


}
