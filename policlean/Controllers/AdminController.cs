using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PolialClean.Models;

namespace PolialClean.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditText(string contentName, string controllerName)
        {
            ViewData["controllerName"] = controllerName;
            ViewData["text"] = Utils.GetText(contentName).Content;
            ViewData["contentName"] = controllerName;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditText(string text, string controllerName, string contentName)
        {
            Utils.SetText(contentName, HttpUtility.HtmlDecode(text));
            return RedirectToAction("Index", controllerName, new { contentName = contentName });
        }

    }
}
