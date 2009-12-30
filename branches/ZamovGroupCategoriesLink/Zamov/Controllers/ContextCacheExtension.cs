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
        public const string CategoriesCachePrefix = "CityCategoriesPresentation_";
        public const string CategoryChainCachePrefix = "CategoriesChain_";
        public const string CitiesCachePrefix = "Cities_";

        private static Cache Cache { get { return HttpContext.Current.Cache; } }

        public static List<CategoryPresentation> GetCachedCategoryChain(this ZamovStorage context, int categoryId, string language)
        {
            string cacheKey = CategoryChainCachePrefix + categoryId + "_" + language;

            if (HttpContext.Current.Cache[cacheKey] == null)
            {
                var initialCategories = context.GetTranslatedCategories(language, true, null, false);
                List<CategoryPresentation> categories = initialCategories
                    .Where(item => item.Entity.Id == categoryId)
                    .Union(
                        initialCategories.Where(c=>c.Entity.Categories.Where(cat=>cat.Id == categoryId).Count()>0)
                    )
                    .Select(tc => new CategoryPresentation
                    {
                        Id = tc.Entity.Id,
                        Name = tc.Translation.Text,
                        ParentId = tc.Entity.Parent.Id
                    }).ToList();
                HttpContext.Current.Cache[cacheKey] = categories;
            } 
            return (List<CategoryPresentation>)HttpContext.Current.Cache[cacheKey];
        }

        public static List<CategoryPresentation> GetCachedCategories(this ZamovStorage context, int cityId, string language)
        {
            string cacheKey = CategoriesCachePrefix + cityId + "_" + language;
            if (HttpContext.Current.Cache[cacheKey] == null)
            {
                List<CategoryPresentation> categories = context.GetTranslatedCategories(language, true, cityId, false)
                        .Select(tc => new CategoryPresentation
                        {
                            Id = tc.Entity.Id,
                            Name = tc.Translation.Text,
                            ParentId = tc.Entity.Parent.Id
                        })
                        .ToList();
                categories.ForEach(c => c.PickChildren(categories));
                categories = categories.Where(c => c.ParentId == null).ToList();
                HttpContext.Current.Cache.Add(cacheKey, categories, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            }
            return (List<CategoryPresentation>)HttpContext.Current.Cache[cacheKey];
        }

        public static List<SelectListItem> GetCitiesFromContext(this ZamovStorage context, string language)
        {
            if (HttpContext.Current.Items[CitiesCachePrefix + language] == null)
            {
                HttpContext.Current.Items[CitiesCachePrefix + language] =
                     context.Cities.Where(c => c.Enabled).Join(context.Translations.Where(t => t.TranslationItemTypeId == (int)ItemTypes.City && t.Language == language),
                         c => c.Id, t => t.ItemId, (c, i) => new { Id = c.Id, Text = i.Text }).ToList().Select(kvp => new SelectListItem { Value = kvp.Id.ToString(), Text = kvp.Text }).ToList();
            }
            return (List<SelectListItem>)HttpContext.Current.Items[CitiesCachePrefix + language];
        }


        public static void ClearCategoriesCache(this Cache cache)
        {
            cache.ClearCache(key => key.StartsWith(CategoriesCachePrefix));
        }

        private static void ClearCache(this Cache cache, Func<string, bool> cacheKeyCondition)
        {
            List<string> keysToClear = new List<string>();

            IDictionaryEnumerator enumerator = cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (cacheKeyCondition(enumerator.Key.ToString()))
                    keysToClear.Add(enumerator.Key.ToString());
            }
            foreach (string key in keysToClear)
            {
                cache.Remove(key);
            }
        }
    }
}
