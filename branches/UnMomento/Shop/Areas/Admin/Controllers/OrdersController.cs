using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;
using System.Data.Objects;

namespace Shop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            using (OrdersStorage context = new OrdersStorage())
            {
                context.OrderItems.MergeOption = MergeOption.NoTracking;
                context.Orders.MergeOption = MergeOption.NoTracking;
                var orders = context.Orders.Include("OrderItems").OrderByDescending(o => o.OrderDate).ToList();
                return View(orders); 
            }
        }

        public ActionResult Details(int id)
        {
            using (OrdersStorage context = new OrdersStorage())
            {
                context.Orders.MergeOption = MergeOption.NoTracking;
                Order order = context.Orders.Include("OrderItems")
                    .Include("PaymentType")
                    .Include("DeliveryType")
                    .First(o => o.Id == id);
                return View(order);
            }
        }

        public ActionResult Delete(int id)
        {
            using (OrdersStorage context = new OrdersStorage())
            {
                Order order = context.Orders.Single(o => o.Id == id);
                context.DeleteObject(order);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
