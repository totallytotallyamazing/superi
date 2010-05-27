using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Models;
using Trips.Mvc.Helpers;
using System.Data;

namespace Lady.Areas.Admin.Controllers
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
                    brand = context.Brands.Where(b => b.Id == id.Value).First();
                }
            }
            return View(brand);
        }

        [HttpPost]
        public ActionResult AddEdit(Brand brand)
        {
            using (ShopStorage context = new ShopStorage())
            {
                if (brand.Id > 0)
                {
                    object originalItem;
                    EntityKey entityKey = context.CreateEntityKey("Brands", brand.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyPropertyChanges(entityKey.EntitySetName, brand);
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
                    Request.Files["logo"].SaveAs(fileName);
                }

                context.SaveChanges();
            } 
            return RedirectToAction("Index");
        }
    }
}
