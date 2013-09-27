using Jackson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jackson.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        SiteContext _context = null;

        public AdminController(SiteContext context)
        {
            _context = context;
        }
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddGroup(Group group, string currentGroup)
        {
            group.Url = Utils.Transliterator.Transliterate(group.Name);
            _context.Groups.Add(group);
            _context.SaveChanges();
            return Json(group.Name);
        }

        public ActionResult DeleteGroup(string id)
        {
            bool result = true;
            try
            {
                var group = _context.Groups.First(g => g.Url == id);
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return Json(result);
        }
    }
}
