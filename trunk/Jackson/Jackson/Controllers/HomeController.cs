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

        SiteContext _context = null;

        public HomeController(SiteContext context)
        {
            _context = context;
        }

        public ActionResult Index(string id)
        {
            Group model = null;
            if (string.IsNullOrEmpty(id))
            {
                model = _context.Groups.FirstOrDefault();
            }
            return View();
        }

    }
}
