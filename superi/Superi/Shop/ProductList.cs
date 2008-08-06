using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Superi.Common;

namespace Superi.Shop
{
    public class ProductList:List<Product>
    {
        public ProductList(bool GetAll)
		{
			if (GetAll)
			{
				string SQL = "select * from Products order by EntryDate DESC";
				DbDataReader dr = AppData.ExecQuery(SQL);
				if (dr != null && dr.HasRows)
					Load(dr);
			}
		}

        public ProductList(int GroupID)
        {
            string SQL = "select * from Products where GroupID = " + GroupID;
            DbDataReader dr = AppData.ExecQuery(SQL);
            if (dr != null && dr.HasRows)
                Load(dr);
        }

		public ProductList(DataTable dt)
		{
			Load(dt);
		}

        public ProductList(DbDataReader dr)
		{
			Load(dr);
		}

        public Product GetByID(int ID)
		{
            Product result = new Product();
            foreach (Product item in this)
			{
				if (item.ID == ID)
				{
					result = item;
					break;
				}
			}
			return result;

		}

		public void Load(DataTable dt)
		{
			if (dt.Rows.Count > 0)
				foreach (DataRow row in dt.Rows)
				{
					Add(new Product(row));
				}
		}

		public void Load(DbDataReader dr)
		{
			if (dr.HasRows)
				while (dr.Read())
				{
                    Add(new Product(dr));
				}
			dr.Close();
		}
    }
}
