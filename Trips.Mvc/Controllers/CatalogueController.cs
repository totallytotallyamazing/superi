using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Trips.Mvc.Controllers
{
    public class CatalogueController : Controller
    {
        //
        // GET: /Catalogue/

        public ActionResult Index(int? id)
        {
            Dictionary<string, List<KeyValuePair<string, int>>> brandClasses = new Dictionary<string, List<KeyValuePair<string, int>>>();
            ViewData["brandClasses"] = brandClasses;
            return View();
        }
    }
}
