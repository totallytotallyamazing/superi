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
            _context.Groups.Add(group);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home", new { id = currentGroup });
        }
    }
}
