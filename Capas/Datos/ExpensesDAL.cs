using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loans.Entity;
using System.Data.SqlClient;
using System.Data;
using LoansDAL;

namespace Loans.DAL
{
    public class ExpensesDAL
    {
        public Connection dbm = new Connection();
        public string errorDescription = string.Empty;


        public ExpensesDAL() { }

        public Boolean Insert(ExpensesEntity expensesEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("ExpensesInsert", con);
                parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
                parametros.Value = expensesEntity.Description;
                parametros = cmd.Parameters.Add("@Ncf", SqlDbType.VarChar);
                parametros.Value = expensesEntity.Ncf;
                parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                parametros.Value = expensesEntity.Date;
                parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                parametros.Value = expensesEntity.Amount;
                parametros = cmd.Parameters.Add("@Category", SqlDbType.VarChar);
                parametros.Value = expensesEntity.Category;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Edit(ExpensesEntity expensesEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("ExpensesUpdate", con);
                parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                parametros.Value = expensesEntity.ID;
                parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
                parametros.Value = expensesEntity.Description;
                parametros = cmd.Parameters.Add("@Ncf", SqlDbType.VarChar);
                parametros.Value = expensesEntity.Ncf;
                parametros = cmd.Parameters.Add("@Date", SqlDbType.DateTime);
                parametros.Value = expensesEntity.Date;
                parametros = cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                parametros.Value = expensesEntity.Amount;
                parametros = cmd.Parameters.Add("@Category", SqlDbType.VarChar);
                parametros.Value = expensesEntity.Category;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Delete(long ID, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("ExpensesDelete", con);
                parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                parametros.Value = ID;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public List<ExpensesEntity> Search(ExpensesEntity expensesEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            SqlDataReader dr = null;
            List<ExpensesEntity> expensesList = new List<ExpensesEntity>();
            try
            {
                dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("ExpensesSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (expensesEntity.ID <= 0)
                {
                    parametros = cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                    parametros.Value = expensesEntity.StartDate;
                    parametros = cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
                    parametros.Value = expensesEntity.EndDate;
                }
                if (expensesEntity.ID > 0)
                {
                    parametros = cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                    parametros.Value = expensesEntity.ID;
                }

                if (!string.IsNullOrEmpty(expensesEntity.Category))
                {
                    parametros = cmd.Parameters.Add("@Category", SqlDbType.VarChar);
                    parametros.Value = expensesEntity.Category;
                }

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        expensesEntity = new ExpensesEntity();
                        expensesEntity.ID = dr.GetInt64(dr.GetOrdinal("ID"));
                        expensesEntity.Description = dr.GetString(dr.GetOrdinal("Description"));
                        expensesEntity.Ncf = dr.GetString(dr.GetOrdinal("Ncf"));
                        expensesEntity.Date = dr.GetDateTime(dr.GetOrdinal("Date"));
                        expensesEntity.Amount = dr.GetDecimal(dr.GetOrdinal("Amount"));
                        expensesEntity.Category = dr.GetString(dr.GetOrdinal("Category"));
                        expensesList.Add(expensesEntity);
                    }
                }
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return expensesList;
        }
    }
}
