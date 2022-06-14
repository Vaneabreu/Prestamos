using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BankingDAL
{
    class Connection
    {

        public SqlConnection getConexion() 
        {
            string conexionString = ConfigurationManager.ConnectionStrings["Banking"].ConnectionString.Replace("@USER@","sa").Replace("@PASS@","gsoftsol");
            SqlConnection conn = new SqlConnection(conexionString);

            return conn;
        }
    }
}
