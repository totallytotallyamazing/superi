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

        public ActionResult About()
        {
            return View();
        }

        public ActionResult SetUkrainian()
        {
            SystemSettings.CurrentLanguage = "uk-UA";
            return RedirectToAction("Index");
        }

        public ActionResult SetRussian()
        {
            SystemSettings.CurrentLanguage = "ru-RU";
            return RedirectToAction("Index");
        }

    }
}
