using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Favorites
    {
        public static int[] FavoritesProductIds
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["favorites"] != null)
                {
                    string favoritesStr = HttpContext.Current.Request.Cookies["favorites"].Value;

                    return favoritesStr.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(
                        c => Convert.ToInt32(c)).ToArray();

                }
                return new int[0];
            }
        }

        public static string PositionNames
        {
            get
            {
                var bookmark = Resources.Global.Bookmark.Replace("'", string.Empty);
                bookmark = bookmark.Replace(" ", string.Empty);
                var bookmarks = bookmark.Split(',');

                if (FavoritesProductIds.Count() == 1)
                    return bookmarks[0];
                if (FavoritesProductIds.Count() > 1 && FavoritesProductIds.Count() <= 4)
                    return bookmarks[1];
                if (FavoritesProductIds.Count() > 4 && FavoritesProductIds.Count() <= 20)
                    return bookmarks[2];
                if (FavoritesProductIds.Count() % 10 == 1)
                    return bookmarks[3];
                if (FavoritesProductIds.Count() % 10 > 1 && FavoritesProductIds.Count() <= 4)
                    return bookmarks[4];
                if (FavoritesProductIds.Count() % 10 > 4 && FavoritesProductIds.Count() <= 10)
                    return bookmarks[5];
                return bookmarks[0];
            }
        }

        public static string CheckedNames
        {
            get
            {
                if(!FavoritesProductIds.Any())
                    return Resources.Global.YouHavea;
                return FavoritesProductIds.Count() % 10 == 1 ? Resources.Global.YouHavea : Resources.Global.YouHave;
            }
        }
    }
}