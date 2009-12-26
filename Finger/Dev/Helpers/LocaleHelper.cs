using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc.Html;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;
using System.Threading;

namespace Dev.Helpers
{
    public static class LocaleHelper
    {
        public static string GetCultureName()
        {
            return CultureInfo.CurrentUICulture.Name;
        }

        public static void SetCulture(string cultureName)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public static CultureInfo GetSelectedCulture()
        {
            CultureInfo info = CultureInfo.CurrentUICulture;
            return info;
        }

        public static string CurrentCulture(this System.Web.Mvc.HtmlHelper helper)
        {
            return GetSelectedCulture().Name;
        }

        public static string GetResourceString(string resourceName)
        {
            return HttpContext.GetGlobalResourceObject("Resources", resourceName, GetSelectedCulture()).ToString();
        }

        public static string ResourceString(this System.Web.Mvc.HtmlHelper helper, string resourceName)
        {
            return GetResourceString(resourceName);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, string conrollerName)
        {
            string linkText = GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, conrollerName);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, string conrollerName, object routeValues, object htmlAttributes)
        {
            string linkText = GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, conrollerName, routeValues, htmlAttributes);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, object routeValues)
        {
            string linkText = GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, routeValues);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, object routeValues, object htmlAttributes)
        {
            string linkText = GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, routeValues, htmlAttributes);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName)
        {
            string linkText = GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, RouteValueDictionary routeValues)
        {
            string linkText = GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, routeValues);
        }

        public static string ResourceActionLink<TController>(this System.Web.Mvc.HtmlHelper helper, string resourceName, Expression<Action<TController>> action) where TController : Controller
        {
            string linkText = GetResourceString(resourceName);
            return helper.ActionLink<TController>(action, linkText);
        }

    }
}
