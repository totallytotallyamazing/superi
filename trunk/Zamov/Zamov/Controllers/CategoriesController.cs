using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            List<Category> subCategories = ContextCache.GetSubCategories(SystemSettings.CategoryId, false);
            List<SelectListItem> leftMenuItems = (from category in subCategories
                                                  select new SelectListItem
                                                  {
                                                      Text = category.GetName(SystemSettings.CurrentLanguage),
                                                      Value = category.Id.ToString()
                                                  }).ToList();
            HttpContext.Cache["categoryItems"] = leftMenuItems;
            ViewData["leftMenuItems"] = leftMenuItems;
            return View();
        }

        public ActionResult SelectCategory(int id)
        {
            SystemSettings.CategoryId = id;
            List<SelectListItem> leftMenuItems = (List<SelectListItem>)HttpContext.Cache["categoryItems"];
            string categoryName = leftMenuItems.Where(lmi => lmi.Value == id.ToString()).Select(lmi => lmi.Text).SingleOrDefault();
            SystemSettings.CategoryName = categoryName;
            HttpContext.Cache.Remove("categoryItems");
            return Redirect("~/Dealers");
        }
    }
}
