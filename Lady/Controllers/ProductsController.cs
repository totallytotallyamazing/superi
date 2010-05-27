using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Models;

namespace Lady.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                List<Product> products = context.Products.Include("Brands").Where(p => p.Category.Id == id).ToList();
                return View();
            }
        }
    }
}