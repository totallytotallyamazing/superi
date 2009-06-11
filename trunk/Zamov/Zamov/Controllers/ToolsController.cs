using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Zamov.Controllers
{
    public class ToolsController : Controller
    {
        //
        // GET: /Tools/

        public static string CurrentLanguage
        {
            get 
            {
                if (System.Web.HttpContext.Current.Session["lang"] == null)
                    System.Web.HttpContext.Current.Session["lang"] = "uk-UA";
                return (string)System.Web.HttpContext.Current.Session["lang"];
            }
        }

    }
}
