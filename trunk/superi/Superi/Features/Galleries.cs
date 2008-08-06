namespace Superi.Features
{
	public static class Galleries
	{
	    public static GalleryList Get()
		{
			return new GalleryList(true);
		}

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
			Gallery item = new Gallery(ID);
			item.Title = Title;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
			Gallery item = new Gallery(ID);
			return item.Remove();
		}

		public static bool Insert(string Title)
		{
			Gallery item = new Gallery();
			item.Title = Title;
			return item.Save();
		}
	}
}
