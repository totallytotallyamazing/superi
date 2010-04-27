using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Mvc.Models;

namespace Lady.Mvc.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        public ActionResult Index()
        {
            using (ShopStorage context = new ShopStorage())
            {
                List<Brand> brands = context.Brands.ToList();
                return View(brands);
            }
        }

        [OutputCache(VaryByParam="*",  NoStore=true, Duration=1)]
        public ActionResult AddEdit(int? id)
        {
            if (id != null)
            { 
                
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddEdit(Brand brand)
        {
            return RedirectToAction("Index");
        }
    }
}
