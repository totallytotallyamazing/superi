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
        private const string openPopupWindowScript = "window.open('iURL', 'wndPopUpHandle', 'width=iWIDTH, height=iHEIGHT, menubar=no, top=0, left=0, status=no, location=no, toolbar=no, scrollbars=yes, resizable=no'); return false";

        public static string PopUpWindowAction(this HtmlHelper htmlHelper, string linkText, string actionName, int width, int height)
        {
            return "";
        }
        public static string PopUpWindowAction(this HtmlHelper htmlHelper, string linkText, string actionName, string controller, object parameter, int width, int height)
        {
            StringBuilder resultingHtml = new StringBuilder();
            string actionUrl = actionName + ((parameter != null) ? "/" + parameter.ToString() : "");
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
