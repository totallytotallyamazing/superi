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
    public class HomeController : LocalizedController
    {
        [ContentMethod]
        public ActionResult Index()
        {
            ViewData["year"] = DateTime.Now.Year;
            ViewData["month"] = DateTime.Now.Month;
            return View();
        }

        public ActionResult Broadcast(string contentName)
        {
            ViewData["expand"] = false;

            using (DataStorage context = new DataStorage())
            {
                string cultureName = LocaleHelper.GetCultureName();
                Article article = context.Articles.Where(a => a.Language == cultureName && a.Type == (int)ArticleType.LifeStyle && a.Name == contentName).Select(a => a).First();
                ViewData["year"] = article.Date.Year;
                ViewData["month"] = article.Date.Month;
                return View(article);
            }
        }
    }
}
