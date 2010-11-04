using System.Text;
using System.Web.Mvc;
using System.Web;

namespace Dev.Mvc.Ajax
{
    public static class ScriptExtensions
    {
        public static string ScriptInclude(this AjaxHelper helper, params string[] url)
        {
            return ScriptInclude(helper.ViewContext.HttpContext, url);
        }

        public static string ScriptInclude(this HtmlHelper helper, params string[] url)
        {
            return ScriptInclude(helper.ViewContext.HttpContext, url);
        }

        private static string ScriptInclude(HttpContextBase context, params string[] url)
        {
            var tracker = new ResourceTracker(context);

            var sb = new StringBuilder();
            foreach (var item in url)
            {
                if (!tracker.Contains(item))
                {
                    tracker.Add(item);
                    sb.AppendFormat("<script type='text/javascript' src='{0}'></script>", item);
                    sb.AppendLine();
                }
            }
            return sb.ToString();
           
        }

        public static string IncludeAjax(this AjaxHelper helper, string scriptFolder)
        {
            return helper.ScriptInclude(scriptFolder + "/MicrosoftAjax.js");
        }

        public static string IncludeMvcAjax(this AjaxHelper helper, string scriptFolder)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(helper.IncludeAjax(scriptFolder));
            sb.Append(helper.ScriptInclude(scriptFolder + "/MicrosoftMvcAjax.js"));
            return sb.ToString();
        }

    }
}