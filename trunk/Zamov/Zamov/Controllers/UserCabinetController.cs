using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Security;

namespace Zamov.Controllers
{
    [Authorize(Roles = "Administrators, Customers")]
    public class UserCabinetController : Controller
    {
        public ActionResult Index()
        {
            using (OrderStorage context = new OrderStorage())
            {
                List<Order> orders = (
                                         from order in
                                             context.Orders.Include("Dealer").Include("Cart").Include("OrderItems")
                                         where order.UserId == SystemSettings.CurrentUserId
                                         select order).ToList();
                return View(orders);
            }
        }

        public ActionResult ShowCart(int id)
        {
            using (OrderStorage context = new OrderStorage())
            {
                List<Order> orders = (from order in context.Orders.Include("OrderItems").Include("Dealer").Include("OrderItems.Unit") where order.Cart.Id == id select order).ToList();
                return View(orders);
            }
        }

        public ActionResult DeleteCart(int id)
        {
            using(OrderStorage context = new OrderStorage())
            {
                Cart cart = (from c in context.Carts where c.Id==id select c).First();
                cart.Deleted = 1;
                context.SaveChanges();
                return Redirect("~/UserCabinet");
            }
        }

        public ActionResult ShowOrder(Order order)
        {
            return View(order);
        }

    }
}
