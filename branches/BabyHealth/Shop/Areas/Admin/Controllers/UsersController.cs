using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Admin/Users/
        [Authorize(Roles = "Administrators")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
