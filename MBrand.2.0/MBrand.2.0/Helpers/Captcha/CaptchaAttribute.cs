using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Helpers.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CaptchaAttribute : ValidationAttribute
    {
        protected CaptchaAttribute()
        {
            RouteData = new RouteValueDictionary();
        }

        public CaptchaAttribute(string action, string controller)
            : this()
        {
            RouteData["controller"] = controller;
            RouteData["action"] = action;
            RouteData["area"] = "";
        }

        public CaptchaAttribute(string routeName)
            : this()
        {
            RouteName = routeName;
        }

        protected RouteValueDictionary RouteData { get; set; }

        protected string RouteName { get; set; }

        public virtual string GetUrl(ControllerContext controllerContext)
        {
            var pathData = RouteTable.Routes.GetVirtualPathForArea(controllerContext.RequestContext,
                                                            RouteName,
                                                            RouteData);

            if (pathData == null)
                throw new InvalidOperationException("No route matched!");

            return pathData.VirtualPath;
        }

        public override bool IsValid(object value)
        {
            return true;
        }
    }
}
