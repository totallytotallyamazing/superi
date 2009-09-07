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
                                         orderby order.Cart.Date descending, order.Cart.Id ascending
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
        
    }
}
