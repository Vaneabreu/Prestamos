using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class ShiftsModel
{
    ShiftsDAL shiftsDAL = new ShiftsDAL();
    private List<ShiftsDAL> ShiftsListDAL = null;

	private int shiftID;
	private string name;
	private bool enabled;

    private int errorCode;
    private string errorDescription;

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

	public int ShiftID
	{
		get { return shiftID; }
		set { shiftID = value; }
	}
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Shifts(){ }

    public Boolean Insert()
    {
        bool result = false;

	    shiftsDAL.Name = Name;
        shiftsDAL.Enabled = Enabled;

        result = shiftsDAL.Insert();

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        shiftsDAL.ShiftID = ShiftID;
        shiftsDAL.Name = Name;
        shiftsDAL.Enabled = Enabled;

        result = shiftsDAL.Edit();

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        shiftsDAL.ShiftID = ShiftID;

        result = shiftsDAL.Delete();

        return result;
    }


    public List<ShiftsDAL> Search()
    {
        ShiftsListDAL = new List<ShiftsDAL>();

        ShiftsListDAL = shiftsDAL.Search();

        errorCode = shiftsDAL.ErrorCode;
        errorDescription = shiftsDAL.ErrorDescription;

        return ShiftsListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        shiftsDAL.ShiftID = ShiftID;

        if (shiftsDAL.GetByKey())
        {
            ShiftID = shiftsDAL.ShiftID ;
            Name = shiftsDAL.Name;
            Enabled = shiftsDAL.Enabled;

            result = true;
        }

        return result;
    }

    public List<ShiftsDAL> LoadCombo()
    {
        ShiftsListDAL = new List<ShiftsDAL>();

        ShiftsListDAL = shiftsDAL.LoadCombo();

        errorCode = shiftsDAL.ErrorCode;
        errorDescription = shiftsDAL.ErrorDescription;

        return ShiftsListDAL;
    }


}
