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

        public static float TotalAmount
        {
            get { return OrderItems.Sum(oi => oi.Value.Price * oi.Value.Quantity); }
        }

        public static Order Order
        {
            get
            {
                if (Session["order"] == null)
                {
                    Session["order"] = new Order { UniqueId = Guid.NewGuid().ToString() };
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
            set 
            { 
                Session["CurrentCategory"] = value;
                Session["CurrentTag"] = null; ;
            }
        }

        public static int CurrentTag
        {
            get
            {
                if (Session["CurrentTag"] != null)
                    return Convert.ToInt32(Session["CurrentTag"]);
                return int.MinValue;
            }
            set 
            { 
                Session["CurrentTag"] = value;
                Session["CurrentCategory"] = null;
            }
        }


        public static DeliveryType DeliveryType
        {
            get
            {
                if (Session["DeliveryType"] != null)
                    return (DeliveryType)Session["DeliveryType"];
                return null;
            }
            set { Session["DeliveryType"] = value; }
        }

        public static PaymentType PaymentType
        {
            get
            {
                if (Session["PaymentType"] != null)
                    return (PaymentType)Session["PaymentType"];
                return null;
            }
            set { Session["PaymentType"] = value; }
        }

        public static List<PaymentPropertyValue> PaymentProertyValues
        {
            get
            {
                if (Session["PaymentProertyValues"] == null)
                    Session["PaymentProertyValues"] = new List<PaymentPropertyValue>();
                return (List<PaymentPropertyValue>)Session["PaymentProertyValues"];
            }
        }


        #region Methods
        public static void ClearOrder()
        {
            Session.Remove("order");
            Session.Remove("orderItems");
            Session["orderItems"] = null;
            Session["order"] = null;
        }

        public static bool IsBillingInfoFilled()
        {
            return (Order != null && !string.IsNullOrEmpty(Order.BillingPhone) && !string.IsNullOrEmpty(Order.BillingName));
        }

        public static bool IsDeliveryInfoFilled()
        {
            return (Order != null && !string.IsNullOrEmpty(Order.DeliveryPhone) && !string.IsNullOrEmpty(Order.DeliveryName));
        }

        public static void ClearSettings() { settings = null; }
        #endregion
    }
}
