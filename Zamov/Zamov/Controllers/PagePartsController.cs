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
        ZamovStorage context = new ZamovStorage();
        //
        // GET: /PageParts/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeaderSelectors()
        {
            List<City> cities = context.Cities.Select(c => c).ToList();
            List<Category> categories = context.Categories.Select(c => c).ToList();
            List<SelectListItem> citiesList = (from city in cities select new SelectListItem { Text = city.Name, Value = city.Id.ToString() }).ToList();
            context.DeleteTranslations(1, 1);
            //List<SelectListItem> categoriesList
            return View();
        }
    }
}
