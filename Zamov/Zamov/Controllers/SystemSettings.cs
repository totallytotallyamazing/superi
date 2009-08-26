using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;
using System.Web.Security;
using Zamov.Models;

namespace Zamov.Controllers
{
    public static class SystemSettings
    {
        private static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }

        public static int UsersPageSize
        {
            get
            {
                int result = 0;
                string pageSizeString = WebConfigurationManager.AppSettings["UsersPageSize"];
                if (!string.IsNullOrEmpty(pageSizeString))
                {
                    result = int.Parse(pageSizeString);
                }
                return result;
            }
        }

        public static string CurrentLanguage
        {
            get
            {
                if (Session["lang"] == null)
                    Session["lang"] = "uk-UA";
                return (string)Session["lang"];
            }
            set { System.Web.HttpContext.Current.Session["lang"] = value; }
        }

        public static DateTime LastTime
        {
            get
            {
                if (Session["lasttime"] == null)
                    Session["lasttime"] = DateTime.Now;
                return (DateTime)Session["lasttime"];
            }
            set { Session["lasttime"] = value; }
        }

        public static int? CurrentDealer
        {
            get
            {
                int? result = null;
                if (Session["CurrentDealer"] != null)
                    result = Convert.ToInt32(Session["CurrentDealer"]);
                return result;
            }
            set { Session["CurrentDealer"] = value; }
        }
        
        public static Guid? CurrentUserId
        {
            get
            {
                MembershipUser user = Membership.GetUser();
                if (user != null)
                    return (Guid) user.ProviderUserKey;
                return null;
            }
        }
        
        public static int CityId
        {
            get 
            {
                int result = int.MinValue;
                if (Session["CityId"] != null)
                    result = Convert.ToInt32(Session["CityId"]);
                return result;
            }
            set { Session["CityId"] = value; }
        }

        public static int CategoryId
        {
            get
            {
                int result = int.MinValue;
                if (Session["CategoryId"] != null)
                    result = Convert.ToInt32(Session["CategoryId"]);
                return result;
            }
            set { Session["CategoryId"] = value; }
        }

        public static string CategoryName
        {
            get 
            {
                if (Session["categoryName"] == null)
                    return null;
                return Session["categoryName"].ToString();
            }
            set { Session["categoryName"] = value; }
        }

        public static int SubCategoryId
        {
            get
            {
                int result = int.MinValue;
                if (Session["SubCategoryId"] != null)
                    result = Convert.ToInt32(Session["SubCategoryId"]);
                return result;
            }
            set { Session["SubCategoryId"] = value; }
        }

        public static Cart Cart
        {
            get 
            {
                if (Session["Cart"] == null)
                    Session["Cart"] = new Cart();
                return (Cart)Session["Cart"];
            }
        }

        public static MemberProperties MemberProperties
        {
            get 
            {
                if (Session["MemberProperties"] == null)
                    Session["MemberProperties"] = new MemberProperties();
                return (MemberProperties)Session["MemberProperties"];
            }
            
        }

        public static void EmptyCart()
        {
            Session["Cart"] = null;
        }
    }
}
