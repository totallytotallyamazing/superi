using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Dev.Mvc.Helpers
{
    public static class HtmlHelpers
    {
        public static string Image(this HtmlHelper helper, string relativeUrl, string alt)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(relativeUrl))
            {
                string srcFormat = "<img src=\"{0}\" alt=\"{1}\" />";
                string imageSource = VirtualPathUtility.ToAbsolute(relativeUrl);
                result = string.Format(srcFormat, imageSource, alt);
            }
            return result;
        }

        public static string Image(this HtmlHelper helper, string relativeUrl, string alt, int imageWidth)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(relativeUrl))
            {
                string srcFormat = "<img src=\"{0}\" alt=\"{1}\" width=\"{2}\" />";
                string imageSource = VirtualPathUtility.ToAbsolute(relativeUrl);
                result = string.Format(srcFormat, imageSource, alt, imageWidth);
            }
            return result;
        }
    }
}