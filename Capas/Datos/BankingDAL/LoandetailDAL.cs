using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDAL
{
    public class LoandetailDAL
    {
        Connection dbm = new Connection();
        public string errorDescription = string.Empty;
        LoandetailDAL loandetailDAL;

        private long loanDetailID;
        private long loanID;
        private int quotaNumber;
        private decimal amouint;
        private decimal dueAmount;
        private DateTime date;
        private string status;

        public long LoanDetailID
        {
            get { return loanDetailID; }
            set { loanDetailID = value; }
        }
        public long LoanID
        {
            get { return loanID; }
            set { loanID = value; }
        }
        public int QuotaNumber
        {
            get { return quotaNumber; }
            set { quotaNumber = value; }
        }
        public decimal Amouint
        {
            get { return amouint; }
            set { amouint = value; }
        }
        public decimal DueAmount
        {
            get { return dueAmount; }
            set { dueAmount = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public LoandetailDAL() { }

        public Boolean Insert()
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("LoanDetailInsert", con);
                parametros = cmd.Parameters.Add("@LoanID", SqlDbType.BigInt);
                parametros.Value = LoanID;
                parametros = cmd.Parameters.Add("@QuotaNumber", SqlDbType.Int);
                parametros.Value = QuotaNumber;
                parametros = cmd.Parameters.Add("@Amouint", SqlDbType.Decimal);
                parametros.Value = Amouint;
                parametros = cmd.Parameters.Add("@DueAmount", SqlDbType.Decimal);
                parametros.Value = DueAmount;
                parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                parametros.Value = Date;
                parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                parametros.Value = Status;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
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
                SqlCommand cmd = new SqlCommand("LoanDetailUpdate", con);
                parametros = cmd.Parameters.Add("@LoanDetailID", SqlDbType.BigInt);
                parametros.Value = LoanDetailID;
                parametros = cmd.Parameters.Add("@LoanID", SqlDbType.BigInt);
                parametros.Value = LoanID;
                parametros = cmd.Parameters.Add("@QuotaNumber", SqlDbType.Int);
                parametros.Value = QuotaNumber;
                parametros = cmd.Parameters.Add("@Amouint", SqlDbType.Decimal);
                parametros.Value = Amouint;
                parametros = cmd.Parameters.Add("@DueAmount", SqlDbType.Decimal);
                parametros.Value = DueAmount;
                parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                parametros.Value = Date;
                parametros = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                parametros.Value = Status;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Delete(long LoanDetailID)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("LoanDetailDelete", con);
                parametros = cmd.Parameters.Add("@LoanDetailID", SqlDbType.BigInt);
                parametros.Value = LoanDetailID;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public List<LoandetailDAL> Search()
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            SqlDataReader dr = null;
            List<LoandetailDAL> loandetailList = new List<LoandetailDAL>();
            try
            {
                con = dbm.getConexion();
                con.Open();
                SqlCommand cmd = new SqlCommand("LoanDetailSearch", con);

                parametros = cmd.Parameters.Add("@LoanID", SqlDbType.BigInt);
                parametros.Value = LoanID;

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        loandetailDAL = new LoandetailDAL();
                        loandetailDAL.LoanDetailID = dr.GetInt64(dr.GetOrdinal("LoanDetailID"));
                        loandetailDAL.LoanID = dr.GetInt64(dr.GetOrdinal("LoanID"));
                        loandetailDAL.QuotaNumber = dr.GetInt32(dr.GetOrdinal("QuotaNumber"));
                        loandetailDAL.Amouint = dr.GetDecimal(dr.GetOrdinal("Amouint"));
                        loandetailDAL.DueAmount = dr.GetDecimal(dr.GetOrdinal("DueAmount"));
                        loandetailDAL.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                        loandetailDAL.Status = dr.GetString(dr.GetOrdinal("Status"));
                        loandetailList.Add(loandetailDAL);
                    }
                }
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return loandetailList;
        }



    }
}
