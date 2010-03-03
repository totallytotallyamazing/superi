using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace Trips.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        public string DefaultCulture
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultLanguage"];
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Content",                                              // Route name
                "Content/{id}",                           // URL with parameters
                new { controller = "Content", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        HttpCookie CreateLangCookie(string lang)
        {
            HttpCookie cookie = new HttpCookie("lang", lang);
            cookie.Expires = DateTime.Now.AddYears(1);
            return cookie;
        }

        void InitCulture(string toCulture)
        {
            string culture;
            if (string.IsNullOrEmpty(toCulture))
            {
                if (Request.Cookies["lang"] == null)
                {
                    Response.Cookies.Set(CreateLangCookie(DefaultCulture));
                    culture = DefaultCulture;
                }
                else
                {
                    culture = Request.Cookies["lang"].Value;
                }
            }
            else
            {
                culture = toCulture;
            }

            if (Thread.CurrentThread.CurrentUICulture.Name != culture)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
            }
            if (Thread.CurrentThread.CurrentCulture.Name != culture)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            }
        }



        protected void Application_BeginRequest()
        {
            if (Request.Path.EndsWith(".aspx") || Request.Path.IndexOf(".") < 0)
            {
                string toCulture = null;
                if (Request.QueryString["lang"] != null)
                {
                    Response.Cookies.Set(CreateLangCookie(Request.QueryString["lang"]));
                    toCulture = Request.QueryString["lang"];
                }
                InitCulture(toCulture);
            }
        }

    }
}