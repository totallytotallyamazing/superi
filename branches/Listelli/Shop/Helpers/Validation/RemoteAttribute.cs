using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Helpers.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RemoteAttribute : ValidationAttribute
    {
        protected RemoteAttribute(string parameterName)
        {
            ParameterName = parameterName;
            RouteData = new RouteValueDictionary();
        }

        public RemoteAttribute(string action, string controller, string parameterName)
            : this(parameterName)
        {
            RouteData["controller"] = controller;
            RouteData["action"] = action;
            RouteData["area"] = "";
        }

        public RemoteAttribute(string routeName, string parameterName)
            : this(parameterName)
        {
            RouteName = routeName;
        }

        public string ParameterName { get; protected set; }

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