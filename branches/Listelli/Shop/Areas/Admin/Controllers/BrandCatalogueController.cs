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
                List<CatalogueGroup> groups = context.CatalogueGroups.ToList();
                return View(groups); 
            }
        }

        public ActionResult AddEditGroup(int? id)
        {
            CatalogueGroup group = null;
            if (id.HasValue)
                using (BrandCatalogue context = new BrandCatalogue())
                {
                    context.CatalogueGroups.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                    group = context.CatalogueGroups.First(g => g.Id == id.Value);
                }

            return View(group);
        }

        [HttpPost]
        public ActionResult AddEditGroup(FormCollection form)
        {
            int id = 0;
            using (BrandCatalogue context = new BrandCatalogue())
            {
                CatalogueGroup group = null;
                if (int.TryParse(form["Id"], out id))
                    group = context.CatalogueGroups.First(g => g.Id == id);
                else
                    group = new CatalogueGroup();
                TryUpdateModel(group, new string[] { "Name" }, form.ToValueProvider());
                context.SaveChanges();
            }
            return View();
        }

        public ActionResult DeleteGroup(int id)
        {
            using (BrandCatalogue context = new BrandCatalogue())
            {
                CatalogueGroup group = context.CatalogueGroups.First(g => g.Id == id);
                context.DeleteObject(group);
                context.SaveChanges();
            }
            return RedirectToAction("Groups");
        }

        struct UploadedImageProperties 
        {
            public int BrandId { get; set; }
            public int GroupId { get; set; }
        }

        public ActionResult ManageImages(int? groupId, int? brandId)
        {
            List<CatalogueImage> images = new List<CatalogueImage>();
            if (groupId.HasValue && brandId.HasValue)
            {
                using (BrandCatalogue context = new BrandCatalogue())
                {
                    images = context.CatalogueImages.Where(ci => ci.Brand.Id == brandId.Value)
                        .Where(ci => ci.CatalogueGroup.Id == groupId.Value).ToList();
                }
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
            return RedirectToAction("ManageImages", new { groupId = form["groupId"], brandId = form["brandId"]});
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

        public ActionResult UploadImages()
        {
            using (BrandCatalogue context = new BrandCatalogue())
            {
                ViewData["brands"] = context.Brands.Where(b => b.HasCatalogue).ToList();
                ViewData["groups"] = context.CatalogueGroups.ToList();
            }
            return View();
        }

        [HttpPost]
        public void UploadImage(FormCollection form)
        {
            string scriptData = form["scriptDataVariable"];
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var imageProperties = serializer.Deserialize<UploadedImageProperties>(scriptData);

            string folderRelativePath = string.Format("~/Content/CatalogueImages/Brand{0}Group{1}", imageProperties.BrandId, imageProperties.GroupId);
            string folderAbsolutePath = Server.MapPath(folderRelativePath);
            
            if (!Directory.Exists(folderAbsolutePath)) Directory.CreateDirectory(folderAbsolutePath);

            HttpPostedFileBase file = Request.Files["Filedata"];
            string fileName = IOHelper.GetUniqueFileName(folderRelativePath, file.FileName);


            string targetFilePath = Path.Combine(folderAbsolutePath, fileName);

            file.SaveAs(targetFilePath);

            using (BrandCatalogue context = new BrandCatalogue())
            {
                CatalogueImage image = new CatalogueImage();
                image.BrandReference.EntityKey = new EntityKey("BrandCatalogue.Brands", "Id", imageProperties.BrandId);
                image.CatalogueGroupReference.EntityKey = new EntityKey("BrandCatalogue.CatalogueGroups", "Id", imageProperties.GroupId);
                image.Image = fileName;
                context.AddToCatalogueImages(image);
                context.SaveChanges();
            }
            Response.Write("1");
        }
    }
}
