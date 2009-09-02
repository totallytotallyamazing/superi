using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zamov.Models;
using System.Web.Caching;

namespace Zamov.Controllers
{
    public static class ContextCache
    {
        private static Cache Cache { get { return HttpContext.Current.Cache; } }

        public static List<Category> GetCachedCategories(this ZamovStorage context, int cityId, bool reload)
        {
            List<Category> result = new List<Category>();
            if (Cache["CityCategories_" + cityId] != null && !reload)
                result = (List<Category>)Cache["CityCategories_" + cityId];
            else
            {
                result = (from category in context.Categories.Include("Parent").Include("Dealers")
                          where category.Parent == null && category.Enabled
                          && category.Dealers.Where(d => d.Cities.Where(c => c.Id == cityId).Count() > 0).Count() > 0
                          select category).ToList();
                Cache["CityCategories_" + cityId] = result;
            }
            return result;
        }

        public static List<UnitPresentation> GetCachedUnitPresentations(this ZamovStorage context, bool reload)
        {
            List<UnitPresentation> result = new List<UnitPresentation>();
            if (Cache["Units"] != null && !reload)
                result = (List<UnitPresentation>)Cache["Units"];
            else
            {
                result = (from unit in context.MeassureUnits select new UnitPresentation { Id = unit.Id, Name = unit.Name }).ToList();
                Cache["Units"] = result;
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
