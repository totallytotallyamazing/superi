using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for AppData
/// </summary>

namespace Superi.Common
{
	public class AppData
	{
		public static string ConnectionString
		{
			get
			{
				return WebConfigurationManager.ConnectionStrings["AppData"].ToString();
			}
		}

		public static DbDataReader ExecQuery(string SQL)
		{
			SqlConnection _conn;
			string cs = ConnectionString;
			_conn = new SqlConnection(cs);
			_conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, _conn);
			SqlDataReader result = null;
            try
            {
                
                result = cmd.ExecuteReader();
            }
            catch (Exception)
            {
                cmd.Dispose();
                _conn.Close();
            }
            finally
            {
                cmd.Dispose();
                _conn.Close();
                _conn.Dispose();
                cmd = null;
                _conn = null;
            }
			return result;
		}

        public static DataSet ExecDataSet(string ProcedureName, ParameterList Parameters)
        {
            DataSet result = new DataSet();
            SqlConnection _conn;
            string cs = ConnectionString;
            _conn = new SqlConnection(cs);
            _conn.Open();
            SqlCommand cmd = new SqlCommand(ProcedureName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (AppDbParameter parameter in Parameters)
                {
                    cmd.Parameters.Add(parameter.SqlParameter);
                }

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
            }
            catch (Exception)
            {
                cmd.Dispose();
                _conn.Close();
            }
            finally
            {
                cmd.Dispose();
                _conn.Close();
                _conn.Dispose();
                cmd = null;
                _conn = null;
            }
            return result;
        }

		public static DbDataReader ExecStoredProcedure(string ProcedureName, ParameterList Parameters)
		{
			DbDataReader result = null;
		    string cs = ConnectionString;
			SqlConnection _conn = new SqlConnection(cs);
			_conn.Open();
			SqlCommand cmd = new SqlCommand(ProcedureName, _conn);
			cmd.CommandType = CommandType.StoredProcedure;

            if(Parameters!=null)
			    foreach (AppDbParameter parameter in Parameters)
			    {
				    cmd.Parameters.Add(parameter.SqlParameter);
			    }

            try
            {
                result = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                _conn.Close();
                if (HttpContext.Current != null)
                    HttpContext.Current.Response.WriteFile(ex.Message);
            }
            //finally
            //{
            //    cmd.Dispose();
            //    _conn.Close();
            //    _conn.Dispose();
            //    cmd = null;
            //    _conn = null;
            //}
			return result;
		}

        
		public static bool ExecNonQuery(string SQL)
		{
            string cs = ConnectionString;
			bool result = true;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                try
                {
                    
                    if (cmd.ExecuteNonQuery() < 1)
                        result = false;
                }
                catch (Exception e)
                {
                    HttpContext.Current.Response.Write(e.Message);
                    result = false;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    cmd = null;
                }
            }
		    
			///SqlConnection _conn = new SqlConnection(cs);

			//_conn.Close();
			return result;
		}

		public static DataSet GetDataSet(string SQL)
		{
		    DataSet ds = new DataSet();
			string cs = ConnectionString;
			SqlConnection _conn = new SqlConnection(cs);
			_conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, _conn);
            try
            {
                
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch
            {
                _conn.Close();
            }
            finally
            {
                cmd.Dispose();
                _conn.Close();
                _conn.Dispose();
                cmd = null;
                _conn = null;
	        }
		    return ds;
		}
	}
}