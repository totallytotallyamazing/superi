﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Models;
using System.Data;
using Trips.Mvc.Helpers;
using System.IO;

namespace Lady.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ProductsController : Controller
    {
        public ActionResult Index(int categoryId, int? brandId)
        {
            ViewData["cId"] = categoryId;
            ViewData["bId"] = brandId;
            using (ShopStorage context = new ShopStorage())
            {
                List<Product> products = context.Products.Where(p => p.Category.Id == categoryId)
                    .Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value)).ToList();
                return View(products);
            }
        }

        public ActionResult AddEdit(int? id, int cId, int? bId)
        {
            ViewData["cId"] = cId;
            ViewData["bId"] = bId;
            ViewData["id"] = id;

            Product product = null;
            using (ShopStorage context = new ShopStorage())
            {
                var br = context.Brands.ToList();

                List<SelectListItem> brands = br
                    .Select(b => new SelectListItem { Text = b.Name, Value = b.Id.ToString() })
                    .ToList();

                ViewData["Brands"] = br;

                if (id.HasValue)
                {
                    product = context.Products.Include("ProductImages").Include("Brand").Where(p => p.Id == id.Value).First();
                }
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult AddEdit(Product product, int? Id, int cId, int? bId, int brandId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                if (Id.HasValue && Id > 0)
                {
                    product.Id = Id.Value;
                    Product prod = context.Products.Include("Brand").Where(p => p.Id == Id.Value).First();
                    prod.Name = product.Name;
                    prod.OldPrice = product.OldPrice;
                    prod.PartNumber = product.PartNumber;
                    prod.SeoDescription = product.SeoDescription;
                    prod.SeoKeywords = product.SeoKeywords;
                    prod.ShortDescription = HttpUtility.HtmlDecode(product.ShortDescription);
                    prod.Description = HttpUtility.HtmlDecode(product.Description);
                    prod.Price = product.Price;

                    if (prod.Brand.Id != brandId)
                    {
                        EntityKey brand = new EntityKey("ShopStorage.Brands", "Id", brandId);
                        prod.Brand = null;
                        prod.BrandReference.EntityKey = brand;
                    }
                }
                else
                {
                    EntityKey category = new EntityKey("ShopStorage.Categories", "Id", cId);
                    EntityKey brand = new EntityKey("ShopStorage.Brands", "Id", brandId);
                    product.CategoryReference.EntityKey = category;
                    product.Brand = null;
                    product.BrandReference.EntityKey = brand;
                    context.AddToProducts(product);
                }
                context.SaveChanges();
            }

            return View("Index", new { categoryId = cId, brandId = bId });
        }

        public ActionResult AddProductImage(int productId, bool isDefault, int categoryId)
        {
            string file = Request.Files["image"].FileName;
            if (!string.IsNullOrEmpty(file))
            {
                string newFileName = IOHelper.GetUniqueFileName("~/Content/ProductImages", file);
                string filePath = Path.Combine(Server.MapPath("~/Content/ProductImages"), newFileName);
                Request.Files["image"].SaveAs(filePath);

                using (ShopStorage context = new ShopStorage())
                {
                    ProductImage image = new ProductImage();
                    image.ProductReference.EntityKey = new EntityKey("ShopStorage.Products", "Id", productId);
                    image.ImageSource = newFileName;
                    image.Default = isDefault;
                    context.AddToProductImages(image);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("AddEdit", new { id = productId, cId = categoryId });
        }

        public ActionResult DeleteImage(long productId, long imageId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                ProductImage image = context.ProductImages.Where(i => i.Id == imageId).First();
                if (image.Default)
                {
                    ProductImage newDefaultImage = context.ProductImages.Where(i => i.Id != imageId).FirstOrDefault();
                    if (newDefaultImage != null)
                        newDefaultImage.Default = true;
                }
                context.DeleteObject(image);
                context.SaveChanges();
                return RedirectToAction("AddEdit", new { id = productId });
            }
        }

        public ActionResult SetDefaultImage(long productId, long defaultImage)
        {
            using (ShopStorage context = new ShopStorage())
            {
                var productImages = context.ProductImages.Where(p => p.Product.Id == productId);
                foreach (var item in productImages)
                {
                    item.Default = item.Id == defaultImage;
                }
                context.SaveChanges();
            }
            return RedirectToAction("AddEdit", new { id = productId });
        }
    }
}
