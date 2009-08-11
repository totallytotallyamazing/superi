using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Web.Security;

namespace Zamov.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index(int id)
        {

            using (ZamovStorage context = new ZamovStorage())
            {
                List<Dealer> dealers = (from dealer in context.Dealers.Include("Cities").Include("Categories")
                                        where dealer.Cities.Where(c => c.Id == SystemSettings.CityId).Count() > 0
                                        && dealer.Categories.Where(c => c.Id == SystemSettings.CategoryId).Count() > 0
                                        select dealer).ToList();
                ViewData["dealers"] = dealers;
            }
            ViewData["dealerId"] = id;
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
            return RedirectToAction("Index", new { id = id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recalculate(string updates, int dealerId)
        {
            if (!string.IsNullOrEmpty(updates))
            {
                Cart cart = SystemSettings.Cart;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, Dictionary<string, string>> orderItems =
                    serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(updates);
                var orderItemList =
                    (from oi in orderItems
                     select new { Id = int.Parse(oi.Key), Quantity = int.Parse(oi.Value["quantity"]) })
                     .ToList();
                foreach (var order in cart.Orders)
                {
                    if (order.OrderItems != null && order.OrderItems.Count > 0)
                    {
                        foreach (var orderItem in order.OrderItems)
                        {
                            foreach (var item in orderItemList)
                            {
                                if (orderItem.GetHashCode() == item.Id)
                                    orderItem.Quantity = item.Quantity;
                            }
                        }

                    }
                }
            }
            return RedirectToAction("Index", new { id = dealerId });
        }


        public ActionResult MakeOrder()
        {
            return View(SystemSettings.Cart.Orders);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MakeOrder(string firstName, string lastName, string city, string deliveryAddress, string contactPhone, string email, string comments, string deliveryDateTime, string orderSettings)
        {
            Cart cart = SystemSettings.Cart;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, Dictionary<string, string>> orderSettingsDictionary =
                serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(orderSettings);
            var systemSettingsList = (from os in orderSettingsDictionary
                                      select new
                                      {
                                          Id = int.Parse(os.Key),
                                          VoucherCode = (os.Value.ContainsKey("voucherCode"))? os.Value["voucherCode"] : null,
                                          PaymentType = GetPaymentType(os.Value)
                                      }).ToList();
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            DateTime deliveryDate = DateTime.Parse(deliveryDateTime, cultureInfo);
            MembershipUser user = Membership.GetUser(true);
            Guid? userId = null;
            if (user != null)
                userId = (Guid)user.ProviderUserKey;
            foreach (var order in cart.Orders)
            {
                order.Address = deliveryAddress;
                order.ClientName = firstName + " " + lastName;
                order.DeliveryDate = deliveryDate;
                order.Phone = contactPhone;
                order.UserId = userId;
                order.PaymentType = (int)PaymentTypes.Encash;
                foreach (var option in systemSettingsList)
                {
                    if (option.Id == order.GetHashCode())
                    {
                        if (option.PaymentType != null)
                            order.PaymentType = option.PaymentType.Value; ;
                        order.DiscountCardNumber = option.VoucherCode;
                    }
                }
            }
            using (OrderStorage context = new OrderStorage())
            {
                context.AddToCarts(cart);
                context.SaveChanges();
            }
            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        private int? GetPaymentType(Dictionary<string, string> item)
        {
            int? result = null;
            if (item.ContainsKey("paymentType") && item["paymentType"] != null)
                result = int.Parse(item["paymentType"]);
            return result;
        }
    }
}
