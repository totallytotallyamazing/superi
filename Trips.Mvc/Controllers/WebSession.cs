using System;
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

        public static List<OrderItem> OrderItems
        {
            get
            {
                if (Session["orderItems"] == null)
                    Session["orderItems"] = new List<OrderItem>();
                return (List<OrderItem>)Session["orderItems"];
            }
        }
    }
}
