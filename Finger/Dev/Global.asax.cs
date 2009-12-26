using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Dev.Models;

namespace Dev
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("index.html");

            //routes.MapRoute(
            //    "Admin",                                              // Route name
            //    "Admin/{action}",                           // URL with parameters
            //    new { controller = "Admin", action = "Index" }  // Parameter defaults
            // );

            routes.MapRoute(
                "Admin",                                              // Route name
                "Admin/Article/{contentName}",                           // URL with parameters
                new { controller = "Admin", action = "Article", contentName = "" }  // Parameter defaults
             );

            routes.MapRoute(
                "Account",                                              // Route name
                "Account/{action}",                           // URL with parameters
                new { controller = "Account", action = "Index" }  // Parameter defaults
             );

            routes.MapRoute(
                "ArticleDetailsLocalized",                                              // Route name
                "{culture}/Notes/Show/{name}",                           // URL with parameters
                new { culture = "ru-RU", controller = "Articles", action = "Show", id = "" }  // Parameter defaults
             );

            routes.MapRoute(
                "ArticleDetails",                                              // Route name
                "Notes/Show/{name}",                           // URL with parameters
                new { culture = "ru-RU", controller = "Articles", action = "Show", id = "" }  // Parameter defaults
             );


            routes.MapRoute(
                "Articles",                                              // Route name
                "Notes/{page}",                           // URL with parameters
                new { culture = "ru-RU", controller = "Articles", action = "Index", page = 0 }  // Parameter defaults
             );

            routes.MapRoute(
                "LocalizedArticles",                                              // Route name
                "{culture}/Notes/{page}",                           // URL with parameters
                new { culture = "ru-RU", controller = "Articles", action = "Index", page = 0 }  // Parameter defaults
             );

            routes.MapRoute(
                "Home",                                              // Route name
                "Home",                           // URL with parameters
                new { culture = "ru-RU", controller = "Home", action = "Index", contentName = "LifeStyle" }  // Parameter defaults
            );

            routes.MapRoute(
                "Content",                                              // Route name
                "{culture}/{contentName}",                           // URL with parameters
                new { culture = "ru-RU", controller = "Home", action = "Index", contentName = "LifeStyle" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{culture}/{controller}/{action}/{contentName}",                           // URL with parameters
                new { culture = "ru-RU", controller = "Home", action = "Index", contentName = "LifeStyle" }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            System.Web.Mvc.ModelBinders.Binders[typeof(ArticleTranslations)] = new ModelBinders.ArticleTranslationsBinder();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}