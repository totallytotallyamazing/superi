using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;
using Superi.Web.Mvc.Localization;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ContentController : Controller
    {
        ContentStorage context = new ContentStorage();

        public ActionResult Edit(string id)
        {
            {
                Content content = context.GetContent(id);
                ViewData["context"] = context;
                return View(content);
            }
        }

        [HttpPost]
        public ActionResult Edit(Content content, ContentLocalResource[] localizations)
        {
            Models.Content originalItem = context.Contents.Where(c => c.Name == content.Name).First();
            content.Id = originalItem.Id;
            content.Text = HttpUtility.HtmlDecode(content.Text);
            context.ApplyCurrentValues("Contents", content);
            if (localizations != null && localizations.Length > 0)
            {
                localizations.ToList().ForEach(l => l.Text = HttpUtility.HtmlDecode(l.Text));
                localizations.SeveLocalizationsTo(context.ContentLocalResource, false);
            }
            context.SaveChanges();
            return RedirectToAction("Go", "Home", new { id = content.Name, area = "" });
        }

        [HttpGet]
        public ActionResult EditPartial(string id)
        {
            Content content = context.GetContent(id);
            ViewData["context"] = context;
            return View(content);
        }

        [HttpPost]
        public void EditPartial(FormCollection form, ContentLocalResource[] localizations)
        {
            string name = form["Name"];
            Content content = context.Contents.First(c => c.Name == name);
            content.Text = HttpUtility.HtmlDecode(form["Text"]);
            if (localizations != null && localizations.Length > 0)
            {
                localizations.ToList().ForEach(l => l.Text = HttpUtility.HtmlDecode(l.Text));
                localizations.SeveLocalizationsTo(context.ContentLocalResource, false);
            }
            context.SaveChanges();
            Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close();</script>");
        }
    }
}
