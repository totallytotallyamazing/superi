using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;

namespace Dev.Mvc.Ajax
{
    public static class JqueryUiExtensions
    {
        public static string UiScriptInclude(this AjaxHelper helper, string themeName)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(helper.ScriptInclude("/Scripts/jquery.ui.js"));
            builder.Append(helper.DynamicCssInclude("/Content/" + themeName + "/jquery.ui.css"));
            return builder.ToString();
        }

        public static string Tabs(this AjaxHelper helper, string name, string[] tabs, string[] content, object settings)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<div id=\"{0}\">", name);
            builder.Append("<ul>");
            for (int i = 0; i < tabs.Length; i++)
            {
                builder.AppendFormat("<li><a href=\"#{0}-{1}\"><span>{2}</span></a></li>", name, i+1, tabs[i]);
            }
            builder.Append("</ul>");
            for (int j = 0; j < content.Length; j++)
            {
                builder.AppendFormat("<div id=\"{0}-{1}\">{2}</div>", name, j+1, content[j]);
            }
            builder.Append("</div>");
            builder.Append("<script type=\"text/javascript\">");
            builder.Append("$(function(){");
            builder.AppendFormat("$(\"#{0}\").tabs({1})", name, settings.ObjectToString());
            builder.Append("});");
            builder.Append("</script>");
            return builder.ToString();
        }

        public static string DatePicker(this HtmlHelper helper, string name, object value, object htmlAttributes, object settings)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(helper.TextBox(name, value, htmlAttributes));
            builder.Append("<script type=\"text/javascript\">");
            builder.Append("$(function(){");
            builder.AppendFormat("$(\"#{0}\").datepicker({1})", name, settings.ObjectToString());
            builder.Append("});");
            builder.Append("</script>");
            return builder.ToString();
        }

        public static string Dialog(this AjaxHelper helper, string selector, object settings, Dictionary<string, string> buttons)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script type=\"text/javascript\">");
            builder.Append("$(function(){");
            builder.AppendFormat("$(\"{0}\").dialog({1});", selector, settings.ObjectToString());
            if (buttons != null)
            {
                string[] buttonScript = buttons.Select(kvp => "'" + kvp.Key + "': " + kvp.Value).ToArray();
                string btns = "{" + string.Join(",", buttonScript) + "}";
                builder.AppendFormat("$(\"{0}\").dialog('option', 'buttons', {1});", selector, btns);
            }
            builder.Append("});");
            builder.Append("</script>");
            return builder.ToString();
        }
    }
}
