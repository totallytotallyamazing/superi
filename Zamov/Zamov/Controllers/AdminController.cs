using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Script.Serialization;

namespace Zamov.Controllers
{
    [Authorize(Roles="Administrators")]
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cities()
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                List<City> cities = context.Cities.Select(c => c).ToList();
                return View(cities);
            }
        }

        public ActionResult DeleteCity(int id)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                City city = (from c in context.Cities where c.Id == id select c).First();
                context.DeleteObject(city);
                context.SaveChanges();
                context.DeleteTranslations(id, (int)ItemTypes.City);
            }
            return RedirectToAction("Cities");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InsertCity(FormCollection form)
        {
            using (ZamovStorage context = new ZamovStorage())
            {
                City city = new City();
                city.Name = form["cityName"];
                city.Names.Clear();
                city.Names["ru-RU"] = form["cityRusName"];
                city.Names["uk-UA"] = form["cityUkrName"];
                city.Enabled = form["cityEnabled"].Contains("true");
                context.AddToCities(city);
                context.SaveChanges();
                context.UpdateTranslations(city.Id, (int)ItemTypes.City, city.NamesXml);
            }
            return RedirectToAction("Cities");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateCities(FormCollection form)
        {
            //JavaScriptSerializer seializer = new JavaScriptSerializer();
            //Dictionary<string, Dictionary<string, string>> updates = seializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(
            //    form["updates"]
            //    );
            //foreach (string key in updates.Keys)
            //{
            //    int itemId = int.Parse(key);
            //    foreach
            //    using (ZamovStorage context = new ZamovStorage())
            //    {
            //        context.Translations.Select(t=>t).Where(t=>t.ItemId==);
            //    }
            return RedirectToAction("Cities");
        }
    }
}
