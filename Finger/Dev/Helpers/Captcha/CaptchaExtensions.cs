using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Caching;

namespace Dev.Helpers
{
    public static class CaptchaExtensions
    {
        public static string CaptchaImage(this HtmlHelper helper, int height, int width)
        {
            CaptchaImage image = new CaptchaImage
            {
                Height = height,
                Width = width,
            };

            HttpContext.Current.Cache.Add(image.UniqueId, image, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

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
    }
}
