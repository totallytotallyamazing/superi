using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Superi.Web.Mvc.Localization;

namespace Shop.Controllers
{
    public class ArticlesController : Controller
    {
        //
        // GET: /Articles/

        public ActionResult Index(int? type)
        {
            type = type ?? 1;

            ViewData["css"] = "/Content/Articles.css";
            ViewData["title"] = Shop.Resources.Global.Events;

            ViewData["type"] = type;
            using (ContentStorage context = new ContentStorage())
            {
                var articles = context.Articles.Where(a => a.Type == type)
                    .OrderByDescending(a => a.Date)
                    .Localize((a, l) => new { Article = a, Localizations = l}, context.ContentLocalResource, null)
                    .ToList()
                    .Select(item=>item.Article.UpdateValues(item.Localizations))
                    .OrderByDescending(a => a.Date);
                return View(articles);
            }
            
        }

    }
}
