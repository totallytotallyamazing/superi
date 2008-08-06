namespace Superi.Features
{
	public static class Songs
	{
	    public static SongList Get()
		{
			return new SongList(true);
		}

		public static SongList Get(int SongID)
		{
			return new SongList(SongID);
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
			Song item = new Song(ID);
			item.Title = Title;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
			Song item = new Song(ID);
			return item.Remove();
		}

		public static bool Insert(string Title)
		{
			Song item = new Song();
			item.Title = Title;
			return item.Save();
		}

	}
}
