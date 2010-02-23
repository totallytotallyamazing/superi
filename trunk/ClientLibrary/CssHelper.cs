using System;
using Jquery;

namespace ClientLibrary
{
    public class CssHelper
    {
        public static void AddCss(string path, string cssKey)
        {
            JQuery query = JQueryProxy.jQuery("<link rel='Stylesheet'>").attr("href", path);
            query = query.attr("key", cssKey);
            query.appendTo("#content");
        }

        public static void RemoveCss(string key)
        {
            JQueryProxy.jQuery("link[key='" + key + "']").remove(null);
        }
    }
}
