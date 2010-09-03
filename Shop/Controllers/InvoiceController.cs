using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dev.Helpers;
using Shop.Models;

namespace Shop.Controllers
{
    public class InvoiceController : Controller
    {
        [OutputCache(NoStore = true, VaryByParam = "*", Duration = 1)]
        public ActionResult Show(string id, int? orderId, string uniqueId)
        {
            if (!orderId.HasValue)
            {
                ViewData["Order"] = WebSession.Order;
                ViewData["OrderItems"] = WebSession.OrderItems.Select(oi => oi.Value).ToList();
                ViewData["DeliveryType"] = WebSession.DeliveryType;
                ViewData["PaymentType"] = WebSession.PaymentType;
            }
            else
            {
                using (OrdersStorage context = new OrdersStorage())
                {
                    context.Orders.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                    Order order = context.Orders.Include("OrderItems").Include("DeliveryType")
                        .Include("PaymentType").Include("PaymentPropertyValues.PaymentProperty")
                        .FirstOrDefault(o => o.Id == orderId.Value && o.UniqueId == uniqueId);

                    if (order != null)
                    {
                        ViewData["Order"] = order;
                        ViewData["OrderItems"] = order.OrderItems;
                        ViewData["DeliveryType"] = order.DeliveryType;
                        ViewData["PaymentType"] = order.PaymentType;
                    }
                    else
                    {
                        throw new HttpException(404, "Page not found");
                    }
                }
            }
            return View(id);
        }
    }
}
