using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Oksi.Models;

namespace Oksi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Content]
        public ActionResult Content(string id)
        {
            return View();
        }

        public ActionResult IndexContent()
        {
            return View();
        }

        public ActionResult LatestVideo()
        {
            using (DataStorage context = new DataStorage())
            {
                Clip clip = context.Clips.OrderBy(c => c.SortOrder).First();
                return View(clip);
            }
        }

        public ActionResult LatestNews()
        {
            using (DataStorage context = new DataStorage())
            {
                Article article = context.Articles.OrderByDescending(a => a.Date).First();
                return View(article);
            }
        }

        public ActionResult RecentNews()
        {
            using (DataStorage context = new DataStorage())
            {
                List<Article> articles = context.Articles
                .Where(a => a.Type == 1)
                .OrderByDescending(a => a.Date)
                .Skip(1)
                .Take(4)
                .Select(a => a).ToList();
                return View(articles);
            }
        }

        public ActionResult PhotoSession()
        {
            using (DataStorage context = new DataStorage())
            {
                Gallery gallery = context.Galleries.OrderByDescending(g => g.Id).First();
                gallery.Images.Load();
                List<Image> images = gallery.Images.Take(3).ToList();
                ViewData["name"] = gallery.Name;
                ViewData["comments"] = gallery.Comments;
                ViewData["id"] = gallery.Id;
                return View(images);
            }
        }
    }
}
