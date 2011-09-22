using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class BrandCatalogController : Controller
    {
        //
        // GET: /BrandCatalog/

        public ActionResult Index()
        {
            using (var context = new BrandCatalogStorage())
            {
                var catalogs = context.BrandCatalogCategory.Include("BrandCatalogFile").ToList();
                return View(catalogs);
            }
        }

    }
}
