﻿using System.Text;
using System.Web.Mvc;

namespace Oksi.Mvc.Ajax
{
    public static class ScriptExtensions
    {
        public static string ScriptInclude(this AjaxHelper helper, params string[] url)
        {
            return helper.ScriptInclude(false, url);
        }

        public static string ScriptInclude(this AjaxHelper helper, bool trackerOnly, params string[] url)
        {
            var tracker = new ResourceTracker(helper.ViewContext.HttpContext);

            var sb = new StringBuilder();
            foreach (var item in url)
            {
                if (!tracker.Contains(item))
                {
                    tracker.Add(item);
                    if (!trackerOnly)
                    {
                        sb.AppendFormat("<script type='text/javascript' src='{0}'></script>", item);
                        sb.AppendLine();
                    }
                }
            }
            return sb.ToString();
        }

    }
}