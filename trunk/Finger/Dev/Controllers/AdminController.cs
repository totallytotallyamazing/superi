using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;

namespace Dev.Controllers
{
    public class AdminController : Controller
    {
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult EditText(string contentUrl, string controllerName)
        {
            using (DataStorage context = new DataStorage())
            {
                SiteContent content = context.GetContent(contentUrl);
                ViewData["controllerName"] = controllerName;
                ViewData["text"] = content.Text;
                ViewData["editTitle"] = content.Title;
                ViewData["keywords"] = content.Keywords;
                ViewData["description"] = content.Description;
                ViewData["contentUrl"] = contentUrl;
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditText(string text, string editTitle, string keywords, string description, string controllerName, string contentUrl)
        {
            using (DataStorage context = new DataStorage())
                context.UpdateContext(contentUrl, HttpUtility.HtmlDecode(text), editTitle, keywords, description); ;

            return RedirectToAction("Index", controllerName, new { contentUrl = contentUrl });
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
    }
}
