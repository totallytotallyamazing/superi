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
                List<ProductAttribute> values = context.Products
                    //.Include("Category.ProductAttributes.ProductArributeValues")
                    .Where(p => p.Id == id).Select(p => p.Category)
                    .SelectMany(c => c.ProductAttributes).ToList();
                return View(values); 
            }
        }

    }
}
