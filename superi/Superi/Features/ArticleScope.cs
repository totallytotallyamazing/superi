using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Features
{
    public class ArticleScope
    {

        #region Private fields
        private int _ID = int.MinValue;
        private string _Name = "";
        private int _ParentID = int.MinValue;
        #endregion

        #region Public properties
        public int ID
        {
            get { return _ID; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        public ArticleList Items
        {
            get { return new ArticleList(ID); }
        }

        public ArticleScopeList SubItems
        {
            get { return new ArticleScopeList(ID); }
        }
        #endregion

        #region Constructors
		public ArticleScope()
		{

		}

		public ArticleScope(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public ArticleScope(DbDataReader dr)
		{
			//if /*(dr.Read())*/ 
			Load(dr);
		}

        public ArticleScope(int ID)
		{
			string sql = "select * from ArticleScopes where ID=" + ID;
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
            ParentID = dr.GetInt32(dr.GetOrdinal("ParentID"));

            if (CloseDr)
                dr.Close();
            return true;
        }

        public bool Load(DataRow dr)
        {
            _ID = (int) dr["ID"];
            Name = dr["Name"].ToString();
            ParentID = int.Parse(dr["ParentID"].ToString());
            return true;
        }

        public bool Save()
        {
            ParameterList pList = new ParameterList();
            pList.Add(new AppDbParameter("id", ID));
            pList.Add(new AppDbParameter("name", Name));
            pList.Add(new AppDbParameter("parentid", ParentID));

            DbDataReader dr = AppData.ExecStoredProcedure("ArticleScope_AddUpdate", pList);
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
            if (SubItems != null && SubItems.Count > 0)
                SubItems.Remove();
            if (ID > 0)
            {
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("id", ID));
                AppData.ExecStoredProcedure("ArticleScope_Delete", pList);
                //string sql = "delete from Languages where id=" + ID;
                //result = AppData.ExecNonQuery(sql);
                result = true;
            }
            else result = false;
            return result;
        }
        #endregion
    }
}
