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
                    List<Article> articles = context.Articles.Where(a => a.Name == name).OrderByDescending(a => a.Language).Select(a => a).ToList();
                    
                }
            }
            return View();
        }
    }
}
