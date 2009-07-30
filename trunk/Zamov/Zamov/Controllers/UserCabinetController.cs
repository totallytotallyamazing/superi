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

            using (OrderStorage context = new OrderStorage())
            {
                List<Cart> carts = (from cart in context.Carts select cart).ToList();
                return View(carts);
            } 

        }

        public ActionResult ShowCart(int id)
        {
            using (OrderStorage context = new OrderStorage())
            {
                List<Order> orders = (from order in context.Orders.Include("OrderItems") where order.Cart.Id == id select order).ToList();
                return View(orders);
            }
        }

        public ActionResult DeleteCart(int id)
        {

            using(OrderStorage context = new OrderStorage())
            {
                /*
                Cart cart = (from c in context.Carts where c.Id==id select c).First();
                context.DeleteObject(cart);
                context.SaveChanges();
                */

                return Redirect("~/UserCabinet");
            }
        }
    }
}
