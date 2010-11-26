using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Helpers;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(int id, int? brandId)
        {
            ViewData["categoryId"] = id;
            ViewData["brandId"] = brandId;
            WebSession.CurrentCategory = id;

            ViewData["showAdminLinks"] = true;
            using (ShopStorage context = new ShopStorage())
            {
                ViewData["title"] = context.Categories.Where(c => c.Id == id).Select(c => c.Name).First();

                List<Product> products = context.Products
                    .Include("Brand")
                    .Include("ProductAttributeValues")
                    .Include("ProductImages")
                    .Where(p => p.Category.Id == id).ToList();
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
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Include("Category")
                    .Include("Brand")
                    .Where(p => p.Id == id).First();
                return View(product); 
            }
        }
        public ActionResult Search(string searchField)
        {
            ViewData["tags"] = true;

            using (ShopStorage context = new ShopStorage())
            {
                int[] ids = context.GetSearchResults(searchField);
                var products = context.Products
                    .Include("Brand")
                    .Include("ProductImages")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Where(ContextExtension.BuildContainsExpression<Product, int>(p => p.Id, ids))
                    .ToList();
                return View("Index", products);
            }
        }
    }
}