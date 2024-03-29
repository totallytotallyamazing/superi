﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Models;
using System.Data;

namespace Lady.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult Edit(string id)
        {
            using (ContentStorage context = new ContentStorage())
            {
                Content content = context.GetContent(id);
                return View(content);
            }
        }

        [HttpPost]
        public ActionResult Edit(Content content)
        {
            using (ContentStorage context = new ContentStorage())
            {
                Models.Content originalItem = context.Contents.Where(c => c.Name == content.Name).First();
                content.Id = originalItem.Id;
                content.Text = HttpUtility.HtmlDecode(content.Text);
                context.ApplyPropertyChanges("Contents", content);

                context.SaveChanges();
            }

            

            return RedirectToAction("Go", "Home", new { id = content.Name, area = "" });
        }

    }
}
