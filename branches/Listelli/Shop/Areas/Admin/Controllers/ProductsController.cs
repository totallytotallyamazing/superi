﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using System.IO;
using Dev.Helpers;
using Dev.Mvc.Helpers;
using Superi.Web.Mvc.Localization;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ProductsController : Controller
    {
        private ShopStorage _context = new ShopStorage();

        public ActionResult Index(int categoryId, int? brandId)
        {
            ViewData["cId"] = categoryId;
            ViewData["bId"] = brandId;
            using (var context = new ShopStorage())
            {
                List<Product> products = context.Products.Where(p => p.Categories.Any(c => c.Id == categoryId))
                    .Where(p => (!brandId.HasValue || p.Brand.Id == brandId.Value)).ToList();
                return View(products);
            }
        }

        [HttpGet]
        public ActionResult AddEdit(int? id, int? cId, int? bId)
        {
            ViewData["cId"] = cId;
            ViewData["bId"] = bId;
            ViewData["id"] = id;

            Product product = null;
            var br = _context.Brands.ToList();

            int brandId = int.MinValue;

            ViewData["context"] = _context;

            List<ProductAttribute> attributes = null;

            if (id.HasValue)
            {
                product = _context.Products.Include("ProductImages")
                    .Include("Categories.ProductAttributes.ProductAttributeValues")
                    .Include("ProductAttributeStaticValues")
                    .Include("Brand").First(p => p.Id == id.Value);
                if (product.Brand != null)
                    brandId = product.Brand.Id;

                attributes = product.Categories.SelectMany(c => c.ProductAttributes.Where(pa => pa.Static)).ToList();
            }

            if (attributes == null && cId.HasValue)
                attributes = _context.ProductAttributes.Where(pa => pa.Categories.Any(c => c.Id == cId.Value)).ToList();

            var attributesData = new KeyValuePair<Product, IEnumerable<ProductAttribute>>(
                product,
                attributes);
            ViewData["attributesData"] = attributesData;

            List<SelectListItem> brands = br
            .Select(b => new SelectListItem { Text = b.Name, Value = b.Id.ToString(), Selected = b.Id == brandId })
            .ToList();

            ViewData["Brands"] = brands;

            return View(product);
        }

        [HttpPost]
        public ActionResult AddEdit(FormCollection form, int? cId, int? bId, int? brandId, ShopLocalResource[] localizations)
        {
            Product product;
            using (var context = new ShopStorage())
            {
                bool add = false;
                int id;
                if (int.TryParse(form["Id"], out id))
                {
                    product = context.Products.Include("Brand")
                        .Include("ProductAttributeStaticValues")
                        .First(p => p.Id == id);
                    if ((product.Brand == null || product.Brand.Id != brandId) && brandId.HasValue)
                    {
                        var brand = new Brand { Id = brandId.Value };
                        brand.EntityKey = new EntityKey("ShopStorage.Brands", "Id", brandId.Value);
                        context.Attach(brand);
                        product.Brand = brand;
                    }
                }
                else
                {
                    add = true;
                    if (!cId.HasValue)
                        throw new ArgumentNullException("cId");
                    product = new Product();
                    EntityKey category = new EntityKey("ShopStorage.Categories", "Id", cId);

                    if (brandId.HasValue)
                    {
                        var brand = new Brand { Id = brandId.Value };
                        brand.EntityKey = new EntityKey("ShopStorage.Brands", "Id", brandId.Value);
                        context.Attach(brand);
                        product.Brand = brand;
                    }

                    object categoryItem;
                    context.TryGetObjectByKey(category, out categoryItem);

                    product.Categories.Add((Category)categoryItem);
                    context.AddToProducts(product);
                }


                TryUpdateModel(product,
                    new[] 
                    { 
                        "PartNumber", "SeoDescription", "SeoKeywords", /*"ShortDescription",
                        "Description", */"IsNew", "SortOrder", "Color", "Published", "IsSpecialOffer", 
                        "PersonalExperience", "PersonalExperienceSet", "ShowInRoot", "Tint"
                    },
                    form.ToValueProvider());

                product.Description = HttpUtility.HtmlDecode(product.Description);
                product.ShortDescription = HttpUtility.HtmlDecode(product.ShortDescription);

                UpdateProductAttributes(product, form);

                product.UpdateValues(localizations.Where(l => l.Language == "ru-RU"));

                if (add)
                {
                    context.SaveChanges();
                }

                localizations.SaveLocalizationsTo(context.ShopLocalResources, false);

                context.SaveChanges();
            }

            return RedirectToAction("AddEdit", new { id = product.Id, cId, bId });
        }

        private void UpdateProductAttributes(Product product, FormCollection form)
        {
            PostData postData = form.ProcessPostData(prefix: "pa_");

            foreach (var item in postData)
            {
                int attributeId = int.Parse(item.Key);
                string attributeValue = item.Value["pa"];

                ProductAttributeStaticValue value = product.ProductAttributeStaticValues
                    .FirstOrDefault(p => p.ProductAttributeReference.GetReferenceId() == attributeId);
                if (value == null)
                {
                    value = new ProductAttributeStaticValue();
                    value.ProductAttributeReference.EntityKey = new EntityKey("ShopStorage.ProductAttributes", "Id", attributeId);
                    product.ProductAttributeStaticValues.Add(value);
                }
                value.Value = attributeValue;
            }
        }

        public ActionResult AddProductImage(int productId, bool isDefault, int? categoryId)
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

        public ActionResult DeleteImage(int productId, int imageId, int? cId)
        {
            DeleteProductImage(productId, imageId);
            return RedirectToAction("AddEdit", new { id = productId, cId });
        }

        private void DeleteProductImage(int productId, int imageId)
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
                if (!string.IsNullOrEmpty(image.ImageSource))
                    System.IO.File.Delete(Server.MapPath("~/Content/ProductImages/" + image.ImageSource));
                context.DeleteObject(image);
                context.SaveChanges();
            }
        }

        public ActionResult SetDefaultImage(long productId, long defaultImage, int? cId)
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
            return RedirectToAction("AddEdit", new { id = productId, cId });
        }

        public ActionResult Delete(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                Product product = context.Products.Include("ProductImages").Include("Categories").Where(p => p.Id == id).First();
                product.Categories.Clear();
                foreach (var item in product.ProductImages)
                {
                    if (!string.IsNullOrEmpty(item.ImageSource))
                        System.IO.File.Delete(Server.MapPath("~/Content/ProductImages/" + item.ImageSource));

                }
                context.DeleteObject(product);
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { controller = "Products", area = "", id = WebSession.CurrentCategory });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
    }
}
