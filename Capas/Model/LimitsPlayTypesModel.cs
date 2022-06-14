using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class LimitsPlayTypesModel
{

    LimitsPlayTypesDAL limitsPlayTypesDAL = new LimitsPlayTypesDAL();
    private List<LimitsPlayTypesDAL> limitsPlayTypesListDAL = null;

   

	private int limitPlayTypeID;
	private int playTypeID;
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

    public List<LimitsPlayTypesDAL> LimitsPlayTypesListDAL
    {
        get { return limitsPlayTypesListDAL; }
        set { limitsPlayTypesListDAL = value; }
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

	public int LimitPlayTypeID
	{
		get { return limitPlayTypeID; }
		set { limitPlayTypeID = value; }
	}
	public int PlayTypeID
	{
		get { return playTypeID; }
		set { playTypeID = value; }
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

	public void LimitsPlayTypes(){ }



    public Boolean Insert()
    {
        bool result = false;

        limitsPlayTypesDAL.PlayTypeID = playTypeID;
        limitsPlayTypesDAL.LimitAmount = limitAmount;
        limitsPlayTypesDAL.Enabled = enabled;

       result = limitsPlayTypesDAL.Insert();

       errorCode = limitsPlayTypesDAL.ErrorCode;
       errorDescription = limitsPlayTypesDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        limitsPlayTypesDAL.LimitPlayTypeID = limitPlayTypeID;
        limitsPlayTypesDAL.PlayTypeID = playTypeID;
        limitsPlayTypesDAL.LimitAmount = limitAmount;
        limitsPlayTypesDAL.Enabled = enabled;

        result = limitsPlayTypesDAL.Edit();
        errorCode = limitsPlayTypesDAL.ErrorCode;
        errorDescription = limitsPlayTypesDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        limitsPlayTypesDAL.LimitPlayTypeID = limitPlayTypeID;

        result = limitsPlayTypesDAL.Delete();

        errorCode = limitsPlayTypesDAL.ErrorCode;
        errorDescription = limitsPlayTypesDAL.ErrorDescription;

        return result;
    }


    public List<LimitsPlayTypesDAL> Search()
    {
        limitsPlayTypesListDAL = new List<LimitsPlayTypesDAL>();

        limitsPlayTypesDAL.clearFields();

        if (LimitPlayTypeID > 0)
            limitsPlayTypesDAL.LimitPlayTypeID = LimitPlayTypeID;
        if (PlayTypeID > 0)
            limitsPlayTypesDAL.PlayTypeID = PlayTypeID;

        limitsPlayTypesListDAL = limitsPlayTypesDAL.Search();

        errorCode = limitsPlayTypesDAL.ErrorCode;
        errorDescription = limitsPlayTypesDAL.ErrorDescription;

        return limitsPlayTypesListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        limitsPlayTypesDAL.LimitPlayTypeID = limitPlayTypeID;

        if (limitsPlayTypesDAL.GetByKey()) 
        {
            limitPlayTypeID = limitsPlayTypesDAL.LimitPlayTypeID;
            playTypeID = limitsPlayTypesDAL.PlayTypeID;
            limitAmount = limitsPlayTypesDAL.LimitAmount;
            enabled = limitsPlayTypesDAL.Enabled;

            result = true;
        }

        errorCode = limitsPlayTypesDAL.ErrorCode;
        errorDescription = limitsPlayTypesDAL.ErrorDescription;

        return result;
    }

    public void clearFields()
    {
        LimitPlayTypeID = 0;
        playTypeID = 0;
        limitAmount = 0;
        Enabled = false;
    }
}
