namespace Superi.Features
{
    public static class ArticleScopes
    {
        public static ArticleScopeList Get()
		{
            return new ArticleScopeList(true);
		}

        public static ArticleScopeList Get(int ParentID)
		{
            return new ArticleScopeList(ParentID);
		}

		public static bool Update(string Name, int ID)
		{
            ArticleScope item = new ArticleScope(ID);
			item.Name = Name;
			return item.Save();
		}

        public static bool Update(string Name, int ParentID,  int ID)
		{
            ArticleScope item = new ArticleScope(ID);
			item.Name = Name;
			item.ParentID = ParentID;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
            ArticleScope item = new ArticleScope(ID);
			return item.Remove();
		}

		public static bool Insert(string Name)
		{
            ArticleScope item = new ArticleScope();
            item.Name = Name;
			return item.Save();
		}
    }
}
