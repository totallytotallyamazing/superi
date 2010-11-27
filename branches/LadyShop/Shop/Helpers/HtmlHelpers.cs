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
            string srcFormat = "<img src=\"{0}\" alt=\"{1}\" />";
            string imageSource = relativeUrl != null ? VirtualPathUtility.ToAbsolute(relativeUrl) : string.Empty;
            return string.Format(srcFormat, imageSource, alt);
        }
    }
}