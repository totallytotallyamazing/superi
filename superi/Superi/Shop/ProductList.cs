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
                string SQL = "select * from Products";
                DataSet ds = AppData.GetDataSet(SQL);
                if (ds != null && ds.Tables.Count > 0)
                    Load(ds.Tables[0]);
			}
		}

        public ProductList(int GroupID)
        {
            string SQL = "select * from Products where GroupID = " + GroupID;
            DataSet ds = AppData.GetDataSet(SQL);
            if (ds != null && ds.Tables.Count>0)
                Load(ds.Tables[0]);
        }

        public ProductList(int PropertyId, string PropertyValue)
        {
            ParameterList parameterList = new ParameterList();
            parameterList.Add(new AppDbParameter("propertyId", PropertyId));
            parameterList.Add(new AppDbParameter("value", PropertyValue));

            DataSet ds = AppData.ExecDataSet("Products_GetByPropertyValue", parameterList);
            if (ds.Tables.Count > 0)
                Load(ds.Tables[0]);
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
