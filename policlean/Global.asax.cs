using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PolialClean
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Services",                                              // Route name
                "Services",                           // URL with parameters
                new { controller = "Services", action = "Index", contentName = "Услуги" }  // Parameter defaults
            );

            routes.MapRoute(
                "Contacts",                                              // Route name
                "Contacts",                           // URL with parameters
                new { controller = "Contacts", action = "Index", contentName = "Контакты" }  // Parameter defaults
            );

            routes.MapRoute(
                "Account",                                              // Route name
                "Account/{action}",                           // URL with parameters
                new { controller = "Account", action = "LogOn" }  // Parameter defaults
            );


            routes.MapRoute(
                "Content",                                              // Route name
                "{controller}/{contentName}",                           // URL with parameters
                new { controller = "Home", action = "Index", contentName = "Миссия" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{contentName}",                           // URL with parameters
                new { controller = "Home", action = "Index", contentName = "Миссия" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}