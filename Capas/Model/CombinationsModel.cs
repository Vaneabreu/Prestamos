using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class CombinationsModel
{

    CombinationsDAL combinationsDAL = new CombinationsDAL();
    private List<CombinationsDAL> combinationsListDAL = null;

   

    private int combinationID;
	private int playTypeID;
	private int combination;
	private int gainAmount;
	private bool enabled;
    private string playTypeName;
    private int errorCode;
    private string errorDescription;
    private string lotteryName;
    private string shiftName;

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


    public string PlayTypeName
    {
        get { return playTypeName; }
        set { playTypeName = value; }
    }

    public List<CombinationsDAL> CombinationsListDAL
    {
        get { return combinationsListDAL; }
        set { combinationsListDAL = value; }
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

	public int CombinationID
	{
		get { return combinationID; }
		set { combinationID = value; }
	}
	public int PlayTypeID
	{
		get { return playTypeID; }
		set { playTypeID = value; }
	}
	public int Combination
	{
		get { return combination; }
		set { combination = value; }
	}
	public int GainAmount
	{
		get { return gainAmount; }
		set { gainAmount = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Combinations(){ }

    public Boolean Insert()
    {
        bool result = false;

        combinationsDAL.PlayTypeID = playTypeID;
        combinationsDAL.Combination = combination;
        combinationsDAL.GainAmount = gainAmount;
        combinationsDAL.Enabled = enabled;

        result = combinationsDAL.Insert();

        errorCode = combinationsDAL.ErrorCode;
        errorDescription = combinationsDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

       combinationsDAL.CombinationID = CombinationID;
       combinationsDAL.PlayTypeID = playTypeID;
       combinationsDAL.Combination = combination;
       combinationsDAL.GainAmount = gainAmount ;
       combinationsDAL.Enabled =  enabled;

        result = combinationsDAL.Edit();

        errorCode = combinationsDAL.ErrorCode;
        errorDescription = combinationsDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        combinationsDAL.CombinationID = CombinationID;

       result = combinationsDAL.Delete();

       errorCode = combinationsDAL.ErrorCode;
       errorDescription = combinationsDAL.ErrorDescription;

        return result;
    }


    public List<CombinationsDAL> Search()
    {

        combinationsDAL.clearFields();
        combinationsListDAL = new List<CombinationsDAL>();

    

        if (combinationID > 0)
            combinationsDAL.CombinationID = combinationID;
        if (playTypeID > 0)
            combinationsDAL.PlayTypeID = playTypeID;


        combinationsListDAL = combinationsDAL.Search();

        errorCode = combinationsDAL.ErrorCode;
        errorDescription = combinationsDAL.ErrorDescription;

        return combinationsListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

       combinationsDAL.CombinationID = CombinationID;

        if(combinationsDAL.GetByKey())
        {
            CombinationID = combinationsDAL.CombinationID;
            playTypeID = combinationsDAL.PlayTypeID;
            combination = combinationsDAL.Combination;
            gainAmount = combinationsDAL.GainAmount;
            enabled = combinationsDAL.Enabled;

            result = true;
        }

        errorCode = combinationsDAL.ErrorCode;
        errorDescription = combinationsDAL.ErrorDescription;

        return result;
    }

    public void clearFields()
    {
        CombinationID = 0;
        Combination = 0;
        playTypeID = 0;
        GainAmount = 0;
        Enabled = false;
    }

}
