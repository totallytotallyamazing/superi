using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    [Authorize(Roles="Administrators")]
    public class AdminController : Controller
    {
        StorageContext context = StorageContext.Instanse;
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cities()
        {
            List<City> cities = context.Cities.Select(c => c).ToList();
            return View(cities);
        }

        public ActionResult DeleteCity(int id)
        {
            City city = (from c in context.Cities where c.Id == id select c).First();
            context.DeleteObject(city);
            context.SaveChanges();
            return RedirectToAction("Cities");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InsertCity(FormCollection form)
        {
            City city = new City();
            city.Name = form["cityName"];
            context.AddToCities(city);
            context.SaveChanges();
            Dictionary<string, string> translations = new Dictionary<string, string>();
            translations["ru-RU"] = form["cityRusName"];
            translations["uk-UA"] = form["cityUkrName"];
            city.UpdateTranslations(translations);
            return RedirectToAction("Cities");
        }
    }
}
