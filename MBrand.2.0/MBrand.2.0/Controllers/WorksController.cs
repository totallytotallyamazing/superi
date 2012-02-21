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
        readonly ContentContainer _context = new ContentContainer();
        //
        // GET: /Works/

        [OutputCache(Duration = 1, VaryByParam = "*", NoStore = true)]
        public PartialViewResult Index()
        {
            var groups = _context.Contents.OfType<WorkGroup>();

            return PartialView(groups);
        }

        [OutputCache(Duration = 1, VaryByParam = "*", NoStore = true)]
        public JsonResult Items (string id)
        {

            var works = //Enumerable.Range(0,20).Select(w=>new {Name = "name" + w, Title="Title" + w, Description = "Description" + w, Image="oldDick.png"})
                _context.Contents.OfType<Work>().Where(w => w.WorkGroup.Name == id)
                .Select(w => new {w.Name, w.Title, w.Description, w.Image})
                .ToArray();//
                //.Select(w => new {w.Name, w.Title, w.Description, w.Image}).ToArray();

            return Json(works, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}
