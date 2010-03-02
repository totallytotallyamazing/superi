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
        public ActionResult Content(string contentName)
        {
            return View();
        }

        public ActionResult IndexContent()
        {
            return View();
        }

        public ActionResult LatestVideo()
        {
            return View();
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
            return View();
        }

        public ActionResult PhotoSession()
        {
            using (DataStorage context = new DataStorage())
            {
                Gallery gallery = context.Galleries.OrderByDescending(g=>g.Id).First();
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
