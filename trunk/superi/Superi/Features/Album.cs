using System;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class Album
	{
		#region Private fields
		private int _ID = int.MinValue;
		private string _Title = "";
		private string _SubTitle = "";
		private string _Cover = "";
		private DateTime _ProductionDate = DateTime.MinValue;
		#endregion

		#region Properties
		public int ID
		{
			get { return _ID; }
		}
		
		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}

		public string SubTitle
		{
			get { return _SubTitle; }
			set { _SubTitle = value; }
		}

		public string Cover
		{
			get { return _Cover; }
			set { _Cover = value; }
		}

		public DateTime ProductionDate
		{
			get { return _ProductionDate; }
			set { _ProductionDate = value; }
		}
		#endregion

		#region Constructors
		public Album()
		{

		}

		public Album(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Album(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Album(int ID)
		{
			string sql = "select * from Albums where ID=" + ID;
			DbDataReader dr = AppData.ExecQuery(sql);
			if (dr != null && dr.Read())
				Load(dr, true);
		}
		#endregion

		#region Public methods
		public bool Load(DbDataReader dr)
		{
			return Load(dr, false);
		}

		public bool Load(DbDataReader dr, bool CloseDr)
		{
			_ID = dr.GetInt32(dr.GetOrdinal("ID"));
			Title = dr["Title"].ToString();
			SubTitle = dr["SubTitle"].ToString();
			Cover = dr["Cover"].ToString();
			ProductionDate = dr.GetDateTime(dr.GetOrdinal("ProductionDate"));
			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			_ID = int.Parse(dr["ID"].ToString());
			Title = dr["Title"].ToString();
			SubTitle = dr["SubTitle"].ToString();
			Cover = dr["Cover"].ToString();
			ProductionDate = DateTime.Parse(dr["ProductionDate"].ToString());
			return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", ID));
			pList.Add(new AppDbParameter("title", Title));
			pList.Add(new AppDbParameter("subtitle", SubTitle));
			pList.Add(new AppDbParameter("cover", Cover));
			pList.Add(new AppDbParameter("productiondate", ProductionDate));

			DbDataReader dr = AppData.ExecStoredProcedure("Albums_AddUpdate", pList);
			if (dr != null && dr.HasRows && dr.Read())
			{
				_ID = int.Parse(dr[0].ToString());
				dr.Close();
			}
			else
				return false;
			return true;
		}


		public bool Remove()
		{
			bool result;
			if (ID > 0)
			{
				string sql = "delete from Albums where id=" + ID;
				result = AppData.ExecNonQuery(sql);
			}
			else result = false;
			return result;
		}
		#endregion
	}
}
