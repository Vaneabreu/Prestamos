using Loans.Entity;
using LoansDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.DAL
{
    public class RoutesDAL
    {
       public Connection dbm = new Connection();
        public string errorDescription = string.Empty;

       

        public RoutesDAL() { }

        public Boolean Insert(RoutesEntity routesEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                dbm.DataSource = loginDAL.DataSource;
                dbm.DataBase = loginDAL.DataBaseName;
                dbm.User = loginDAL.UserName;
                dbm.Password = loginDAL.UserPassword;
                con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("RoutesInsert", con);
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = routesEntity.Name;
                parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
                parametros.Value = routesEntity.Description;
                parametros = cmd.Parameters.Add("@Status", SqlDbType.Bit);
                parametros.Value = routesEntity.Status;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Edit(RoutesEntity routesEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                dbm.DataSource = loginDAL.DataSource;
                dbm.DataBase = loginDAL.DataBaseName;
                dbm.User = loginDAL.UserName;
                dbm.Password = loginDAL.UserPassword;
                con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("RoutesUpdate", con);
                parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                parametros.Value = routesEntity.RouteID;
                parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                parametros.Value = routesEntity.Name;
                parametros = cmd.Parameters.Add("@Description", SqlDbType.VarChar);
                parametros.Value = routesEntity.Description;
                parametros = cmd.Parameters.Add("@Status", SqlDbType.Bit);
                parametros.Value = routesEntity.Status;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Delete(int RouteID, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                dbm.DataSource = loginDAL.DataSource;
                dbm.DataBase = loginDAL.DataBaseName;
                dbm.User = loginDAL.UserName;
                dbm.Password = loginDAL.UserPassword;
                con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("RoutesDelete", con);
                parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                parametros.Value = RouteID;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public List<RoutesEntity> Search(RoutesEntity routesEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            SqlDataReader dr = null;
            List<RoutesEntity> routesList = new List<RoutesEntity>();
            try
            {
                dbm.DataSource = loginDAL.DataSource;
                dbm.DataBase = loginDAL.DataBaseName;
                dbm.User = loginDAL.UserName;
                dbm.Password = loginDAL.UserPassword;
                con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("RoutesSearch", con);

                if (routesEntity.RouteID>0)
                {
                    parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                    parametros.Value = routesEntity.RouteID;
                }

                if (!string.IsNullOrEmpty(routesEntity.Name)) 
                {
                    parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                    parametros.Value = routesEntity.Name;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        routesEntity = new RoutesEntity();
                        routesEntity.RouteID = dr.GetInt32(dr.GetOrdinal("RouteID"));
                        routesEntity.Name = dr.GetString(dr.GetOrdinal("Name"));
                        routesEntity.Description = dr.GetString(dr.GetOrdinal("Description"));
                        routesEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                        routesList.Add(routesEntity);
                    }
                }
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return routesList;
        }

        public List<RoutesEntity> LoadCombo(RoutesEntity routesEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            SqlDataReader dr = null;
            List<RoutesEntity> routesList = new List<RoutesEntity>();
            try
            {
                dbm.DataSource = loginDAL.DataSource;
                dbm.DataBase = loginDAL.DataBaseName;
                dbm.User = loginDAL.UserName;
                dbm.Password = loginDAL.UserPassword;
                con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("RoutesSearch", con);

                if (!string.IsNullOrEmpty(routesEntity.Name))
                {
                    parametros = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                    parametros.Value = routesEntity.Name;
                }

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    routesEntity = new RoutesEntity();
                    routesEntity.RouteID = -1;
                    routesEntity.Name = "--- Todos ---";
                    routesList.Add(routesEntity);
                    while (dr.Read())
                    {
                        routesEntity = new RoutesEntity();
                        routesEntity.RouteID = dr.GetInt32(dr.GetOrdinal("RouteID"));
                        routesEntity.Name = dr.GetString(dr.GetOrdinal("Name"));
                        routesEntity.Description = dr.GetString(dr.GetOrdinal("Description"));
                        routesEntity.Status = dr.GetBoolean(dr.GetOrdinal("Status"));
                        routesList.Add(routesEntity);
                    }
                }
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return routesList;
        }


    }

}
