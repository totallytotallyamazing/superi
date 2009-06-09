﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zamov.Models;
using System.Globalization;
using System.Threading;

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

        public ActionResult Ru()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
            //.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            return RedirectToAction("Index");
        }
    }
}
