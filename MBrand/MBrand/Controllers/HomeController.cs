using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBrand.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult White(string redirectUrl)
        {
            HttpCookie blackCookie = Request.Cookies.Get("black");
            HttpCookie newCookie = new HttpCookie("black", "false");
            newCookie.Path = "/";
            newCookie.Expires = DateTime.Now.AddYears(1);
            if (blackCookie == null)
                Response.AppendCookie(newCookie);
            else
                Response.SetCookie(newCookie);
            return Redirect(redirectUrl);
        }

        public ActionResult Black(string redirectUrl)
        {
            HttpCookie blackCookie = Request.Cookies.Get("black");
            HttpCookie newCookie = new HttpCookie("black", "true");
            newCookie.Path = "/";
            newCookie.Expires = DateTime.Now.AddYears(1);
            if (blackCookie == null)
                Response.AppendCookie(newCookie);
            else
                Response.SetCookie(newCookie);
            return Redirect(redirectUrl);
        }
    }
}
