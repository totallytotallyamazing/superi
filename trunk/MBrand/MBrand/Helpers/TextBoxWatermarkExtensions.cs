using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace AjaxControlToolkitMvc
{
    public static class TextBoxWatermarkExtensions
    {
        public static string TextBoxWatermark(this AjaxHelper helper, string targetControlId, string watermarkText, string watermarkCssClass)
        {
            var sb = new StringBuilder();

            sb.AppendLine(helper.ToolkitInclude
            (
                "AjaxControlToolkit.ExtenderBase.BaseScripts.js",
                "AjaxControlToolkit.Common.Common.js",
                "AjaxControlToolkit.TextboxWatermark.TextboxWatermark.js"
            ));

                        var props = new
            {
                WatermarkText = watermarkText,
                WatermarkCssClass = watermarkCssClass
            };

            sb.AppendLine(helper.Create("AjaxControlToolkit.TextBoxWatermarkBehavior", props, targetControlId));
            return sb.ToString();
        }
    }
}
