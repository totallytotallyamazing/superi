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

        public static string FavoriteNames
        {
            get
            {
                if (FavoritesProductIds.Count() == 1)
                    return "позиция";
                if (FavoritesProductIds.Count() > 1 && FavoritesProductIds.Count() <= 4)
                    return "позиции";
                if (FavoritesProductIds.Count() > 4 && FavoritesProductIds.Count() <= 20)
                    return "позиций";
                if (FavoritesProductIds.Count() % 10 == 1)
                    return "позиция";
                if (FavoritesProductIds.Count() % 10 > 1 && FavoritesProductIds.Count() <= 4)
                    return "позиции";
                if (FavoritesProductIds.Count() % 10 > 4 && FavoritesProductIds.Count() <= 10)
                    return "позиций";
                return "позиции";
            }

        }
    }
}