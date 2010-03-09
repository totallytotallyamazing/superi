using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trips.Mvc.Models;
using Dev.Helpers;

namespace Trips.Mvc.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Index()
        {


            ViewData["hasItems"] = WebSession.OrderItems.Count != 0;
            return View();
        }

        public ActionResult PersonalData()
        {
            return View();
        }

        public ActionResult PickCity(string term)
        {
            using (RouteStorage context = new RouteStorage())
            {
                string language = LocaleHelper.GetCultureName();
                var cities = context.CityNames.Include("City").Where(c => c.Language == language)
                    .Where(cn => cn.Name.StartsWith(term))
                    .Select(cn => new
                    {
                        value = cn.Name,
                        id = cn.City.Id
                    }).ToList();
                return Json(cities);
            }
        }

    }
}
