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
                    Session["orderItems"] = new Dictionary<long, OrderItem>();
                return (Dictionary<int, OrderItem>)Session["orderItems"];
            }
        }

        public static float PriceDisplayed
        {
            get
            {
                if (Session["PriceDisplayed"] == null)
                    Session["PriceDisplayed"] = 0;
                return Convert.ToSingle(Session["PriceDisplayed"]);
            }
            set { Session["PriceDisplayed"] = value; }
        }

        public static string Name
        {
            get
            {
                return (string)Session["Name"];
            }
            set
            {
                Session["Name"] = value;
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

        public static string Phone
        {
            get
            {
                return (string)Session["Phone"];
            }
            set
            {
                Session["Phone"] = value;
            }
        }

        public static string Email
        {
            get
            {
                return (string)Session["Email"];
            }
            set
            {
                Session["Email"] = value;
            }
        }

        public static string AdditionalInfo
        {
            get
            {
                return (string)Session["AdditionalInfo"];
            }
            set
            {
                Session["AdditionalInfo"] = value;
            }
        }

        public static string DeliveryAddress
        {
            get
            {
                return (string)Session["DeliveryAddress"];
            }
            set
            {
                Session["DeliveryAddress"] = value;
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

        internal static void ClearOrder()
        {
            OrderItems.Clear();
            AdditionalInfo = null;
        }

        public static void ClearSettings() { settings = null; }
    }
}
