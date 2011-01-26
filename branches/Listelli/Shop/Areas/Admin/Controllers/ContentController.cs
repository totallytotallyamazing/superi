using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
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
                context.ApplyCurrentValues("Contents", content);

                context.SaveChanges();
            }
            return RedirectToAction("Go", "Home", new { id = content.Name, area = "" });
        }

        //[HttpPost]
        //public ActionResult Edit(IList<LocalResource> localizations, int name)
        //{
        //    return RedirectToAction("Go", "Home", new { id = name, area = "" });
        //}

        [HttpGet]
        public ActionResult EditPartial(string id)
        {
            using (ContentStorage context = new ContentStorage())
            {
                Content content = context.GetContent(id);
                return View(content);
            }
        }

        [HttpPost]
        public void EditPartial(FormCollection form)
        {
            using (ContentStorage context = new ContentStorage())
            {
                string name = form["Name"];
                Content content = context.Contents.First(c => c.Name == name);
                content.Text = HttpUtility.HtmlDecode(form["Text"]);
                context.SaveChanges();
            }
            Response.Write("<script type=\"text/javascript\">window.top.$.fancybox.close();</script>");
        }
    }
}
