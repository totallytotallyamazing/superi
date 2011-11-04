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
                TryUpdateModel(content, new[] { "Title", "Description", "SortOrder" });
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
                TryUpdateModel(content, new[] { "Title", "Description", "SortOrder" });
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

        public ActionResult AddReviewConentItem(int id)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Where(c => c.Id == id).First();
                ViewData["reviewContentId"] = content.Id;
                return View();
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

                return RedirectToAction("Details", "Review", new { Area = "", id = content.Id });
            }
        }

        public ActionResult AddReviewContentItemImage(int reviewContentId, int? reviewContentItemId)
        {
            using (var context = new ReviewStorage())
            {
                ViewData["reviewContentId"] = reviewContentId;
                ViewData["reviewContentItemId"] = reviewContentItemId;
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
                        contentItem = new ReviewContentItem { ContentType=3 };
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


                return RedirectToAction("Details", "Review", new { Area = "", id = content.Id });
            }

        }


    }
}
