using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Mvc.Helpers;
using System.IO;

namespace Shop.Areas.Admin.Controllers
{
    
    public class ReviewController : Controller
    {
        //
        // GET: /Admin/Review/
        [Authorize(Roles = "Administrators")]
        public ActionResult Add()
        {

            return View();
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            using (var context = new ReviewStorage())
            {

                ReviewContent content = new ReviewContent();
                TryUpdateModel(content, new[] { "Title", "SortOrder", "Name" });


                content.Description = HttpUtility.HtmlDecode(form["Description"]);

                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    string fileName = IOHelper.GetUniqueFileName("~/Content/ReviewImages", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/ReviewImages");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    content.ImageSource = fileName;
                }

                context.AddToReviewContent(content);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Review", new { Area = "" });
        }


        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int id)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Include("ReviewContentItems").Where(c => c.Id == id).First();
                return View(content);
            }
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            using (var context = new ReviewStorage())
            {
                int id = Convert.ToInt32(form["Id"]);
                var content = context.ReviewContent.Where(c => c.Id == id).First();
                TryUpdateModel(content, new[] { "Title", "SortOrder", "Name" });

                content.Description = HttpUtility.HtmlDecode(form["Description"]);
                //designer.Summary = HttpUtility.HtmlDecode(form["Summary"]);

                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    if (!string.IsNullOrEmpty(content.ImageSource))
                    {
                        IOHelper.DeleteFile("~/Content/ReviewImages", content.ImageSource);
                    }
                    string fileName = IOHelper.GetUniqueFileName("~/Content/ReviewImages", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/ReviewImages");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    content.ImageSource = fileName;
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Review", new { Area = "" });
        }
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int id)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Include("ReviewContentItems").Where(c => c.Id == id).First();

                string imageSource = content.ImageSource;

                context.DeleteObject(content);
                context.SaveChanges();
                IOHelper.DeleteFile("~/Content/ReviewImages", imageSource);
                return RedirectToAction("Index", "Review", new { Area = "" });
            }
        }
        [Authorize(Roles = "Administrators")]
        public ActionResult AddReviewConentItem(int id, int? contentType)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Include("ReviewContentItems").Where(c => c.Id == id).First();
                ViewData["reviewContentId"] = content.Id;
                ViewData["reviewContentName"] = content.Name;
                int maxSortOrder = content.ReviewContentItems.Count() > 0 ? content.ReviewContentItems.Max(c => c.SortOrder) : 0;
                var contentItem = new ReviewContentItem { SortOrder = maxSortOrder + 1 };
                ViewData["ContentType"] = contentType;
                return View(contentItem);
            }
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult AddReviewConentItem(int reviewContentId, FormCollection form)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Where(c => c.Id == reviewContentId).First();

                var contentItem = new ReviewContentItem();
                TryUpdateModel(contentItem, new[] { "SortOrder", "ContentType" });
                contentItem.Text = HttpUtility.HtmlDecode(form["Text"]);
                content.ReviewContentItems.Add(contentItem);
                context.SaveChanges();

                return RedirectToAction("Details", "Review", new { Area = "", id = content.Name });
            }
        }
        [Authorize(Roles = "Administrators")]
        public ActionResult EditReviewConentItem(int id)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContentItem.Include("ReviewContent").Where(c => c.Id == id).First();
                ViewData["reviewContentId"] = content.ReviewContent.Id;
                ViewData["reviewContentName"] = content.ReviewContent.Name;
                return View(content);
            }
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult EditReviewConentItem(FormCollection form)
        {
            using (var context = new ReviewStorage())
            {
                int id = Convert.ToInt32(form["Id"]);
                var content = context.ReviewContentItem.Include("ReviewContent").Where(c => c.Id == id).First();
                var contentName = content.ReviewContent.Name;
                TryUpdateModel(content, new[] { "SortOrder" });
                content.Text = HttpUtility.HtmlDecode(form["Text"]);
                context.SaveChanges();
                return RedirectToAction("Details", "Review", new { Area = "", id = contentName });
            }

        }
        [Authorize(Roles = "Administrators")]
        public ActionResult DeleteReviewContentItem(int id)
        {
            using (var context = new ReviewStorage())
            {
                var contentItem = context.ReviewContentItem.Include("ReviewContent").Include("ReviewContentItemImages").Where(c => c.Id == id).First();
                string contentName = contentItem.ReviewContent.Name;

                while (contentItem.ReviewContentItemImages.Any())
                {
                    var image = contentItem.ReviewContentItemImages.First();
                    IOHelper.DeleteFile("~/Content/ReviewImages", image.ImageSource);
                    context.DeleteObject(image);
                }


                context.DeleteObject(contentItem);
                context.SaveChanges();

                return RedirectToAction("Details", "Review", new { Area = "", id = contentName });
            }
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult CheckForEmptyEntriesAndDelete(int id)
        {
            using (var context = new ReviewStorage())
            {
                var contentItem = context.ReviewContentItem.Include("ReviewContent").Include("ReviewContentItemImages").Where(c => c.Id == id).First();
                string contentName = contentItem.ReviewContent.Name;
                if (contentItem.ReviewContentItemImages.Count() == 0)
                {
                    context.DeleteObject(contentItem);
                    context.SaveChanges();
                }
                return RedirectToAction("Details", "Review", new { Area = "", id = contentName });
            }
        }

        public ActionResult AddReviewContentItemImage(int reviewContentId, int? reviewContentItemId)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Where(c => c.Id == reviewContentId).First();
                ReviewContentItem contentItem;

                if (!reviewContentItemId.HasValue)
                {

                    contentItem = new ReviewContentItem { ContentType = 3 };
                    content.ReviewContentItems.Add(contentItem);
                    context.SaveChanges();
                    reviewContentItemId = contentItem.Id;
                    
                }
                else
                {
                    contentItem = context.ReviewContentItem.Include("ReviewContentItemImages").Where(c => c.Id == reviewContentItemId).First();
                    ViewData["hasImages"] = true;
                }

                ViewData["reviewContentItemId"] = reviewContentItemId;
                ViewData["reviewContentId"] = reviewContentId;

                ViewData["scriptData"] = string.Format("{{ReviewContentId: {0}, ReviewContentItemId: {1}}}", reviewContentId, reviewContentItemId);

                ViewData["reviewContentName"] = content.Name;
                return View(contentItem);
            }
        }

        [HttpPost]
        public ActionResult AddReviewContentItemImage(int reviewContentId, int? reviewContentItemId, FormCollection form)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Where(c => c.Id == reviewContentId).First();
                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    ReviewContentItem contentItem;

                    if (reviewContentItemId.HasValue)
                    {
                        contentItem = context.ReviewContentItem.Where(c => c.Id == reviewContentItemId).First();
                    }
                    else
                    {
                        contentItem = new ReviewContentItem { ContentType = 3 };
                        content.ReviewContentItems.Add(contentItem);
                    }


                    var image = new ReviewContentItemImage();



                    string fileName = IOHelper.GetUniqueFileName("~/Content/ReviewImages", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/ReviewImages");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    image.ImageSource = fileName;

                    contentItem.ReviewContentItemImages.Add(image);

                    context.SaveChanges();

                }


                return RedirectToAction("Details", "Review", new { Area = "", id = content.Name });
            }

        }


        static object lockobj = 1;

        [HttpPost]
        public void UploadImage(FormCollection form)
        {
            lock (lockobj)
            {
                using (var context = new ReviewStorage())
                {
                    int reviewContentId = Convert.ToInt32(form["ReviewContentId"]);
                    int reviewContentItemId = Convert.ToInt32(form["ReviewContentItemId"]);

                    var content = context.ReviewContent.Where(c => c.Id == reviewContentId).First();

                    ReviewContentItem contentItem;

                    if (reviewContentItemId != 0)
                    {
                        contentItem = context.ReviewContentItem.Where(c => c.Id == reviewContentItemId).First();
                    }
                    else
                    {
                        contentItem = new ReviewContentItem { ContentType = 3 };
                        content.ReviewContentItems.Add(contentItem);
                    }


                    /*
                    string folderRelativePath = string.Format("~/Content/CatalogueImages/Brand{0}Group{1}", form["BrandId"], form["GroupId"]);
                    string folderAbsolutePath = Server.MapPath(folderRelativePath);
            
                    if (!Directory.Exists(folderAbsolutePath)) Directory.CreateDirectory(folderAbsolutePath);
                    */



                    HttpPostedFileBase file = Request.Files["Filedata"];
                    //string fileName = IOHelper.GetUniqueFileName(folderRelativePath, file.FileName);
                    string fileName = IOHelper.GetUniqueFileName("~/Content/ReviewImages", file.FileName);
                    string filePath = Server.MapPath("~/Content/ReviewImages");
                    filePath = Path.Combine(filePath, fileName);

                    //string targetFilePath = Path.Combine(folderAbsolutePath, fileName);

                    file.SaveAs(filePath);


                    var image = new ReviewContentItemImage();

                    image.ImageSource = fileName;

                    contentItem.ReviewContentItemImages.Add(image);

                    context.SaveChanges();

                    /*
                    CatalogueImage image = new CatalogueImage();
                    image.BrandReference.EntityKey = new EntityKey("BrandCatalogue.Brands", "Id", int.Parse(form["BrandId"]));
                    image.CatalogueGroupReference.EntityKey = new EntityKey("BrandCatalogue.CatalogueGroups", "Id", int.Parse(form["GroupId"]));
                    image.Image = fileName;
                    context.AddToCatalogueImages(image);
                    context.SaveChanges();
                     */



                }
            }
            Response.Write("1");
        }


        public ActionResult DeleteReviewContentItemImage(int id, string contentName)
        {
            using (var context = new ReviewStorage())
            {

                var image = context.ReviewContentItemImage.Include("ReviewContentItem").Where(i => i.Id == id).First();
                var contentItem = image.ReviewContentItem;

                var contentItemImagesCount = image.ReviewContentItem.ReviewContentItemImages.Count();

                IOHelper.DeleteFile("~/Content/ReviewImages", image.ImageSource);
                context.DeleteObject(image);

                if (contentItemImagesCount == 1)
                    context.DeleteObject(contentItem);
                context.SaveChanges();
            }

            return RedirectToAction("Details", "Review", new { Area = "", id = contentName });
        }


    }
}
