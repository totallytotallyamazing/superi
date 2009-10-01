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
using System.Data.Objects.DataClasses;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Zamov.Helpers;

namespace Zamov.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            if (SystemSettings.Cart.Orders.Count == 0)
                return RedirectToAction("Index", "Home");
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

        public ActionResult EmptyCart()
        {
            SystemSettings.EmptyCart();
            return RedirectToAction("Index", "Categories");
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
            
            if(cart.Orders!=null)
                for (int i = cart.Orders.Count - 1; i >= 0; i--)
                {
                    Order order = cart.Orders.ElementAt(i);
                    if (order.OrderItems.Count == 0)
                        cart.Orders.Remove(order);
                }

            int orderItemsCount = cart.Orders.Sum(o => o.OrderItems.Sum(oi => oi.Quantity));
            if (orderItemsCount == 0)
                SystemSettings.EmptyCart();
            return RedirectToAction("Index", new { id = id });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recalculate(string updates)
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
            return RedirectToAction("Index");
        }


        public ActionResult ClearCart()
        {
            SystemSettings.EmptyCart();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MakeOrder()
        {
            ViewData["deliveryDate"] = DateTime.Now.ToString("dd.MM.yyyy");
            if (SystemSettings.Cart.Orders.Count == 0)
                return RedirectToAction("Expired");


            HttpCookie cookie = new HttpCookie("makeOrder", "true");
            cookie.Path = "/";
            Response.AppendCookie(cookie);

            using (ZamovStorage context = new ZamovStorage())
            {
                string city = (from c in context.Cities
                               join tran in context.Translations on c.Id equals tran.ItemId
                               where tran.TranslationItemTypeId == (int)ItemTypes.City
                                   && tran.Language == SystemSettings.CurrentLanguage
                                   && c.Id == SystemSettings.CityId
                               select tran.Text).First();
                ViewData["city"] = city;
            }
            if(Request.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser();
                ProfileCommon profile = ProfileCommon.Create(user.UserName) as ProfileCommon;
                ViewData["firstName"] = profile.FirstName;
                ViewData["lastName"] = profile.LastName;
                ViewData["deliveryAddress"] = profile.DeliveryAddress;
                ViewData["contactPhone"] = profile.MobilePhone;
                ViewData["phone"] = profile.Phone;
            }

            return View(SystemSettings.Cart.Orders);
        }

        [BreadCrumb(ResourceName = "PageExpired", Url = "")]
        public ActionResult Expired()
        {
            SystemSettings.EmptyCart();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [CaptchaValidation("captcha")]
        public ActionResult MakeOrder(
            string firstName,
            string lastName,
            string city,
            string deliveryAddress,
            string contactPhone,
            string email,
            string comments,
            string deliveryDate,
            string deliveryTime,
            string deliveryDateTime,
            string orderSettings,
            bool agreed,
            bool captchaValid,
            FormCollection form
            )
        {
            foreach (string key in form)
            {
                if (key.StartsWith("paymentType") || key.StartsWith("voucherCode"))
                    ViewData[key] = form[key];
            }
            if (!ValidateMakeOrder(firstName, city, deliveryAddress, contactPhone, deliveryDate, deliveryTime, agreed, captchaValid))
                return View(SystemSettings.Cart.Orders);
            Cart cart = SystemSettings.Cart;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, Dictionary<string, string>> orderSettingsDictionary =
                serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(orderSettings);
            var systemSettingsList = (from os in orderSettingsDictionary
                                      select new
                                      {
                                          Id = int.Parse(os.Key),
                                          VoucherCode = (os.Value.ContainsKey("voucherCode")) ? os.Value["voucherCode"] : null,
                                          PaymentType = GetPaymentType(os.Value)
                                      }).ToList();
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            DateTime date = DateTime.Parse(deliveryDateTime, cultureInfo);
            MembershipUser user = Membership.GetUser(true);
            Guid? userId = null;
            SystemSettings.MemberProperties.DeliveryAddress = deliveryAddress;
            SystemSettings.MemberProperties.Email = email;
            SystemSettings.MemberProperties.FirstName = firstName;
            SystemSettings.MemberProperties.LastName = lastName;
            SystemSettings.MemberProperties.MobilePhone = contactPhone;
            SystemSettings.MemberProperties.Phone = contactPhone;
            SystemSettings.MemberProperties.City = city;
            if (user != null)
                userId = (Guid)user.ProviderUserKey;
            using (OrderStorage context = new OrderStorage())
            {
                foreach (var order in cart.Orders)
                {
                    order.Address = deliveryAddress;
                    order.ClientName = firstName + " " + lastName;
                    order.Date = DateTime.Now;
                    order.DeliveryDate = date;
                    order.Phone = contactPhone;
                    order.Email = email;
                    order.UserId = userId;
                    order.PaymentType = (int)PaymentTypes.Encash;
                    order.City = city;
                    order.Comments = comments;
                    foreach (var option in systemSettingsList)
                    {
                        if (option.Id == order.GetHashCode())
                        {
                            if (option.PaymentType != null)
                                order.PaymentType = option.PaymentType.Value; ;
                            order.DiscountCardNumber = option.VoucherCode;
                        }
                    }
                    order.DiscountCardNumber = form["voucherCode_" + order.GetHashCode()];
                    order.PaymentType = int.Parse(form["paymentType_" + order.GetHashCode()]);
                }
                cart.Date = DateTime.Now;
                context.AddToCarts(cart);
                context.SaveChanges();
                context.Detach(cart);
                MailOrders(cart);
            }
            return RedirectToAction("ThankYou");
        }

        private void MailOrders(Cart cart)
        {
            using (OrderStorage context = new OrderStorage())
            {
                context.Attach(cart);
                if (!cart.Orders.IsLoaded)
                    cart.Orders.Load();
                List<MailAddress> addresses = new List<MailAddress>();
                foreach (Order order in cart.Orders)
                {
                    if (NeedsToBeMailed(order))
                    {
                        string mailAddress = MembershipExtensions.GetDealerEmail((int)order.DealerReference.EntityKey.EntityKeyValues[0].Value);
                        if(!string.IsNullOrEmpty(mailAddress))
                        addresses.Add(new MailAddress(mailAddress));
                    }
                }
                if (addresses.Count > 0)
                    MailHelper.SendTemplate(ApplicationData.FeedbackEmail, addresses, "newOrder", false);
            }
        }

        private bool NeedsToBeMailed(Order order)
        {
            if (HttpContext.Items["onlineDealers"] == null)
                HttpContext.Items["onlineDealers"] = MembershipExtensions.GetOnlineDealers();
            int[] onlineDealers = (int[])HttpContext.Items["onlineDealers"];
            if (!onlineDealers.Contains((int)order.DealerReference.EntityKey.EntityKeyValues[0].Value))
                return true;
            return false;
        }

        private bool ValidateMakeOrder(
            string firstName,
            string city,
            string deliveryAddress,
            string contactPhone,
            string deliveryDate,
            string deliveryTime,
            bool agreed,
            bool captchaValid
            )
        {
            if (string.IsNullOrEmpty(firstName))
                ModelState.AddModelError("firstName", ResourcesHelper.GetResourceString("FirstNameRequired"));
            if (string.IsNullOrEmpty(city))
                ModelState.AddModelError("city", ResourcesHelper.GetResourceString("CityRequired"));
            if (string.IsNullOrEmpty(deliveryAddress))
                ModelState.AddModelError("deliveryAddress", ResourcesHelper.GetResourceString("DeliveryAddressRequired"));
            if (string.IsNullOrEmpty(contactPhone))
                ModelState.AddModelError("contactPhone", ResourcesHelper.GetResourceString("PhoneRequired"));
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            DateTime date;
            if (!DateTime.TryParse(deliveryDate, cultureInfo, DateTimeStyles.None, out date))
                ModelState.AddModelError("deliveryDate", ResourcesHelper.GetResourceString("DateTimeInvalidOrEmpty"));
            Regex rtime = new Regex(@"[0-2][0-9]\:[0-6][0-9]");
            if (!rtime.IsMatch(deliveryTime))
                ModelState.AddModelError("deliveryTime", ResourcesHelper.GetResourceString("TimeInvalidOrEmpty"));
            if (!agreed)
                ModelState.AddModelError("agreed", ResourcesHelper.GetResourceString("YouMustAgree"));
            if (!captchaValid)
                ModelState.AddModelError("captchaInvalid", ResourcesHelper.GetResourceString("IncorrectCaptcha"));
            return ModelState.IsValid;
        }

        public ActionResult ThankYou()
        {
            if (Request.IsAuthenticated)
                SystemSettings.EmptyCart();
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