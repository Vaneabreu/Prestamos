using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;
using BankingDAL;

public class CompaniesModel
{

    CompaniesDAL companiesDAL = new CompaniesDAL();
    private List<CompaniesDAL> companiesListDAL = null;

    private int companyID;
    private string name;
    private string description;
    private decimal commissionPercent;
    private decimal partnerCommissionPercent;
    private string imageName;
    private bool enabled;

    private string errorDescription = "successful";
    private int errorCode = 0;

    public List<CompaniesDAL> CompaniesListDAL
    {
        get { return companiesListDAL; }
        set { companiesListDAL = value; }
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

    public bool Enabled
    {
        get { return enabled; }
        set { enabled = value; }
    }

    public string ImageName
    {
        get { return imageName; }
        set { imageName = value; }
    }

    public decimal PartnerCommissionPercent
    {
        get { return partnerCommissionPercent; }
        set { partnerCommissionPercent = value; }
    }

    public decimal CommissionPercent
    {
        get { return commissionPercent; }
        set { commissionPercent = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int CompanyID
    {
        get { return companyID; }
        set { companyID = value; }
    }


	public Boolean Insert()
	{
        bool result = false;
         companiesDAL.Name = Name;
         companiesDAL.Description = Description;
         companiesDAL.CommissionPercent = CommissionPercent;
         companiesDAL.PartnerCommissionPercent = PartnerCommissionPercent;
         companiesDAL.ImageName = ImageName;
         companiesDAL.Enabled = Enabled;

         result = companiesDAL.Insert();

         errorCode = companiesDAL.ErrorCode;
         errorDescription = companiesDAL.ErrorDescription;

        return result;
	}


	public Boolean Edit()
	{
        bool result = false;

        companiesDAL.CompanyID = CompanyID;
        companiesDAL.Name = Name;
        companiesDAL.Description = Description;
        companiesDAL.CommissionPercent = CommissionPercent;
        companiesDAL.PartnerCommissionPercent = PartnerCommissionPercent;
        companiesDAL.ImageName = ImageName;
        companiesDAL.Enabled = Enabled;

        result = companiesDAL.Edit();

        errorCode = companiesDAL.ErrorCode;
        errorDescription = companiesDAL.ErrorDescription;

        return result;
	}


	public Boolean Delete()
	{
        bool result = false;

        companiesDAL.CompanyID = CompanyID;

        result = companiesDAL.Delete();

        errorCode = companiesDAL.ErrorCode;
        errorDescription = companiesDAL.ErrorDescription;

        return result;
	}


    public List<CompaniesDAL> Search()
	{
        companiesDAL.clearFields();

        //if (BranchID > 0)
        //   companiesDAL.BranchID = BranchID;
        //if (!string.IsNullOrEmpty(Name))
        //    companiesDAL.Name = Name;

        companiesListDAL = new List<CompaniesDAL>();

        companiesListDAL = companiesDAL.Search();

        errorCode = companiesDAL.ErrorCode;
        errorDescription = companiesDAL.ErrorDescription;

        return companiesListDAL;
	}


	public Boolean GetByKey()
	{
        bool result = false;

        companiesDAL.CompanyID = CompanyID;

        if (companiesDAL.GetByKey()) 
        {
            CompanyID = companiesDAL.CompanyID;
            Name = companiesDAL.Name;
            Description = companiesDAL.Description;
            CommissionPercent = companiesDAL.CommissionPercent;
            PartnerCommissionPercent = companiesDAL.PartnerCommissionPercent;
            ImageName = companiesDAL.ImageName;
            Enabled = companiesDAL.Enabled;

            result = true;
        }

        errorCode = companiesDAL.ErrorCode;
        errorDescription = companiesDAL.ErrorDescription;

        return result;
	}

    public List<CompaniesDAL> LoadCombo()
    {

        companiesListDAL = new List<CompaniesDAL>();

        companiesListDAL = companiesDAL.LoadCombo();

        errorCode = companiesDAL.ErrorCode;
        errorDescription = companiesDAL.ErrorDescription;

        return companiesListDAL;
    }

    public void clearFields()
    {
        CompanyID = 0;
        Name = "";
        Description = "";
        commissionPercent = 0;
        PartnerCommissionPercent = 0;
        ImageName = "";
        Enabled = false;
    }

}
