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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProcessArticle(bool news, string title, string description, string text)
        {
            ViewData["Id"] = 0;
            ViewData["Image"] = "";
            int type = (news) ? 1 : 2;
            ViewData["type"] = type;
            ViewData["Title"] = title;
            ViewData["Description"] = description;
            ViewData["Text"] = text;
            ViewData["pageTitle"] = (news) ? "Новости" : "Пресса";
            ViewData["folder"] = (news) ? "News" : "Press";
            return View("Article");
        }


        public ActionResult NewArticle(bool news)
        {
            ViewData["Id"] = 0;
            ViewData["Image"] = "";
            ViewData["News"] = news;
            int type = (news) ? 1 : 2;
            ViewData["type"] = type;
            ViewData["pageTitle"] = (news) ? "Новости" : "Пресса";
            ViewData["folder"] = (news) ? "News" : "Press";
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
                        if (string.IsNullOrEmpty(article.Image))
                        {
                            article.Image = ((Article)objectValue).Image;
                        }
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


        public ActionResult Albums()
        {
            using (var context = new DataStorage())
            {
                var albums = context.Albums.Include("Songs").ToList();
                return View(albums);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddSong(FormCollection form, int albumId)
        {
            using (DataStorage context = new DataStorage())
            {

                var album = context.Albums.Where(a => a.Id == albumId).First();

               

                if (Request.Files["song"] != null && !string.IsNullOrEmpty(Request.Files["song"].FileName))
                {

                    string fileName = Request.Files["song"].FileName;
                    string filePath = "~/Songs/";
                    string newFilePath = Path.Combine(Server.MapPath(filePath), IOHelper.GetUniqueFileName(filePath, fileName));
                    /*if (article.Id > 0)
                    {
                        IOHelper.DeleteFile(filePath, article.Image);
                    }*/
                    Request.Files["song"].SaveAs(newFilePath);
                   

                    var song = new Song
                                   {
                                       Album = album,
                                       Source = Path.Combine("http://oksi-com-ua.1gb.ua/Songs/", Path.GetFileName(newFilePath)),
                                       TrackNumber = Convert.ToInt32(form["TrackNumber"]),
                                       Title = form["SongTitle"]
                                   };


                    context.AddToSongs(song);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Albums");
        }

        public ActionResult DeleteSong(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                string filePath = "~/Songs/";
                var song = context.Songs.Where(s => s.Id == id).First();
                IOHelper.DeleteFile(filePath, song.Source);
                context.DeleteObject(song);
                context.SaveChanges();
            }
            return RedirectToAction("Albums");
        }




        public ActionResult Banners()
        {
            using (BannerStorage context = new BannerStorage())
            {
                List<Banner> banners = context.Banner.ToList();
                return View(banners);
            }
        }
        
        
        public ActionResult DeleteBanner(int id)
        {
            using (var context = new BannerStorage())
            {
                Banner banner = context.Banner.First(b => b.id == id);

                if (!string.IsNullOrEmpty(banner.ImageSource))
                {
                    IOHelper.DeleteFile("~/Content/Banners", banner.ImageSource);
                }

                context.DeleteObject(banner);
                context.SaveChanges();
            }
            return RedirectToAction("Banners");
        }

        public ActionResult BannerAddEdit(int? id)
        {

            Banner banner = null;
            if (id.HasValue)
            {
                using (var context = new BannerStorage())
                {
                    banner = context.Banner.First(b => b.id == id.Value);
                }
            }
            return View(banner);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BannerAddEdit(FormCollection form)
        {
            using (var context = new BannerStorage())
            {
                int id;
                Banner banner;
                if (int.TryParse(form["Id"], out id))
                    banner = context.Banner.First(b => b.id == id);
                else
                {
                    banner = new Banner();
                    context.AddToBanner(banner);
                }

                TryUpdateModel(banner, new string[] { "Position" }, form.ToValueProvider());


                if (Request.Files["logo"] != null && !string.IsNullOrEmpty(Request.Files["logo"].FileName))
                {
                    if (!string.IsNullOrEmpty(banner.ImageSource))
                    {
                        IOHelper.DeleteFile("~/Content/Banners", banner.ImageSource);
                    }
                    string fileName = IOHelper.GetUniqueFileName("~/Content/Banners", Request.Files["logo"].FileName);
                    string filePath = Server.MapPath("~/Content/Banners");
                    filePath = Path.Combine(filePath, fileName);
                    Request.Files["logo"].SaveAs(filePath);
                    banner.ImageSource = fileName;
                }

                context.SaveChanges();
            }

            return RedirectToAction("Banners");
        }





        #region Videos

        public ActionResult Video()
        {
            using (DataStorage context = new DataStorage())
            {
                List<Clip> clips = context.Clips.OrderBy(c => c.SortOrder).ToList();
                return View(clips);
            }
        }

        public ActionResult EditVideo(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Clip clip = context.Clips.Where(c => c.Id == id).First();
                return View(clip);
            }
        }


        public ActionResult CreateVideo()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateVideo(Clip c, FormCollection form)
        {
            using (DataStorage context = new DataStorage())
            {
                Clip clip = new Clip
                {
                    Comment = c.Comment,
                    Title = c.Title,
                    Year = c.Year,
                    SortOrder = c.SortOrder,
                    Description = c.Description
                };

                if (!string.IsNullOrEmpty(form["newUrl"]))
                {
                    string newId = TextHelper.GetYoutubeId2(form["newUrl"]);
                    clip.Source =
                        string.Format(
                            "<object width=\"640\" height=\"385\"><param name=\"movie\" value=\"http://www.youtube.com/v/{0}&hl=ru_RU&fs=1&\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"http://www.youtube.com/v/{0}&hl=ru_RU&fs=1&\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"640\" height=\"385\"></embed></object>",
                            newId);
                    clip.SmallSource =
                        string.Format(
                            "<object width=\"433\" height=\"250\"><param name=\"movie\" value=\"http://www.youtube.com/v/{0}&hl=ru_RU&fs=1&\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"http://www.youtube.com/v/{0}&hl=ru_RU&fs=1&\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"433\" height=\"250\"></embed></object>",
                            newId);


                    context.AddToClips(clip);

                    context.SaveChanges();
                }
            }
            return RedirectToAction("Video");
        }

        public ActionResult DeleteVideo(int id)
        {
            using (DataStorage context = new DataStorage())
            {
                Clip clip = context.Clips.Where(c => c.Id == id).First();
                context.DeleteObject(clip);
                context.SaveChanges();
            }
            return RedirectToAction("Video");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditVideo(FormCollection form)
        {
            int id = Convert.ToInt32(form["Id"]);
            using (DataStorage context = new DataStorage())
            {
                Clip clip = context.Clips.Where(c => c.Id == id).First();

                if (!string.IsNullOrEmpty(form["newUrl"]))
                {
                    string newId = TextHelper.GetYoutubeId2(form["newUrl"]);
                    clip.Source = string.Format("<object width=\"640\" height=\"385\"><param name=\"movie\" value=\"http://www.youtube.com/v/{0}&hl=ru_RU&fs=1&\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"http://www.youtube.com/v/{0}&hl=ru_RU&fs=1&\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"640\" height=\"385\"></embed></object>", newId);
                    clip.SmallSource = string.Format("<object width=\"433\" height=\"250\"><param name=\"movie\" value=\"http://www.youtube.com/v/{0}&hl=ru_RU&fs=1&\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"http://www.youtube.com/v/{0}&hl=ru_RU&fs=1&\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" width=\"433\" height=\"250\"></embed></object>", newId);
                }

                context.SaveChanges();
            }
            return RedirectToAction("Video");
        }

        #endregion


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

