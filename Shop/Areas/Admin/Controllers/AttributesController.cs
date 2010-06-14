using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class AttributesController : Controller
    {
        public ActionResult Index(int? id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                List<ProductAttribute> attributes = context.ProductAttributes.ToList();
                return View(attributes);
            }
        }
    }
}
