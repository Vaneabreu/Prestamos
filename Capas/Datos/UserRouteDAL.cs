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
    public class UserRouteDAL
    {
        public Connection dbm = new Connection();
        public string errorDescription = string.Empty;

      

        public UserRouteDAL() { }

        public Boolean Insert(UserrouteEntity userrouteEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("UserRouteInsert", con);
                parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
                parametros.Value = userrouteEntity.UserID;
                parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                parametros.Value = userrouteEntity.RouteID;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Edit(UserrouteEntity userrouteEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            Boolean res = false;
            try
            {
                dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("UserRouteUpdate", con);
                parametros = cmd.Parameters.Add("@UserRouteID", SqlDbType.BigInt);
                parametros.Value = userrouteEntity.UserRouteID;
                parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
                parametros.Value = userrouteEntity.UserID;
                parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                parametros.Value = userrouteEntity.RouteID;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    res = true;
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return res;
        }


        public Boolean Delete(long id, LoginDAL loginDAL)
	{
		SqlConnection con = new SqlConnection();
		SqlParameter parametros;
		Boolean res = false;
		try
		{
			dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
			con.Open();
			SqlCommand cmd = new SqlCommand("UserRouteDelete", con);
			parametros = cmd.Parameters.Add("@UserRouteID", SqlDbType.BigInt);
            parametros.Value = id;
			cmd.CommandType = CommandType.StoredProcedure;
			if (cmd.ExecuteNonQuery() > 0)
				res = true;
			con.Close();
		}
		catch (Exception e) { errorDescription = e.Message; }
		return res;
	}


        public List<UserrouteEntity> Search(UserrouteEntity userrouteEntity, LoginDAL loginDAL)
        {
            SqlConnection con = new SqlConnection();
            SqlParameter parametros;
            SqlDataReader dr = null;
            List<UserrouteEntity> userrouteList = new List<UserrouteEntity>();
            try
            {
                dbm.DataSource = loginDAL.DataSource;dbm.DataBase = loginDAL.DataBaseName;dbm.User = loginDAL.UserName; dbm.Password = loginDAL.UserPassword; con = dbm.getConexion(dbm);
                con.Open();
                SqlCommand cmd = new SqlCommand("UserRouteSearch", con);

                if (userrouteEntity.UserID > 0) 
                {
                    parametros = cmd.Parameters.Add("@UserID", SqlDbType.Int);
                    parametros.Value = userrouteEntity.UserID;
                }
                if (userrouteEntity.RouteID > 0)
                {
                    parametros = cmd.Parameters.Add("@RouteID", SqlDbType.Int);
                    parametros.Value = userrouteEntity.RouteID;
                }

                     

                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        userrouteEntity = new UserrouteEntity();
                        userrouteEntity.UserRouteID = dr.GetInt64(dr.GetOrdinal("UserRouteID"));
                        userrouteEntity.UserID = dr.GetInt32(dr.GetOrdinal("UserID"));
                        userrouteEntity.RouteID = dr.GetInt32(dr.GetOrdinal("RouteID"));
                        userrouteEntity.RouteName = dr.GetString(dr.GetOrdinal("RouteName"));
                        userrouteEntity.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                        userrouteList.Add(userrouteEntity);
                    }
                }
                con.Close();
            }
            catch (Exception e) { errorDescription = e.Message; }
            return userrouteList;
        }


    }

}
