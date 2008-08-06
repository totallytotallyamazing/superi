namespace Superi.Features
{
	public static class News
	{
	    public static NewsItemList Get()
		{
			return new NewsItemList(true);
		}

		public static NewsItemList Get(int Top)
		{
			return new NewsItemList(Top);
		}

		public static NewsItemList Get(int Start, int Count)
		{
			return new NewsItemList(Start, Count);
		}

		public static bool Update(string Title, int ID)
		{
			NewsItem item = new NewsItem(ID);
			item.Title = Title;
			return item.Save();
		}

		public static bool Update(string Title, string Alias, int ID)
		{
			NewsItem item = new NewsItem(ID);
			item.Title = Title;
			item.Alias = item.Alias;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
			NewsItem item = new NewsItem(ID);
			return item.Remove();
		}

		public static bool Insert(string Title)
		{
			NewsItem item = new NewsItem();
			item.Title = Title;
			return item.Save();
		}
	}
}
