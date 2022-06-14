
using Loans.Entity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoansDAL;

public class CustomersDAL
{
	public Connection dbm = new Connection();
    public string errorDescription = string.Empty;
    public bool loanActive = false;
    public int customerID = 0;

	public CustomersDAL(){ }

	public Boolean Insert(CustomersEntity customersEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
        SqlDataReader dr = null;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;
			dbm.DataBase = loginDAL.DataBaseName;
			dbm.User = loginDAL.UserName;
			dbm.Password = loginDAL.UserPassword;

			con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("CustomersInsert", con);
			parametros = cmd.Parameters.Add("@IdentificationType", SqlDbType.VarChar);
            parametros.Value = customersEntity.IdentificationType;
			parametros = cmd.Parameters.Add("@IdentificationNumber", SqlDbType.VarChar);
            parametros.Value = customersEntity.IdentificationNumber;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            parametros.Value = customersEntity.Name;
			parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
            parametros.Value = customersEntity.LastName;
			parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            parametros.Value = customersEntity.Address;
			parametros = cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
            parametros.Value = customersEntity.Phone;
			parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
            parametros.Value = customersEntity.Status;
			parametros = cmd.Parameters.Add("@Age", SqlDbType.Int);
            parametros.Value = customersEntity.Age;
			parametros = cmd.Parameters.Add("@Position", SqlDbType.VarChar);
            parametros.Value = customersEntity.Position;
			parametros = cmd.Parameters.Add("@WorkPlace", SqlDbType.VarChar);
            parametros.Value = customersEntity.WorkPlace;
			parametros = cmd.Parameters.Add("@Salary", SqlDbType.Decimal);
            parametros.Value = customersEntity.Salary;
			parametros = cmd.Parameters.Add("@OtherSalary", SqlDbType.Decimal);
            parametros.Value = customersEntity.OtherSalary;
			parametros = cmd.Parameters.Add("@Dependents", SqlDbType.VarChar);
            parametros.Value = customersEntity.Dependents;
			parametros = cmd.Parameters.Add("@TimeInWork", SqlDbType.VarChar);
            parametros.Value = customersEntity.TimeInWork;
			parametros = cmd.Parameters.Add("@FatherName", SqlDbType.VarChar);
            parametros.Value = customersEntity.FatherName;
			parametros = cmd.Parameters.Add("@MotherName", SqlDbType.VarChar);
            parametros.Value = customersEntity.MotherName;
			parametros = cmd.Parameters.Add("@PersonalReferences", SqlDbType.VarChar);
            parametros.Value = customersEntity.PersonalReferences;
			parametros = cmd.Parameters.Add("@WorkReferences", SqlDbType.VarChar);
            parametros.Value = customersEntity.WorkReferences;
			parametros = cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
            parametros.Value = customersEntity.RegistrationDate;
            parametros = cmd.Parameters.Add("@LateAmount", SqlDbType.Decimal);
            parametros.Value = customersEntity.LateAmount;
            parametros = cmd.Parameters.Add("@AmountType", SqlDbType.VarChar);
            parametros.Value = customersEntity.AmountType;
            parametros = cmd.Parameters.Add("@UserMobileID", SqlDbType.Int);
            parametros.Value = customersEntity.UserMobileID;
            parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
            parametros.Value = customersEntity.RouteID;
            parametros = cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime);
            parametros.Value = customersEntity.BirthDate;
			cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    customerID = dr.GetInt32(dr.GetOrdinal("ID"));
                    res = true;
                }
            }

            con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public Boolean Edit(CustomersEntity customersEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;
			dbm.DataBase = loginDAL.DataBaseName;
			dbm.User = loginDAL.UserName;
			dbm.Password = loginDAL.UserPassword;

			con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("CustomersUpdate", con);
			parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
            parametros.Value = customersEntity.ID;
			parametros = cmd.Parameters.Add("@IdentificationType", SqlDbType.VarChar);
            parametros.Value = customersEntity.IdentificationType;
			parametros = cmd.Parameters.Add("@IdentificationNumber", SqlDbType.VarChar);
            parametros.Value = customersEntity.IdentificationNumber;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            parametros.Value = customersEntity.Name;
			parametros = cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
            parametros.Value = customersEntity.LastName;
			parametros = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            parametros.Value = customersEntity.Address;
			parametros = cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
            parametros.Value = customersEntity.Phone;
			parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
            parametros.Value = customersEntity.Status;
			parametros = cmd.Parameters.Add("@Age", SqlDbType.Int);
            parametros.Value = customersEntity.Age;
			parametros = cmd.Parameters.Add("@Position", SqlDbType.VarChar);
            parametros.Value = customersEntity.Position;
			parametros = cmd.Parameters.Add("@WorkPlace", SqlDbType.VarChar);
            parametros.Value = customersEntity.WorkPlace;
			parametros = cmd.Parameters.Add("@Salary", SqlDbType.Decimal);
            parametros.Value = customersEntity.Salary;
			parametros = cmd.Parameters.Add("@OtherSalary", SqlDbType.Decimal);
            parametros.Value = customersEntity.OtherSalary;
			parametros = cmd.Parameters.Add("@Dependents", SqlDbType.VarChar);
            parametros.Value = customersEntity.Dependents;
			parametros = cmd.Parameters.Add("@TimeInWork", SqlDbType.VarChar);
            parametros.Value = customersEntity.TimeInWork;
			parametros = cmd.Parameters.Add("@FatherName", SqlDbType.VarChar);
            parametros.Value = customersEntity.FatherName;
			parametros = cmd.Parameters.Add("@MotherName", SqlDbType.VarChar);
            parametros.Value = customersEntity.MotherName;
			parametros = cmd.Parameters.Add("@PersonalReferences", SqlDbType.VarChar);
            parametros.Value = customersEntity.PersonalReferences;
			parametros = cmd.Parameters.Add("@WorkReferences", SqlDbType.VarChar);
            parametros.Value = customersEntity.WorkReferences;
			parametros = cmd.Parameters.Add("@RegistrationDate", SqlDbType.DateTime);
            parametros.Value = customersEntity.RegistrationDate;
            parametros = cmd.Parameters.Add("@LateAmount", SqlDbType.Decimal);
            parametros.Value = customersEntity.LateAmount;
            parametros = cmd.Parameters.Add("@AmountType", SqlDbType.VarChar);
            parametros.Value = customersEntity.AmountType;
            parametros = cmd.Parameters.Add("@UserMobileID", SqlDbType.Int);
            parametros.Value = customersEntity.UserMobileID;
            parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
            parametros.Value = customersEntity.RouteID;
            parametros = cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime);
            parametros.Value = customersEntity.BirthDate;

			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public Boolean Delete(int ID, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;
			dbm.DataBase = loginDAL.DataBaseName;
			dbm.User = loginDAL.UserName;
			dbm.Password = loginDAL.UserPassword;

			con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("CustomersDelete", con);
			parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
			parametros.Value = ID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


	public List<CustomersEntity> Search(CustomersEntity customersEntity, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
		List<CustomersEntity> customersList = new List<CustomersEntity>();
		try
		{
			dbm.DataSource = loginDAL.DataSource;
			dbm.DataBase = loginDAL.DataBaseName;
			dbm.User = loginDAL.UserName;
			dbm.Password = loginDAL.UserPassword;

			con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("CustomersSearch", con);
            if (customersEntity.ID > 0)
            {
                parametros = cmd.Parameters.Add("@ID", SqlDbType.Int);
                parametros.Value = customersEntity.ID;
            }

            if (!string.IsNullOrEmpty(customersEntity.Name))
            {
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = customersEntity.Name;
            }
            if (!string.IsNullOrEmpty(customersEntity.IdentificationNumber))
            {
                parametros = cmd.Parameters.Add("@IdentificationNumber", SqlDbType.VarChar);
                parametros.Value = customersEntity.IdentificationNumber;
            }
			cmd.CommandType = CommandType.StoredProcedure;
			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
					while (dr.Read())
					{
						customersEntity = new CustomersEntity();
						customersEntity.ID = dr.GetInt32(dr.GetOrdinal("ID"));
						customersEntity.IdentificationType = dr.GetString(dr.GetOrdinal("IdentificationType"));
						customersEntity.IdentificationNumber = dr.GetString(dr.GetOrdinal("IdentificationNumber"));
						customersEntity.Name = dr.GetString(dr.GetOrdinal("Name"));
						customersEntity.LastName = dr.GetString(dr.GetOrdinal("LastName"));
						customersEntity.Address = dr.GetString(dr.GetOrdinal("Address"));
						customersEntity.Phone = dr.GetString(dr.GetOrdinal("Phone"));
						customersEntity.Status = dr.GetString(dr.GetOrdinal("Status"));
						customersEntity.Age = dr.GetInt32(dr.GetOrdinal("Age"));
						customersEntity.Position = dr.GetString(dr.GetOrdinal("Position"));
						customersEntity.WorkPlace = dr.GetString(dr.GetOrdinal("WorkPlace"));
						customersEntity.Salary = dr.GetDecimal(dr.GetOrdinal("Salary"));
						customersEntity.OtherSalary = dr.GetDecimal(dr.GetOrdinal("OtherSalary"));
						customersEntity.Dependents = dr.GetString(dr.GetOrdinal("Dependents"));
						customersEntity.TimeInWork = dr.GetString(dr.GetOrdinal("TimeInWork"));
						customersEntity.FatherName = dr.GetString(dr.GetOrdinal("FatherName"));
						customersEntity.MotherName = dr.GetString(dr.GetOrdinal("MotherName"));
						customersEntity.PersonalReferences = dr.GetString(dr.GetOrdinal("PersonalReferences"));
						customersEntity.WorkReferences = dr.GetString(dr.GetOrdinal("WorkReferences"));
						customersEntity.RegistrationDate = dr.GetDateTime(dr.GetOrdinal("RegistrationDate"));
                        customersEntity.LoanActive = dr.GetBoolean(dr.GetOrdinal("LoanActive"));
                        customersEntity.LateAmount = dr.GetDecimal(dr.GetOrdinal("LateAmount"));
                        customersEntity.AmountType = dr.GetString(dr.GetOrdinal("AmountType"));

                        customersEntity.UserMobileID = dr.GetInt32(dr.GetOrdinal("UserMobileID"));
                        customersEntity.UserMobileName = dr.GetString(dr.GetOrdinal("UserMobileName"));
                        customersEntity.EmployeeName = dr.GetString(dr.GetOrdinal("EmployeeName"));
                        customersEntity.RouteID = dr.GetInt32(dr.GetOrdinal("RouteID"));
                        customersEntity.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
                        customersEntity.PendingCount = dr.GetInt32(dr.GetOrdinal("PendingCount"));
                        customersEntity.PayCount = dr.GetInt32(dr.GetOrdinal("PayCount"));
						customersList.Add(customersEntity); 
						}
			}
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		 return customersList;
	}


}
