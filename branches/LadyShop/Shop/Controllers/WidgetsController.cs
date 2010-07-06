using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class WidgetsController : Controller
    {
        [ChildActionOnly]
        public ActionResult News()
        {
            using (ContentStorage context = new ContentStorage())
            {
                var articles = context.Articles
                    .OrderByDescending(a => a.Date)
                    .Take(3).ToList();
                ViewData["type"] = 1;
                return View(articles);
            }
        }
    }
}
