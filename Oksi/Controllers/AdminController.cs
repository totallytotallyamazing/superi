using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Oksi.Models;
using Oksi.Helpers;
using Helpers;
using System.IO;
using System.Data;

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

        public ActionResult Articles(int id)
        {
            ViewData["pageTitle"] = (id == 1) ? "Новости" : "Пресса";
            ViewData["news"] = (id == 1);
            using (DataStorage context = new DataStorage())
            {
                var articles = context.Articles.Where(a => a.Type == id)
                    .OrderByDescending(a => a.Date).ToList();
                return View(articles);
            }
        }

        public ActionResult Article(int? id, bool news)
        {
            ViewData["Id"] = 0;
            ViewData["Image"] = "";
            int type = (news) ? 1 : 2;
            ViewData["type"] = type;
            ViewData["pageTitle"] = (news) ? "Новости" : "Пресса";
            ViewData["folder"] = (news) ? "News" : "Press";
            if (id > 0)
            {
                using (DataStorage context = new DataStorage())
                {
                    var article = context.Articles.Where(a => a.Id == id)
                        .Where(a => a.Type == type)
                        .Select(a => a).First();
                    return View(article);
                }
            }
            return View();
        }

        public ActionResult DeleteArticle(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Article article = context.Articles.Where(a => a.Id == id).First();
                string folder = (article.Type == 1) ? "News" : "Press";
                string filePath = "/Content/Articles/" + folder + "/";
                IOHelper.DeleteFile(filePath, article.Image);
                context.DeleteObject(article);
                long type = article.Type;
                context.SaveChanges();
                return RedirectToAction("Articles", new { id = type });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Article(Article article)
        {
            using (DataStorage context = new DataStorage())
            {
                article.Text = HttpUtility.HtmlDecode(article.Text);
                article.Description = HttpUtility.HtmlDecode(article.Description);
                if (Request.Files["picture"] != null &&
                    !string.IsNullOrEmpty(Request.Files["picture"].FileName))
                {
                    string folder = (article.Type == 1) ? "News" : "Press";
                    string fileName = Request.Files["picture"].FileName;
                    string filePath = "~/Content/Articles/" + folder + "/";
                    string newFilePath = Path.Combine(Server.MapPath(filePath), IOHelper.GetUniqueFileName(filePath, fileName));
                    if (article.Id > 0)
                    {
                        IOHelper.DeleteFile(filePath, article.Image);
                    }
                    Request.Files["picture"].SaveAs(newFilePath);
                    article.Image = Path.GetFileName(newFilePath);
                }
                else
                {
                    //article.Image = "oksiSiteDefaultArticleImage.jpg";
                }
                article.Name = TextHelper.Transliterate(article.Title);
                if (article.Id > 0)
                {
                    object objectValue = null;
                    EntityKey key = new EntityKey("DataStorage.Articles", "Id", article.Id);
                    if (context.TryGetObjectByKey(key, out objectValue))
                    {
                        context.ApplyPropertyChanges("Articles", article);
                    }
                }
                else
                {
                    context.AddToArticles(article);
                }
                context.SaveChanges();
            }
            return RedirectToAction("Articles", new { id = article.Type });
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

                context.DeleteObject(gallery);

                context.SaveChanges();
            }
        }

        private void DeleteImage(string fileName)
        {
            IOHelper.DeleteFile("~/Content/GalleryContent", fileName);
        }
       
        public ActionResult DeleteImage(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Image image = context.Images.Where(i => i.Id == id).First();
                DeleteImage(image.Picture);
                DeleteImage(image.Preview);
                context.DeleteObject(image);
                context.SaveChanges();
            }

            return Json(null);
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
        #endregion
    }
}

