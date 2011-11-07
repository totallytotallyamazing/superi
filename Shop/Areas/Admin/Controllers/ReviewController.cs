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
    [Authorize(Roles = "Administrators")]
    public class ReviewController : Controller
    {
        //
        // GET: /Admin/Review/

        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            using (var context = new ReviewStorage())
            {

                ReviewContent content = new ReviewContent();
                TryUpdateModel(content, new[] { "Title", "Description", "SortOrder", "Name" });
                //designer.Summary = HttpUtility.HtmlDecode(form["Summary"]);

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



        public ActionResult Edit(int id)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Include("ReviewContentItems").Where(c => c.Id == id).First();
                return View(content);
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            using (var context = new ReviewStorage())
            {
                int id = Convert.ToInt32(form["Id"]);
                var content = context.ReviewContent.Where(c => c.Id == id).First();
                TryUpdateModel(content, new[] { "Title", "Description", "SortOrder", "Name" });
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

        public ActionResult Delete(int id)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Include("ReviewContentItems").Where(c => c.Id == id).First();

                string imageSource = content.ImageSource;
                
                context.DeleteObject(content);
                context.SaveChanges();
                IOHelper.DeleteFile("~/Content/ReviewImages", imageSource);
                return RedirectToAction("Index", "Review",new{Area=""});
            }
        }

        public ActionResult AddReviewConentItem(int id)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Include("ReviewContentItems").Where(c => c.Id == id).First();
                ViewData["reviewContentId"] = content.Id;
                ViewData["reviewContentName"] = content.Name;
                int maxSortOrder = content.ReviewContentItems.Count() > 0 ? content.ReviewContentItems.Max(c => c.SortOrder) : 0;
                var contentItem = new ReviewContentItem { SortOrder = maxSortOrder + 1 };
                return View(contentItem);
            }
        }

        [HttpPost]
        public ActionResult AddReviewConentItem(int reviewContentId, FormCollection form)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Where(c => c.Id == reviewContentId).First();

                var contentItem = new ReviewContentItem();
                TryUpdateModel(contentItem, new[] { "Text", "SortOrder", "ContentType" });

                content.ReviewContentItems.Add(contentItem);
                context.SaveChanges();

                return RedirectToAction("Details", "Review", new { Area = "", id = content.Name });
            }
        }

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

        [HttpPost]
        public ActionResult EditReviewConentItem(FormCollection form)
        {
            using (var context = new ReviewStorage())
            {
                int id = Convert.ToInt32(form["Id"]);
                var content = context.ReviewContentItem.Include("ReviewContent").Where(c => c.Id == id).First();
                var contentName = content.ReviewContent.Name;
                TryUpdateModel(content, new[] {"Text", "SortOrder"});
                context.SaveChanges();
                return RedirectToAction("Details", "Review", new { Area = "", id = contentName });
            }
            
        }

        public ActionResult DeleteReviewContentItem(int id, int contentId)
        {
            using (var context = new ReviewStorage())
            {
                var contentItem = context.ReviewContentItem.Include("ReviewContent").Where(c => c.Id == id).First();
                string contentName = contentItem.ReviewContent.Name;
                context.DeleteObject(contentItem);
                context.SaveChanges();
                return RedirectToAction("Details", "Review", new {Area = "", id = contentName});
            }
        }

        public ActionResult AddReviewContentItemImage(int reviewContentId, int? reviewContentItemId)
        {
             using (var context = new ReviewStorage())
            {
                ViewData["reviewContentId"] = reviewContentId;
                ViewData["reviewContentItemId"] = reviewContentItemId;

                var content = context.ReviewContent.Where(c => c.Id == reviewContentId).First();

                ViewData["reviewContentName"] = content.Name;
                return View();
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
