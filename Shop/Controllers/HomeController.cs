using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Go", new { id = "home" });
        }

        [Content]
        public ActionResult Go(string id)
        {
            return View("Content");
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
