using System;

namespace Superi.Features
{
	public static class GalleryItems
	{
	    public static GalleryItemList Get()
		{
			return new GalleryItemList(true);
		}

		public static GalleryItemList Get(int GalleryID)
		{
			return new GalleryItemList(GalleryID);
		}

        public static GalleryItemList GetRandom(int Count)
        {
            GalleryItemList list = new GalleryItemList(true);
            Random random = new Random();
            GalleryItemList result =new GalleryItemList(false);
            for (int i = 0; i <= Count; i++)
            {
                int index = random.Next(list.Count - 1);
                result.Add(list[index]);
                list.RemoveAt(index);
            }
            return result;
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
		    //return true;
			GalleryItem item = new GalleryItem(ID);
			item.Title = Title;
			return item.Save();
		}

        public static bool Update(Resource Titles, int ID)
        {
            GalleryItem item = new GalleryItem(ID);
            item.TitleTextId = Titles.Save();
            //return true;
            return item.Save();
        }

		public static bool Delete(int ID)
		{
			GalleryItem item = new GalleryItem(ID);
			return item.Remove();
		}

		public static bool Insert(string Title)
		{
			GalleryItem item = new GalleryItem();
			item.Title = Title;
			return item.Save();
		}

		public static bool Insert(string Title, int GalleryID)
		{
			GalleryItem item = new GalleryItem();
			item.Title = Title;
			item.GalleryID = GalleryID;
			return item.Save();
		}

	}
}
