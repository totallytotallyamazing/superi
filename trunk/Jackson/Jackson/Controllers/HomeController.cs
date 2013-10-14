using System.Web.Management;
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

        [OutputCache(Duration = 1, NoStore = true, VaryByParam = "*")]
        public ActionResult Index(string id, string _escaped_fragment_)
        {
            if (!string.IsNullOrEmpty(_escaped_fragment_))
            {
                if (Request.UserAgent.Contains("facebookexternalhit"))
                {
                    ViewBag.Url = _escaped_fragment_;
                    return View("Facebook");
                }
                return Redirect("~/#!" + _escaped_fragment_);
            }

            IEnumerable<Item> model = null;
            Group group = null;
            if (string.IsNullOrEmpty(id))
            {
                group = _context.Groups.AsNoTracking().Include("Items").OrderBy(g=>g.SortOrder).FirstOrDefault();
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
                throw new HttpException(404, "Not Found");
            }
            
            if (model != null)
            {
                model = model.OrderBy(i => i.SortOrder);
            }
            ViewBag.Group = group;
            ViewBag.Title = group.Name;
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Menu(string id) 
        {
            ViewBag.Id = id;
            return PartialView(_context.Groups.OrderBy(g=>g.SortOrder));
        }
    }
}
