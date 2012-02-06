using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBrand.Models;

namespace MBrand.Controllers
{
    public class WorksController : Controller
    {

        ContentContainer context = new ContentContainer();
        //
        // GET: /Works/

        public ActionResult Index()
        {
            var groups = context.Contents.OfType<WorkGroup>();
            ViewBag.WorkGroups = groups;
            return View();
        }

    }
}
