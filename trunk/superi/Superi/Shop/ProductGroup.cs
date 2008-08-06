using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Superi.Common;

namespace Superi.Shop
{
    public class ProductGroup
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

        public ProductList Items
        {
            get { return new ProductList(ID); }
        }
        
        public ProductGroupList SubGroups
        {
            get { return new ProductGroupList(ID); }
        }
        #endregion

        #region Constructors
		public ProductGroup()
		{

		}

		public ProductGroup(DataRow dr)
		{
			if (dr != null) Load(dr);
		}

		public ProductGroup(DbDataReader dr)
		{
			Load(dr);
		}

        public ProductGroup(int ID)
		{
			string sql = "select * from ProductGroups where ID=" + ID;
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
            ParentID = dr.GetInt32(dr.GetOrdinal("ParentID"));

            if (CloseDr)
                dr.Close();
            return true;
        }

        public bool Load(DataRow dr)
        {
            _ID = int.Parse(dr["ID"].ToString());
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

            DbDataReader dr = AppData.ExecStoredProcedure("ProductGroups_AddUpdate", pList);
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
            if (SubGroups != null && SubGroups.Count > 0)
                SubGroups.Remove();
            if (ID > 0)
            {
                ParameterList pList = new ParameterList();
                pList.Add(new AppDbParameter("id", ID));
                AppData.ExecStoredProcedure("ProductGroups_Delete", pList);
                result = true;
            }
            else result = false;
            return result;
        }
        #endregion
    }
}
