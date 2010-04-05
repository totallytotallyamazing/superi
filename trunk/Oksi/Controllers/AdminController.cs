using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Oksi.Models;
using Oksi.Helpers;

namespace Oksi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult EditText(string id)
        {
            using (DataStorage context = new DataStorage())
            {
                SiteContent content = context.GetContent(id);
                ViewData["text"] = content.Text;
                ViewData["contentName"] = id;
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public void EditText(string text, string contentName)
        {
            using (DataStorage context = new DataStorage())
                context.UpdateContext(contentName, HttpUtility.HtmlDecode(text), " ", null, null);
            Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close();window.top.ClientLibrary.PageManager.get_current().goToUrl(\"/Home/Content/bio\");</script>");
        }

        public ActionResult Article(string id)
        {
            ViewData["Id"] = 0;
            ViewData["Image"] = "";
            if (!string.IsNullOrEmpty(id))
            {
                using (DataStorage context = new DataStorage())
                {
                    var articles = context.Articles.Where(a => a.Name == id).Select(a => a);
                    foreach (var item in articles)
                    {
                        ViewData["id"] = item.Id;
                        ViewData["name"] = item.Name;
                        ViewData["title"] = item.Title;
                        ViewData["date"] = item.Date;
                        ViewData["description"] = item.Description;
                        ViewData["text"] = item.Text;
                        ViewData["image"] = item.Image;
                    }
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Article(Article article)
        {
            using (DataStorage context = new DataStorage())
            {
                if (article.Id > 0)
                {
                    context.Attach(article);
                }
                else
                {
                    context.AddToArticles(article);
                }
                context.AcceptAllChanges();
                context.SaveChanges();
            }
            return RedirectToAction("Articles");
        }

        #region Galleries
        public ActionResult AddEditGallery(int? id)
        {
            ViewData["id"] = id;
            if (id != null)
            {
                using (DataStorage context = new DataStorage())
                {
                    var gallery = context.Galleries.Where(g => g.Id == id.Value).Select(g => new { name = g.Name, comments = g.Comments }).First();
                    ViewData["name"] = gallery.name;
                    ViewData["comments"] = gallery.comments;
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void AddEditGallery(int? id, string name, string comments)
        {
            using (DataStorage context = new DataStorage())
            {
                Gallery gallery = null;
                if (id != null)
                {
                    gallery = context.Galleries.Where(g => g.Id == id.Value).First();
                }
                else
                {
                    gallery = new Gallery();
                }

                gallery.Name = name;
                gallery.Comments = comments;

                if (id == null)
                {
                    context.AddToGalleries(gallery);
                }

                context.SaveChanges();
            }
        }

        public void DeleteGallery(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Gallery gallery = context.Galleries.Where(g => g.Id == id).First();

                foreach (var item in gallery.Images)
                {
                    context.DeleteObject(item);
                    DeleteImage(item.Picture);
                    DeleteImage(item.Preview);
                }

                context.DeleteObject(gallery);

                context.SaveChanges();
            }
        }

        private void DeleteImage(string fileName)
        {
            IOHelper.DeleteFile("~/Content/GalleryContent", fileName);
        }

        public ActionResult AddImage(int id)
        {
            ViewData["galleryId"] = id;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void AddImage(long galleryId, FormCollection frm)
        {
            string preview = Request.Files["preview"].FileName;
            string picture = Request.Files["picture"].FileName;
            if (!string.IsNullOrEmpty(preview) && !string.IsNullOrEmpty(picture))
            {
                string previewName = IOHelper.GetUniqueFileName("~/GalleryContent", preview);
                Request.Files["preview"].SaveAs(IOHelper.CreateAbsolutePath("~/GalleryContent", previewName));

                string pictureName = IOHelper.GetUniqueFileName("~/GalleryContent", picture);
                Request.Files["picture"].SaveAs(IOHelper.CreateAbsolutePath("~/GalleryContent", pictureName));

                using (DataStorage context = new DataStorage())
                {
                    Image image = new Image();
                    image.GalleryReference.EntityKey = new System.Data.EntityKey("DataStorage.Galleries", "Id", galleryId);
                    image.Preview = previewName;
                    image.Picture = pictureName;
                    context.AddToImages(image);
                    context.SaveChanges();
                }
            }

            Response.Write("<script type=\"text/javascript\">window.top.ClientLibrary.GalleryExtender.update();</script>");
        }

        public void DeleteImage(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Image image = context.Images.Where(i => i.Id == id).First();
                DeleteImage(image.Picture);
                DeleteImage(image.Preview);
                context.DeleteObject(image);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
