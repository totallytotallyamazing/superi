using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trips.Mvc.Models;
using Dev.Helpers;

namespace Trips.Mvc.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            using (ContentStorage context = new ContentStorage())
            {
                string language = LocaleHelper.GetCultureName();
                List<Article> articles = context.Articles.Where(a => a.Language == language)
                    .OrderByDescending(a => a.Date).ToList();
                return View(articles);
            }
        }

    }
}
