using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MBrand.Controllers
{
    public class NotesController : Controller
    {
        //
        // GET: /Notes/

        public ActionResult Index(int? id)
        {
            return View();
        }

    }
}
