using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dev.Helpers;

namespace Shop.Controllers
{
    public class InvoiceController : Controller
    {
        public ActionResult Show(string id, int? orderId)
        {
            ViewData["Order"] = WebSession.Order;
            ViewData["OrderItems"] = WebSession.OrderItems.Select(oi => oi.Value).ToList();
            return View(id);
        }
    }
}
