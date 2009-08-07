using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Zamov.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            return View(SystemSettings.Cart.Orders);
        }

        public ActionResult EmptyCart(int dealerId, int? groupId)
        {
            SystemSettings.EmptyCart();
            return RedirectToAction("Index", "Products", new { dealerId = dealerId, groupId = groupId });
        }
    }
}
