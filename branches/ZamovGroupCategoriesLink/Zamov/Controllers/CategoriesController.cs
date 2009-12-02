using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using Zamov.Helpers;
using System.Data.Objects;

namespace Zamov.Controllers
{
    public class CategoriesController : Controller
    {
        [BreadCrumb(CategoryId=true)]
        public ActionResult Index()
        {
            string menuHeader = null;
            using (ZamovStorage context = new ZamovStorage())
            {
                menuHeader = (from name in context.Translations
                              where name.ItemId == SystemSettings.CategoryId
                              && name.Language == SystemSettings.CurrentLanguage
                              && name.TranslationItemTypeId == (int)ItemTypes.SubCategoriesName
                              select name.Text).FirstOrDefault();
            }
            if(string.IsNullOrEmpty(menuHeader))
                menuHeader = ResourcesHelper.GetResourceString("SubCategories");

            ViewData["menuHeader"] = menuHeader;
            List<Category> subCategories = ContextCache.GetSubCategories(SystemSettings.CategoryId, false);


            ViewData["leftMenuItems"] = GetLeftMenuItems();
            return View(subCategories);
        }

        public ActionResult SelectCategory(int id)
        {
            SystemSettings.SubCategoryId = id;
            if (SystemSettings.CategoryId == int.MinValue)
                SystemSettings.CategoryId = GetParentCategoryId(id);
            List<SelectListItem> leftMenuItems = GetLeftMenuItems();
            string categoryName = leftMenuItems.Where(lmi => lmi.Value == id.ToString()).Select(lmi => lmi.Text).SingleOrDefault();
            SystemSettings.CategoryName = categoryName;
            return RedirectToRoute("Default", new { controller="Dealers", action = "Index", id="" });
        }

        private int GetParentCategoryId(int categoryId)
        {

            if (HttpContext.Cache["ParentCategoryId_" + categoryId] == null)
            {
                int result = int.MinValue;
                using (ZamovStorage context = new ZamovStorage())
                {
                    Category category = context.Categories.Include("Parent").Where(c => c.Id == categoryId).Select(c => c).FirstOrDefault();
                    if (category != null)
                    {
                        if (category.Parent == null && !category.ParentReference.IsLoaded)
                            category.ParentReference.Load();
                        if (category != null)
                            result = category.Id;
                        else
                            result = categoryId;
                    }
                }
                HttpContext.Cache["ParentCategoryId_" + categoryId] = result;
            }
            return (int)HttpContext.Cache["ParentCategoryId_" + categoryId];
        }

        private List<SelectListItem> GetLeftMenuItems()
        {
            if (HttpContext.Cache["categoryItems_" + SystemSettings.CategoryId] == null)
            {
                List<Category> subCategories = ContextCache.GetSubCategories(SystemSettings.CategoryId, false);

                List<SelectListItem> leftMenuItems = (from category in subCategories
                                                      select new SelectListItem
                                                      {
                                                          Text = category.GetName(SystemSettings.CurrentLanguage),
                                                          Value = category.Id.ToString()
                                                      }).ToList();

                HttpContext.Cache["categoryItems_" + SystemSettings.CategoryId] = leftMenuItems;
            }
            return ((List<SelectListItem>)HttpContext.Cache["categoryItems_" + SystemSettings.CategoryId]);
        }
    }
}
