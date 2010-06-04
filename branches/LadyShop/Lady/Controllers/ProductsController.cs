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
        public ActionResult Index(int id, int? brandId)
        {
            ViewData["categoryId"] = id;
            ViewData["brandId"] = brandId;
            using (ShopStorage context = new ShopStorage())
            {
                List<Product> products = context.Products
                    .Include("Brand")
                    .Include("ProductAttributeValues")
                    .Include("ProductImages")
                    .Where(p => p.Category.Id == id).ToList();

                products.ForEach(p => p.ProductAttributeValues.ToList()
                    .ForEach(pav => pav.ProductAttributeReference.Load()));
                return View(products);
            }
        }
    }
}