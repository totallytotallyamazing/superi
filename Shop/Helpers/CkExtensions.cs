using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;
using System.Linq.Expressions;

namespace Dev.Mvc.Ajax
{
    public static class CkExtensions
    {
        public static string CkEditor(this HtmlHelper helper, 
            string name, 
            string callbackFunction = "null", 
            string settingsObject = "null", 
            string value="",
            int rows = 3,
            int columns = 5,
            object htmlAttributes = null
            )
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder script = new StringBuilder();

            builder.Append(helper.ScriptInclude("/Controls/ckeditor/ckeditor.js"));
            builder.Append(helper.ScriptInclude("/Controls/ckeditor/adapters/jquery.js"));

            string control = helper.TextArea(name, value, rows, columns, htmlAttributes).ToString();

            script.Append("<script type=\"text/javascript\">");
            script.Append("$(function(){");
            script.AppendFormat("$('{0}').ckeditor({1}, {2})", name);
            script.Append("});");
            script.Append("</script>");
            builder.Append(script.ToString());

            return builder.ToString();
        }

        //public static MvcHtmlString CkEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
        //    Expression<Func<TModel, TProperty>> expression,
        //    string callbackFunction = "null",
        //    string settingsObject = "null",
        //    string value = "",
        //    int rows = 3,
        //    int columns = 5,
        //    object htmlAttributes = null
        //    )
        //{ 
        //    if(expression == null)
        //        throw new ArgumentNullException("expression");

        //    ModelState state;
        //    string expressionString
        //    string attemptedValue;
        //    string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
        //    if (string.IsNullOrEmpty(fullHtmlFieldName))
        //    {
        //        throw new ArgumentException("name");
        //    }
        //}

        public static string CkEditor(this AjaxHelper helper, string name, string callbackFunction = "null", string settingsObject = "null")
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder script = new StringBuilder();
            builder.Append(helper.ScriptInclude("/Controls/ckeditor/ckeditor.js"));
            builder.Append(helper.ScriptInclude("/Controls/ckeditor/adapters/jquery.js"));

            script.Append("<script type=\"text/javascript\">");
            script.Append("$(function(){");
            script.AppendFormat("debugger;$('#{0}').ckeditor({1}, {2})", name, callbackFunction, settingsObject);
            script.Append("});");
            script.Append("</script>");
            builder.Append(script.ToString());

            return builder.ToString();
        }
    }
}
