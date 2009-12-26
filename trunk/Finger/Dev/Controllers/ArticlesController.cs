using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;
using Dev.Helpers;

namespace Dev.Controllers
{
    public class ArticlesController : LocalizedController
    {
        public ActionResult Index(int? page)
        {
            using (DataStorage context = new DataStorage())
            {
                string cultureName = LocaleHelper.GetCultureName();
                List<Article> articles = context.Articles.Where(a => a.Language == cultureName).OrderByDescending(a => a.Date).Select(a => a).ToList();
                return View(articles);
            }
        }

        public ActionResult Show(string name)
        {
            using (DataStorage context = new DataStorage())
            {
                string cultureName = LocaleHelper.GetCultureName();
                Article article = context.Articles.Where(a => a.Language == cultureName).Select(a => a).First();
                return View(article);
            }
        }
    }
}
