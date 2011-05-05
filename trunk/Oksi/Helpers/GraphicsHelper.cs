using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Oksi.Helpers
{
    public static class GraphicsHelper
    {
        public static string RegisterFlashScript(this HtmlHelper helper, string fileName, string containerName, int width, int height)
        {
            return RegisterFlashScript(helper, fileName, containerName, width, height, false);
        }

        public static string RegisterFlashScript(this HtmlHelper helper, string fileName, string containerName, int width, int height, bool transparent)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;
            var sb = new StringBuilder();
            string path = Path.Combine("/Content/Banners/", fileName);
            sb.Append("<script type=\"text/javascript\">$(function() {swfobject = new SWFObject(\"" + path + "\", \"" + containerName + "\", \"" + width + "\", \"" + height + "\", \"9.0.0\"); " + (transparent ? "swfobject.addParam(\"wmode\", \"transparent\"); " : "") + "  swfobject.write(\"" + containerName + "\");});</script>");
            sb.Append("<div id=\"" + containerName + "\"></div>");
            return sb.ToString();
        }
    }
}
