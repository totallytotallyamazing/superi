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
            builder.Append(helper.ScriptInclude("/Controls/ckeditor/ckeditor.js"));
            if(useCkFinder)
                builder.Append(helper.ScriptInclude("/Controls/ckfinder/ckfinder.js"));

            string editorScript = "<script type=\"text/javascript\">$(function(){editor_{2} = CKEDITOR.replace( '{0}', {1} );});</script>;";
            builder.Append(editorScript.Replace("{0}", name).Replace("{1}", settings.ObjectToString()).Replace("{2}", name));
            if (useCkFinder)
                builder.Append("<script type=\"text/javascript\">$(function(){CKFinder.SetupCKEditor( editor_" + name + ", '/Controls/ckfinder/' );});</script>");

            return builder.ToString();
        }
    }
}
