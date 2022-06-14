using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingModel;

public class NotificationsModel
{

    NotificationsDAL notificationsDAL = new NotificationsDAL();
    private List<NotificationsDAL> notificationsListDAL = null;

  

	private int notificationID;
	private string textNotification;
	private DateTime date;
	private bool enabled;

    private int errorCode;
    private string errorDescription;

    public List<NotificationsDAL> NotificationsListDAL
    {
        get { return notificationsListDAL; }
        set { notificationsListDAL = value; }
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
        bool result = false;

        notificationsDAL.TextNotification = TextNotification;
        notificationsDAL.Enabled = Enabled;

       result = notificationsDAL.Insert();

       errorCode = notificationsDAL.ErrorCode;
       errorDescription = notificationsDAL.ErrorDescription;

        return result;
    }


    public Boolean Edit()
    {
        bool result = false;

        notificationsDAL.NotificationID = NotificationID;
        notificationsDAL.TextNotification = TextNotification;
        notificationsDAL.Enabled = Enabled;

        result = notificationsDAL.Edit();

        errorCode = notificationsDAL.ErrorCode;
        errorDescription = notificationsDAL.ErrorDescription;

        return result;
    }


    public Boolean Delete()
    {
        bool result = false;

        notificationsDAL.NotificationID = NotificationID;

        result = notificationsDAL.Delete();

        errorCode = notificationsDAL.ErrorCode;
        errorDescription = notificationsDAL.ErrorDescription;

        return result;
    }


    public List<NotificationsDAL> Search()
    {
        notificationsListDAL = new List<NotificationsDAL>();
        notificationsDAL.clearFields();

        if (NotificationID > 0)
            notificationsDAL.NotificationID = NotificationID;
        if (!string.IsNullOrEmpty(TextNotification))
            notificationsDAL.TextNotification = TextNotification;

        notificationsListDAL = notificationsDAL.Search();

        errorCode = notificationsDAL.ErrorCode;
        errorDescription = notificationsDAL.ErrorDescription;

        return notificationsListDAL;
    }


    public Boolean GetByKey()
    {
        bool result = false;

        notificationsDAL.NotificationID = NotificationID;

        if (notificationsDAL.GetByKey())
        {
            NotificationID = notificationsDAL.NotificationID;
            TextNotification =  notificationsDAL.TextNotification;
            Date = notificationsDAL.Date;
            Enabled = notificationsDAL.Enabled;

            result = true;
        }

        errorCode = notificationsDAL.ErrorCode;
        errorDescription = notificationsDAL.ErrorDescription;

        return result;
    }

    public Boolean GetNotifications()
    {
        bool result = false;

        if (notificationsDAL.GetNotifications())
        {
            NotificationID = notificationsDAL.NotificationID;
            TextNotification = notificationsDAL.TextNotification;

            result = true;
        }

        errorCode = notificationsDAL.ErrorCode;
        errorDescription = notificationsDAL.ErrorDescription;

        return result;
    }

    public void clearFields()
    {
        NotificationID = 0;
        TextNotification = "";
        Enabled = false;
    }
}
