using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Dev.Mvc.Ajax
{
    public static class CkExtensions
    {
        public static string CkEditor(this AjaxHelper helper, string name, bool useCkFinder, object settings)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder script = new StringBuilder();

            builder.Append(helper.ScriptInclude("/Controls/ckeditor/ckeditor.js"));
            builder.Append(helper.ScriptInclude("/Scripts/ck.extensions.js"));

            script.Append("<script type=\"text/javascript\">");
            script.Append("$(function(){");
            script.AppendFormat("ckExtender.bindFileManager('{0}');", name);
            script.Append("});");
            script.Append("</script>");
            builder.Append(script.ToString());

            return builder.ToString();
        }
    }
}
