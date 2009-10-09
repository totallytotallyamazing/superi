using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace PolialClean.Controllers
{
    public class BaseContentController : Controller
    {
        public ActionResult Index(string contentName)
        {
            ViewData["textName"] = contentName;
            ViewData["text"] = Utils.GetText(contentName);
            return View();
        }
    }
}
