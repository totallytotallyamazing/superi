using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Superi.Common
{
	public class AppDbParameter
	{
		const string ParameterPrefixOdbc = "?";
		const string ParameterPrefixSql = "@";


		private string _Name = "";
		private object _Value = null;
		private bool _IsNullable = true;
		private ParameterDirection _Direction = ParameterDirection.Input;
	//	private OdbcType _ParameterType = OdbcType.Text;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public object Value
		{
			get { return _Value; }
			set { _Value = value; }
		}

		public ParameterDirection Direction
		{
			get { return _Direction; }
			set { _Direction = value; }
		}

		//public OdbcType ParameterType
		//{
		//    get { return _ParameterType; }
		//    set { _ParameterType = value; }
		//}

		public OdbcParameter OdbcParameter
		{
			get
			{
				OdbcParameter result = new OdbcParameter(ParameterPrefixOdbc + Name, Value);
				result.Direction = Direction;
				result.IsNullable = _IsNullable;
				//result.OdbcType = _ParameterType;
				return result;
			}
		}

		public OleDbParameter OleDbParameter
		{
			get
			{
				OleDbParameter result = new OleDbParameter(Name, Value);
				result.Direction = Direction;
				result.IsNullable = _IsNullable;
				return result;
			}
		}

		public SqlParameter SqlParameter
		{
			get
			{
				SqlParameter result = new SqlParameter(ParameterPrefixSql + Name, Value);
				result.Direction = Direction;
				result.IsNullable = _IsNullable;
				return result;
			}
		}

		public AppDbParameter(string pName, object pValue)
		{
			this._Name = pName;
			this._Value = pValue;
		}
	}
}
