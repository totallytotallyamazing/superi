using Jackson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jackson.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        readonly SiteContext _context = null;

        public HomeController(SiteContext context)
        {
            _context = context;
        }

        public ActionResult Index(string id)
        {
            IEnumerable<Item> model = null;
            Group group = null;
            if (string.IsNullOrEmpty(id))
            {
                group = _context.Groups.AsNoTracking().Include("Items").FirstOrDefault();
            }
            else 
            {
                group = _context.Groups.AsNoTracking().Include("Items").FirstOrDefault(g=>g.Url == id);
            }

            if (group != null)
            {
                model = group.Items;
                ViewBag.Id = group.Url;
            }
            else if(!string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", new { controller = "Home", id = UrlParameter.Optional });
            }
            
            if (model != null)
            {
                model = model.OrderBy(i => i.SortOrder);
            }

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Menu(string id) 
        {
            ViewBag.Id = id;
            return PartialView(_context.Groups);
        }

    }
}
