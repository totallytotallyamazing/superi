using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Dev.Controllers
{
    public class ArticlesController : Controller
    {
        public ActionResult Index(string language)
        {
            return View();
        }
    }
}
