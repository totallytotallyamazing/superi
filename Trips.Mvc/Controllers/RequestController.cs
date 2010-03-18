using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trips.Mvc.Models;
using Dev.Helpers;
using System.Text;
using Trips.Mvc.Runtime;
using System.Net.Mail;

namespace Trips.Mvc.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Index()
        {
            string script = "<script type=\"text/javascript\">var euroRate = {0}; var dollarRate = {1}; var rubleRate = {2};</script>";
            ViewData["script"] = string.Format(script, Configurator.GetSetting("EuroRate"), Configurator.GetSetting("DollarRate"), Configurator.GetSetting("RubleRate"));
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

            ViewData["toCity"] = WebSession.ToCity;
            ViewData["toCityId"] = WebSession.ToCityId;
            ViewData["moreDetails"] = WebSession.MoreTripDetails;

            ViewData["hasItems"] = WebSession.OrderItems.Count != 0;
            return View();
        }

        public ActionResult DeleteOrderItem(long id)
        {
            WebSession.OrderItems.Remove(id);
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PersonalData(long fromCityId, string toCity, long? toCityId, string moreDetails)
        {
            WebSession.FromCityId = fromCityId;

            using (RouteStorage context = new RouteStorage())
            {
                string language = LocaleHelper.GetCultureName();
                WebSession.FromCity = context.Cities.Where(c=>c.Id == fromCityId)
                    .Select(c=>c.CityNames.Where(cn=>cn.Language == language).Select(cn=>cn.Name).FirstOrDefault())
                    .First(); 
            }

            WebSession.ToCity = toCity;
            WebSession.ToCityId = (toCityId.HasValue) ? toCityId.Value : 0;
            WebSession.MoreTripDetails = moreDetails;

            ViewData["name"] = WebSession.Name;
            ViewData["phone"] = WebSession.Phone;
            ViewData["email"] = WebSession.Email;
            
            return View();
        }

        public ActionResult VerifyData(string name, string phone, string email)
        {
            WebSession.Name = name;
            WebSession.Phone = phone;
            WebSession.Email = email;

            ViewData["moreDetails"] = WebSession.MoreTripDetails.Replace("\r", "<br />");
            ViewData["contactsData"] = WebSession.Name + "<br />" + WebSession.Phone + "<br />" + WebSession.Email;
            ViewData["route"] = WebSession.FromCity + " &mdash; " + WebSession.ToCity;

            return View();
        }

        public ActionResult Send()
        {
            //List<MailAddress> to = new List<MailAddress>();
            //to.Add(new MailAddress(Configurator.GetSetting("ReceiverMail")));
            //MailHelper.SendTemplate("mailinator@trips.kiev.ua", to, "Заявка на сайте trips.kiev.ua",
            //    "MailTemplate.htm", null, true, WebSession.Name, WebSession.Phone, WebSession.Email, 
            //    WebSession.FromCity, WebSession.ToCity,
            //    WebSession.MoreTripDetails.Replace("\r", "<br />"), CreateRequestTable());

            //WebSession.ClearOrder();

            return View();
        }

        private string CreateRequestTable()
        {
            string url = Request.Url.Scheme + ":" + Request.Url.Authority + Request.ApplicationPath;
            StringBuilder result = new StringBuilder();
            foreach (var item in WebSession.OrderItems)
            {
                result.Append("<tr>");
                result.AppendFormat("<td><img src=\"{0}ImageCache/thumbnail3/{1}\" /></td>",
                    url, item.Value.ImageSource);
                result.AppendFormat("<td>{0} ({1})</td>", item.Value.AdModel, item.Value.Year);
                result.AppendFormat("<td>{0}</td>", item.Value.Quantity);
                result.Append("</tr>");
            }
            return result.ToString();
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

        public void UpdateQuantity(long id, int quantity)
        {
            if (WebSession.OrderItems.ContainsKey(id))
            {
                WebSession.OrderItems[id].Quantity = quantity;
            }
        }

        public ActionResult RoutesData(long? fromCityId, long? toCityId)
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
