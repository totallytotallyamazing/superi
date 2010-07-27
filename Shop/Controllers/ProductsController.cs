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
            ViewData["showAdminLinks"] = true;
            WebSession.CurrentCategory = id;

            using (ShopStorage context = new ShopStorage())
            {
                List<Product> products = null;
                Category category = context.Categories.Include("Parent").Include("Categories.Products.Brand")
                    .Include("Categories.Products.ProductImages")
                    //.Include("Categories.Products.ProductAttributeValues.ProductAttribute")
                    .Where(c => c.Id == id).First();
                if (category.Parent == null)
                {
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
                ViewData["title"] = category.Name;
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

        public ActionResult Tags(int id)
        {
            ViewData["tags"] = true;
            ViewData["showAdminLinks"] = false;
            using (ShopStorage context = new ShopStorage())
            {
                var products = context.Products
                    .Include("Brand")
                    .Include("ProductImages")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Where(p=>p.Tags.Where(t=>t.Id == id).Count()>0)
                    .ToList();
                return View("Index", products); 
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