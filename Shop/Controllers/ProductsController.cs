using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Helpers;
using System.Web.Security;
using Dev.Mvc.Runtime;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(int id, int? brandId, int? page, string orderBy)
        {
            ViewData["categoryId"] = id;
            ViewData["brandId"] = brandId;
            ViewData["showAdminLinks"] = true;
            ViewData["isAdmin"] = Roles.IsUserInRole("Administrators");
            ViewData["page"] = page ?? 0;
            ViewData["orderBy"] = orderBy;
            ViewData["action"] = "Index";
            WebSession.CurrentCategory = id;

            using (ShopStorage context = new ShopStorage())
            {
                IQueryable<Product> products = null;
                Category category = context.Categories.Include("Parent")
                    .First(c => c.Id == id);

                 products = context.Products
                        .Include("Brand")
                        .Include("ProductAttributeValues.ProductAttribute")
                        .Include("ProductAttributeStaticValues.ProductAttribute")
                        .Include("ProductImages")
                        .Include("Categories")
                        .Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value));
                if (category.Parent == null)
                {
                    ViewData["showAdminLinks"] = false;

                    products = products.Where(p=>p.Categories.Any(
                        c=>c.Id == id || (c.Parent!=null && c.Parent.Id == id)))
                        .Where(p => p.ShowInRoot);
                }
                else
                    products = products.Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value));

                orderBy = orderBy ?? string.Empty;
                products = ApplyOrdering(products, orderBy.ToLowerInvariant());

                ViewData["totalCount"] = products.Count();
                products = ApplyPaging(products, page);
                ViewData["title"] = category.Name;
                return View(products.ToList());
            }
        }

        IQueryable<Product> ApplyOrdering(IQueryable<Product> products, string orderBy)
        {
            switch (orderBy)
            {
                case "name":
                    return products.OrderBy(p => p.Name);
                case "brand":
                    return products.OrderBy(p => p.Brand.Name);
                case "onlynew":
                    return products.OrderBy(p => p.SortOrder).Where(p=>p.IsNew);
                default:
                    return products.OrderBy(p => p.SortOrder);
            }
        }

        IQueryable<Product> ApplyPaging(IQueryable<Product> products, int? page)
        {
            int currentPage = page ?? 0;
            SiteSettings settings = Configurator.LoadSettings();
            int pageSize = settings.PageSize;

            return products.Skip(currentPage * pageSize).Take(pageSize);
        }

        [OutputCache(NoStore=true, Duration=1, VaryByParam="*")]
        public ActionResult Show(int id)
        {
            HttpContext.Items["IsProductView"] = true;
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products
                    .Include("ProductImages")
                    .Include("ProductAttributeValues")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Include("ProductAttributeStaticValues.ProductAttribute")
                    .Include("Tags.Products.ProductImages")
                    .Include("Tags.Products.ProductAttributeStaticValues.ProductAttribute")
                    .Include("Tags.Products.Categories")
                    .Include("Categories")
                    .Include("Tags.Products.Brand")
                    .Include("Brand")
                    .Where(p => p.Id == id).First();
                ViewData["keywords"] = product.SeoKeywords;
                ViewData["description"] = product.SeoDescription;
                return View("ShowModal", product); 
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
                    .Include("ProductAttributeValues")
                    .Include("Categories")
                    .Include("ProductImages")
                    .Include("ProductAttributeStaticValues.ProductAttribute")
                    .Where(ContextExtension.BuildContainsExpression<Product, int>(p => p.Id, ids))
                    .OrderBy(p => p.SortOrder)
                    .ToList();
                return View("Index", products);
            }
        }
    }
}