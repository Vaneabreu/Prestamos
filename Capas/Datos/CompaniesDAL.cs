using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class CompaniesDAL
{
	Connection dbm = new Connection();
    CompaniesDAL companiesDAL = null;

    private int companyID;
    private string name;
    private string description;
    private decimal commissionPercent;
    private decimal partnerCommissionPercent;
    private string imageName;
    private bool enabled;

    private string errorDescription = "successful";
    private int errorCode = 0;

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
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("CompaniesInsert", con);
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
            parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
			parametros.Value = Description;
            parametros = cmd.Parameters.Add("@CommissionPercent", SqlDbType.Decimal);
			parametros.Value = CommissionPercent;
            parametros = cmd.Parameters.Add("@PartnerCommissionPercent", SqlDbType.Decimal);
			parametros.Value = PartnerCommissionPercent;
            parametros = cmd.Parameters.Add("@ImageName", SqlDbType.VarChar);
			parametros.Value = ImageName;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) 
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
		return res;
	}


	public Boolean Edit()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("CompaniesUpdate", con);
            parametros = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
            parametros.Value = CompanyID;
            parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            parametros.Value = Name;
            parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
            parametros.Value = Description;
            parametros = cmd.Parameters.Add("@CommissionPercent", SqlDbType.Decimal);
            parametros.Value = CommissionPercent;
            parametros = cmd.Parameters.Add("@PartnerCommissionPercent", SqlDbType.Decimal);
            parametros.Value = PartnerCommissionPercent;
            parametros = cmd.Parameters.Add("@ImageName", SqlDbType.VarChar);
            parametros.Value = ImageName;
            parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
            parametros.Value = Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        return res;
	}


	public Boolean Delete()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			con = dbm.getConexion();
			con.Open();
            SqlCommand cmd = new SqlCommand("CompaniesDelete", con);
			parametros = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
			parametros.Value = CompanyID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        return res;
	}


    public List<CompaniesDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<CompaniesDAL> companiesList = new List<CompaniesDAL>();
        try
        {

            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CompaniesSearch", con);

            //if (BranchID > 0)
            //{
            //    parametros = cmd.Parameters.Add("@BranchID", SqlDbType.Int);
            //    parametros.Value = BranchID;
            //}
            //if (!string.IsNullOrEmpty(Name))
            //{
            //    parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            //    parametros.Value = Name;
            //}

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    companiesDAL = new CompaniesDAL();
                    companiesDAL.companyID = dr.GetInt32(dr.GetOrdinal("CompanyID"));
                    companiesDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    companiesDAL.description = dr.GetString(dr.GetOrdinal("Description"));
                    companiesDAL.commissionPercent = dr.GetDecimal(dr.GetOrdinal("CommissionPercent"));
                    companiesDAL.partnerCommissionPercent = dr.GetDecimal(dr.GetOrdinal("PartnerCommissionPercent"));
                    companiesDAL.imageName = dr.GetString(dr.GetOrdinal("ImageName"));
                    companiesDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    companiesList.Add(companiesDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return companiesList;
	}


	public Boolean GetByKey()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CompaniesGetByKey", con);
            parametros = cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
            parametros.Value = CompanyID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                companyID = dr.GetInt32(dr.GetOrdinal("CompanyID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
                description = dr.GetString(dr.GetOrdinal("Description"));
                commissionPercent = dr.GetDecimal(dr.GetOrdinal("CommissionPercent"));
                partnerCommissionPercent = dr.GetDecimal(dr.GetOrdinal("PartnerCommissionPercent"));
                imageName = dr.GetString(dr.GetOrdinal("ImageName"));
                enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));

                res = true;
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
            res = false;
        }

        return res;
	}

    public List<CompaniesDAL> LoadCombo()
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<CompaniesDAL> companiesList = new List<CompaniesDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("CompaniesSearch", con);

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                companiesDAL = new CompaniesDAL();
                companiesDAL.companyID = -1;
                companiesDAL.Name = "-- Seleccione --";
                companiesList.Add(companiesDAL);
                while (dr.Read())
                {
                    companiesDAL = new CompaniesDAL();
                    companiesDAL.companyID = dr.GetInt32(dr.GetOrdinal("CompanyID"));
                    companiesDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    companiesDAL.description = dr.GetString(dr.GetOrdinal("Description"));
                    companiesDAL.commissionPercent = dr.GetDecimal(dr.GetOrdinal("CommissionPercent"));
                    companiesDAL.partnerCommissionPercent = dr.GetDecimal(dr.GetOrdinal("PartnerCommissionPercent"));
                    companiesDAL.imageName = dr.GetString(dr.GetOrdinal("ImageName"));
                    companiesDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    companiesList.Add(companiesDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return companiesList;
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
