using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Jackson
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("robots.txt");

            routes.MapRoute("IdOnly", "{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("NotFound", "{*url}", new {controller = "Error", action = "NotFound"});
        }
    }
}