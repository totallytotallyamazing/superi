using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using System.IO;
using Dev.Mvc.Helpers;

namespace Shop.Areas.Admin.Controllers
{
    public class ProductVariantsController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewData["productId"] = id;
            using (ShopStorage context = new ShopStorage())
            {
                var productVariants = context.ProductVariants.Where(pv => pv.Product.Id == id).ToList();
                return View(productVariants);
            }
        }

        [OutputCache(NoStore = false, Duration = 1, VaryByParam = "*")]
        [HttpGet]
        public ActionResult AddEdit(int? id, int productId)
        {
            if (id.HasValue)
                using (ShopStorage context = new ShopStorage())
                    return View(context.ProductVariants.First(pv => pv.Id == id.Value));
            return View();
        }

        [HttpPost]
        public ActionResult AddEdit(FormCollection form)
        {
            using (ShopStorage context = new ShopStorage())
            {
                ProductVariant variant = null;
                if (!string.IsNullOrEmpty(form["Id"]))
                {
                    int id = int.Parse(form["Id"]);
                    variant = context.ProductVariants.First(v => v.Id == id);
                }
                else
                {
                    variant = new ProductVariant();
                    EntityKey key = new EntityKey("ShopStorage.Products", "Id", int.Parse(form["ProductId"]));
                    variant.ProductReference.EntityKey = key;
                    context.AddToProductVariants(variant);
                }
                TryUpdateModel(variant,
                    new string[] { "Name", "SortOrder", "Published", "Price", "OldPrice", "Published", "ShowOnMainPage" },
                    form.ToValueProvider());

                variant.Description = HttpUtility.HtmlDecode(form["Description"]);

                if (Request.Files["Image"] != null && !string.IsNullOrEmpty(Request.Files["Image"].FileName))
                {
                    if (!string.IsNullOrEmpty(variant.Image))
                        IOHelper.DeleteFile("~/Content/ProductImages", variant.Image);
                    string fileName = IOHelper.GetUniqueFileName("~/Content/ProductImages", Request.Files["Image"].FileName);
                    string filePath = Server.MapPath("~/Content/ProductImages");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["Image"].SaveAs(filePath);
                    variant.Image = fileName;
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { id = int.Parse(form["productiD"]) });
        }

        [HttpGet]
        public ActionResult Delete(int id, int productId)
        {
            using (ShopStorage context = new ShopStorage())
            {
                ProductVariant variant = context.ProductVariants.First(v => v.Id == id);
                context.DeleteObject(variant);
                if (!string.IsNullOrEmpty(variant.Image))
                    IOHelper.DeleteFile("~/Content/ProductImages", variant.Image);
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { id = productId });
        }
    }
}
