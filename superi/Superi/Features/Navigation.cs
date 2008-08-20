using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class Navigation
	{
		#region Private fields
		private int _ID = int.MinValue;
		private string _Name = "";
        private int _NameTextID = int.MinValue;
		private string _Text = "";
		private string _Page = null;
		private bool _IsSeparator = false;
		private int _ParentID = int.MinValue;
		private int _TextID = int.MinValue;
		private int _SortOrder = 0;
		private string _Description = "";
		private string _Keywords = "";
		private bool _IncludeInMenu = false;
        private int _ArticleScopeID = int.MinValue;
	    private int _ProductGroupID = int.MinValue;
	    private string _Picture = "";
	    private bool _SingleMenuPage = false;
	    private string additionalTitle = "";
	    private int additionalTitleTextId = int.MinValue;
	    private string path = "";
		#endregion

		#region Properties
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

        public int NameTextID
        {
            get { return _NameTextID; }
            set { _NameTextID = value; }
        }

        public Resource Texts
        {
            get { return new Resource(NameTextID); }
        }

		public string Text
		{
			get { return _Text; }
			set { _Text = value; }
		}

		public string Page
		{
			get { return _Page; }
			set { _Page = value; }
		}

		public bool IsSeparator
		{
			get { return _IsSeparator; }
			set { _IsSeparator = value; }
		}

		public int ParentID
		{
			get { return _ParentID; }
			set { _ParentID = value; }
		}

		public int TextID
		{
			get { return _TextID; }
			set { _TextID = value; }
		}

		public int SortOrder
		{
			get { return _SortOrder; }
			set { _SortOrder = value; }
		}

		public NavigationList Children
		{
			get { return new NavigationList(ID); }
		}

		public NavigationList ChildrenIncludedOnly
		{
			get { return new NavigationList(ID, false); }
		}
		
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		public string Keywords
		{
			get { return _Keywords; }
			set { _Keywords = value; }
		}
		
		public bool IncludeInMenu
		{
			get { return _IncludeInMenu; }
			set { _IncludeInMenu = value; }
		}

        public int ArticleScopeID
        {
            get { return _ArticleScopeID; }
            set { _ArticleScopeID = value; }
        }

	    public int ProductGroupID
	    {
	        get { return _ProductGroupID; }
	        set { _ProductGroupID = value; }
	    }

	    public string Picture
	    {
	        get { return _Picture; }
	        set { _Picture = value; }
        }

	    public bool SingleMenuPage
	    {
	        get { return _SingleMenuPage; }
	        set { _SingleMenuPage = value; }
	    }

	    public string AdditionalTitle
	    {
	        get { return additionalTitle; }
	        set { additionalTitle = value; }
	    }

	    public int AdditionalTitleTextId
	    {
	        get { return additionalTitleTextId; }
	        set { additionalTitleTextId = value; }
	    }

	    public Resource AdditionalTitles
	    {
            get { return new Resource(AdditionalTitleTextId); }
	    }

	    public string Path
	    {
	        get { return path; }
	    }
	    #endregion

        #region Constructors
        public Navigation()
		{

		}

		public Navigation(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Navigation(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Navigation(int ID)
		{
			string sql = "select * from Navigation where ID=" + ID;
			DbDataReader dr = AppData.ExecQuery(sql);
			if (dr != null && dr.Read())
				Load(dr, true);
		}

		public Navigation(string Name)
		{
			string sql = "select * from Navigation where Name='" + Name + "'";
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
			Name = dr["Name"].ToString();
            NameTextID = dr.GetInt32(dr.GetOrdinal("NameTextID"));
			Text = dr["Text"].ToString();
			Page = dr["Page"].ToString();
			IsSeparator = dr.GetBoolean(dr.GetOrdinal("IsSeparator"));
			ParentID = dr.GetInt32(dr.GetOrdinal("ParentID"));
			TextID = dr.GetInt32(dr.GetOrdinal("TextID"));
			SortOrder = dr.GetInt32(dr.GetOrdinal("SortOrder"));
			Description = dr["Description"].ToString();
			Keywords = dr["Keywords"].ToString();
			IncludeInMenu = dr.GetBoolean(dr.GetOrdinal("IncludeInMenu"));
            ArticleScopeID = dr.GetInt32(dr.GetOrdinal("ArticleScopeID"));
            ProductGroupID = dr.GetInt32(dr.GetOrdinal("ProductGroupID"));
		    Picture = dr["Picture"].ToString();
		    SingleMenuPage = dr.GetBoolean(dr.GetOrdinal("SingleMenuPage"));
		    AdditionalTitle = dr["AdditionalTitle"].ToString();
		    AdditionalTitleTextId = dr.GetInt32(dr.GetOrdinal("AdditionalTitleTextID"));
		    path = dr["Path"].ToString();
		    path = path.Substring(1);

			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			_ID = int.Parse(dr["ID"].ToString());
			Name = dr["Name"].ToString();
            NameTextID = int.Parse(dr["NameTextID"].ToString());
			Text = dr["Text"].ToString();
			Page = dr["Page"].ToString();
			IsSeparator = (int.Parse(dr["IsSeparator"].ToString()) == 0) ? false : true;
			ParentID = int.Parse(dr["ParentID"].ToString());
			TextID = int.Parse(dr["TextID"].ToString());
			SortOrder = int.Parse(dr["SortOrder"].ToString());
			Description = dr["Description"].ToString();
			Keywords = dr["Keywords"].ToString();
			IncludeInMenu = (int.Parse(dr["IncludeInMenu"].ToString()) == 0) ? false : true;
            ArticleScopeID = int.Parse(dr["ArticleScopeID"].ToString());
            ProductGroupID = (int)dr["ProductGroupID"];
		    Picture = dr["Picture"].ToString();
		    SingleMenuPage = (bool) dr["SingleMenuPage"];
            AdditionalTitle = dr["AdditionalTitle"].ToString();
		    AdditionalTitleTextId = (int) dr["AdditionalTitleTextID"];
		    path = dr["Path"].ToString();
            path = path.Substring(1);

            return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", ID));
			pList.Add(new AppDbParameter("name", Name));
            pList.Add(new AppDbParameter("nametextid", NameTextID));
			pList.Add(new AppDbParameter("text", Text));
			pList.Add(new AppDbParameter("page", Page));
			pList.Add(new AppDbParameter("isseparator", (IsSeparator) ? 1 : 0));
			pList.Add(new AppDbParameter("parentid", ParentID));
			pList.Add(new AppDbParameter("textid", TextID));
			pList.Add(new AppDbParameter("sortorder", SortOrder));
			pList.Add(new AppDbParameter("description", Description));
			pList.Add(new AppDbParameter("keywords", Keywords));
            pList.Add(new AppDbParameter("includeinmenu", IncludeInMenu));
            pList.Add(new AppDbParameter("articlescopeid", ArticleScopeID));
		    pList.Add(new AppDbParameter("productgroupid", ProductGroupID));
            pList.Add(new AppDbParameter("picture", Picture));
		    pList.Add(new AppDbParameter("singlemenupage", SingleMenuPage));
            pList.Add(new AppDbParameter("additionaltitle", AdditionalTitle));
            pList.Add(new AppDbParameter("AdditionalTitleTextID", AdditionalTitleTextId));

			DbDataReader dr = AppData.ExecStoredProcedure("Navigation_AddUpdate", pList);
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
			foreach (Navigation navigation in Children)
			{
				navigation.Remove();
			}
			if (ID > 0)
			{
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("id", ID));
                AppData.ExecStoredProcedure("Navigation_Delete", pList);
                result = true;
			}
			else result = false;
			return result;
		}
		#endregion
	}
}
