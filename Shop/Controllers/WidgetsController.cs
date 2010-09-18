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
        public ActionResult News()
        {
            using (ContentStorage context = new ContentStorage())
            {
                var articles = context.Articles
                    .Where(a => a.Type == 1)
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
                List<Article> articles = null;
                int articlesCount = context.Articles.Where(a => a.Type == 2).Count();
                Random rnd = new Random();
                if (articlesCount > 0)
                {
                    int index = rnd.Next(articlesCount - 1);
                    articles = context.Articles
                        .Where(a => a.Type == 2)
                        .OrderByDescending(a => a.Date)
                        .Skip(index)
                        .Take(1).ToList();
                    ViewData["type"] = 2;
                    ViewData["index"] = index + 1;
                }
                return View(articles);
            }
        }
    }
}
