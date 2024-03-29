﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Shop.Helpers.Validation;

namespace MBrand
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{folder}/{*pathInfo}", new { folder = "storage" });
            routes.IgnoreRoute("{folder}/{*pathInfo}", new { folder = "lj" });
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("captcha.ashx");

            routes.MapRoute(
                "DeleteWorkGroup",
                "Admin/DeleteWorkGroup/{id}",
                new { controller = "Admin", action = "DeleteWorkGroup", id = "" }
            );


            routes.MapRoute(
                "See",
                "Admin/{action}/{type}",
                new { controller = "Admin", action = "See", type = "Site" }
            );

            routes.MapRoute(
                "SeeMe",                                              // Route name
                "See/{action}/{id}",                           // URL with parameters
                new { controller = "See", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Paged",
                "{controller}/{action}/{id}/{currentPage}",
                new { controller = "Notes", action = "Index", id = "", currentPage = "" }
             );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RemoteAttribute), typeof(RemoteAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(CaptchaAttribute), typeof(CaptchaAttributeAdapter));

        }
    }
}