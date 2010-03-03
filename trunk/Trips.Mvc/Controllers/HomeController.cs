using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trips.Mvc.Models;
using Dev.Helpers;

namespace Trips.Mvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ContentStorage context = new ContentStorage())
            {
                ViewData["id"] = "Home";
                string language = LocaleHelper.GetCultureName();
                Content content = context.Content
                    .Where(c => c.Language == language)
                    .Where(c => c.Name == "Home")
                    .FirstOrDefault();
                return View("Content", content);
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
