using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class NotificationsDAL
{
    Connection dbm = new Connection();
    NotificationsDAL notificationsDAL = null;

	private int notificationID;
	private string textNotification;
	private DateTime date;
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

	public int NotificationID
	{
		get { return notificationID; }
		set { notificationID = value; }
	}
	public string TextNotification
	{
		get { return textNotification; }
		set { textNotification = value; }
	}
	public DateTime Date
	{
		get { return date; }
		set { date = value; }
	}
	public bool Enabled
	{
		get { return enabled; }
		set { enabled = value; }
	}

	public void Notifications(){ }

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
            SqlCommand cmd = new SqlCommand("NotificationsInsert", con);
			parametros = cmd.Parameters.Add("@TextNotification", SqlDbType.VarChar);
			parametros.Value = TextNotification;
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
            SqlCommand cmd = new SqlCommand("NotificationsUpdate", con);
			parametros = cmd.Parameters.Add("@NotificationID", SqlDbType.Int);
			parametros.Value = NotificationID;
			parametros = cmd.Parameters.Add("@TextNotification", SqlDbType.VarChar);
			parametros.Value = TextNotification;
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
            SqlCommand cmd = new SqlCommand("NotificationsDelete", con);
			parametros = cmd.Parameters.Add("@NotificationID", SqlDbType.Int);
			parametros.Value = NotificationID;
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


    public List<NotificationsDAL> Search()
	{
        ErrorCode = 0;
        ErrorDescription = "Successful";
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        List<NotificationsDAL> notificationsList = new List<NotificationsDAL>();
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("NotificationsSearch", con);

            if (NotificationID > 0)
            {
                parametros = cmd.Parameters.Add("@NotificationID", SqlDbType.Int);
                parametros.Value = NotificationID;
            }
            if (!string.IsNullOrEmpty(TextNotification))
            {
                parametros = cmd.Parameters.Add("@TextNotification", SqlDbType.VarChar);
                parametros.Value = TextNotification;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    notificationsDAL = new NotificationsDAL();
                    notificationsDAL.notificationID = dr.GetInt32(dr.GetOrdinal("NotificationID"));
                    notificationsDAL.textNotification = dr.GetString(dr.GetOrdinal("TextNotification"));
                    notificationsDAL.date = dr.GetDateTime(dr.GetOrdinal("Date"));
                    notificationsDAL.enabled = dr.GetBoolean(dr.GetOrdinal("Enabled"));
                    notificationsList.Add(notificationsDAL);
                }
            }
            con.Close();
        }
        catch (Exception e)
        {
            errorDescription = "Error de SQL :" + e.Message;
            errorCode = 1;
        }

        return notificationsList;
	}


	public Boolean GetByKey()
	{
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("NotificationsGetByKey", con);
            parametros = cmd.Parameters.Add("@NotificationID", SqlDbType.Int);
            parametros.Value = NotificationID;
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                notificationID = dr.GetInt32(dr.GetOrdinal("NotificationID"));
                textNotification = dr.GetString(dr.GetOrdinal("TextNotification"));
                date = dr.GetDateTime(dr.GetOrdinal("Date"));
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

    public Boolean GetNotifications()
    {
        bool res = false;
        SqlConnection con = new SqlConnection();
        SqlParameter parametros;
        SqlDataReader dr = null;
        try
        {
            con = dbm.getConexion();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetNotifications", con);

            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                notificationID = dr.GetInt32(dr.GetOrdinal("NotificationID"));
                textNotification = dr.GetString(dr.GetOrdinal("TextNotification"));

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



    public void clearFields()
    {
        NotificationID = 0;
        TextNotification = "";
        Enabled = false;
    }
}
