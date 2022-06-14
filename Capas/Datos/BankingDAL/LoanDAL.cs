using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDAL
{
    public class LoanDAL
    {
        Connection dbm = new Connection();
        public string errorDescription = string.Empty;
        LoanDAL loanDAL;

        private long loanID;
        private int employeeID;
        private DateTime date;
        private decimal totalAmount;
        private decimal dueAmount;
        private string status;
        private string userCreate;
        private string frecuencia;
        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public string Frecuencia
        {
            get { return frecuencia; }
            set { frecuencia = value; }
        }

        public long LoanID
        {
            get { return loanID; }
            set { loanID = value; }
        }
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        public decimal DueAmount
        {
            get { return dueAmount; }
            set { dueAmount = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string UserCreate
        {
            get { return userCreate; }
            set { userCreate = value; }
        }

        public LoanDAL() { }

        public Boolean Insert()
        {
            SqlConnection con = new SqlConnection();
            SqlDataReader dr = null;
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("LoanInsert", con);
                parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                parametros.Value = EmployeeID;
                parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                parametros.Value = Date;
                parametros = cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                parametros.Value = TotalAmount;
                parametros = cmd.Parameters.Add("@DueAmount", SqlDbType.Decimal);
                parametros.Value = DueAmount;
                parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                parametros.Value = Status;
                parametros = cmd.Parameters.Add("@UserCreate", SqlDbType.VarChar);
                parametros.Value = UserCreate;
                parametros = cmd.Parameters.Add("@Frecuencia", SqlDbType.VarChar);
                parametros.Value = Frecuencia;
                cmd.CommandType = CommandType.StoredProcedure;
               dr = cmd.ExecuteReader();
               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       LoanID = dr.GetInt64(dr.GetOrdinal("LoanID"));
                       res = true;
                   }
               }
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Edit()
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("LoanUpdate", con);
                parametros = cmd.Parameters.Add("@LoanID", SqlDbType.BigInt);
                parametros.Value = LoanID;
                parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                parametros.Value = EmployeeID;
                parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                parametros.Value = Date;
                parametros = cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                parametros.Value = TotalAmount;
                parametros = cmd.Parameters.Add("@DueAmount", SqlDbType.Decimal);
                parametros.Value = DueAmount;
                parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                parametros.Value = Status;
                parametros = cmd.Parameters.Add("@UserCreate", SqlDbType.VarChar);
                parametros.Value = UserCreate;
                parametros = cmd.Parameters.Add("@Frecuencia", SqlDbType.VarChar);
                parametros.Value = Frecuencia;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Delete(long LoanID)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("LoanDelete", con);
                parametros = cmd.Parameters.Add("@LoanID", SqlDbType.BigInt);
                parametros.Value = LoanID;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public List<LoanDAL> Search()
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            SqlDataReader dr = null;
            List<LoanDAL> loanList = new List<LoanDAL>();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("LoanSearch", con);

                if (LoanID > 0)
                {
                    parametros = cmd.Parameters.Add("@LoanID", SqlDbType.BigInt);
                    parametros.Value = LoanID;
                }

                if (!string.IsNullOrEmpty(EmployeeName))
                {
                    parametros = cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar);
                    parametros.Value = EmployeeName;
                }
                if (EmployeeID > 0)
                {
                    parametros = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                    parametros.Value = EmployeeID;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        loanDAL = new LoanDAL();
                        loanDAL.LoanID = dr.GetInt64(dr.GetOrdinal("LoanID"));
                        loanDAL.EmployeeID = dr.GetInt32(dr.GetOrdinal("EmployeeID"));
                        loanDAL.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                        loanDAL.TotalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                        loanDAL.DueAmount = dr.GetDecimal(dr.GetOrdinal("DueAmount"));
                        loanDAL.Status = dr.GetString(dr.GetOrdinal("Status"));
                        loanDAL.UserCreate = dr.GetString(dr.GetOrdinal("UserCreate"));
                        loanDAL.Frecuencia = dr.GetString(dr.GetOrdinal("Frecuencia"));
                        loanDAL.EmployeeName = dr.GetString(dr.GetOrdinal("EmployeeName"));
                        loanList.Add(loanDAL);
                    }
                }
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return loanList;
        }


    }
}
