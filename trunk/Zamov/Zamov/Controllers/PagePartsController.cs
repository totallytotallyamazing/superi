using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class PagePartsController : Controller
    {
        //
        // GET: /PageParts/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeaderSelectors()
        {

            using (ZamovStorage context = new ZamovStorage())
            {
                string currentLanguage = SystemSettings.CurrentLanguage;
                List<City> cities = context.Cities.Select(c => c).ToList();
                List<Category> categories = context.Categories.Select(c => c).ToList();
                List<SelectListItem> citiesList = (from city in cities select new SelectListItem { Text = city.GetName(currentLanguage), Value = city.Id.ToString() }).ToList();
                List<SelectListItem> categoriesList = (from category in categories select new SelectListItem { Text = category.GetName(currentLanguage), Value = category.Id.ToString() }).ToList();
                ViewData["citiesList"] = citiesList;
                ViewData["categoriesList"] = categoriesList;
                return View();
            }
        }
    }
}
