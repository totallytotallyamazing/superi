using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using Zamov.Helpers;
using System.Data.Objects;
using System.Web.Security;
using System.Data;

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
                                         && order.Cart.Deleted == 0
                                         orderby order.Cart.Date descending, order.Cart.Id ascending
                                         select order).ToList();
                return View(orders);
            }
        }

        public ActionResult ShowCart(int id)
        {
            using (OrderStorage context = new OrderStorage())
            {
                List<Order> orders = (from order in context.Orders.Include("OrderItems").Include("Dealer") where order.Cart.Id == id select order).ToList();
                //ViewData["caller"] = caller;
                return View(orders);
            }
        }

        public ActionResult DeleteCart(int id)
        {
            using (OrderStorage context = new OrderStorage())
            {
                Cart cart = (from c in context.Carts where c.Id == id select c).First();
                cart.Deleted = 1;
                context.SaveChanges();
                return Redirect("~/UserCabinet");
            }
        }


        public ActionResult UserDetails()
        {
            string userEmail = Membership.GetUser(true).UserName;
            ProfileCommon profile = ProfileCommon.Create(userEmail) as ProfileCommon;
            ViewData["firstName"] = profile.FirstName;
            ViewData["lastName"] = profile.LastName;
            ViewData["deliveryAddress"] = profile.DeliveryAddress;
            ViewData["mobilePhone"] = profile.MobilePhone;
            ViewData["phone"] = profile.Phone;
            ViewData["city"] = profile.City;
            return View();
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserDetails(string firstName, string lastName, string deliveryAddress, string city, string mobilePhone, string phone)
        {
            if (ValidateDetails(firstName, lastName, mobilePhone, phone))
            {
                string userEmail = Membership.GetUser(true).Email;
                ProfileCommon profile = ProfileCommon.Create(userEmail) as ProfileCommon;
                profile.FirstName = firstName;
                profile.LastName = lastName;
                profile.DeliveryAddress = deliveryAddress;
                profile.MobilePhone = mobilePhone;
                profile.Phone = phone;
                profile.City = city;
                profile.Save();
            }
            return View();
        }

        private bool ValidateDetails(string firstName, string lastName, string mobilePhone, string phone)
        {
            if (string.IsNullOrEmpty(firstName))
                ModelState.AddModelError("firstName", ResourcesHelper.GetResourceString("FirstNameRequired"));
            if (string.IsNullOrEmpty(lastName))
                ModelState.AddModelError("lastName", ResourcesHelper.GetResourceString("LastNameRequired"));
            if (string.IsNullOrEmpty(mobilePhone))
                ModelState.AddModelError("mobilePhone", ResourcesHelper.GetResourceString("PhoneRequired"));
            return ModelState.IsValid;
        }

        
        public ActionResult AddToCart(int id)
        {
            Cart cart = SystemSettings.Cart;
            Dictionary<int, Product> products = null;
            int dealerId = int.MinValue;
            using(OrderStorage context = new OrderStorage())
            {
                var orderItems = (from oi in context.OrderItems where oi.Order.Id == id select new 
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                }).ToList();

                string[] productIds = orderItems.Select(oi=>oi.ProductId.ToString()).ToArray();

                dealerId = (from order in context.Orders where order.Id == id select order.Dealer.Id).First();
                
                using (ZamovStorage zamovContext = new ZamovStorage())
                {
                    string productIdsCondition = string.Join(",", productIds);
                    if (!string.IsNullOrEmpty(productIdsCondition))
                    {
                        ObjectQuery<Product> productsQuery = new ObjectQuery<Product>(
                                        "SELECT VALUE P FROM Products AS P WHERE P.Id IN {" + productIdsCondition + "}",
                                        zamovContext);
                        products = productsQuery.Where(p=>!p.Deleted).ToDictionary(pr => pr.Id);
                    }
                }
                
                if (products != null && products.Count > 0)
                {
                    foreach (var orderItem in orderItems)
                    {
                        Order order = (from o in cart.Orders where o.DealerReference.EntityKey != null && (int)o.DealerReference.EntityKey.EntityKeyValues[0].Value == dealerId select o).SingleOrDefault();
                        if (order == null)
                        {
                            order = new Order();
                            IEnumerable<KeyValuePair<string, object>> dealerKeyValues = new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("Id", dealerId) };
                            EntityKey dealer = new EntityKey("OrderStorage.OrderDealers", dealerKeyValues);
                            order.DealerReference.EntityKey = dealer;
                            cart.Orders.Add(order);
                        }
                        Product product = products[orderItem.ProductId.Value];
                        OrderItem item = null;
                        if (order.OrderItems != null && order.OrderItems.Count > 0)
                            item = (from i in order.OrderItems where i.PartNumber == product.PartNumber select i).SingleOrDefault();
                        if (item == null)
                            item = new OrderItem();
                        item.PartNumber = product.PartNumber;
                        item.Name = product.Name;
                        item.Price = product.Price;
                        item.ProductId = product.Id;
                        item.Quantity = orderItem.Quantity;
                        item.Unit = product.Unit;
                        order.OrderItems.Add(item);
                    }
                }
            }
            
            return RedirectToAction("Index", "UserCabinet");
        }
        
    }
}
