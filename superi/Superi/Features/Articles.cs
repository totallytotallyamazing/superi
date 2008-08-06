namespace Superi.Features
{
    public static class Articles
    {
        public static ArticleList Get()
		{
            return new ArticleList(true);
		}

        public static ArticleList Get(int ScopeID)
		{
            return new ArticleList(ScopeID);
		}

        //public static ArticleList Get(int Start, int Count)
        //{
        //    return new NewsItemList(Start, Count);
        //}

		public static bool Update(string Alias, int ID)
		{
            Article item = new Article(ID);
            item.Alias = Alias;
			return item.Save();
		}

		public static bool Update(string Title, string Alias, int ID)
		{
            Article item = new Article(ID);
			item.Title = Title;
			item.Alias = Alias;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
            Article item = new Article(ID);
			return item.Remove();
		}

		public static bool Insert(string Alias, string Title, int ScopeID)
		{
            Article item = new Article();
			item.Alias = Alias;
            item.Title = Title;
            item.ScopeID = ScopeID;
			return item.Save();
		}
    }
}
