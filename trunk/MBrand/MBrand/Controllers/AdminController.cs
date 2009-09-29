using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MBrand.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Eugene()
        {
            return View();
        }

        public ActionResult See()
        {
            return View();
        }

        public ActionResult Clients()
        {
            return View();
        }

        public ActionResult Notes(int? id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddNote(string title, string shortText, string longText, int currentPage)
        {
            return RedirectToAction("Index", "Notes", new { id = currentPage });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteNote(int id, int currentPage)
        {
            return RedirectToAction("Index", "Notes", new { id = currentPage });
        }

        public ActionResult Contacts()
        {
            return View();
        }

    }
}
