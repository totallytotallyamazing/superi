using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Areas.BrandCatalog.Models;
using System.Dynamic;
using System.Text;
using Dev.Mvc.Helpers;

namespace Shop.Areas.BrandCatalog.Controllers
{
    public class BrandsController : Controller
    {
        //
        // GET: /BrandCatalog/Brands/
        [OutputCache(VaryByParam="*", Duration=600)]
        [HttpPost]
        public ActionResult Index(int groupId, int brandId, int? page)
        {
            int currentPage = page ?? 0;
            using (BrandCatalogue context = new BrandCatalogue())
            {
                context.Brands.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                context.CatalogueImages.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                var brand = context.Brands.Select(b=>new {Name=  b.Name, Id= b.Id, Description = b.Description}).First(b => b.Id == brandId);
                ViewData["brandName"] = brand.Name;
                ViewData["brandDescription"] = brand.Description;
                int skip = currentPage * 7;
                int imagesOverall = context.CatalogueImages.Where(c => c.CatalogueGroup.Id == groupId && c.Brand.Id == brandId).Count();
                var allImg = context.CatalogueImages.Where(c => c.CatalogueGroup.Id == groupId && c.Brand.Id == brandId)
                    .OrderBy(c => c.SortOrder).ToList();
                
                var images =allImg
                    .Skip(skip)
                    .Take(7)
                    .Select((img, i) => new { Id = img.Id, Image = img.Image, Index = i });

                var imgArray = allImg.Select(i => "http://listelli.ua/ImageCache/catalogueMain/" + i.Image).ToArray();
                ViewData["imgArray"] = imgArray;
                StringBuilder dockContent = new StringBuilder();
                dockContent.Append(@"<div id=""dock"">");
                dockContent.Append(@"<div class=""dock-container"">");
                foreach (var item in images)
                {
                    dockContent.AppendFormat(@"<a href='/Graphics/ShowCatalogueMain/{0}?alt=""""&brandId={1}&groupId={2}' index=""{3}"" class=""dock-item"">",
                        item.Image, brandId, groupId, item.Index);
                    dockContent.Append("<span></span>");
                    
                    dockContent.Append(GraphicsHelper.CachedImage(null, "~/Content/CatalogueImages/Brand" + brandId + "Group" + groupId, item.Image, "catalogueThumb", item.Image));
                    dockContent.Append("</a>");
                }
                dockContent.Append("</div></div>");

                var result = new
                {
                    BrandDescription = brand.Description,
                    BrandName = brand.Name,
                    ThumbnailsLayout = dockContent.ToString(),
                    ShowPrev = currentPage != 0,
                    ShowNext = (int)(imagesOverall / 7) + 7 > currentPage + 7,
                    Page = currentPage,
                    BrandId = brandId, 
                    GroupId = groupId,
                    ImageArray = imgArray
                };

                return Json(result, "text/x-json");
            }
        }

        public ActionResult BrandLinks(int id)
        {
            ViewData["groupId"] = id;
            using (BrandCatalogue context = new BrandCatalogue())
            {
                var brands = context.Brands.Where(b => b.CatalogueImages.Any(i => i.CatalogueGroup.Id == id)).Select(b => new { Id = b.Id, Name = b.Name }).ToList();

                var result = brands.Select(b => {
                    dynamic res = new ExpandoObject();
                    res.Name = b.Name;
                    res.Id = b.Id;
                    return res;
                });

                return View(result);
            }
        }
    }
}
