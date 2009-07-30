using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class UserCabinetController : Controller
    {
        //
        // GET: /UserCabinet/

        public ActionResult Index()
        {

            using (OrdersCS context = new OrdersCS())
            {
                List<Cart> carts = (from cart in context.Carts select cart).ToList();
                return View(carts);
            } 

        }

        public ActionResult ShowCart(int id)
        {
            return View();
        }

    }
}
