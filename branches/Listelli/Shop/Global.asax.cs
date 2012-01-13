using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Dev.Helpers;
using Shop.Helpers;
using System.IO;
using Dev.Mvc.Helpers;
using Shop.Helpers.Validation;
using System.Globalization;
using System.Threading;

namespace Shop
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("captcha.ashx");
            routes.IgnoreRoute("elmah/default.aspx");
            routes.IgnoreRoute("elmah/default.aspx/detail");
            routes.IgnoreRoute("elmah/default.aspx/stylesheet");
            routes.IgnoreRoute("elmah/default.aspx/download");
            routes.IgnoreRoute("elmah/default.aspx/rss");
            routes.IgnoreRoute("elmah/default.aspx/digestrss");
            routes.IgnoreRoute("elmah/default.aspx/about");
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("elmah/default.aspx");
            routes.IgnoreRoute("elmah/default.aspx/detail");
            routes.IgnoreRoute("elmah/default.aspx/stylesheet");
            routes.IgnoreRoute("elmah/default.aspx/download");
            routes.IgnoreRoute("elmah/default.aspx/rss");
            routes.IgnoreRoute("elmah/default.aspx/digestrss");
            routes.IgnoreRoute("elmah/default.aspx/about");
            routes.IgnoreRoute("elmah.axd");



            routes.MapRoute(
                "Konkurs", // Route name
                "Konkurs", // URL with parameters
                new { controller = "Products", action = "Index", id = "22" }, // Parameter defaults
                new string[1] { "Shop.Controllers" }
            );

            /*
            routes.MapRoute(
                "Articles", // Route name
                "Articles", // URL with parameters
                new { controller = "Articles", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[1] { "Shop.Controllers" }
            );
            */



            routes.MapRoute(
                "Go", // Route name
                "Go/{id}", // URL with parameters
                new { controller = "Home", action = "Go", id = UrlParameter.Optional }, // Parameter defaults
                new string[1] { "Shop.Controllers" }
            );

            routes.MapRoute(
             "LogOn", // Route name
             "to/logon", // URL with parameters
             new { controller = "Account", action = "LogOn", id = UrlParameter.Optional }, // Parameter defaults
             new string[1] { "Shop.Controllers" }
            );

            routes.MapRoute(
             "Catalogs", // Route name
             "to/catalogs", // URL with parameters
             new { controller = "BrandCatalog", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
             new string[1] { "Shop.Controllers" }
            );

            routes.MapRoute(
                "AltObzor", // Route name
                "to/alt-obzor", // URL with parameters
                new { controller = "Review", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[1] { "Shop.Controllers" }
            );

            routes.MapRoute(
                "AltObzorDetails", // Route name
                "to/alt-obzor/{id}", // URL with parameters
                new { controller = "Review", action = "Details", id = UrlParameter.Optional }, // Parameter defaults
                new string[1] { "Shop.Controllers" }
            );


            routes.MapRoute(
             "Designers", // Route name
             "to/{id}", // URL with parameters
             new { controller = "Designers", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
             new string[1] { "Shop.Controllers" }
            );

            routes.MapRoute(
             "DesignersLiving", // Route name
             "Designers/{id}/living", // URL with parameters
             new { controller = "Designers", action = "ViewLiving", id = UrlParameter.Optional }, // Parameter defaults
             new string[1] { "Shop.Controllers" }
            );

            routes.MapRoute(
             "DesignersNotLiving", // Route name
             "Designers/{id}/notliving", // URL with parameters
             new { controller = "Designers", action = "ViewNotLiving", id = UrlParameter.Optional }, // Parameter defaults
             new string[1] { "Shop.Controllers" }
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[1] { "Shop.Controllers" }
            );
        }

        protected void Application_BeginRequest()
        {
            string lang = Request.QueryString["lang"];
            if (string.IsNullOrEmpty(lang) && Request.Cookies["lang"] != null)
                lang = Request.Cookies["lang"].Value;
            else
                Response.Cookies.Set(new HttpCookie("lang", lang) { Expires = DateTime.Now.AddDays(365) });
            if (!string.IsNullOrEmpty(lang) && lang != CultureInfo.CurrentUICulture.Name)
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
        }

        protected void Application_AcquireRequestState()
        {
            if (Request.Path.EndsWith(".aspx") || Request.Path.IndexOf(".") < 0)
            {
                if (Request.QueryString["curr"] != null)
                {
                    WebSession.Currency = (Currencies)Enum.Parse(typeof(Currencies), Request.QueryString["curr"]);
                }
            }

            if (Request.Path.Contains("/ImageCache/"))
            {
                string fileName = Path.GetFileName(Server.MapPath(Request.Path));

                string folder = Request.Path.Replace("/" + fileName, "");
                folder = folder.Substring(folder.LastIndexOf("/") + 1);

                string path = GraphicsHelper.GetCachedImage("~/Content/ProductImages", fileName, folder);
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RemoteAttribute), typeof(RemoteAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(CaptchaAttribute), typeof(CaptchaAttributeAdapter));
        }
    }
}