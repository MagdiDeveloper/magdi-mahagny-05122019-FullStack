using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Tools.Logger;
using WeatherApp.DAL.Bases;
using WeatherApp.Tools;

namespace WeatherApp.DAL.Database
{
    public class DatabaseProvider<Response> : IDataProvider<SqlCommand, Response> where Response : new()
    {
        SqlConnection conn = null;
        public DatabaseProvider()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["WeatherApp"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        public List<Response> Get(SqlCommand cmd)
        {
            List<Response> response = new List<Response>();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = cmd.CommandText;
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Response item = new Response();
                        response.Add(item.ConvertDataRowToItem(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return response;

        }
        public bool Insert(SqlCommand cmd)
        {
            bool result = false;
            try
            {
                if (cmd.Parameters.Count == 0)
                {
                    throw new Exception("SqlParameter cannot be empty!");
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = cmd.CommandText;
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public bool Remove(SqlCommand cmd)
        {
            bool result = false;
            try
            {
                if (cmd.Parameters.Count == 0)
                {
                    throw new Exception("SqlParameter cannot be empty!");
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = cmd.CommandText;
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
