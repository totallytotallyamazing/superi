using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class ToolsController : Controller
    {
        public static string CurrentLanguage
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["lang"] == null)
                    System.Web.HttpContext.Current.Session["lang"] = "uk-UA";
                return (string)System.Web.HttpContext.Current.Session["lang"];
            }
            set { System.Web.HttpContext.Current.Session["lang"] = value; }
        }
    }
}
