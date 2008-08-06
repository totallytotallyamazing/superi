namespace Superi.Features
{
    public static class Languages
    {
        public static LanguageList Get()
		{
            return new LanguageList(true);
		}

		//public static AlbumList Get(int Top)
		//{
		//    return new AlbumList(Top);
		//}

		//public static AlbumList Get(int Start, int Count)
		//{
		//    return new AlbumList(Start, Count);
		//}

		public static bool Update(string Name, string Code, string ShortName, int ID)
		{
            Language item = new Language(ID);
			item.Name = Name;
            item.Code = Code;
            item.ShortName = ShortName;
			return item.Save();
		}

		public static bool Delete(int ID)
		{
            Language item = new Language(ID);
			return item.Remove();
		}

		public static bool Insert(string Name, string Code, string ShortName)
		{
            Language item = new Language();
            item.Name = Name;
            item.Code = Code;
            item.ShortName = ShortName;
			return item.Save();
		}
    }
}
