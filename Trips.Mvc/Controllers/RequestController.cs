using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Trips.Mvc.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersonalData()
        {
            return View();
        }

    }
}
