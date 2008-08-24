using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class GalleryItem
	{
		#region Private fields
		private int _ID = int.MinValue;
		private string _Picture = "";
		private string _Preview = "";
		private string _Title = "";
        private int _TitleTextId = int.MinValue;
        private string _SubTitle = "";
        private int _SubTitleTextId = int.MinValue;
        private int _GalleryID = int.MinValue;
        private string _Url;
		#endregion

		#region Public properties
		public int ID
		{
			get { return _ID; }
		}

		public string Picture
		{
			get { return _Picture; }
			set { _Picture = value; }
		}

		public string Preview
		{
			get { return _Preview; }
			set { _Preview = value; }
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

		public int GalleryID
		{
			get { return _GalleryID; }
			set { _GalleryID = value; }
		}

        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
		#endregion

		#region Constructors
		public GalleryItem()
		{

		}

		public GalleryItem(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public GalleryItem(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public GalleryItem(int ID)
		{
			string sql = "select * from GalleryItems where ID=" + ID;
			DataSet ds = AppData.GetDataSet(sql);
			if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				Load(ds.Tables[0].Rows[0]);
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
			Preview = dr["Preview"].ToString();
			GalleryID = dr.GetInt32(dr.GetOrdinal("GalleryID"));
            Url = dr["Url"].ToString();

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
		    _ID = (int) dr["ID"];
			Title = dr["Title"].ToString();
            TitleTextId = (int)dr["TitleTextID"];
			SubTitle = dr["SubTitle"].ToString();
            SubTitleTextId = (int)dr["SubTitleTextId"];
			Picture = dr["Picture"].ToString();
			Preview = dr["Preview"].ToString();
		    GalleryID = (int) dr["GalleryID"];
            Url = dr["Url"].ToString();
			return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", ID));
			pList.Add(new AppDbParameter("picture", Picture));
			pList.Add(new AppDbParameter("preview", Preview));
			pList.Add(new AppDbParameter("title", Title));
            pList.Add(new AppDbParameter("titletextid", TitleTextId));
			pList.Add(new AppDbParameter("subtitle", SubTitle));
            pList.Add(new AppDbParameter("subtitletextid", SubTitleTextId));
			pList.Add(new AppDbParameter("galleryid", GalleryID));
            pList.Add(new AppDbParameter("url", Url));

			DbDataReader dr = AppData.ExecStoredProcedure("GalleryItems_AddUpdate", pList);
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
			    AppData.ExecStoredProcedure("GalleryItems_Delete", pList);
			    result = true;
			}
			else result = false;
			return result;
		}
		#endregion

	}
}
