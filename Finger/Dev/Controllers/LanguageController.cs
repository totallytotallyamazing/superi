using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Models;
using Dev.Helpers;
using System.Globalization;
using System.Threading;

namespace Dev.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult SetLanguage(string language, string contentController, string contentUrl)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(language);
            string newUrl = contentUrl;
            if (!string.IsNullOrEmpty(contentUrl))
            {
                using (DataStorage context = new DataStorage())
                {
                    newUrl = (from content in context.SiteContent
                              where content.Url == contentUrl
                              let contentName = content.Name
                              select
                                (from sc in context.SiteContent where sc.Language == language && sc.Name == contentName select sc.Url).First())
                              .First();
                }
            }
            return RedirectToAction("Index", contentController, new { contentUrl = newUrl });
        }
    }
}
