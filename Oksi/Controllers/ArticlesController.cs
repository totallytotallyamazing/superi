using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Oksi.Models;
using Oksi.Helpers;

namespace Oksi.Controllers
{
    public class ArticlesController : Controller
    {
        public ActionResult Index(int? id)
        {
            ViewData["type"] = 1;
            using (DataStorage context = new DataStorage())
            {
                List<Article> articles = context.Articles
                    .Where(a => !id.HasValue || a.Id == id.Value)
                    .Where(a => a.Type == 1)
                    .OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View("Index", articles);
            }
        }

        public ActionResult ArticlesFull(int? id)
        {
            ViewData["type"] = 1;
            using (DataStorage context = new DataStorage())
            {
                List<Article> articles = context.Articles
                    .Where(a => !id.HasValue || a.Id == id.Value)
                    .Where(a => a.Type == 1)
                    .OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View("ArticlesFull", articles);
            }
        }

        public ActionResult Press(int? id)
        {
            ViewData["type"] = 2;
            using (DataStorage context = new DataStorage())
            {
                List<Article> articles = context.Articles
                    .Where(a => !id.HasValue || a.Id == id.Value)
                    .Where(a => a.Type == 2)
                    .OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View("Index", articles);
            }
        }

        public ActionResult PressFull(int? id)
        {
            ViewData["type"] = 2;
            using (DataStorage context = new DataStorage())
            {
                List<Article> articles = context.Articles
                    .Where(a => !id.HasValue || a.Id == id.Value)
                    .Where(a => a.Type == 2)
                    .OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View("ArticlesFull", articles);
            }
        }

        public ActionResult Show(string name)
        {
            using (DataStorage context = new DataStorage())
            {
                Article article = context.Articles.Where(a => a.Name == name).Select(a => a).First();
                return View(article);
            }
        }
    }
}
