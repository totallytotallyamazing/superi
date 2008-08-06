using System;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class Article
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
        private int _ScopeID = int.MinValue;
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

        public Resource ShortDescriptions
        {
            get { return new Resource(ShortDescriptionTextID); }
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

        public Resource Descriptions
        {
            get { return new Resource(DescriptionTextID); }
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

        public Resource Titles
        {
            get { return new Resource(TitleTextID); }
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

        public int ScopeID
        {
            get { return _ScopeID; }
            set { _ScopeID = value; }
        }
		#endregion

		#region Constructors
		public Article()
		{

		}

		public Article(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Article(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Article(int ID)
		{
			string sql = "select * from Articles where ID=" + ID;
			DbDataReader dr = AppData.ExecQuery(sql);
			if (dr != null && dr.Read())
				Load(dr, true);
		}

        public Article(string Alias)
		{
            string sql = "select * from Articles where Alias='" + Alias + "'";
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
            ScopeID = dr.GetInt32(dr.GetOrdinal("ScopeID"));

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
            ScopeID = (int)dr["ScopeID"];
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
            pList.Add(new AppDbParameter("sid", ScopeID));

			DbDataReader dr = AppData.ExecStoredProcedure("Articles_AddUpdate", pList);
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
				string sql = "delete from Articles where id=" + ID;
				result = AppData.ExecNonQuery(sql);
			}
			else result = false;
			return result;
		}
		#endregion
    }
}
