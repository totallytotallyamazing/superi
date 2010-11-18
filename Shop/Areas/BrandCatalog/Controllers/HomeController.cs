using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.BrandCatalog.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /BrandCatalog/Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}
