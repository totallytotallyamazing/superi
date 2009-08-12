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
        [CaptchaValidation("captcha")]
        public ActionResult DoSomething(bool captchaValid)
        {
            ViewData["captchaValid"] = captchaValid;
            return View("Index");
           
        }
    }
}
