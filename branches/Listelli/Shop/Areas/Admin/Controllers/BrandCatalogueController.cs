using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Areas.BrandCatalog.Models;
using System.IO;
using System.Web.Script.Serialization;
using Dev.Mvc.Helpers;
using Dev.Helpers;
using System.Data;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    public class BrandCatalogueController : Controller
    {
        public ActionResult Groups()
        {
            using (BrandCatalogue context = new BrandCatalogue())
            {
                context.CatalogueGroups.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                List<CatalogueGroup> groups = context.CatalogueGroups.OrderBy(g => g.SortOrder).ToList();
                return View(groups);
            }
        }

        [HttpPost]
        public ActionResult Groups(FormCollection form)
        {
            int id = 0;
            using (BrandCatalogue context = new BrandCatalogue())
            {
                CatalogueGroup group = null;
                if (int.TryParse(form["Id"], out id))
                    group = context.CatalogueGroups.First(g => g.Id == id);
                else
                {
                    group = new CatalogueGroup();
                    context.AddToCatalogueGroups(group);
                }
                TryUpdateModel(group, new string[] { "Name", "SortOrder" }, form.ToValueProvider());
                context.SaveChanges();
            }
            return RedirectToAction("Groups");
        }

        public ActionResult DeleteGroup(int id)
        {
            using (BrandCatalogue context = new BrandCatalogue())
            {
                CatalogueGroup group = context.CatalogueGroups
                    .Include("CatalogueImages").Include("Brand")
                    .First(g => g.Id == id);
                foreach (var image in group.CatalogueImages)
                {
                    if (!string.IsNullOrEmpty(image.Image))
                    {
                        string relativePath = string.Format("~/Content/CatalogueImages/Brand{0}Group{1}/{2}", image.Brand.Id, id, image.Image);
                        System.IO.File.Delete(Server.MapPath(relativePath));
                    }
                }
                context.DeleteObject(group);
                context.SaveChanges();
            }
            return RedirectToAction("Groups");
        }

        public ActionResult ManageImages(int? groupId, int? brandId)
        {
            List<CatalogueImage> images = new List<CatalogueImage>();
            using (BrandCatalogue context = new BrandCatalogue())
            {
                context.Brands.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                context.CatalogueGroups.MergeOption = System.Data.Objects.MergeOption.NoTracking;

                var brands = context.Brands.Where(b => b.HasCatalogue).OrderBy(b => b.SortOrder).ToList();

                ViewData["brands"] = brands
                    .Select(b => new SelectListItem
                    {
                        Text = b.Name,
                        Value = b.Id.ToString(),
                        Selected = brandId == b.Id
                    })
                    .ToList();

                var groups = context.CatalogueGroups.OrderBy(b => b.SortOrder).ToList();

                ViewData["groups"] = groups
                    .Select(g => new SelectListItem
                    {
                        Text = g.Name,
                        Value = g.Id.ToString(),
                        Selected = groupId == g.Id
                    })
                    .ToList();

                int bId = brandId ?? brands.First().Id;
                int gId = groupId ?? groups.First().Id;

                context.CatalogueImages.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                images = context.CatalogueImages.Where(ci => ci.Brand.Id == bId)
                    .Where(ci => ci.CatalogueGroup.Id == gId).ToList();

                ViewData["scriptData"] = string.Format("{{BrandId: {0}, GroupId: {1}}}", bId, gId);
            }
            return View(images);
        }

        public ActionResult DeleteImages(FormCollection form)
        {
            int[] imagesToDelete = form.GetArray<int>("imageDelete_");
            using (BrandCatalogue context = new BrandCatalogue())
            {
                var images = context.CatalogueImages.Where(ContextExtension.BuildContainsExpression<CatalogueImage, int>(ci => ci.Id, imagesToDelete));
                foreach (var item in images)
                    context.DeleteObject(item);
                context.SaveChanges();
            }
            return RedirectToAction("ManageImages", new { groupId = form["groupId"], brandId = form["brandId"] });
        }

        public ActionResult UpdateSortOrder(FormCollection form)
        {
            using (BrandCatalogue context = new BrandCatalogue())
            {
                Dictionary<int, int> sortOrderUpdates = form.GetDictionary<int, int>("imageSortOrder_");
                var images = context.CatalogueImages.Where(ContextExtension.BuildContainsExpression<CatalogueImage, int>(ci => ci.Id, sortOrderUpdates.Keys));
                foreach (var item in images)
                    item.SortOrder = sortOrderUpdates[item.Id];

                context.SaveChanges();
            }
            return RedirectToAction("ManageImages", new { groupId = form["groupId"], brandId = form["brandId"] });
        }

        static object lockobj = 1;

        [HttpPost]
        public void UploadImage(FormCollection form)
        {
            string folderRelativePath = string.Format("~/Content/CatalogueImages/Brand{0}Group{1}", form["BrandId"], form["GroupId"]);
            string folderAbsolutePath = Server.MapPath(folderRelativePath);

            if (!Directory.Exists(folderAbsolutePath)) Directory.CreateDirectory(folderAbsolutePath);

            HttpPostedFileBase file = Request.Files["Filedata"];
            string fileName = IOHelper.GetUniqueFileName(folderRelativePath, file.FileName);


            string targetFilePath = Path.Combine(folderAbsolutePath, fileName);

            file.SaveAs(targetFilePath);
            lock (lockobj)
            {
                using (BrandCatalogue context = new BrandCatalogue())
                {
                    CatalogueImage image = new CatalogueImage();
                    image.BrandReference.EntityKey = new EntityKey("BrandCatalogue.Brands", "Id", int.Parse(form["BrandId"]));
                    image.CatalogueGroupReference.EntityKey = new EntityKey("BrandCatalogue.CatalogueGroups", "Id", int.Parse(form["GroupId"]));
                    image.Image = fileName;
                    context.AddToCatalogueImages(image);
                    context.SaveChanges();
                }
            }
            Response.Write("1");
        }
    }
}
