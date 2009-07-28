﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zamov.Models;

namespace Zamov.Controllers
{
    public static class ContextCache
    {
        private static Cache Cache { get { return Zamov.Controllers.Cache.UniqueInstance; } }

        public static List<Category> GetCachedCategories(this ZamovStorage context, int cityId, bool reload)
        {
            List<Category> result = new List<Category>();
            if (Cache["CityCategories_" + cityId] != null && !reload)
                result = (List<Category>)Cache["CityCategories_" + cityId];
            else
            {
                result = (from category in context.Categories.Include("Parent").Include("Dealers")
                          where category.Parent == null
                          && category.Dealers.Where(d => d.Cities.Where(c => c.Id == cityId).Count() > 0).Count() > 0
                          select category).ToList();
                Cache.UniqueInstance["CityCategories_" + cityId] = result;
            }
            return result;
        }

        /// <summary>
        /// Retrieves list of subcategories from cache and, in not cached, from context
        /// </summary>
        /// <param name="categoryId">The Id of the parent category</param>
        /// <param name="reload">True if the cache should be reloaded</param>
        /// <returns></returns>
        public static List<Category> GetSubCategories(int categoryId, bool reload)
        {
            List<Category> result = new List<Category>();
            if (Cache["SubCategories_" + categoryId] != null && !reload)
                result = (List<Category>)Cache["SubCategories_" + categoryId];
            else
            {
                using (ZamovStorage context = new ZamovStorage())
                {
                    result = (from category in context.Categories where category.Parent.Id == categoryId && category.Dealers.Count > 0 select category).ToList();
                }
                Cache.UniqueInstance["SubCategories_" + categoryId] = result;
            }
            return result;
        }
    }
}
