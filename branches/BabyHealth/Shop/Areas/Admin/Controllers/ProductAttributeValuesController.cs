using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ProductAttributeValuesController : Controller
    {
        public ActionResult Index(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                List<ProductAttribute> values = context.Categories
                    .Include("ProductArributeValues")
                    .Where(c => c.Id == id).SelectMany(c=>c.ProductAttributes).ToList();
                return View(values); 
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            using(ShopStorage context = new ShopStorage())
	        {
                ProductAttributeValue val = context.ProductAttributeValues.Where(pav => pav.Id == 1).First();
                Product product = context.Products.Include("ProductAttributeValues").Where(p => p.Id == 2).First();
                if (product.ProductAttributeValues.Where(pv => pv.Id == val.Id).Count() == 0)
                {
                    product.ProductAttributeValues.Add(val);
                }
                context.SaveChanges();
	        }
            return RedirectToAction("Somewhere");
        }
    }
}
