using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using Superi.Web.Mvc.Localization;


namespace Shop.Controllers
{
    public class ReviewController : Controller
    {
        //
        // GET: /AltObzor/

        public ActionResult Index()
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent//.Where(c=>c.Id!=6)
                    .Localize((c, l) => new { Content = c, Localizations = l }, context.ReviewLocalResources, null)
                    .ToList()
                    .Select(item => item.Content.UpdateValues(item.Localizations));
                ViewData["reviewHeaderText"] = content.First(c => c.Id == 6).Description;
                return View(content.Where(c => c.Id != 6));
            }
        }

        public ActionResult Details(string id)
        {
            using (var context = new ReviewStorage())
            {
                var content = context.ReviewContent.Include("ReviewContentItems").Where(c => c.Name == id).First();
                foreach (var item in content.ReviewContentItems)
                {
                    item.ReviewContentItemImages.Load();
                }
                ViewData["reviewContentId"] = content.Id;
                ViewData["reviewContentName"] = content.Name;

                ViewData["reviewHeaderText"] = context.ReviewContent.Where(c => c.Id == 6).Select(c=>c.Description).FirstOrDefault();

                return View(content);
            }
        }
    }
}
