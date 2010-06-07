using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Lady.Models;

namespace Dev.Helpers
{
    public static class WebSession
    {
        static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        public static Dictionary<long, OrderItem> OrderItems
        {
            get
            {
                if (Session["orderItems"] == null)
                    Session["orderItems"] = new Dictionary<long, OrderItem>();
                return (Dictionary<long, OrderItem>)Session["orderItems"];
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

        internal static void ClearOrder()
        {
            OrderItems.Clear();
            AdditionalInfo = null;
        }
    }
}
