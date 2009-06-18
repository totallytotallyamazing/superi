using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Microsoft.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Zamov.Helpers
{
    public static class Helpers
    {
        private static CultureInfo GetSelectedCulture()
        {
            CultureInfo info = null;
            if (HttpContext.Current.Session["lang"] != null)
            {
                string lang = HttpContext.Current.Session["lang"].ToString();
                info = CultureInfo.GetCultureInfo(lang);
            }
            else
                info = CultureInfo.GetCultureInfo("uk-UA");
            return info;
        }

        public static string CurrentCulture(this System.Web.Mvc.HtmlHelper helper)
        {
            return GetSelectedCulture().Name;
        }

        public static string RegisterCss(this System.Web.Mvc.HtmlHelper helper, string relativePath)
        {
            string cssPath = VirtualPathUtility.ToAbsolute(relativePath);
            string linkSource = "<link rel=\"Stylesheet\" href=\"{0}\" />";
            return string.Format(linkSource, cssPath);
        }

        public static string RegisterJS(this System.Web.Mvc.HtmlHelper helper, string scriptLib)
        {
            //get the directory where the scripts are
            string scriptRoot = VirtualPathUtility.ToAbsolute("~/Scripts");
            string scriptFormat = "<script src=\"{0}/{1}\" type=\"text/javascript\"></script>\r\n";
            return string.Format(scriptFormat, scriptRoot, scriptLib);
        }

        public static string ResourceString(this System.Web.Mvc.HtmlHelper helper, string resourceName)
        {
            return HttpContext.GetGlobalResourceObject("Resources", resourceName, GetSelectedCulture()).ToString();
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, string conrollerName)
        {
            string linkText = HttpContext.GetGlobalResourceObject("Resources", resourceName, GetSelectedCulture()).ToString();
            return helper.ActionLink(linkText, actionName, conrollerName);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, object routeValues)
        {
            string linkText = HttpContext.GetGlobalResourceObject("Resources", resourceName, GetSelectedCulture()).ToString();
            return helper.ActionLink(linkText, actionName, routeValues);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName)
        {
            string linkText = HttpContext.GetGlobalResourceObject("Resources", resourceName, GetSelectedCulture()).ToString();
            return helper.ActionLink(linkText, actionName);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, RouteValueDictionary routeValues)
        {
            string linkText = HttpContext.GetGlobalResourceObject("Resources", resourceName, GetSelectedCulture()).ToString();
            return helper.ActionLink(linkText, actionName, routeValues);
        }

        public static string ResourceActionLink<TController>(this System.Web.Mvc.HtmlHelper helper, string resourceName, Expression<Action<TController>> action) where TController:Controller
        {
            string linkText = HttpContext.GetGlobalResourceObject("Resources", resourceName, GetSelectedCulture()).ToString();
            return helper.ActionLink<TController>(action, linkText);
        }
    }
}
