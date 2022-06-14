using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using LoansDAL;

public class ShiftsDAL
{
   public Connection dbm = new Connection();
    ShiftsDAL shiftsDAL = null;

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

	public Boolean Insert(LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("spShifts_N", con);
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
        catch (SqlException e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
		return res;
	}


	public Boolean Edit(LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("spShifts_M", con);
			parametros = cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
			parametros.Value = ShiftID;
			parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
			parametros.Value = Name;
			parametros = cmd.Parameters.Add("@Enabled", SqlDbType.Bit);
			parametros.Value = Enabled;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
        catch (SqlException e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
		return res;
	}


	public Boolean Delete(LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("spShifts_E", con);
			parametros = cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
			parametros.Value = ShiftID;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
        catch (SqlException e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 0001;
        }
		return res;
	}


    public List<ShiftsDAL> Search(LoginDAL loginDAL)
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<ShiftsDAL> shiftsList = new List<ShiftsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("ShiftsSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    shiftsDAL = new ShiftsDAL();
                    shiftsDAL.shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                    shiftsDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    shiftsDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    shiftsList.Add(shiftsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return shiftsList;
	}

    public List<ShiftsDAL> LoadCombo(LoginDAL loginDAL)
    {
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<ShiftsDAL> shiftsList = new List<ShiftsDAL>();
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("ShiftsSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                shiftsDAL = new ShiftsDAL();
                shiftsDAL.shiftID = -1;
                shiftsDAL.Name = "-- Seleccione --";
                shiftsList.Add(shiftsDAL);
                while (dr.Read())
                {
                    shiftsDAL = new ShiftsDAL();
                    shiftsDAL.shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                    shiftsDAL.name = dr.GetString(dr.GetOrdinal("Name"));
                    shiftsDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    shiftsList.Add(shiftsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return shiftsList;
    }



	public Boolean GetByKey(LoginDAL loginDAL)
	{
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            dbm.DataSource = loginDAL.DataSource; dbm.DataBase = loginDAL.DataBaseName; dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
            con.Open();
            SqlCommand cmd = new SqlCommand("spShifts_TT", con);
            parametros = cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
            parametros.Value = ShiftID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                shiftID = dr.GetInt32(dr.GetOrdinal("ShiftID"));
                name = dr.GetString(dr.GetOrdinal("Name"));
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


}
