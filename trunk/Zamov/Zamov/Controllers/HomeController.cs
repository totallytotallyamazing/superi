using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zamov.Models;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Web.Routing;

namespace Zamov.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int currentCity, int currentCategory)
        {
            SystemSettings.CityId = currentCity;
            SystemSettings.CategoryId = currentCategory;
            return Redirect("~/Categories");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Agreement()
        {
            return View();
        }

        public ActionResult SetUkrainian(string returnUrl)
        {
            SystemSettings.CurrentLanguage = "uk-UA";
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SetRussian(string returnUrl)
        {
            SystemSettings.CurrentLanguage = "ru-RU";
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
