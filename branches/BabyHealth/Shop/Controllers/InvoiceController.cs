using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class InvoiceController : Controller
    {
        public ActionResult Show(string id)
        {
            return View(id);
        }
    }
}
