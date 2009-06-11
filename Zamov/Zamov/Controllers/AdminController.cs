using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    [Authorize(Roles="Administrators")]
    public class AdminController : Controller
    {
        ZamovStorage context = new ZamovStorage();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cities()
        {
            List<City> cities = context.Cities.Select(c => c).ToList();
            return View(cities);
        }
    }
}
