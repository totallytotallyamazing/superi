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
            using (DataStorage context = new DataStorage())
            {
                List<Article> articles = context.Articles
                    .Where(a=>!id.HasValue || a.Id == id.Value).
                    OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View("Index", articles);
            }
        }

        public ActionResult Press(int? id)
        {
            using (DataStorage context = new DataStorage())
            {
                List<Article> articles = context.Articles
                    .Where(a => !id.HasValue || a.Id == id.Value)
                    .OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View("Index", articles);
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
