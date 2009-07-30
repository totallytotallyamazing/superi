using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Zamov.Controllers
{
    public class UserCabinetController : Controller
    {
        //
        // GET: /UserCabinet/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCart(int id)
        {
            return View();
        }

    }
}
