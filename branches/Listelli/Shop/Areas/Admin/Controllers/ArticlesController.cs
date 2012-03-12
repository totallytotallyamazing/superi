using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using Dev.Helpers;
using System.Net.Mail;
using Superi.Web.Mvc.Localization;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ArticlesController : Controller
    {
        ContentStorage context = new ContentStorage();
        //
        // GET: /Admin/Articles/
        [HttpGet]
        public ActionResult AddEdit(int? id, int type)
        {
            ViewData["context"] = context;
            Article article = null;
            ViewData["type"] = type;
            if (id.HasValue)
                article = context.Articles.Select(a => a).Where(a => a.Id == id.Value).First();
            return View(article);
        }

        [HttpPost]
        public ActionResult AddEdit(Article article, int? Id, bool send, ContentLocalResource[] localizations)
        {
            bool add = false;
            if (Id.HasValue && Id.Value > 0)
            {
                article.Id = Id.Value;
                article.Name = article.Title ?? string.Empty;
                article.Title = article.Title ?? string.Empty;
                article.Text = HttpUtility.HtmlDecode(article.Text);
                article.Language = "ru-RU";
                object originalItem;
                EntityKey entityKey = new EntityKey("ContentStorage.Articles", "Id", article.Id);
                if (context.TryGetObjectByKey(entityKey, out originalItem))
                    context.ApplyCurrentValues(entityKey.EntitySetName, article);
            }
            else
            {
                add = true;
                article.Text = HttpUtility.HtmlDecode(article.Text);
                article.Language = "ru-RU";
                article.Name = article.Title ?? string.Empty;
                article.Title = article.Title ?? string.Empty;
                context.AddToArticles(article);
                // TODO: Добавлена отправка новостей

            }

            if (localizations != null && localizations.Length > 0)
            {
                if (add)
                {
                    context.SaveChanges();
                }
                localizations.ToList().ForEach(l => { l.Text = HttpUtility.HtmlDecode(l.Text);
                                                        l.EntityId = article.Id;
                });
                localizations.SaveLocalizationsTo(context.ContentLocalResource, false);
                article.UpdateValues(localizations.Where(l => l.Language == "ru-RU"));
            }

            context.SaveChanges();
            if (send)
                SendArticle(article);
            return RedirectToAction("Index", "Articles", new { area = "", type = article.Type });
        }

        private void SendArticle(Article article)
        {
            using (Clients context = new Clients())
            {
                string articleText = HttpUtility.HtmlDecode(article.Text).Replace("src=\"", "src=\"http://listelli.ua");
                List<MailAddress> addresses = new List<MailAddress>();
                foreach (var item in context.Subscribers.Where(s => s.IsActive))
                    addresses.Add(new MailAddress(item.Email));
                MailHelper.SendTemplate(addresses, article.Title, "Newsletter.htm", null, true, articleText);
            }
        }

        public ActionResult Delete(int id)
        {
            Article article = context.Articles.Where(a => a.Id == id).First();
            var localizations = article.Localizations(context.ContentLocalResource);
            foreach (var item in localizations)
            {
                context.DeleteObject(item);
            }
            context.DeleteObject(article);
            context.SaveChanges();
            return RedirectToAction("Index", "Articles", new { area = "", type = article.Type });
        }
    }
}
