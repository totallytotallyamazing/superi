using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Helpers;

namespace Trips.Mvc.Controllers
{
    public class WidgetsController : Controller
    {
        string[] widgets = { "Smoking", "Beer", "Late", "Luggage" };

        string[] rightBanners = { "Map", "Customs", "Counter", "Translate" };

        string[] decor = { "Decor1", "Decor2", "Decor3" };

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Widget()
        {
            Random rnd = new Random();
            string widgetName = widgets[rnd.Next(widgets.Length - 1)];
            return View(widgetName + "_" + LocaleHelper.GetCultureName());
        }

        public ActionResult RightBanner()
        {
            Random rnd = new Random();
            string imgUrl = rightBanners[rnd.Next(rightBanners.Length - 1)];
            ViewData["url"] = "/Content/RightBanners/" + LocaleHelper.GetCultureName() + "/" + imgUrl + ".png";
            return View();
        }

        public ActionResult Decor()
        {
            Random rnd = new Random();
            string widgetName = decor[rnd.Next(widgets.Length - 1)];
            return View(widgetName);
        }
    }
}
