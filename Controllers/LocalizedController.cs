using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Dev.Helpers;

namespace Dev.Controllers
{
    public class LocalizedController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.RouteData.Values["culture"] != null)
            { 
                string cultureName = filterContext.RouteData.Values["culture"].ToString();
                LocaleHelper.SetCulture(cultureName);
            }
        }
    }
}
