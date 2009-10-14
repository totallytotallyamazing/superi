using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PolialClean.Models;
using System.Web.Mvc;
using PolialClean.Controllers;

namespace PolialClean.Helpers
{
    public static class Helpers
    {
        public static string RegisterCss(this System.Web.Mvc.HtmlHelper helper, string relativePath)
        {
            string cssPath = VirtualPathUtility.ToAbsolute(relativePath);
            string linkSource = "<link rel=\"Stylesheet\" href=\"{0}\" />";
            return string.Format(linkSource, cssPath);
        }

        public static string RegisterJS(this System.Web.Mvc.HtmlHelper helper, string scriptLib)
        {
            //get the directory where the scripts are
            string scriptRoot = VirtualPathUtility.ToAbsolute("~/Scripts");
            string scriptFormat = "<script src=\"{0}/{1}\" type=\"text/javascript\"></script>\r\n";
            return string.Format(scriptFormat, scriptRoot, scriptLib);
        }


        public static string WriteText(this HtmlHelper helper, string textName)
        {
            return Utils.GetText(textName).Content;
        }

        public static string WriteText(this HtmlHelper helper, int id)
        {
            return Utils.GetText(id).Content;
        }
    }
}
