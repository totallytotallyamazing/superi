using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;
using Dev.Helpers;
using System.Globalization;
using System.Data;

namespace Dev.Controllers
{
    [Authorize]
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
            return RedirectToAction("Index", controllerName, new { contentName = contentName, culture = LocaleHelper.GetCultureName() });
        }

        public ActionResult Article(string contentName, ArticleType type)
        {
            if (!string.IsNullOrEmpty(contentName))
            {
                using (DataStorage context = new DataStorage())
                {
                    int typeId = (int)type;
                    var articles = context.Articles.Where(a => a.Name == contentName && a.Type == typeId).OrderByDescending(a => a.Language).Select(a => a);
                    foreach (var item in articles)
                    {
                        ViewData["id_" + item.Language] = item.Id;
                        ViewData["name"] = item.Name;
                        ViewData["title_" + item.Language] = item.Title;
                        ViewData["subTitle_" + item.Language] = item.SubTitle;
                        ViewData["date"] = item.Date.ToString("dd.MM.yyyy");
                        ViewData["description_" + item.Language] = item.Description;
                        ViewData["text_" + item.Language] = item.Text;
                        ViewData["image_" + item.Language] = item.Image;
                    }
                }
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Article(ArticleTranslations articleTranslations, string name, string date, ArticleType type)
        {
            using (DataStorage context = new DataStorage())
            {
                foreach (string key in articleTranslations.Keys)
                {
                    articleTranslations[key].Name = name;
                    articleTranslations[key].Date = DateTime.Parse(date, CultureInfo.GetCultureInfo("ru-RU"));
                    articleTranslations[key].Type = (int)type;
                    if (articleTranslations[key].Id > 0)
                    {
                        object originalItem;
                        EntityKey entityKey = context.CreateEntityKey("Articles", articleTranslations[key]);
                        if (context.TryGetObjectByKey(entityKey, out originalItem))
                        {
                            context.ApplyPropertyChanges(entityKey.EntitySetName, articleTranslations[key]);
                        }
                    }
                    else
                    {
                        context.AddToArticles(articleTranslations[key]);
                    }
                }
                context.SaveChanges();
            }
            if(type == ArticleType.Note)
                return RedirectToAction("Index", "Articles");
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteArticle(string contentName, ArticleType type)
        {
            using (DataStorage context = new DataStorage())
            {
                var articles = context.Articles.Where(a => a.Name == contentName && a.Type == (int)type).OrderByDescending(a => a.Language).Select(a => a);
                foreach (var item in articles)
                {
                    context.DeleteObject(item);
                }
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Articles");
        }
    }
}
