using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lady.Mvc.Models;

namespace Lady.Mvc.Areas.Admin.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Brands()
        {
            return View();
        }
    }
}
