using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Pandemiia.Controllers
{
    [HandleError]
    [HandleError(ExceptionType=typeof(Exception), View="Default")]
    public class ErrorsController : Controller
    {
        //
        // GET: /Errors/

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }


    }
}
