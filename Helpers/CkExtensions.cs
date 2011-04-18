using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace Oksi.Mvc.Ajax
{
    public static class CkExtensions
    {
        public static string CkEditor(this AjaxHelper helper, string name, bool useCkFinder, object settings)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(helper.ScriptInclude("/Controls/ckeditor/ckeditor.js"));
            builder.Append(helper.ScriptInclude("/Scripts/ck.extensions.js"));
            if (useCkFinder)
                builder.Append(helper.ScriptInclude("/Controls/ckfinder/ckfinder.js"));

            string editorScript = "<script type=\"text/javascript\">editor_{2} = CKEDITOR.replace( '{0}', {1} );</script>";
            builder.AppendFormat(editorScript, name, settings.ObjectToString(), name);
            builder.AppendFormat("<script type=\"text/javascript\">ckExtender.enableHtmlEncodeOutput(editor_{0});</script>", name);
            if (useCkFinder)
                builder.Append("<script type=\"text/javascript\">$(function(){CKFinder.SetupCKEditor( editor_" + name + ", '/Controls/ckfinder/' );});</script>");

            return builder.ToString();
        }
    }
}
