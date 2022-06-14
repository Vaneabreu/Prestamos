using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BankingDAL;

public class EmailConfiguratonDAL
{
	 Connection dbm = new Connection();
     EmailConfiguratonDAL emailConfiguratonDAL = null;
     List<EmailConfiguratonDAL> emailConfiguratonList = null;

     public List<EmailConfiguratonDAL> EmailConfiguratonList
     {
         get { return emailConfiguratonList; }
         set { emailConfiguratonList = value; }
     }

	private int iD;
	private string emailFrom;
	private string smtp;
	private string port;
	private bool ssl;
	private string mailUser;
	private string mailPass;

	public int ID
	{
		get { return iD; }
		set { iD = value; }
	}
	public string EmailFrom
	{
		get { return emailFrom; }
		set { emailFrom = value; }
	}
	public string Smtp
	{
		get { return smtp; }
		set { smtp = value; }
	}
	public string Port
	{
		get { return port; }
		set { port = value; }
	}
	public bool Ssl
	{
		get { return ssl; }
		set { ssl = value; }
	}
	public string MailUser
	{
		get { return mailUser; }
		set { mailUser = value; }
	}
	public string MailPass
	{
		get { return mailPass; }
		set { mailPass = value; }
	}

	public EmailConfiguratonDAL(){ }

	public List<EmailConfiguratonDAL> Search()
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		SqlDataReader dr = null;
		emailConfiguratonList = new List<EmailConfiguratonDAL>();
		try
		{
			con = dbm.getConexion();
			con.Open();
			SqlCommand cmd = new SqlCommand("EmailConfiguratonSearch", con);
			cmd.CommandType = CommandType.StoredProcedure;
			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
					while (dr.Read())
					{
						emailConfiguratonDAL = new EmailConfiguratonDAL();
                        emailConfiguratonDAL.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                        emailConfiguratonDAL.emailFrom = dr.GetString(dr.GetOrdinal("EmailFrom"));
                        emailConfiguratonDAL.smtp = dr.GetString(dr.GetOrdinal("Smtp"));
                        emailConfiguratonDAL.port = dr.GetString(dr.GetOrdinal("Port"));
                        emailConfiguratonDAL.mailUser = dr.GetString(dr.GetOrdinal("MailUser"));
                        emailConfiguratonDAL.mailPass = dr.GetString(dr.GetOrdinal("MailPass"));
                        emailConfiguratonDAL.ssl = dr.GetBoolean(dr.GetOrdinal("Ssl"));
                        emailConfiguratonList.Add(emailConfiguratonDAL);
                        
				    }
			}
			con.Close();
		}
		catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
		catch (Exception e) { Console.WriteLine("Error :" + e.Message); }

		 return emailConfiguratonList;
	}


}
