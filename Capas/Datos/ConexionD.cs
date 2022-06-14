using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoftLoans.Datos
{
    public class ConexionD
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string DataSource { get; set; }
        public string DataBase { get; set; }

        public SqlConnection getConexion(ConexionD conexionD)
        {
            conexionD.DataSource = ConfigurationManager.AppSettings["DbMasterSource"];// "gsoftsolution.ddns.net";
            conexionD.User = ConfigurationManager.AppSettings["DbMasterUser"]; //"sa";
            conexionD.Password = ConfigurationManager.AppSettings["DbMasterPass"]; //"Gsoft0525";
            conexionD.DataBase = ConfigurationManager.AppSettings["DbMaster"]; //"BankingC";
            string conexionString = ConfigurationManager.ConnectionStrings["Loans"].
                ConnectionString.Replace("@DataBase@", conexionD.DataBase).
                Replace("@DataSource@", conexionD.DataSource).
                Replace("@User@", conexionD.User).
                Replace("@Password@", conexionD.Password);

            SqlConnection conn = new SqlConnection(conexionString);

            return conn;
        }
    }
}