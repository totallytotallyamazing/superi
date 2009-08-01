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
        
        public ActionResult Index()
        {
            using (OrderStorage context = new OrderStorage())
            {
                List<Order> orders = (from order in context.Orders.Include("Dealers").Include("Cart").Include("OrderItems") select order).ToList();
                return View(orders);
            }


        }

        public ActionResult ShowCart(int id)
        {
            using (OrderStorage context = new OrderStorage())
            {
                List<Order> orders = (from order in context.Orders.Include("OrderItems").Include("Dealers") where order.Cart.Id == id select order).ToList();
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
    }
}
