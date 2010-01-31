using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Oksi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
            return View();
        }

        public ActionResult RecentNews()
        {
            return View();
        }

        public ActionResult PhotoSession()
        {
            return View();
        }
    }
}
