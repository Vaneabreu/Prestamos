using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace LoansDAL
{
    public class Connection
    {

        public string User { get; set; }
        public string Password { get; set; }
        public string DataSource { get; set; }
        public string DataBase { get; set; }

        public SqlConnection getConexion(Connection connection)
        {
            //connection.DataSource = "198.23.207.113";
            connection.User = ConfigurationManager.AppSettings["DbMasterUser"];//"sa";
            connection.Password = ConfigurationManager.AppSettings["DbMasterPass"];//"Gsoft0525";
            //connection.DataBase = Global.Instance().DataBaseName;//"BankingMobilePruebaVictor";
            string conexionString = ConfigurationManager.ConnectionStrings["Loans"].
                ConnectionString.Replace("@DataBase@", connection.DataBase).
                Replace("@DataSource@", connection.DataSource).
                Replace("@User@", connection.User).
                Replace("@Password@", connection.Password);

            SqlConnection conn = new SqlConnection(conexionString);

            return conn;
        }
    }
}

