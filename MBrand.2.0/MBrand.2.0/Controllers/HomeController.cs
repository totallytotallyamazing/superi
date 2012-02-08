using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class HomeController : Controller
    {
        ContentContainer context = new ContentContainer();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Start()
        {
            return PartialView(context.Statements);
        }

        public PartialViewResult Contacts()
        {
            return PartialView();
        }
    }
}
