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
        public ActionResult EditText(string contentName, string controllerName)
        {
            using (DataStorage context = new DataStorage())
            {
                SiteContent content = context.GetContent(contentName);
                ViewData["controllerName"] = controllerName;
                ViewData["text"] = content.Text;
                ViewData["editTitle"] = content.Title;
                ViewData["keywords"] = content.Keywords;
                ViewData["description"] = content.Description;
                ViewData["contentName"] = contentName;
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditText(string text, string editTitle, string keywords, string description, string controllerName, string contentName)
        {
            using (DataStorage context = new DataStorage())
                context.UpdateContext(contentName, HttpUtility.HtmlDecode(text), editTitle, keywords, description); ;

            return RedirectToAction("Index", controllerName, new { contentUrl = contentName });
        }

        public ActionResult Article(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                using (DataStorage context = new DataStorage())
                {
                    var articles = context.Articles.Where(a => a.Name == name).OrderByDescending(a => a.Language).Select(a => a);
                    foreach (var item in articles)
                    {
                        ViewData["id_" + item.Language] = item.Id;
                        ViewData["name_" + item.Language] = item.Name;
                        ViewData["title_" + item.Language] = item.Title;
                        ViewData["date_" + item.Language] = item.Date;
                        ViewData["description_" + item.Language] = item.Description;
                        ViewData["text_" + item.Language] = item.Text;
                        ViewData["image_" + item.Language] = item.Image;
                    }
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void Article(ArticleTranslations articleTranslations)
        {
            using (DataStorage context = new DataStorage())
            {
                foreach (string key in articleTranslations.Keys)
                {
                    if (articleTranslations[key].Id > 0)
                    {
                        context.Attach(articleTranslations[key]);
                    }
                    else
                    {
                        context.AddToArticles(articleTranslations[key]);
                    }
                    context.AcceptAllChanges();
                    context.SaveChanges();
                }
            }
            Response.Write("blabla");
        }

        #region Galleries
        public ActionResult AddEditGallery(int? id)
        {
            ViewData["id"] = id;
            if (id != null)
            {
                using (DataStorage context = new DataStorage())
                {
                    var gallery = context.Galleries.Where(g => g.Id == id.Value).Select(g => new {name = g.Name, comments = g.Comments }).First();
                    ViewData["name"] = gallery.name;
                    ViewData["comments"] = gallery.comments;
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void AddEditGallery(int? id, string name, string comments)
        {
            using(DataStorage context = new DataStorage())
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

        public void DeleteImage(string fileName)
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
