using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Dev.Mvc.Helpers;
using System.IO;
using Superi.Web.Mvc.Localization;

namespace Shop.Areas.Admin.Controllers
{

    public class ReviewController : Controller
    {
        private readonly ReviewStorage _context = new ReviewStorage();

        //
        // GET: /Admin/Review/
        [Authorize(Roles = "Administrators")]
        public ActionResult Add()
        {
            ViewData["context"] = _context;
            return View();
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Add(ReviewContent content, ReviewLocalResource[] localizations)
        {
            content.Description = HttpUtility.HtmlDecode(content.Description);

            if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
            {
                string fileName = IOHelper.GetUniqueFileName("~/Content/ReviewImages", Request.Files["logo"].FileName);
                string filePath = Server.MapPath("~/Content/ReviewImages");
                filePath = Path.Combine(filePath, fileName);
                Request.Files["logo"].SaveAs(filePath);
                content.ImageSource = fileName;
            }

            _context.AddToReviewContent(content);
            _context.SaveChanges();

            if (localizations != null && localizations.Length > 0)
            {
                localizations.ToList().ForEach(l =>
                {
                    l.Text = HttpUtility.HtmlDecode(l.Text);
                    l.EntityId = content.Id;
                });

                localizations.SaveLocalizationsTo(_context.ReviewLocalResources, false);
                content.UpdateValues(localizations.Where(l => l.Language == "ru-RU"));

                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Review", new { Area = "" });
        }


        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int id)
        {
            ViewData["context"] = _context;
            var content = _context.ReviewContent.First(c => c.Id == id);
            return View(content);
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Edit(FormCollection form, ReviewLocalResource[] localizations)
        {

            int id = Convert.ToInt32(form["Id"]);
            var content = _context.ReviewContent.First(c => c.Id == id);
            TryUpdateModel(content, new[] { "Title", "SortOrder", "Name" });

            content.Description = HttpUtility.HtmlDecode(form["Description"]);

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
            _context.SaveChanges();

            if (localizations != null && localizations.Length > 0)
            {
                localizations.ToList().ForEach(l =>
                {
                    l.Text = HttpUtility.HtmlDecode(l.Text);
                    l.EntityId = content.Id;
                });

                localizations.SaveLocalizationsTo(_context.ReviewLocalResources, false);
                content.UpdateValues(localizations.Where(l => l.Language == "ru-RU"));

                _context.SaveChanges();
            }


            return RedirectToAction("Index", "Review", new { Area = "" });
        }
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int id)
        {
            var content = _context.ReviewContent.Include("ReviewContentItems").First(c => c.Id == id);
            string imageSource = content.ImageSource;
            _context.DeleteObject(content);
            _context.SaveChanges();
            if (!string.IsNullOrEmpty(imageSource))
                IOHelper.DeleteFile("~/Content/ReviewImages", imageSource);
            return RedirectToAction("Index", "Review", new { Area = "" });

        }
        [Authorize(Roles = "Administrators")]
        public ActionResult AddReviewConentItem(int id, int? contentType)
        {
            ViewData["context"] = _context;
            var content = _context.ReviewContent.Include("ReviewContentItems").First(c => c.Id == id);
            ViewData["reviewContentId"] = content.Id;
            ViewData["reviewContentName"] = content.Name;
            int maxSortOrder = content.ReviewContentItems.Any() ? content.ReviewContentItems.Max(c => c.SortOrder) : 0;
            var contentItem = new ReviewContentItem { SortOrder = maxSortOrder + 1 };
            ViewData["ContentType"] = contentType;
            return View(contentItem);
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult AddReviewConentItem(int reviewContentId, FormCollection form, ReviewLocalResource[] localizations)
        {

            var content = _context.ReviewContent.First(c => c.Id == reviewContentId);

            var contentItem = new ReviewContentItem();
            TryUpdateModel(contentItem, new[] { "SortOrder", "ContentType" });
            contentItem.Text = HttpUtility.HtmlDecode(form["Text"]);
            content.ReviewContentItems.Add(contentItem);
            _context.SaveChanges();

            if (localizations != null && localizations.Length > 0)
            {
                localizations.ToList().ForEach(l =>
                {
                    l.Text = HttpUtility.HtmlDecode(l.Text);
                    l.EntityId = content.Id;
                });

                localizations.SaveLocalizationsTo(_context.ReviewLocalResources, false);
                content.UpdateValues(localizations.Where(l => l.Language == "ru-RU"));

                _context.SaveChanges();
            }


            return RedirectToAction("Details", "Review", new { Area = "", id = content.Name });

        }
        [Authorize(Roles = "Administrators")]
        public ActionResult EditReviewConentItem(int id)
        {
            ViewData["context"] = _context;
            var content = _context.ReviewContentItem.Include("ReviewContent").First(c => c.Id == id);
            ViewData["reviewContentId"] = content.ReviewContent.Id;
            ViewData["reviewContentName"] = content.ReviewContent.Name;
            return View(content);

        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult EditReviewConentItem(FormCollection form, ReviewLocalResource[] localizations)
        {

            int id = Convert.ToInt32(form["Id"]);
            var content = _context.ReviewContentItem.Include("ReviewContent").First(c => c.Id == id);
            var contentName = content.ReviewContent.Name;
            TryUpdateModel(content, new[] { "SortOrder" });
            content.Text = HttpUtility.HtmlDecode(form["Text"]);
            _context.SaveChanges();

            if (localizations != null && localizations.Length > 0)
            {
                localizations.ToList().ForEach(l =>
                {
                    l.Text = HttpUtility.HtmlDecode(l.Text);
                    l.EntityId = content.Id;
                });

                localizations.SaveLocalizationsTo(_context.ReviewLocalResources, false);
                content.UpdateValues(localizations.Where(l => l.Language == "ru-RU"));

                _context.SaveChanges();
            }

            return RedirectToAction("Details", "Review", new { Area = "", id = contentName });


        }
        [Authorize(Roles = "Administrators")]
        public ActionResult DeleteReviewContentItem(int id)
        {

            var contentItem = _context.ReviewContentItem.Include("ReviewContent").Include("ReviewContentItemImages").First(c => c.Id == id);
            string contentName = contentItem.ReviewContent.Name;

            while (contentItem.ReviewContentItemImages.Any())
            {
                var image = contentItem.ReviewContentItemImages.First();
                IOHelper.DeleteFile("~/Content/ReviewImages", image.ImageSource);
                _context.DeleteObject(image);
            }


            _context.DeleteObject(contentItem);
            _context.SaveChanges();

            return RedirectToAction("Details", "Review", new { Area = "", id = contentName });

        }

        [Authorize(Roles = "Administrators")]
        public ActionResult CheckForEmptyEntriesAndDelete(int id)
        {

            var contentItem = _context.ReviewContentItem.Include("ReviewContent").Include("ReviewContentItemImages").First(c => c.Id == id);
            string contentName = contentItem.ReviewContent.Name;
            if (!contentItem.ReviewContentItemImages.Any())
            {
                _context.DeleteObject(contentItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Details", "Review", new { Area = "", id = contentName });

        }

        public ActionResult AddReviewContentItemImage(int reviewContentId, int? reviewContentItemId)
        {

            var content = _context.ReviewContent.First(c => c.Id == reviewContentId);
            ReviewContentItem contentItem;

            if (!reviewContentItemId.HasValue)
            {

                contentItem = new ReviewContentItem { ContentType = 3 };
                content.ReviewContentItems.Add(contentItem);
                _context.SaveChanges();
                reviewContentItemId = contentItem.Id;

            }
            else
            {
                contentItem = _context.ReviewContentItem.Include("ReviewContentItemImages").First(c => c.Id == reviewContentItemId);
                ViewData["hasImages"] = true;
            }

            ViewData["reviewContentItemId"] = reviewContentItemId;
            ViewData["reviewContentId"] = reviewContentId;

            ViewData["scriptData"] = string.Format("{{ReviewContentId: {0}, ReviewContentItemId: {1}}}", reviewContentId, reviewContentItemId);

            ViewData["reviewContentName"] = content.Name;
            return View(contentItem);

        }

        [HttpPost]
        public ActionResult AddReviewContentItemImage(int reviewContentId, int? reviewContentItemId, FormCollection form)
        {

            var content = _context.ReviewContent.First(c => c.Id == reviewContentId);
            if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
            {
                ReviewContentItem contentItem;

                if (reviewContentItemId.HasValue)
                {
                    contentItem = _context.ReviewContentItem.First(c => c.Id == reviewContentItemId);
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
                _context.SaveChanges();
            }
            return RedirectToAction("Details", "Review", new { Area = "", id = content.Name });
        }


        static object lockobj = 1;

        [HttpPost]
        public void UploadImage(FormCollection form)
        {
            lock (lockobj)
            {
                int reviewContentId = Convert.ToInt32(form["ReviewContentId"]);
                int reviewContentItemId = Convert.ToInt32(form["ReviewContentItemId"]);

                var content = _context.ReviewContent.First(c => c.Id == reviewContentId);

                ReviewContentItem contentItem;

                if (reviewContentItemId != 0)
                {
                    contentItem = _context.ReviewContentItem.First(c => c.Id == reviewContentItemId);
                }
                else
                {
                    contentItem = new ReviewContentItem { ContentType = 3 };
                    content.ReviewContentItems.Add(contentItem);
                }

                HttpPostedFileBase file = Request.Files["Filedata"];
                //string fileName = IOHelper.GetUniqueFileName(folderRelativePath, file.FileName);
                string fileName = IOHelper.GetUniqueFileName("~/Content/ReviewImages", file.FileName);
                string filePath = Server.MapPath("~/Content/ReviewImages");
                filePath = Path.Combine(filePath, fileName);
                file.SaveAs(filePath);
                var image = new ReviewContentItemImage { ImageSource = fileName };
                contentItem.ReviewContentItemImages.Add(image);
                _context.SaveChanges();
            }
            Response.Write("1");
        }


        public ActionResult DeleteReviewContentItemImage(int id, string contentName)
        {
            var image = _context.ReviewContentItemImage.Include("ReviewContentItem").First(i => i.Id == id);
            var contentItem = image.ReviewContentItem;
            var contentItemImagesCount = image.ReviewContentItem.ReviewContentItemImages.Count();
            IOHelper.DeleteFile("~/Content/ReviewImages", image.ImageSource);
            _context.DeleteObject(image);
            if (contentItemImagesCount == 1)
                _context.DeleteObject(contentItem);
            _context.SaveChanges();
            return RedirectToAction("Details", "Review", new { Area = "", id = contentName });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

    }
}
