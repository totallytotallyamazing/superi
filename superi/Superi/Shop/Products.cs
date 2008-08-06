using System;
using System.Collections.Generic;
using System.Text;

namespace Superi.Shop
{
    public static class Products
    {
		public static ProductList Get()
		{
            return new ProductList(true);
		}

        public static ProductList Get(int ScopeID)
		{
            return new ProductList(ScopeID);
		}

		public static bool Update(decimal Price, string Name, int ID)
		{
            Product item = new Product(ID);
            item.Name = Name;
		    item.Price = Price;
			return item.Save();
		}

        public static bool Update(decimal Price, string Name, int ID, decimal Weight)
        {
            Product item = new Product(ID);
            item.Name = Name;
            item.Price = Price;
            item.Weight = Weight;
            return item.Save();
        }

		public static bool Delete(int ID)
		{
            Product item = new Product(ID);
            return item.Remove();
		}

		public static bool Insert(string Name, decimal Price, int GroupID)
		{
            Product item = new Product();
			item.Name = Name;
            item.Price = Price;
            item.GroupID = GroupID;
			return item.Save();
		}

        public static bool Insert(string Name, decimal Price, int GroupID, decimal Weight)
        {
            Product item = new Product();
            item.Name = Name;
            item.Price = Price;
            item.GroupID = GroupID;
            item.Weight = Weight;
            return item.Save();
        }

    }
}
