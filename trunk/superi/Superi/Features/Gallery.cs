using System;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class Gallery
	{
		#region Private fields
		private int _ID = int.MinValue;
		private DateTime _EntryDate = DateTime.MinValue;
		private string _Picture = "";
		private string _Title = "";
	    private int _TitleTextId = int.MinValue;
		private string _SubTitle = "";
	    private int _SubTitleTextId = int.MinValue;
		#endregion

		#region Properties
		public int ID
		{
			get { return _ID; }
		}

		public DateTime EntryDate
		{
			get { return _EntryDate; }
			set { _EntryDate = value; }
		}

		public string Picture
		{
			get { return _Picture; }
			set { _Picture = value; }
		}

		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}

	    public int TitleTextId
	    {
	        get { return _TitleTextId; }
	        set { _TitleTextId = value; }
	    }

	    public Resource Titles
	    {
            get { return new Resource(TitleTextId); }
	    }

	    public string SubTitle
		{
			get { return _SubTitle; }
			set { _SubTitle = value; }
		}

	    public int SubTitleTextId
	    {
	        get { return _SubTitleTextId; }
	        set { _SubTitleTextId = value; }
	    }

	    public Resource SubTitles
	    {
            get { return new Resource(SubTitleTextId); }
	    }

	    #endregion

		#region Constructors
		public Gallery()
		{

		}

		public Gallery(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Gallery(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Gallery(int ID)
		{
			string sql = "select * from Gallery where ID=" + ID;
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
		    TitleTextId = dr.GetInt32(dr.GetOrdinal("TitleTextID"));
			SubTitle = dr["SubTitle"].ToString();
            SubTitleTextId = dr.GetInt32(dr.GetOrdinal("SubTitleTextID"));
			Picture = dr["Picture"].ToString();
			EntryDate = dr.GetDateTime(dr.GetOrdinal("EntryDate"));

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			_ID = (int)dr["ID"];
			Title = dr["Title"].ToString();
		    TitleTextId = (int) dr["TitleTextID"];
            SubTitle = dr["SubTitle"].ToString();
            SubTitleTextId = (int)dr["SubTitleTextId"];
			Picture = dr["Picture"].ToString();
			EntryDate = DateTime.Parse(dr["EntryDate"].ToString());
			return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", ID));
			pList.Add(new AppDbParameter("entrydate", EntryDate));
			pList.Add(new AppDbParameter("picture", Picture));
			pList.Add(new AppDbParameter("title", Title));
            pList.Add(new AppDbParameter("titletextid", TitleTextId));
			pList.Add(new AppDbParameter("subtitle", SubTitle));
            pList.Add(new AppDbParameter("subtitletextid", SubTitleTextId));

			DbDataReader dr = AppData.ExecStoredProcedure("Gallery_AddUpdate", pList);
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
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("id", ID));
                AppData.ExecStoredProcedure("Gallery_Delete", pList);
			    result = true;
            }
			else result = false;
			return result;
		}
		#endregion

	}
}
