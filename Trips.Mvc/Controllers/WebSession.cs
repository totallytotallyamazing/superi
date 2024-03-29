﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trips.Mvc.Models;
using System.Web.UI;
using System.Web.SessionState;

namespace Trips.Mvc.Controllers
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

        public static long FromCityId
        {
            get
            {
                if (Session["FromCityId"] == null)
                    Session["FromCityId"] = 0;
                return Convert.ToInt64(Session["FromCityId"]);
            }
            set { Session["FromCityId"] = value; }
        }

        public static string FromCity {
            get
            {
                return (string)Session["FromCity"];
            }
            set
            {
                Session["FromCity"] = value;
            }
        }

        public static long ToCityId
        {
            get
            {
                if (Session["ToCityId"] == null)
                    Session["ToCityId"] = 0;
                return Convert.ToInt64(Session["ToCityId"]);
            }
            set { Session["ToCityId"] = value; }
        }

        public static string ToCity
        {
            get
            {
                return (string)Session["ToCity"];
            }
            set
            {
                Session["ToCity"] = value;
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

        public static string MoreTripDetails
        {
            get
            {
                return (string)Session["MoreTripDetails"];
            }
            set
            {
                Session["MoreTripDetails"] = value;
            }
        }

        internal static void ClearOrder()
        {
            OrderItems.Clear();
            ToCityId = 0;
            ToCity = null;
            FromCityId = 0;
            FromCity = null;
            MoreTripDetails = null;
        }
    }
}
