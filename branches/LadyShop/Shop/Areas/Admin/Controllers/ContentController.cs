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
                Content originalItem = context.Contents.Where(c => c.Name == content.Name).First();
                content.Id = originalItem.Id;
                content.Text = HttpUtility.HtmlDecode(content.Text);
                context.ApplyCurrentValues("Contents", content);

                context.SaveChanges();
            }
            return RedirectToAction("Go", "Home", new { id = content.Name, area = "" });
        }

    }
}
