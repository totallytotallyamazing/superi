using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
	public class Text
	{
		#region Private fields
		private int _ID = int.MinValue;
		private string _Alias = "";
		private string _Name = "";
		private string _Text = "";
        private int _TextID = int.MinValue;
	    private int nameTextId = int.MinValue;
		#endregion

		#region Properties
		public int ID
		{
			get { return _ID; }
		}

		public string Alias
		{
			get { return _Alias; }
			set { _Alias = value; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

	    public int NameTextId
	    {
	        get { return nameTextId; }
	        set { nameTextId = value; }
	    }

	    public Resource Names
	    {
	        get{return new Resource(nameTextId);}
	    }

	    public string Value
		{
			get { return _Text; }
			set { _Text = value; }
		}

        public int TextID
        {
            get { return _TextID; }
            set { _TextID = value; }
        }

        public Resource TextResource
        {
            get { return new Resource(TextID); }
        }
		#endregion

		#region Constructors
		public Text()
		{

		}

		public Text(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public Text(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

		public Text(int ID)
		{
			string sql = "select * from Texts where ID=" + ID;
			DataSet ds = AppData.GetDataSet(sql);
			if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				Load(ds.Tables[0].Rows[0]);
		}

		public Text(string Alias)
		{
			string sql = "select * from Texts where Alias=" + "'" + Alias + "'";
            DataSet ds = AppData.GetDataSet(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
			Name = dr["Name"].ToString();
			Value = dr["Text"].ToString();
			Alias = dr["Alias"].ToString();
            TextID = dr.GetInt32(dr.GetOrdinal("TextID"));
            NameTextId = dr.GetInt32(dr.GetOrdinal("NameTextId"));
			if (CloseDr)
				dr.Close();
			return true;
		}

		public bool Load(DataRow dr)
		{
			_ID = (int)dr["ID"];
			Name = dr["Name"].ToString();
			Value = dr["Text"].ToString();
			Alias = dr["Alias"].ToString();
		    TextID = (int) dr["TextID"];
		    nameTextId = (int) dr["NameTextId"];
			return true;
		}

		public bool Save()
		{
			ParameterList pList = new ParameterList();
			pList.Add(new AppDbParameter("id", ID));
			pList.Add(new AppDbParameter("name", Name));
			pList.Add(new AppDbParameter("alias", Alias));
			pList.Add(new AppDbParameter("text", Value));
            pList.Add(new AppDbParameter("textid", TextID));
		    pList.Add(new AppDbParameter("nametextid", nameTextId));

			DbDataReader dr = AppData.ExecStoredProcedure("Texts_AddUpdate", pList);
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
                Names.Remove();
                TextResource.Remove();
				string sql = "delete from Texts	 where id=" + ID;
				result = AppData.ExecNonQuery(sql);
			}
			else result = false;
			return result;
		}
		#endregion
	}
}
