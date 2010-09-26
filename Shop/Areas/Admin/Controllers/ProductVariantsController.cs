using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class ProductVariantsController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewData["id"] = id;
            using (ShopStorage context = new ShopStorage())
            {
                var productVariants = context.ProductVariants.Where(pv => pv.Product.Id == id).ToList();
                return View(productVariants); 
            }
        }

        [OutputCache(NoStore = false, Duration = 1, VaryByParam = "*")]
        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            if (id.HasValue)
                using (ShopStorage context = new ShopStorage())
                    return View(context.ProductVariants.First(pv => pv.Id == id.Value));
            return View();
        }

        [HttpPost]
        public void AddEdit(FormCollection form)
        { 
        }
    }
}
