﻿using System;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Oksi.Mvc.Ajax
{
    public static class AjaxExtensions
    {
        private static string _microsoftAjaxLibraryUrl = "/Scripts/MicrosoftAjax.js";
        private static string _microsoftMvcAjaxLibraryUrl = "/Scripts/MicrosoftMvcAjax.js";
        private static string _toolkitFolderUrl = "/Scripts/AjaxControlToolkit/";

        public static void SetMicrosoftAjaxLibraryUrl(this AjaxHelper helper, string url)
        {
            _microsoftAjaxLibraryUrl = url;
        }

        public static string GetMicrosoftAjaxLibraryUrl(this AjaxHelper helper)
        {
            return _microsoftAjaxLibraryUrl;
        }


        public static void SetToolkitFolderUrl(this AjaxHelper helper, string url)
        {
            _toolkitFolderUrl = url;
        }

        public static string GetToolkitFolderUrl(this AjaxHelper helper)
        {
            return _toolkitFolderUrl;
        }

        public static string MicrosoftAjaxLibraryInclude(this AjaxHelper helper)
        {
            return ScriptExtensions.ScriptInclude(helper, _microsoftAjaxLibraryUrl);
        }

        public static string MicrosoftMvcAjaxLibraryInclude(this AjaxHelper helper)
        {
            var sb = new StringBuilder();
            sb.Append(ScriptExtensions.ScriptInclude(helper, _microsoftAjaxLibraryUrl));
            sb.Append(ScriptExtensions.ScriptInclude(helper, _microsoftMvcAjaxLibraryUrl));
            return sb.ToString();
        }

        public static string ToolkitInclude(this AjaxHelper helper, params string[] fileName)
        {
            var sb = new StringBuilder();
            foreach (string item in fileName)
            {
                var fullUrl = _toolkitFolderUrl + item;
                sb.AppendLine(ScriptExtensions.ScriptInclude(helper, fullUrl));
            }
            return sb.ToString();
        }


        public static string DynamicToolkitCssInclude(this AjaxHelper helper, string fileName)
        {
            var fullUrl = _toolkitFolderUrl + fileName;
            return helper.DynamicCssInclude(fullUrl);
        }

        public static string DynamicCssInclude(this AjaxHelper helper, string url)
        {
            var tracker = new ResourceTracker(helper.ViewContext.HttpContext);
            if (tracker.Contains(url))
                return String.Empty;

            var sb = new StringBuilder();
            sb.AppendLine("<script type='text/javascript'>");
            sb.AppendLine("var link=document.createElement('link');");
            sb.AppendLine("link.setAttribute('rel', 'stylesheet');");
            sb.AppendLine("link.setAttribute('type', 'text/css');");
            sb.AppendFormat("link.setAttribute('href', '{0}');", url);
            sb.AppendLine();
            sb.AppendLine("var head = document.getElementsByTagName('head')[0];");
            sb.AppendLine("head.appendChild(link);");
            sb.AppendLine("</script>");
            return sb.ToString();
        }



        public static string Create(this AjaxHelper helper, string clientType, string elementId)
        {
            return helper.Create(clientType, String.Empty, elementId, String.Empty);
        }

        public static string Create(this AjaxHelper helper, string clientType, object props, string elementId)
        {
            return helper.Create(clientType, props, elementId, string.Empty);
        }


        public static string Create(this AjaxHelper helper, string clientType, object props, string elementId, string scriptKey)
        {
            var strProps = props.ObjectToString();
            var sb = new StringBuilder();
            sb.AppendLine("<script type='text/javascript' rel=\"" + scriptKey + "\">");
            sb.AppendLine("Sys.Application.add_init(function(){try{");
            sb.AppendFormat("$create({0},{1},null,null,$get('{2}'))", clientType, strProps, elementId);
            sb.AppendLine("}catch(e){}});");
            sb.AppendLine("</script>");
            return sb.ToString();
        }


        public static string ObjectToString(this object thing)
        {
            string properties = string.Empty;
            if (thing != null)
            {
                var colProps = new List<string>();
                var props = thing.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var val = prop.GetValue(thing, null);
                    if (val is string)
                        colProps.Add(String.Format("{0}:'{1}'", prop.Name, prop.GetValue(thing, null)));
                    else if (val is bool)
                        colProps.Add(String.Format("{0}:{1}", prop.Name, prop.GetValue(thing, null).ToString().ToLower()));
                    else
                        colProps.Add(String.Format("{0}:{1}", prop.Name, prop.GetValue(thing, null)));
                }

                properties = String.Join(",", colProps.ToArray());
            }
            return "{" + properties + "}";
        }
    }
}
