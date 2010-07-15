using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trips.Mvc.Runtime;
using System.Globalization;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Admin/Settings/

        public ActionResult Index()
        {
            return View(Configurator.LoadSettings());
        }

        [HttpPost]
        public ActionResult Index(SiteSettings siteSettings)
        {
            Configurator.SaveSettings(siteSettings);
            return RedirectToAction("Index");
        }

    }
}
