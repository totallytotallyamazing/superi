using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Shop.Models;
using Trips.Mvc.Runtime;
using Shop.Helpers;

namespace Dev.Helpers
{
    public static class WebSession
    {
        private static SiteSettings settings = null;
        private static Order order = null;

        static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        public static Dictionary<int, OrderItem> OrderItems
        {
            get
            {
                if (Session["orderItems"] == null)
                    Session["orderItems"] = new Dictionary<int, OrderItem>();
                return (Dictionary<int, OrderItem>)Session["orderItems"];
            }
        }

        public static Order Order
        {
            get
            {
                if (order == null)
                {
                    order = new Order();
                    Session["order"] = order;
                }
                return (Shop.Models.Order)Session["order"];
            }
        }

        public static SiteSettings Settings
        {
            get
            {
                if (settings == null)
                    settings = Configurator.LoadSettings();
                return settings;
            }
        }

        public static Currencies Currency
        {
            get
            {
                if (Session["Currency"] == null)
                    Session["Currency"] = Currencies.Hrivna;
                return (Currencies)Session["Currency"];
            }
            set
            {
                Session["Currency"] = value;
            }
        }

        public static int CurrentCategory
        {
            get
            {
                if (Session["CurrentCategory"] != null)
                    return Convert.ToInt32(Session["CurrentCategory"]);
                return int.MinValue;
            }
            set { Session["CurrentCategory"] = value; }
        }


        #region Methods
        public static void ClearOrder()
        {
            Session.Remove("order");
        }

        public static bool IsBillingInfoFilled()
        { 
            return (order!=null && !string.IsNullOrEmpty(order.BillingPhone) && !string.IsNullOrEmpty(order.BillingName));
        }

        public static bool IsDeliveryInfoFilled()
        {
            return (order != null && !string.IsNullOrEmpty(order.DeliveryPhone) && !string.IsNullOrEmpty(order.DeliveryName));
        }

        public static void ClearSettings() { settings = null; }
        #endregion
    }
}
