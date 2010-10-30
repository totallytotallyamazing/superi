using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.BrandCatalog.Controllers
{
    public class BrandsController : Controller
    {
        //
        // GET: /BrandCatalog/Brands/

        public ActionResult Index(int? id)
        {

            return View();
        }

    }
}
