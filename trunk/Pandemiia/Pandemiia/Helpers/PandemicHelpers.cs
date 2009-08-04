using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;

namespace Pandemiia.Helpers
{
    public static class PandemicHelpers
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

        private const string openPopupWindowScript = "window.open('iURL', 'wndPopUpHandle', 'width=iWIDTH, height=iHEIGHT, menubar=no, top=0, left=0, status=no, location=no, toolbar=no, scrollbars=yes, resizable=no'); return false";

        public static string PopUpWindowAction(this HtmlHelper htmlHelper, string linkText, string actionName, int width, int height)
        {
            return "";
        }
        public static string PopUpWindowAction(this HtmlHelper htmlHelper, string linkText, string actionName, string controller, object parameter, int width, int height)
        {
            StringBuilder resultingHtml = new StringBuilder();
            UrlHelper helper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            string actionUrl = helper.Action(actionName, controller, new { id = parameter});//actionName + ((parameter != null) ? "/" + parameter.ToString() : "");
            string openWindowScript = openPopupWindowScript.Replace("iURL", actionUrl)
                .Replace("iWIDTH", width.ToString())
                .Replace("iHEIGHT", height.ToString());
            resultingHtml.AppendFormat
                (
                    "{0}a href=\"#\" onclick=\"{1}\" {2}",
                    new object[] 
                        {
                            HtmlTextWriter.TagLeftChar,
                            //actionName,
                            //(parameter!=null)?"/":"",
                            //(parameter!=null)?parameter.ToString():"",
                            openWindowScript,
                            HtmlTextWriter.TagRightChar
                        }
                );
            resultingHtml.Append(linkText);
            resultingHtml.Append("</a>");
            return resultingHtml.ToString();
        }
    }
}
