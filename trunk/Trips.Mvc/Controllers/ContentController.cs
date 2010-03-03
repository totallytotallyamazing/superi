using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Trips.Mvc.Models;
using Dev.Helpers;

namespace Trips.Mvc.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult Index(string id)
        {
            using (ContentStorage context= new ContentStorage())
            {
                ViewData["id"] = id;
                string language = LocaleHelper.GetCultureName();
                Content content = context.Content
                    .Where(c=>c.Language == language)
                    .Where(c=>c.Name == id)
                    .FirstOrDefault();
                return View("Content", content); 
            }
        }

    }
}
