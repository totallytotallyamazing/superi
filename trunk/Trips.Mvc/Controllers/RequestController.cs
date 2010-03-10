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
            using (RouteStorage context = new RouteStorage())
            {
                var cities = context.Cities.Include("CityNames").Where(c => c.Id == 1 || c.Id == 3).ToList();
                List<SelectListItem> fromCity = cities.Select(c => new SelectListItem
                    {
                        Text = c.CityNames.ToDictionary(cn => cn.Language, cn => cn.Name)[LocaleHelper.GetCultureName()],
                        Value = c.Id.ToString()
                    }).ToList();

                ViewData["fromCityId"] = fromCity;
            }

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

        public ActionResult RouteData(long? fromCityId, long? toCityId)
        {
            if (fromCityId.HasValue && toCityId.HasValue)
            {
                using (RouteStorage context = new RouteStorage())
                {
                    Route route = context.Routes.Include("RoutePrices")
                        .Where(r => r.FromCityId == fromCityId.Value)
                        .Where(r => r.ToCityId == toCityId.Value)
                        .FirstOrDefault();

                    if (route != null)
                    {
                        ViewData["distance"] = route.Distance;

                        Func<long, float> getPrice = (cl) =>
                        {
                            float price = route.RoutePrices
                                .Where(r => r.ClassId == cl)
                                .Select(r => r.Price)
                                .First();
                            return price;
                        };

                        var grouppedClasses = (from oi in WebSession.OrderItems
                                               group oi by oi.Value.Class
                                                   into g
                                                   select new
                                                       {
                                                           Class = g.Key,
                                                           Price = g.Sum(i => i.Value.Quantity * getPrice(g.Key))
                                                       })
                                                      .ToDictionary(g => ((CarAdClasses)g.Class),
                                                        g => g.Price);
                        return View(grouppedClasses);
                    }
                }
            }
            return View("NoRoute");
        }
    }
}
