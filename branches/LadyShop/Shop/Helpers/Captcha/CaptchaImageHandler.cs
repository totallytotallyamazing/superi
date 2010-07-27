using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;

namespace Dev.Helpers
{
    public class CaptchaImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            // get the unique GUID of the captcha; this must be passed in via the querystring
            string guid = context.Request.QueryString["guid"];
            CaptchaImage ci = CaptchaImage.GetCachedCaptcha(guid);

            if (String.IsNullOrEmpty(guid) || ci == null)
            {
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "Not Found";
                context.ApplicationInstance.CompleteRequest();
                return;
            }

            // write the image to the HTTP output stream as an array of bytes
            using (Bitmap b = ci.RenderImage())
            {
                b.Save(context.Response.OutputStream, ImageFormat.Gif);
            }

            context.Response.ContentType = "image/png";
            context.Response.StatusCode = 200;
            context.Response.StatusDescription = "OK";
            context.ApplicationInstance.CompleteRequest();
        }
    }
}
