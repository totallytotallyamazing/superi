using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dev
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Account",                                              // Route name
                "Account/{action}",                           // URL with parameters
                new { controller = "Account", action = "Index" }  // Parameter defaults
             );

            routes.MapRoute(
                "Content",                                              // Route name
                "{controller}/{contentUrl}",                           // URL with parameters
                new { controller = "Home", action = "Index", contentUrl = "О компании" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{contentUrl}",                           // URL with parameters
                new { controller = "{controller}", action = "{action}", contentUrl = "" }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}