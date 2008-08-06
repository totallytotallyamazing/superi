using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for AppData
/// </summary>

namespace Superi.Common
{
	public class AppData1
	{
		public static string ConnectionString
		{
			get
			{
				return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AppData"].ToString();
			}
		}

		public static DbDataReader ExecQuery(string SQL)
		{
			OdbcConnection _conn = null;
			if (HttpContext.Current.Application["_conn"] == null)
			{
				string cs = ConnectionString;
				_conn = new OdbcConnection(cs);
				_conn.Open();
				HttpContext.Current.Application["_conn"] = _conn;
			}
			_conn = (HttpContext.Current.Application["_conn"] as OdbcConnection);//new OdbcConnection(cs);
			if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
				_conn.Open();
			//_conn.Open();
			while (_conn.State == ConnectionState.Connecting) { }

			OdbcDataReader result = null;
			try
			{
				OdbcCommand cmd = new OdbcCommand(SQL, _conn);
				result = cmd.ExecuteReader();
			}
			catch (Exception)
			{
				_conn.Close();
				_conn.Open();
				OdbcCommand cmd = new OdbcCommand(SQL, _conn);
				result = cmd.ExecuteReader();
			}
			//_conn.Close();
			return result;
		}

		public static DbDataReader ExecStoredProcedure(string ProcedureName, ParameterList Parameters)
		{
			DbDataReader result = null;
			OdbcConnection _conn = null;
			if (HttpContext.Current.Application["_conn"] == null)
			{
				string cs = ConnectionString;
				_conn = new OdbcConnection(cs);
				_conn.Open();
				HttpContext.Current.Application["_conn"] = _conn;
			}
			_conn = (HttpContext.Current.Application["_conn"] as OdbcConnection);//new OdbcConnection(cs);
			if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
				_conn.Open();
			//_conn.Open();
			while (_conn.State == ConnectionState.Connecting) { ;}

			string suffix = "(";

			if (Parameters.Count > 0)
			{
				for (int i = 0; i < Parameters.Count; i++)
				{
					if (i == 0)
						suffix += "?";
					else
						suffix += ",?";
				}
			}
			suffix += ")";

			OdbcCommand cmd = new OdbcCommand("call " + ProcedureName + suffix, _conn);
			cmd.CommandType = CommandType.StoredProcedure;

			foreach (AppDbParameter parameter in Parameters)
			{
				cmd.Parameters.Add(parameter.OdbcParameter);
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
			OdbcConnection _conn = null;
			if (HttpContext.Current.Application["_conn"] == null)
			{
				string cs = ConnectionString;
				_conn = new OdbcConnection(cs);
				_conn.Open();
				HttpContext.Current.Application["_conn"] = _conn;
			}
			_conn = (HttpContext.Current.Application["_conn"] as OdbcConnection);//new OdbcConnection(cs);
			if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
				_conn.Open();
			while (_conn.State == ConnectionState.Connecting) { }
			bool result = true;
			try
			{
				OdbcCommand cmd = new OdbcCommand(SQL, _conn);
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
			//		OdbcConnection _conn = new OdbcConnection(cs);
			//		_conn.Open();
			OdbcConnection _conn = null;
			if (HttpContext.Current.Application["_conn"] == null)
			{
				string cs = ConnectionString;
				_conn = new OdbcConnection(cs);
				_conn.Open();
				HttpContext.Current.Application["_conn"] = _conn;
			}
			_conn = (HttpContext.Current.Application["_conn"] as OdbcConnection);//new OdbcConnection(cs);
			if (_conn.State == ConnectionState.Closed || _conn.State == ConnectionState.Broken)
				_conn.Open();
			while (_conn.State == ConnectionState.Connecting) { }
			try
			{
				OdbcCommand cmd = new OdbcCommand(SQL, _conn);
				OdbcDataAdapter da = new OdbcDataAdapter();
				da.SelectCommand = cmd;
				da.Fill(ds);
			}
			catch (Exception)
			{
			}
			//	_conn.Close();
			return ds;
		}
	}
}