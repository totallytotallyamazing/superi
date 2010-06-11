using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Helpers;

namespace Lady.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(int id, int? brandId)
        {
            ViewData["categoryId"] = id;
            ViewData["brandId"] = brandId;
            ViewData["showAdminLinks"] = true;
            using (ShopStorage context = new ShopStorage())
            {
                List<Product> products = null;
                Category category = context.Categories.Include("Parent").Include("Categories.Products.Brand")
                    .Include("Categories.Products.ProductImages")
                    //.Include("Categories.Products.ProductAttributeValues.ProductAttribute")
                    .Where(c => c.Id == id).First();
                if (category.Parent == null)
                {
                    WebSession.CurrentCategory = id;
                    ViewData["showAdminLinks"] = false;

                    products = category.Categories.SelectMany(c => c.Products).Union(category.Products).ToList();
                }
                else
                {
                    products = context.Products
                        .Include("Brand")
                        .Include("ProductAttributeValues.ProductAttribute")
                        .Include("ProductImages")
                        .Where(p => p.Category.Id == id)
                        .Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value))
                        .ToList();
                }

                return View(products);
            }
        }

        public ActionResult Show(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products
                    .Include("ProductImages")
                    .Include("ProductAttributeValues")
                    .Where(p => p.Id == id).First();
                return View(product); 
            }
        }
    }
}