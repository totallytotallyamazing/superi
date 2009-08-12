using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Zamov.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DoSomething()
        {
            if (HttpContext.Request.Form["captchaValid"] == "true")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

 
        /*
        protected override bool OnPreAction(string actionName, System.Reflection.MethodInfo methodInfo)
        {
            object[] attributes = methodInfo.GetCustomAttributes(typeof(CaptchaValidationAttribute), false);

            if (attributes != null && attributes.Length > 0)
                OnCaptchaValidation(actionName, methodInfo, (CaptchaValidationAttribute)attributes[0]);

            return base.OnPreAction(actionName, methodInfo);
        }  
        */

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // make sure no values are getting sent in from the outside
            if (filterContext.ActionParameters.ContainsKey("captchaValid"))
                filterContext.ActionParameters["captchaValid"] = null;

            // get the guid from the post back
            string guid = filterContext.HttpContext.Request.Form["captcha-guid"];

            // check for the guid because it is required from the rest of the opperation
            if (String.IsNullOrEmpty(guid))
            {
                filterContext.RouteData.Values.Add("captchaValid", false);
                return;
            }

            // get values
            CaptchaImage image = CaptchaImage.GetCachedCaptcha(guid);
            string actualValue = filterContext.HttpContext.Request.Form["captcha"];
            string expectedValue = image == null ? String.Empty : image.Text;

            // removes the captch from cache so it cannot be used again
            filterContext.HttpContext.Cache.Remove(guid);

            // validate the captch
            filterContext.ActionParameters["captchaValid"] =
                    !String.IsNullOrEmpty(actualValue)
                    && !String.IsNullOrEmpty(expectedValue)
                    && String.Equals(actualValue, expectedValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
