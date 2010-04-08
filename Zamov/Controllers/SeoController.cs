using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class SeoController : Controller
    {
        //
        // GET: /Seo/
        [Authorize(Roles="Administrators, Managers")]
        public ActionResult Index()
        {
            string lang = SystemSettings.CurrentLanguage;
            ViewData["lng"] = lang;
            using (SeoStorage context = new SeoStorage())
            {
                return View(context.Seo.Where(s=>s.Language == lang).ToList());
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int? id, string lang, string url, string keywords, string description, string title)
        {
            using (SeoStorage context = new SeoStorage())
            {
                Seo seo;
                if (id != null)
                {
                    seo = context.Seo.Where(s => s.Id == id.Value).First();
                }
                else
                {
                    seo = new Seo();
                    context.AddToSeo(seo);
                }
                seo.Language = lang;
                seo.Url = url;
                seo.Keywords = keywords;
                seo.Description = description;
                seo.Title = title;

                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSeo(int id)
        {
            using (SeoStorage context = new SeoStorage())
            {
                Seo seo = context.Seo.Where(s => s.Id == id).First();
                context.DeleteObject(seo);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
