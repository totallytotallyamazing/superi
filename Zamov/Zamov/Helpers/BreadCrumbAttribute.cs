using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zamov.Controllers;

namespace Zamov.Helpers
{
    public class BreadCrumbAttribute : ActionFilterAttribute
    {
 
        public string Text { get; set; }
        public string Url { get; set; }
        public string ResourceName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string url = Url;
            string text = Text;
            if (!string.IsNullOrEmpty(ResourceName))
                text = ResourcesHelper.GetResourceString(ResourceName);

            BreadCrumbsExtensions.AddBreadCrumb(filterContext.HttpContext, text, url);
            base.OnActionExecuting(filterContext);
        }
    }
}
