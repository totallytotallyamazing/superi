using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PolialClean.Models;

namespace PolialClean.Controllers
{
    public class BaseContentController : Controller
    {
        public ActionResult Index(string contentName)
        {
            ViewData["textName"] = contentName;
            SiteContent content = Utils.GetText(contentName);
            ViewData["text"] = content.Content;
            ViewData["contentId"] = content.Id;
            return View();
        }
    }
}
