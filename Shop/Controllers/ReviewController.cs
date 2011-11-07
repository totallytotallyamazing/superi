using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

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
                var content = context.ReviewContent.ToList();
                return View(content);
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
                return View(content);
            }
        }
    }
}
