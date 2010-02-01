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
        public ActionResult Index(int? page)
        {
            ViewData["text"] = "Новости";
            //using (DataStorage context = new DataStorage())
            //{
                //List<Article> articles = context.Articles.OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View("Index");
           // }
        }

        public ActionResult Press(int? page)
        {
            ViewData["text"] = "Пресса";
            return View("Index");
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
