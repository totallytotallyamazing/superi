using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Models;

namespace Lady.Controllers
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

        [ChildActionOnly]
        public ActionResult Categories()
        {
            using (ShopStorage context = new ShopStorage())
            {
                List<Category> categories = context.Categories.Where(c => c.Parent == null).ToList();
                return View(categories);
            }
        }
    }
}
