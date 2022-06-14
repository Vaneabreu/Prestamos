using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public class BranchePlayTypeModel
    {
       BranchePlayTypeDAL branchePlayTypeDAL = new BranchePlayTypeDAL();
       List<BranchePlayTypeDAL> branchePlayTypeList = null;

       public List<BranchePlayTypeDAL> BranchePlayTypeList
       {
           get { return branchePlayTypeList; }
           set { branchePlayTypeList = value; }
       }

    private long branchePlayTypeID;
    private int branchID;
    private int playTypeID;
    private decimal percent;
    private string branchName;
    private string playTypeName;
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

    public string BranchName
    {
        get { return branchName; }
        set { branchName = value; }
    }


    private int errorCode = 0;
    private string errorDescription = "successful";

    public string ErrorDescription
    {
        get { return errorDescription; }
        set { errorDescription = value; }
    }

    public int ErrorCode
    {
        get { return errorCode; }
        set { errorCode = value; }
    }

    public long BranchePlayTypeID
    {
        get { return branchePlayTypeID; }
        set { branchePlayTypeID = value; }
    }
    public int BranchID
    {
        get { return branchID; }
        set { branchID = value; }
    }
    public int PlayTypeID
    {
        get { return playTypeID; }
        set { playTypeID = value; }
    }
    public decimal Percent
    {
        get { return percent; }
        set { percent = value; }
    }

	public BranchePlayTypeModel(){ }

	public Boolean Insert()
	{
        bool result = false;

        branchePlayTypeDAL.BranchID = BranchID;
        branchePlayTypeDAL.PlayTypeID = PlayTypeID;
        branchePlayTypeDAL.Percent = Percent;
        branchePlayTypeDAL.BranchName = BranchName;
        branchePlayTypeDAL.PlayTypeName = PlayTypeName;

        result = branchePlayTypeDAL.Insert();

        errorCode = branchePlayTypeDAL.ErrorCode;
        errorDescription = branchePlayTypeDAL.ErrorDescription;

        return result;
	}


	public Boolean Edit()
	{
        bool result = false;

        branchePlayTypeDAL.BranchePlayTypeID = BranchePlayTypeID;
        branchePlayTypeDAL.BranchID = BranchID;
        branchePlayTypeDAL.PlayTypeID = PlayTypeID;
        branchePlayTypeDAL.Percent = Percent;
        branchePlayTypeDAL.BranchName = BranchName;
        branchePlayTypeDAL.PlayTypeName = PlayTypeName;

        result = branchePlayTypeDAL.Edit();

        errorCode = branchePlayTypeDAL.ErrorCode;
        errorDescription = branchePlayTypeDAL.ErrorDescription;

        return result;
	}


	public Boolean Delete()
	{
        bool result = false;

        branchePlayTypeDAL.BranchePlayTypeID = BranchePlayTypeID;

        result = branchePlayTypeDAL.Delete();

        errorCode = branchePlayTypeDAL.ErrorCode;
        errorDescription = branchePlayTypeDAL.ErrorDescription;

        return result;
	}


	public List<BranchePlayTypeDAL> Search()
	{
        branchePlayTypeDAL.clearFields();

        if (BranchID > 0)
            branchePlayTypeDAL.BranchID = BranchID;
        if (PlayTypeID > 0)
            branchePlayTypeDAL.PlayTypeID = PlayTypeID;

        branchePlayTypeList = new List<BranchePlayTypeDAL>();

        branchePlayTypeList = branchePlayTypeDAL.Search();

        errorCode = branchePlayTypeDAL.ErrorCode;
        errorDescription = branchePlayTypeDAL.ErrorDescription;

        return branchePlayTypeList;
	}

    public Boolean GetByKey()
    {
        bool result = false;

        branchePlayTypeDAL.BranchePlayTypeID = BranchePlayTypeID;

        if (branchePlayTypeDAL.GetByKey())
        {
            BranchePlayTypeID = branchePlayTypeDAL.BranchePlayTypeID;
            BranchID = branchePlayTypeDAL.BranchID;
            PlayTypeID = branchePlayTypeDAL.PlayTypeID;
            Percent = branchePlayTypeDAL.Percent;
            BranchName = branchePlayTypeDAL.BranchName;
            PlayTypeName = branchePlayTypeDAL.PlayTypeName;
            LotteryName = branchePlayTypeDAL.LotteryName;
            ShiftName = branchePlayTypeDAL.ShiftName;

            result = true;
        }


        errorCode = branchePlayTypeDAL.ErrorCode;
        errorDescription = branchePlayTypeDAL.ErrorDescription;

        return result;
    }

    }

