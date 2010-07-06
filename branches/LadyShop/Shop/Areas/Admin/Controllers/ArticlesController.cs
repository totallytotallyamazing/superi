﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ArticlesController : Controller
    {
        //
        // GET: /Admin/Articles/
        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            Article article = null;
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
        public ActionResult AddEdit(Article article, int? Id)
        {
            using (ContentStorage context = new ContentStorage())
            {
                if (Id.HasValue && Id.Value > 0)
                {
                    article.Id = Id.Value;
                    object originalItem;
                    EntityKey entityKey = new EntityKey("ContentStorage.Articles", "Id", article.Id);
                    if (context.TryGetObjectByKey(entityKey, out originalItem))
                    {
                        context.ApplyPropertyChanges(entityKey.EntitySetName, article);
                    }
                }
                else
                {
                    article.Language = "ru-RU";
                    article.Name = article.Title;
                    context.AddToArticles(article);
                }
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Articles", new { area = ""});
        }
    }
}
