using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class PlayTypesModel
{

    PlayTypesDAL playTypesDAL = new PlayTypesDAL();
    private List<PlayTypesDAL> playTypesListDAL = null;

 

	private int playTypeID;
	private int lotteryID;
	private int customerID;
	private string name;
	private decimal commissionPercent;
	private decimal partnerCommissionPercent;
	private bool enabled;
    private string shiftName;

    public string ShiftName
    {
        get { return shiftName; }
        set { shiftName = value; }
    }

    private int errorCode;
    private string errorDescription;

    public List<PlayTypesDAL> PlayTypesListDAL
    {
        get { return playTypesListDAL; }
        set { playTypesListDAL = value; }
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

	public int PlayTypeID
	{
		get { return playTypeID; }
		set { playTypeID = value; }
	}
	public int LotteryID
	{
		get { return lotteryID; }
		set { lotteryID = value; }
	}
	public int CustomerID
	{
		get { return customerID; }
		set { customerID = value; }
	}
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public decimal CommissionPercent
	{
		get { return commissionPercent; }
		set { commissionPercent = value; }
	}
	public decimal PartnerCommissionPercent
	{
		get { return partnerCommissionPercent; }
		set { partnerCommissionPercent = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void PlayTypes(){ }

    public Boolean Insert()
    {
        bool result = false;

        playTypesDAL.LotteryID = LotteryID;
        playTypesDAL.CustomerID = CustomerID;
        playTypesDAL.Name = Name;
        playTypesDAL.CommissionPercent = CommissionPercent;
        playTypesDAL.PartnerCommissionPercent = PartnerCommissionPercent;
        playTypesDAL.Enabled = Enabled;

        result = playTypesDAL.Insert();

        errorCode = playTypesDAL.ErrorCode;
        errorDescription = playTypesDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        playTypesDAL.PlayTypeID = PlayTypeID;
        playTypesDAL.LotteryID = LotteryID;
        playTypesDAL.CustomerID = CustomerID;
        playTypesDAL.Name = Name;
        playTypesDAL.CommissionPercent = CommissionPercent;
        playTypesDAL.PartnerCommissionPercent = PartnerCommissionPercent;
        playTypesDAL.Enabled = Enabled;

        result = playTypesDAL.Edit();

        errorCode = playTypesDAL.ErrorCode;
        errorDescription = playTypesDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        playTypesDAL.PlayTypeID = PlayTypeID;

        result = playTypesDAL.Delete();

        errorCode = playTypesDAL.ErrorCode;
        errorDescription = playTypesDAL.ErrorDescription;

        return result;
    }


    public List<PlayTypesDAL> Search()
    {
        playTypesListDAL = new List<PlayTypesDAL>();

        if (playTypeID > 0)
            playTypesDAL.PlayTypeID = PlayTypeID;
        if (!string.IsNullOrEmpty(Name))
            playTypesDAL.Name = Name;
        if (CustomerID > 0)
            playTypesDAL.CustomerID = CustomerID;
        if (LotteryID > 0)
            playTypesDAL.LotteryID = LotteryID;

        playTypesListDAL = playTypesDAL.Search();

        errorCode = playTypesDAL.ErrorCode;
        errorDescription = playTypesDAL.ErrorDescription;

        return playTypesListDAL;
    }

    public List<PlayTypesDAL> LoadCombo()
    {
        playTypesListDAL = new List<PlayTypesDAL>();

        playTypesListDAL = playTypesDAL.LoadCombo();

        errorCode = playTypesDAL.ErrorCode;
        errorDescription = playTypesDAL.ErrorDescription;

        return playTypesListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        playTypesDAL.PlayTypeID = PlayTypeID;

        if (playTypesDAL.GetByKey()) 
        {
           PlayTypeID = playTypesDAL.PlayTypeID ;
           LotteryID = playTypesDAL.LotteryID;
           CustomerID = playTypesDAL.CustomerID;
           Name = playTypesDAL.Name;
           CommissionPercent = playTypesDAL.CommissionPercent;
           PartnerCommissionPercent = playTypesDAL.PartnerCommissionPercent;
           Enabled = playTypesDAL.Enabled;

           result = true;
        }

        errorCode = playTypesDAL.ErrorCode;
        errorDescription = playTypesDAL.ErrorDescription;

        return result;
    }

    public void clearFields()
    {
        playTypeID = 0;
        lotteryID = 0;
        CustomerID = 0;
        Name = "";
        CommissionPercent = 0;
        PartnerCommissionPercent = 0;
        Enabled = false;
    }

}
