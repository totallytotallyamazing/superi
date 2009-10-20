using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Globalization;
using System.Web.Caching;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Microsoft.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Mvc;
using Zamov.Models;
using Zamov.Controllers;
using System.Web.UI.WebControls;

namespace Zamov.Helpers
{
    public static class Helpers
    {
        public static string RegisterCss(this System.Web.Mvc.HtmlHelper helper, string relativePath)
        {
            string cssPath = VirtualPathUtility.ToAbsolute(relativePath);
            string linkSource = "<link rel=\"Stylesheet\" href=\"{0}\" />";
            return string.Format(linkSource, cssPath);
        }

        public static string RegisterJS(this System.Web.Mvc.HtmlHelper helper, string scriptLib)
        {
            //get the directory where the scripts are
            string scriptRoot = VirtualPathUtility.ToAbsolute("~/Scripts");
            string scriptFormat = "<script src=\"{0}/{1}\" type=\"text/javascript\"></script>\r\n";
            return string.Format(scriptFormat, scriptRoot, scriptLib);
        }

        public static string ResourceString(this System.Web.Mvc.HtmlHelper helper, string resourceName)
        {
            return Controllers.ResourcesHelper.GetResourceString(resourceName);
        }

        public static string CaptchaImage(this HtmlHelper helper, int height, int width)
        {
            CaptchaImage image = new CaptchaImage
            {
                Height = height,
                Width = width,
            };

            HttpRuntime.Cache.Add(
                image.UniqueId,
                image,
                null,
                DateTime.Now.AddSeconds(Zamov.CaptchaImage.CacheTimeOut),
                Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable,
                null);

            StringBuilder stringBuilder = new StringBuilder(256);
            stringBuilder.Append("<input type=\"hidden\" name=\"captcha-guid\" value=\"");
            stringBuilder.Append(image.UniqueId);
            stringBuilder.Append("\" />");
            stringBuilder.AppendLine();
            stringBuilder.Append("<img src=\"");
            stringBuilder.Append("/captcha.ashx?guid=" + image.UniqueId);
            stringBuilder.Append("\" alt=\"CAPTCHA\" width=\"");
            stringBuilder.Append(width);
            stringBuilder.Append("\" height=\"");
            stringBuilder.Append(height);
            stringBuilder.Append("\" />");

            return stringBuilder.ToString();
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, string conrollerName)
        {
            string linkText = Controllers.ResourcesHelper.GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, conrollerName);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, string conrollerName, object routeValues, object htmlAttributes)
        {
            string linkText = Controllers.ResourcesHelper.GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, conrollerName, routeValues, htmlAttributes);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, object routeValues)
        {
            string linkText = Controllers.ResourcesHelper.GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, routeValues);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, object routeValues, object htmlAttributes)
        {
            string linkText = Controllers.ResourcesHelper.GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, routeValues, htmlAttributes);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName)
        {
            string linkText = Controllers.ResourcesHelper.GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName);
        }

        public static string ResourceActionLink(this System.Web.Mvc.HtmlHelper helper, string resourceName, string actionName, RouteValueDictionary routeValues)
        {
            string linkText = Controllers.ResourcesHelper.GetResourceString(resourceName);
            return helper.ActionLink(linkText, actionName, routeValues);
        }

        public static string ResourceSortHeader(this System.Web.Mvc.HtmlHelper helper, string resourceName, string targetUrl, string sortField)
        {
            string text = ResourcesHelper.GetResourceString(resourceName);
            string linkFormat = "<a href=\"{0}\">{1}</a>{2}";
            string sortFieldName = (string)helper.ViewData["sortField"];
            string imageLayout = "";
            string sortOrder = "Ascending";
            if(sortFieldName == sortField)
            {
                SortDirection sortDirection = (SortDirection)helper.ViewData["sortDirection"];
                if (sortDirection == SortDirection.Ascending)
                    sortOrder = "Descending";
                string imageFormat = "&nbsp;<img alt=\"\" src=\"/Content/img/{0}.gif\">";
                imageLayout = String.Format(imageFormat, sortDirection.ToString().ToLower());
            }

            string link = String.Format("{0}?sortField={1}&sortOrder={2}", targetUrl, sortField, sortOrder);
            string linkLayout = String.Format(linkFormat, link, text, imageLayout);

            return linkLayout;
        }

        public static string ResourceActionLink<TController>(this System.Web.Mvc.HtmlHelper helper, string resourceName, Expression<Action<TController>> action) where TController : Controller
        {
            string linkText = Controllers.ResourcesHelper.GetResourceString(resourceName);
            return helper.ActionLink<TController>(action, linkText);
        }

        public static string FrameWindow(this HtmlHelper helper, string targetControlId, string contentUrl)
        {
            string onLoadScript = DialogScript(targetControlId);

            string displayWindowFunction = DisplayWindowFunction(targetControlId, contentUrl);

            string closeWindowFunction = CloseWindowFunction(targetControlId);

            return "<script type=\"text/javascript\">" + string.Concat(onLoadScript, displayWindowFunction, closeWindowFunction) + "</script>";
        }

        public static string TranslatedText(this HtmlHelper helper, string targetControlId, string formAction, string formController, string richEditorPanel)
        {
            string onLoadScript = DialogScript(targetControlId);

            if (string.IsNullOrEmpty(richEditorPanel))
                richEditorPanel = "Basic";
            string displayWindowFunction = DisplayWindowFunction(targetControlId, "/PageParts/TranslatedText?formAction=" + formAction + "&formController=" + formController + "&richEditorPanel=" + richEditorPanel);

            string closeWindowFunction = CloseWindowFunction(targetControlId);

            return "<script type=\"text/javascript\">" + string.Concat(onLoadScript, displayWindowFunction, closeWindowFunction) + "</script>";
        }

        public static string CloseParentScript(string targetControlId)
        {
            return "<script>top.close" + targetControlId + "();</script>";
        }

        private static string DialogScript(string targetControlId)
        {
            return @"    
             $(function() { " +
                 "$('#" + targetControlId + "')" +
                    @".dialog({
                        autoOpen: false,
                        width: 700,
                        height: 500,
                        minHeight: 360,
                        resizable: false,
                        buttons: {" +
                            "'" + ResourcesHelper.GetResourceString("Cancel") + "': function(){close" + targetControlId + "();}," +
                            "'" + ResourcesHelper.GetResourceString("Save") + "': function() { $get('" + targetControlId + "Frame').contentWindow.update" + targetControlId + "(); }" +
                        @"}
                    });
                });

                ";
        }

        private static string DisplayWindowFunction(string targetControlId, string contentUrl)
        {
            return "function open" + targetControlId + "() {" +
                "var controlId = '#" + targetControlId + "';" +
            "$(controlId)" +
                ".html('<iframe frameborder=\"0\" name=\"" + targetControlId + "Frame\" id=\"" + targetControlId + "Frame\" hidefocus=\"true\" style=\"width:660px; height:500px;\" src=\"" + contentUrl + "\"></iframe>');" +
            @"$(controlId).dialog('open').css('height', 400);
            $(controlId).dialog('option', 'height', 500);
            $(controlId).dialog('option', 'position', 'center');
            };

            ";
        }

        private static string CloseWindowFunction(string targetControlId)
        {
            return "function close" + targetControlId + "(){$('#" + targetControlId + "').dialog('close');}";
        }
    }
}
