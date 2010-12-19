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

                products.ForEach(p => p.ProductAttributeValues.ToList()
                    .ForEach(pav => pav.ProductAttributeReference.Load()));

                return View(products);
            }
        }

        public ActionResult Show(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                var product = context.Products
                    .Include("ProductImages")
                    .Include("ProductAttributeValues")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Include("Category")
                    .Include("Brand")
                    .Where(p => p.Id == id).First();
                product.Tags.Load();
                product.Tags.ToList().ForEach(t => t.Products.Load());
                product.Tags.SelectMany(t => t.Products).ToList().ForEach(p => p.ProductAttributeValues.Load());
                product.Tags.SelectMany(t => t.Products).ToList().ForEach(p => p.ProductImages.Load());
                product.Tags.SelectMany(t => t.Products.SelectMany(p => p.ProductAttributeValues)).ToList().ForEach(pav => pav.ProductAttributeReference.Load());
                ViewData["categoryId"] = product.Category.Id;
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