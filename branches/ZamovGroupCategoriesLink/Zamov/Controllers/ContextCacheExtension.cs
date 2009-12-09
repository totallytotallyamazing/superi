using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zamov.Models;
using System.Web.Caching;
using System.Collections;
using System.Web.Mvc;

namespace Zamov.Controllers
{
    public static class ContextCache
    {
        private static Cache Cache { get { return HttpContext.Current.Cache; } }

        public static List<CategoryPresentation> GetCachedCategoryPresentation(this ZamovStorage context, int cityId, bool reload, string language)
        {
            List<CategoryPresentation> result = new List<CategoryPresentation>();
            if (Cache["CityCategoriesPresentation_" + cityId] != null && !reload)
                result = (List<CategoryPresentation>)Cache["CityCategoriesPresentation_" + cityId];
            else
            {
                result = (from category in context.Categories.Include("Parent").Include("Dealers").Include("Categories")
                          join name in context.Translations on category.Id equals name.ItemId
                          where category.Parent == null && category.Enabled
                          && category.Categories.Where(c => c
                          .Dealers.Where(d => d.Cities.Where(sub => sub.Id == cityId).Count() > 0).Count() > 0).Count() > 0
                          && name.Language == language
                          && name.TranslationItemTypeId == (int)ItemTypes.Category
                          select new CategoryPresentation
                          {
                              Id = category.Id,
                              Name = name.Text
                          }).ToList();
                Cache.Add("CityCategoriesPresentation_" + cityId, result, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            }
            return result;
        }

        public static List<SelectListItem> GetCitiesFromContext(this ZamovStorage context, string language)
        { 
            if(HttpContext.Current.Items["Cities_" + language] == null)
            {
                HttpContext.Current.Items["Cities_" + language] =
                     context.Cities.Where(c => c.Enabled).Join(context.Translations.Where(t => t.TranslationItemTypeId == (int)ItemTypes.City && t.Language == language),
                         c => c.Id, t => t.ItemId, (c, i) => new { Id = c.Id, Text = i.Text }).ToList().Select(kvp => new SelectListItem { Value = kvp.Id.ToString(), Text = kvp.Text }).ToList();
            }
            return (List<SelectListItem>)HttpContext.Current.Items["Cities_" + language];
        }

        public static List<Category> GetCachedCategories(this ZamovStorage context, int cityId, bool reload)
        {
            List<Category> result = new List<Category>();
            if (Cache["CityCategories_" + cityId] != null && !reload)
                result = (List<Category>)Cache["CityCategories_" + cityId];
            else
            {
                result = (from category in context.Categories.Include("Parent").Include("Dealers").Include("Categories")
                          where category.Parent == null && category.Enabled
                          && category.Categories.Where(c => c
                          .Dealers.Where(d => d.Cities.Where(sub => sub.Id == cityId).Count() > 0).Count() > 0).Count() > 0
                          select category).ToList();
                Cache["CityCategories_" + cityId] = result;
            }
            return result;
        }

        public static void ClearCategoriesCache(this Cache cache)
        {
            List<string> keysToClear = new List<string>();

            IDictionaryEnumerator enumerator = cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().StartsWith("CityCategories_")
                    || enumerator.Key.ToString().StartsWith("CityCategoriesPresentation_"))
                    keysToClear.Add(enumerator.Key.ToString());
            }
            foreach (string key in keysToClear)
            {
                cache.Remove(key);
            }
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
            //if (Cache["SubCategories_" + categoryId] != null && !reload)
            //    result = (List<Category>)Cache["SubCategories_" + categoryId];
            //else
            //{
            using (ZamovStorage context = new ZamovStorage())
            {
                result = (from category in context.Categories.Include("Categories")
                          where category.Parent.Id == categoryId
                          && category.Dealers.Count > 0
                          && category.Enabled
                          select category).ToList();
            }
            // Cache["SubCategories_" + categoryId] = result;
            //}
            return result;
        }


    }
}
