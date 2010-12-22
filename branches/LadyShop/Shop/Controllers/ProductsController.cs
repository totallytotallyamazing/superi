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

        public ActionResult ExtendedSearch() 
        {
            using (ShopStorage context= new ShopStorage())
            {
                var categories = context.Categories.Select(c => new { Name = c.Name, Id = c.Id }).ToList();
                ViewData["CategoryId"] = new List<SelectListItem> { new SelectListItem { Text = null, Value = null, Selected = true } }.Union(categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = false
                })).ToList();

                var brands = context.Brands.Select(c => new { Name = c.Name, Id = c.Id }).ToList();
                ViewData["BrandId"] = new List<SelectListItem> { new SelectListItem { Text = null, Value = null, Selected = true } }.Union(brands.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = false
                })).ToList();

                var sizes = context.ProductAttributeValues.Where(pav => pav.ProductAttribute.Id == 1).Select(pav => new { Value = pav.Value, Id = pav.Id }).ToList();
                ViewData["SizeId"] = new List<SelectListItem> { new SelectListItem { Text = null, Value = null, Selected = true } }.Union(sizes.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Value,
                    Selected = false
                })).ToList();

                var contents = context.ProductAttributeValues.Where(pav => pav.ProductAttribute.Id == 3).Select(pav => new { Value = pav.Value, Id = pav.Id }).ToList();
                ViewData["ContentId"] = new List<SelectListItem> { new SelectListItem { Text = null, Value = null, Selected = true } }.Union(contents.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Value,
                    Selected = false
                })).ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult ExtendedSearch(ExtendedSearchModel extendedSearchModel)
        { 
            ViewData["tags"] = true;
            using (ShopStorage context = new ShopStorage())
            {
                int[] ids = { };
                if(!string.IsNullOrWhiteSpace(extendedSearchModel.Phrase))
                    ids = context.GetSearchResults(extendedSearchModel.Phrase);
                var products = context.Products
                    .Include("Brand")
                    .Include("ProductImages")
                    .Include("ProductAttributeValues.ProductAttribute")
                    .Where(p => extendedSearchModel.BrandId == null || p.Brand.Id == extendedSearchModel.BrandId)
                    .Where(p => extendedSearchModel.CategoryId == null || p.Category.Id == extendedSearchModel.CategoryId)
                    .Where(p => extendedSearchModel.SizeId == null || p.ProductAttributeValues.Any(pav => pav.ProductAttribute.Id == 1 && pav.Id == extendedSearchModel.SizeId))
                    .Where(p => extendedSearchModel.ContentId == null || p.ProductAttributeValues.Any(pav => pav.ProductAttribute.Id == 3 && pav.Id == extendedSearchModel.ContentId))
                    .Where(p => extendedSearchModel.PriceFrom == null || p.Price > extendedSearchModel.PriceFrom)
                    .Where(p => extendedSearchModel.PriceTo == null || p.Price < extendedSearchModel.PriceTo);
                if (!string.IsNullOrWhiteSpace(extendedSearchModel.Phrase))
                    products = products.Where(ContextExtension.BuildContainsExpression<Product, int>(p => p.Id, ids));

                return View("Index", products.ToList());
            }
        }
    }
}