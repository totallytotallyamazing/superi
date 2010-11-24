using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using Dev.Helpers;
using System.Net.Mail;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ArticlesController : Controller
    {
        //
        // GET: /Admin/Articles/
        [HttpGet]
        public ActionResult AddEdit(int? id, int type)
        {
            Article article = null;
            ViewData["type"] = type;
            if (id.HasValue)
            {
                using (ContentStorage context = new ContentStorage())
                {
                    article = context.Articles.Select(a => a).Where(a => a.Id == id.Value).First();
                }
            }
            return View(article);
        }

        [HttpPost]
        public ActionResult AddEdit(Article article, int? Id, bool send)
        {
            using (ContentStorage context = new ContentStorage())
            {
                if (Id.HasValue && Id.Value > 0)
                {
                    article.Id = Id.Value;
                    article.Name = article.Title;
                    article.Text = HttpUtility.HtmlDecode(article.Text);
                    article.Language = "ru-RU";
                    object originalItem;
                    EntityKey entityKey = new EntityKey("ContentStorage.Articles", "Id", article.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyCurrentValues(entityKey.EntitySetName, article);
                    }
                }
                else
                {
                    article.Text = HttpUtility.HtmlDecode(article.Text);
                    article.Language = "ru-RU";
                    article.Name = article.Title;
                    context.AddToArticles(article);
                }
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Articles", new { area = "", type = article.Type });
        }

        private void SendArticle(Article article)
        {
            using (Clients context = new Clients())
                foreach (var item in context.Subscribers)
                    MailHelper.SendTemplate(new List<MailAddress> { new MailAddress(item.Email) }, article.Title, "Newsletter.htm", null, true, article.Text);
        }

        public ActionResult Delete(int id)
        {
            using (ContentStorage context = new ContentStorage())
            {
                Article article = context.Articles.Where(a => a.Id == id).First();
                context.DeleteObject(article);
                context.SaveChanges();
                return RedirectToAction("Index", "Articles", new { area = "", type = article.Type }); 
            }
        }
    }
}
