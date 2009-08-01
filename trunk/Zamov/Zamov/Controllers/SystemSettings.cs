using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;
using System.Web.Security;

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
        
        public static Guid CurrentUserId
        {
            get
            {
                Guid result;
                if (Session["CurrentUser"] != null)
                    result = (Guid)Session["CurrentUser"];
                else
                {
                    MembershipUser user = Membership.GetUser();
                    result = (Guid)user.ProviderUserKey;
                    Session["CurrentUser"] = result;
                }
                return result;
            }
            set { Session["CurrentUser"] = value; }
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
    }
}
