using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ArticlesController : Controller
    {
        //
        // GET: /Articles/

        public ActionResult Index(int? type)
        {
            type = type ?? 1;
            switch (type)
            {
                case 1:
                    ViewData["title"] = "НАШИ СОБЫТИЯ";
                    ViewData["css"] = "/Content/Articles.css";
                    break;
                case 2:
                    ViewData["title"] = "Мифы";
                    ViewData["css"] = "/Content/Myths.css";
                    break;
            }

            ViewData["type"] = type;
            using (ContentStorage context = new ContentStorage())
            {
                var articles = context.Articles.Where(a => a.Type == type).OrderByDescending(a => a.Date).ToList();
                return View(articles);
            }
            
        }

    }
}
