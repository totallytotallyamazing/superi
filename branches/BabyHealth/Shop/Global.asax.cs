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

namespace Shop
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Go", // Route name
                "Go/{id}", // URL with parameters
                new { controller = "Home", action = "Go", id = UrlParameter.Optional }, // Parameter defaults
                new string[1] { "Shop.Controllers" }
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[1] { "Shop.Controllers" }
            );

        }

        protected void Application_AquireSessionState()
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

                string path = GraphicsHelper.GetCachedImage("~/Content/AdImages", fileName, folder);
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RemoteAttribute), typeof(RemoteAttributeAdapter));
        }
    }
}