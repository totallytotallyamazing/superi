using System;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class NewsItem
	{
		#region Private fields
		private int _ID = int.MinValue;
		private string _ShortDescription = "";
        private int _ShortDescriptionTextID = int.MinValue;
		private string _Description = "";
        private int _DescriptionTextID = int.MinValue;
		private string _Title = "";
        private int _TitleTextID = int.MinValue;
		private string _TitlePicture = "";
		private string _Picture = "";
		private string _PictureSign = "";
		private string _EntrySource = "";
		private DateTime _EntryDate = DateTime.Now;
		private string _Alias = "";
		#endregion

		#region Properties
		public int ID
		{
			get { return _ID; }
		}

		public string ShortDescription
		{
			get { return _ShortDescription; }
			set { _ShortDescription = value; }
		}

        public int ShortDescriptionTextID
        {
            get { return _ShortDescriptionTextID; }
            set { _ShortDescriptionTextID = value; }
        }

		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

        public int DescriptionTextID
        {
            get { return _DescriptionTextID; }
            set { _DescriptionTextID = value; }
        }

		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}

        public int TitleTextID
        {
            get { return _TitleTextID; }
            set { _TitleTextID = value; }
        }

		public string TitlePicture
		{
			get { return _TitlePicture; }
			set { _TitlePicture = value; }
		}

		public string Picture
		{
			get { return _Picture; }
			set { _Picture = value; }
		}

		public string PictureSign
		{
			get { return _PictureSign; }
			set { _PictureSign = value; }
		}

		public string EntrySource
		{
			get { return _EntrySource; }
			set { _EntrySource = value; }
		}

		public DateTime EntryDate
		{
			get { return _EntryDate; }
			set { _EntryDate = value; }
		}

		public string Alias
		{
			get { return _Alias; }
			set { _Alias = value; }
		}
		#endregion

		#region Constructors
		public NewsItem()
		{

		}

		public NewsItem(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public NewsItem(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public NewsItem(int ID)
		{
			string sql = "select * from News where ID=" + ID;
			DbDataReader dr = AppData.ExecQuery(sql);
			if (dr != null && dr.Read())
				Load(dr, true);
		}

		public NewsItem(string Alias)
		{
			string sql = "select * from News where Alias='" + Alias + "'";
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
            TitleTextID = dr.GetInt32(dr.GetOrdinal("TitleTextID"));
			ShortDescription = dr["ShortDescription"].ToString();
            ShortDescriptionTextID = dr.GetInt32(dr.GetOrdinal("ShortDescriptionTextID"));
			Description = dr["Description"].ToString();
            DescriptionTextID = dr.GetInt32(dr.GetOrdinal("DescriptionTextID"));
			TitlePicture = dr["TitlePicture"].ToString();
			Picture = dr["Picture"].ToString();
			PictureSign = dr["PictureSign"].ToString();
			EntrySource = dr["EntrySource"].ToString();
			EntryDate = dr.GetDateTime(dr.GetOrdinal("EntryDate"));
			Alias = dr["Alias"].ToString();

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			_ID = (int)dr["ID"];
			Title = dr["Title"].ToString();
            TitleTextID = int.Parse(dr[TitleTextID].ToString());
			ShortDescription = dr["ShortDescription"].ToString();
            ShortDescriptionTextID = int.Parse(dr["ShortDescriptionTextID"].ToString());
			Description = dr["Description"].ToString();
            DescriptionTextID = int.Parse(dr["DescriptionTextID"].ToString());
			TitlePicture = dr["TitlePicture"].ToString();
			Picture = dr["Picture"].ToString();
			PictureSign = dr["PictureSign"].ToString();
			EntrySource = dr["EntrySource"].ToString();
			EntryDate = DateTime.Parse(dr["EntryDate"].ToString());
			Alias = dr["Alias"].ToString();
			return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", ID));
			pList.Add(new AppDbParameter("sd", ShortDescription));
            pList.Add(new AppDbParameter("sdtid", ShortDescriptionTextID));
			pList.Add(new AppDbParameter("d", Description));
            pList.Add(new AppDbParameter("dtid", DescriptionTextID));
			pList.Add(new AppDbParameter("t", Title));
            pList.Add(new AppDbParameter("ttid", TitleTextID));
            pList.Add(new AppDbParameter("tp", TitlePicture));
			pList.Add(new AppDbParameter("p", Picture));
			pList.Add(new AppDbParameter("ps", PictureSign));
			pList.Add(new AppDbParameter("ed", EntryDate));
			pList.Add(new AppDbParameter("es", EntrySource));
			pList.Add(new AppDbParameter("al", Alias));

			DbDataReader dr = AppData.ExecStoredProcedure("News_AddUpdate", pList);
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
				string sql = "delete from News where id=" + ID;
				result = AppData.ExecNonQuery(sql);
			}
			else result = false;
			return result;
		}
		#endregion

	}
}
