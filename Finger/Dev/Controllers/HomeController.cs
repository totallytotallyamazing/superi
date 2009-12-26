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
    public class HomeController : BaseContentController
    {
        public ActionResult Broadcast(string name)
        {
            using (DataStorage context = new DataStorage())
            {
                string cultureName = LocaleHelper.GetCultureName();
                Article article = context.Articles.Where(a => a.Language == cultureName && a.Type == (int)ArticleType.LifeStyle).Select(a => a).First();
                return View(article);
            }
        }
    }
}
