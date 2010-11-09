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
    [Authorize(Roles="Administrators")]
    public class BrandsController : Controller
    {
        public ActionResult Index()
        {
            using (ShopStorage context = new ShopStorage())
            {
                List<Brand> brands = context.Brands.ToList();
                return View(brands);
            }
        }

        [OutputCache(VaryByParam="*",  NoStore=true, Duration=1)]
        public ActionResult AddEdit(int? id)
        {
            Brand brand = null;
            if (id.HasValue)
            {
                using (ShopStorage context = new ShopStorage())
                {
                    brand = context.Brands.First(b => b.Id == id.Value);
                }
            }
            return View(brand);
        }

        [HttpPost]
        public ActionResult AddEdit(Brand brand, int? Id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                if (Id.HasValue && Id > 0)
                {
                   //brand.Id = Id;
                    EntityKey key = new EntityKey("ShopStorage.Brands", "Id", Id.Value);
                    brand.Id = Id.Value;
                    brand.Description = HttpUtility.HtmlDecode(brand.Description);
                    object originalItem = null;
                    if(context.TryGetObjectByKey(key, out originalItem))
                    {
                        context.ApplyCurrentValues("Brands", brand);
                    }
                }
                else
                {
                    context.AddToBrands(brand);
                }

                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    if (!string.IsNullOrEmpty(brand.Logo))
                    {
                        IOHelper.DeleteFile("~/Content/BrandLogos", brand.Logo);
                    }
                    string fileName = IOHelper.GetUniqueFileName("~/Content/BrandLogos", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/BrandLogos");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    brand.Logo = fileName;
                }

                context.SaveChanges();
            } 
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (ShopStorage context = new ShopStorage())
            {
                Brand brand = context.Brands.Where(b => b.Id == id).First();
                context.DeleteObject(brand);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
