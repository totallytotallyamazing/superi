namespace Superi.Features
{
	public static class Navigations
	{
	    public static NavigationList Get()
		{
			return new NavigationList(true);
		}

		public static NavigationList Get(bool GetSubItems)
		{
			return new NavigationList(true, GetSubItems);
		}

		public static NavigationList GetAll()
		{
			return new NavigationList(true, true);
		}

		public static NavigationList Get(int ParentID)
		{
			return new NavigationList(ParentID);
		}
		
		//public static VideoList Get(int SongID)
		//{
		//    return new SongList(SongID);
		//}

		//public static NewsItemList Get(int Top)
		//{
		//    return new NewsItemList(Top);
		//}

		//public static NewsItemList Get(int Start, int Count)
		//{
		//    return new NewsItemList(Start, Count);
		//}

		public static bool Update(string Title, int ID)
		{
			Video item = new Video(ID);
			item.Title = Title;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
			Video item = new Video(ID);
			return item.Remove();
		}

		public static bool Insert(string Title)
		{
			Video item = new Video();
			item.Title = Title;
			return item.Save();
		}
	}
}
