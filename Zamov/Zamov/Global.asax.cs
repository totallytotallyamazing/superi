﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zamov
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("captcha.ashx");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
            "ProductImageDefault",                                              // Route name
                "Image/ProductImageDefault/{id}/{maxDimension}",                           // URL with parameters
                new { controller = "Image", action = "ProductImageScaled", id = "", maxDimension = "100" }  // Parameter defaults
            );


            routes.MapRoute(
            "ProductImageScaled",                                              // Route name
                "Image/ProductImageScaled/{id}/{maxDimension}",                           // URL with parameters
                new { controller = "Image", action = "ProductImageScaled", id = "", maxDimension = "100" }  // Parameter defaults
            );

            routes.MapRoute(
             "AddToCart",                                              // Route name
                 "Products/AddToCart",                           // URL with parameters
                 new { controller = "Products", action = "AddToCart" }  // Parameter defaults
             );

            routes.MapRoute(
            "ProductDescription",                                              // Route name
                "Products/Description/{id}",                           // URL with parameters
                new { controller = "Products", action = "Description", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Products",                                              // Route name
                "Products/{dealerId}/{groupId}",                           // URL with parameters
                new { controller = "Products", action = "Index", dealerId = "", groupId = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Dealer",                                              // Route name
                "Dealer/{id}",
                new { controller = "Dealer", action = "Index", id = "" }  // Parameter defaults
            );
            routes.MapRoute(
                "DeleteFeedback",                                              // Route name
                "Feedback/DeleteFeedback",
                new { controller = "Feedback", action = "DeleteFeedback", dealerId = "", feedbackId = "" }  // Parameter defaults
            );


            routes.MapRoute(
                "Feedback",                                              // Route name
                "Feedback/{id}",
                new { controller = "Feedback", action = "Index", id = "" }  // Parameter defaults
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
    }
}