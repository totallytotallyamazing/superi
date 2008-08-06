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
			if (HttpContext.Current.Application["_conn"] == null)
			{
				string cs = ConnectionString;
				_conn = new SqlConnection(cs);
				_conn.Open();
				HttpContext.Current.Application["_conn"] = _conn;
			}
			_conn = (HttpContext.Current.Application["_conn"] as SqlConnection);//new SqlConnection(cs);
			if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
				_conn.Open();
			//_conn.Open();
			while (_conn.State == ConnectionState.Connecting) { }

			SqlDataReader result;
			try
			{
				SqlCommand cmd = new SqlCommand(SQL, _conn);
				result = cmd.ExecuteReader();
			}
			catch (Exception)
			{
				_conn.Close();
				_conn.Open();
				SqlCommand cmd = new SqlCommand(SQL, _conn);
				result = cmd.ExecuteReader();
			}
			//_conn.Close();
			return result;
		}

		public static DbDataReader ExecStoredProcedure(string ProcedureName, ParameterList Parameters)
		{
			DbDataReader result = null;
			SqlConnection _conn;
			if (HttpContext.Current.Application["_conn"] == null)
			{
				string cs = ConnectionString;
				_conn = new SqlConnection(cs);
				_conn.Open();
				HttpContext.Current.Application["_conn"] = _conn;
			}
			_conn = (HttpContext.Current.Application["_conn"] as SqlConnection);//new SqlConnection(cs);
			if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
				_conn.Open();
			//_conn.Open();
			while (_conn.State == ConnectionState.Connecting) { ;}

			//string suffix = "(";

			//if (Parameters.Count > 0)
			//{
			//    for (int i = 0; i < Parameters.Count; i++)
			//    {
			//        if (i == 0)
			//            suffix += "?";
			//        else
			//            suffix += ",?";
			//    }
			//}
			//suffix += ")";

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
			catch (Exception)
			{
				_conn.Close();
				_conn.Open();
				cmd.ExecuteNonQuery();
			}
			return result;
		}

		public static bool ExecNonQuery(string SQL)
		{
			SqlConnection _conn;
			if (HttpContext.Current.Application["_conn"] == null)
			{
				string cs = ConnectionString;
				_conn = new SqlConnection(cs);
				_conn.Open();
				HttpContext.Current.Application["_conn"] = _conn;
			}
			_conn = (HttpContext.Current.Application["_conn"] as SqlConnection);//new SqlConnection(cs);
			if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
				_conn.Open();
			while (_conn.State == ConnectionState.Connecting) { }
			bool result = true;
			try
			{
				SqlCommand cmd = new SqlCommand(SQL, _conn);
				if (cmd.ExecuteNonQuery() < 1)
					result = false;
			}
			catch (Exception e)
			{
				HttpContext.Current.Response.Write(e.Message);
				result = false;
			}
			//	_conn.Close();
			return result;
		}

		public static DataSet GetDataSet(string SQL)
		{
			DataSet ds = new DataSet();
			//		string cs = ConnectionString;
			//		SqlConnection _conn = new SqlConnection(cs);
			//		_conn.Open();
			SqlConnection _conn;
			if (HttpContext.Current.Application["_conn"] == null)
			{
				string cs = ConnectionString;
				_conn = new SqlConnection(cs);
				_conn.Open();
				HttpContext.Current.Application["_conn"] = _conn;
			}
			_conn = (HttpContext.Current.Application["_conn"] as SqlConnection);//new SqlConnection(cs);
			if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
				_conn.Open();
			while (_conn.State == ConnectionState.Connecting) { }
			try
			{
				SqlCommand cmd = new SqlCommand(SQL, _conn);
				SqlDataAdapter da = new SqlDataAdapter();
				da.SelectCommand = cmd;
				da.Fill(ds);
			}
			catch
			{
			}
			//	_conn.Close();
			return ds;
		}
	}
}