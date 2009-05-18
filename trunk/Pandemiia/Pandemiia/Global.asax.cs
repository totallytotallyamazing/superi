using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pandemiia
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Tools",
                "Tools/{action}/{caller}/{returnAction}/{parameters}",
                new { controller = "Tools", parameters = "", action = "", caller = "Home", returnAction = "Index" }
                );

            routes.MapRoute(
                "Tools1",
                "Tools/{action}/{entityId}/{caller}/{returnAction}/{uploadFolder}/{fileKey}/{previewKey}",
                new { controller = "Tools", uploadFolder = "", pairKey = "", action = "", caller = "Home", returnAction = "Index" }
                );

            routes.MapRoute(
                "Images",
                "Manage/{action}/{data}/{entityId}",
                new { controller = "Manage" }
                );

            routes.MapRoute(
                "Filter",
                "Filter/{action}/{typeName}/{pageNumber}",
                new { controller = "Filter", action = "All", typeName = "All", pageNumber = 0 }
                );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}