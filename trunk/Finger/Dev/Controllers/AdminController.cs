using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;
using Dev.Helpers;

namespace Dev.Controllers
{
    public class AdminController : LocalizedController
    {
        [OutputCache(NoStore = true, Duration = 1, VaryByParam = "*")]
        public ActionResult EditText(string contentName, string controllerName)
        {
            using (DataStorage context = new DataStorage())
            {
                SiteContent content = context.GetContent(contentName, LocaleHelper.GetCultureName());
                ViewData["controllerName"] = controllerName;
                ViewData["text"] = content.Text;
                ViewData["editTitle"] = content.Title;
                ViewData["subTitle"] = content.SubTitle;
                ViewData["keywords"] = content.Keywords;
                ViewData["description"] = content.Description;
                ViewData["contentName"] = contentName;
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditText(string text, string editTitle, string subTitle, string keywords, string description, string controllerName, string contentName)
        {
            using (DataStorage context = new DataStorage())
                context.UpdateContent(contentName, LocaleHelper.GetCultureName(), HttpUtility.HtmlDecode(text), editTitle, subTitle, keywords, description); ;

            return RedirectToAction("Index", controllerName, new { contentUrl = contentName, culture = LocaleHelper.GetCultureName() });
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
