using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {

            using (ZamovStorage context = new ZamovStorage())
            {
                List<Dealer> dealers = (from dealer in context.Dealers.Include("Cities").Include("Categories")
                                        where dealer.Cities.Where(c => c.Id == SystemSettings.CityId).Count() > 0
                                        && dealer.Categories.Where(c => c.Id == SystemSettings.CategoryId).Count() > 0
                                        select dealer).ToList();
                ViewData["dealers"] = dealers;
            }
            return View(SystemSettings.Cart.Orders);
        }

        public ActionResult EmptyCart(int dealerId, int? groupId)
        {
            SystemSettings.EmptyCart();
            return RedirectToAction("Index", "Products", new { dealerId = dealerId, groupId = groupId });
        }

        public ActionResult RemoveOrderItem(int id)
        {
            Cart cart = SystemSettings.Cart;
            foreach (var order in cart.Orders)
            {
                if (order.OrderItems != null && order.OrderItems.Count > 0)
                {
                    for (int i = order.OrderItems.Count - 1; i >= 0; i--)
                    {
                        OrderItem orderItem = order.OrderItems.ElementAt(i);
                        if (orderItem.GetHashCode() == id)
                            order.OrderItems.Remove(orderItem);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        //public ActionResult MakeOrder() { 
            
        //}
    }
}
