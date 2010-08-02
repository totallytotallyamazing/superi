using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class TitleAttribute : ActionFilterAttribute
    {
        private string title = string.Empty;

        public TitleAttribute(string title)
        {
            this.title = title;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.Controller.ViewData["title"] = title;
        }
    }
}
