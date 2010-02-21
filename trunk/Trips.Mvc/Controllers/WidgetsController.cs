using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Trips.Mvc.Controllers
{
    public class WidgetsController : Controller
    {
        string[] widgets = { "Smoking" };

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Widget()
        {
            Random rnd = new Random();
            string widgetName = widgets[rnd.Next(widgets.Length - 1)];
            return View(widgetName);
        }

    }
}
