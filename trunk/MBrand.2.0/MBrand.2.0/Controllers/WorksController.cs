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

        [OutputCache(Duration = 1, VaryByParam = "*", NoStore = true)]
        public PartialViewResult Index()
        {
            var groups = context.Contents.OfType<WorkGroup>();

            return PartialView(groups);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}
