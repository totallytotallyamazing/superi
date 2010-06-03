using System;
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
    [Authorize(Roles="Administrators")]
    public class ProductsController : Controller
    {
        //
        // GET: /Admin/Products/

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

            Product product = null;
            if (id.HasValue)
            {
                using (ShopStorage context = new ShopStorage())
                {
                    product = context.Products.Where(p => p.Id == id.Value).First();
                }
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult AddEdit(Product product, int cId, int? bId)
        {

            using (ShopStorage context = new ShopStorage())
            {
                if (product.Id > 0)
                {
                    object originalItem;
                    EntityKey entityKey = context.CreateEntityKey("ShopStorage.Products", product.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyPropertyChanges(entityKey.EntitySetName, product);
                    }
                }
                else
                {
                    context.AddToProducts(product);
                }
                context.SaveChanges();
            } 

            return RedirectToAction("Index", new { categoryId = cId, brandId = bId });
        }

        public ActionResult AddProductImage(long productId, bool isDefault)
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
            return RedirectToAction("AddEdit", new { id = productId });
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
