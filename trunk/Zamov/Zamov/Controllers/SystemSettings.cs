using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Zamov.Controllers
{
    public static class SystemSettings
    {
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
                if (System.Web.HttpContext.Current.Session["lang"] == null)
                    System.Web.HttpContext.Current.Session["lang"] = "uk-UA";
                return (string)System.Web.HttpContext.Current.Session["lang"];
            }
            set { System.Web.HttpContext.Current.Session["lang"] = value; }
        }
    }
}
