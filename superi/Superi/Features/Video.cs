using System;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class Video
	{
		#region Private fields
		private int _ID = int.MinValue;
		private string _Video = "";
		private string _Name = "";
		private string _Director = "";
		private string _Camera = "";
		private DateTime _ProductionDate = DateTime.MinValue;
		private string _Title = "";
		private string _SubTitle = "";
		#endregion

		#region Properties
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		public string Path
		{
			get { return _Video; }
			set { _Video = value; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public string Director
		{
			get { return _Director; }
			set { _Director = value; }
		}

		public string Camera
		{
			get { return _Camera; }
			set { _Camera = value; }
		}

		public DateTime ProductionDate
		{
			get { return _ProductionDate; }
			set { _ProductionDate = value; }
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
		#endregion

		#region Constructors
		public Video()
		{

		}

		public Video(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Video(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Video(int ID)
		{
			string sql = "select * from Videos where ID=" + ID;
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
			Path = dr["Video"].ToString();
			Name = dr["Name"].ToString();
			Director = dr["Director"].ToString();
			Camera = dr["Camera"].ToString();
			ProductionDate = dr.GetDateTime(dr.GetOrdinal("ProductionDate"));
			Title = dr["Title"].ToString();
			SubTitle = dr["SubTitle"].ToString();

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			_ID = int.Parse(dr["ID"].ToString());
			Path = dr["Video"].ToString();
			Name = dr["Name"].ToString();
			Director = dr["Director"].ToString();
			Camera = dr["Camera"].ToString();
			ProductionDate = DateTime.Parse(dr["ProductionDate"].ToString());
			Title = dr["Title"].ToString();
			SubTitle = dr["SubTitle"].ToString();
			return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", ID));
			pList.Add(new AppDbParameter("video", Path));
			pList.Add(new AppDbParameter("name", Name));
			pList.Add(new AppDbParameter("director", Director));
			pList.Add(new AppDbParameter("productiondate", ProductionDate));
			pList.Add(new AppDbParameter("title", Title));
			pList.Add(new AppDbParameter("subtitle", SubTitle));

			DbDataReader dr = AppData.ExecStoredProcedure("Videos_AddUpdate", pList);
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
				string sql = "delete from Videos where id=" + ID;
				result = AppData.ExecNonQuery(sql);
			}
			else result = false;
			return result;
		}
		#endregion
	}
}
