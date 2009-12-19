using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Dev.Mvc.Ajax
{
    public static class JqueryUiExtensions
    {
        public static string UiScriptInclude(this AjaxHelper helper, string scriptUrl, string themeName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(helper.ScriptInclude("/Scripts/jquery.js", scriptUrl));
            builder.Append(helper.DynamicCssInclude("/Content/" + themeName + "/jquery.ui.css"));
            return builder.ToString();
        }
    }
}
