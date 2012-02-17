// Uri.cs
//

using System;
using System.Html;

namespace MBrand.Client.Utility
{
    public static class Uri
    {
        private const string PageNamePattern = "[a-zA-Z/:0-9.]*/(\\w+\\.html)";

        public static string GetQueryString(WindowInstance window, string key)
        {
            string value = string.Empty;
            RegularExpression re = new RegularExpression("[?&]" + key + "=([^&$]*)", "i");
            //    #warning "Rework similar to GetCurrentPage"
            int offset = window.Location.Search.Search(re);
            if (offset != -1)
                value = (string)Script.Literal("RegExp.$1");
            return value;
        }

        public static string GetCurrentPage()
        {
            return GetPage(Window.Self);
        }

        public static string GetPage(WindowInstance window)
        {
            RegularExpression pageNameMatch = new RegularExpression(PageNamePattern);

            string[] groups = pageNameMatch.Exec(window.Location.Href);
            return (groups != null) ? groups[1] : string.Empty;
        }


    }
}
