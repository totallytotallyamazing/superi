namespace Superi.Shop
{
    public static class ProductGroups
    {
        public static ProductGroupList Get()
		{
            return new ProductGroupList(true);
		}

        public static ProductGroupList Get(int ParentID)
		{
            return new ProductGroupList(ParentID);
		}

		public static bool Update(string Name, int ID)
		{
            ProductGroup item = new ProductGroup(ID);
			item.Name = Name;
			return item.Save();
		}

        public static bool Update(string Name, int ParentID,  int ID)
		{
            ProductGroup item = new ProductGroup(ID);
			item.Name = Name;
			item.ParentID = ParentID;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
            ProductGroup item = new ProductGroup(ID);
			return item.Remove();
		}

		public static bool Insert(string Name)
		{
            ProductGroup item = new ProductGroup();
            item.Name = Name;
			return item.Save();
		}

    }
}
