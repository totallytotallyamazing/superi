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

        public ActionResult Index()
        {
            using (ContentStorage context = new ContentStorage())
            {
                var articles = context.Articles.Select(a => a).ToList();
                return View(articles);
            }
            
        }

    }
}
