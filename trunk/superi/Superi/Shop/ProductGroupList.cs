using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Superi.Common;

namespace Superi.Shop
{
    public class ProductGroupList:List<ProductGroup>
    {
        public ProductGroupList(bool GetAll)
		{
			if (GetAll)
			{
                string SQL = "select * from ProductGroups where ParentID<=0";
                DataSet ds = AppData.GetDataSet(SQL);
				if (ds.Tables.Count>0)
					Load(ds.Tables[0]);
			}
		}

        public ProductGroupList(int ParentID)
        {
            string SQL = "select * from ProductGroups where ParentID = " + ParentID;
            DataSet ds = AppData.GetDataSet(SQL);
            if (ds.Tables.Count > 0)
                Load(ds.Tables[0]);
        }

		public ProductGroupList(DataTable dt)
		{
			Load(dt);
		}

        public ProductGroupList(DbDataReader dr)
		{
			Load(dr);
		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new ProductGroup(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
                    Add(new ProductGroup(dr));
				}
			dr.Close();
		}

        public void Remove()
        {
            foreach (ProductGroup group in this)
            {
                group.Remove();
            }
        }

    }
}
