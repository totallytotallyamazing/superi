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
            //if(useCkFinder)
            //    builder.Append(helper.ScriptInclude("/Controls/ckfinder/ckfinder.js"));

            string editorScript = "editor_{2} = CKEDITOR.replace( '{0}', {1} );";
            script.Append("<script type=\"text/javascript\">");
            script.Append("$(function(){");
            //script.AppendFormat(editorScript, name, settings.ObjectToString(), name.Replace("-", "_"));
//            script.AppendFormat("ckExtender.enableHtmlEncodeOutput(editor_{0}, '{1}');", name.Replace("-", "_"), name.Replace("-", "_"));
            //if (useCkFinder)
            //    script.AppendFormat("CKFinder.SetupCKEditor( editor_{0}, '/Controls/ckfinder/' );", name.Replace("-", "_"));
            script.AppendFormat("ckExtender.bindFileManager('{0}');", name);
            script.Append("});");
            script.Append("</script>");
            builder.Append(script.ToString());

            return builder.ToString();
        }
    }
}
