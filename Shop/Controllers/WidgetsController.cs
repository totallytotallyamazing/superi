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
                    //.Where(a=>a.Type=1)
                    .OrderByDescending(a => a.Date)
                    .Take(1).ToList();
                ViewData["type"] = 1;
                return View(articles);
            }
        }

        public ActionResult Myths()
        {
            using (ContentStorage context = new ContentStorage())
            {
                var articles = context.Articles
                    //.Where(a=>a.Type=2)
                    .OrderByDescending(a => a.Date)
                    .Take(1).ToList();

                return View(articles);
            }
        }
    }
}
