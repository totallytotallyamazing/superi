namespace Superi.Features
{
	public static class Albums
	{
	    public static AlbumList Get()
		{
			return new AlbumList(true);
		}

		//public static AlbumList Get(int Top)
		//{
		//    return new AlbumList(Top);
		//}

		//public static AlbumList Get(int Start, int Count)
		//{
		//    return new AlbumList(Start, Count);
		//}

		public static bool Update(string Title, int ID)
		{
			Album item = new Album(ID);
			item.Title = Title;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
			Album item = new Album(ID);
			return item.Remove();
		}

		public static bool Insert(string Title)
		{
			Album item = new Album();
			item.Title = Title;
			return item.Save();
		}

	}
}
