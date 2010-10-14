using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Helpers;
using System.Web.Security;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(int id, int? brandId)
        {
            ViewData["categoryId"] = id;
            ViewData["brandId"] = brandId;
            ViewData["showAdminLinks"] = true;
            ViewData["isAdmin"] = Roles.IsUserInRole("Administrators");
            WebSession.CurrentCategory = id;

            using (ShopStorage context = new ShopStorage())
            {
                List<Product> products = null;
                Category category = context.Categories.Include("Parent").Include("Categories.Products.Brand")
                    .Include("Products.ProductImages")
                    .Include("Categories.Products.ProductImages")
                    .Include("Products.ProductVariants")
                    //.Include("Categories.Products.ProductAttributeValues.ProductAttribute")
                    .First(c => c.Id == id);
                if (category.Parent == null)
                {
                    ViewData["showAdminLinks"] = false;
                    products = category.Categories.SelectMany(c => c.Products)
                        .Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value))
                        .Union(category.Products)
                        .OrderBy(p => p.SortOrder)
                        .ToList();
                }
                else
                {
                    products = context.Products
                        .Include("Brand")
                        .Include("ProductAttributeValues.ProductAttribute")
                        .Include("ProductImages")
                        .Where(p => p.Categories.Any(c=>c.Id == id))
                        .Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value))
                        .OrderBy(p => p.SortOrder)
                        .ToList();
                }
                ViewData["title"] = category.Name;
                return View(products);
            }
        }

        public ActionResult Show(int id)
        {
            HttpContext.Items["IsProductView"] = true;
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products
                    .Include("ProductImages")
                    .Include("ProductAttributeValues")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Include("ProductVariants")
                    .Include("Brand")
                    .Where(p => p.Id == id).First();
                ViewData["keywords"] = product.SeoKeywords;
                ViewData["description"] = product.SeoDescription;
                return View(product); 
            }
        }

        public ActionResult Tags(int id)
        {
            WebSession.CurrentTag = id;

            ViewData["tags"] = true;
            ViewData["showAdminLinks"] = false;
            using (ShopStorage context = new ShopStorage())
            {
                var products = context.Products
                    .Include("Brand")
                    .Include("ProductImages")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Where(p => p.Tags.Where(t => t.Id == id).Count() > 0)
                    .OrderBy(p => p.SortOrder)
                    .ToList();
                return View("Index", products);
            }
        }

        public ActionResult Search(string searchField)
        {
            ViewData["tags"] = true;
            WebSession.CurrentTag = int.MinValue;
            WebSession.CurrentCategory = int.MinValue;

            using (ShopStorage context = new ShopStorage())
            {
                int[] ids = context.GetSearchResults(searchField);
                var products = context.Products
                    .Include("Brand")
                    .Include("ProductImages")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Where(ContextExtension.BuildContainsExpression<Product, int>(p => p.Id, ids))
                    .OrderBy(p => p.SortOrder)
                    .ToList();
                return View("Index", products);
            }
        }
    }
}