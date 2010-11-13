using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Areas.BrandCatalog.Models;

namespace Shop.Areas.BrandCatalog.Controllers
{
    public class BrandsController : Controller
    {
        //
        // GET: /BrandCatalog/Brands/

        public ActionResult Index(int groupId, int brandId)
        {
            using (BrandCatalogue context = new BrandCatalogue())
            {
                var images = context.CatalogueImages.Where(c => c.CatalogueGroup.Id == groupId && c.Brand.Id == brandId).OrderBy(c => c.SortOrder).ToList();
                return View(images);
            }
        }


        public ActionResult BrandLinks(int id)
        {
            using (BrandCatalogue context = new BrandCatalogue())
            {
                var brands = context.Brands.Where(b => b.CatalogueImages.Any(i => i.CatalogueGroup.Id == id)).Select(b => new { Id = b.Id, Name = b.Name }).ToList();
                return View(brands);
            }
        }
    }
}
