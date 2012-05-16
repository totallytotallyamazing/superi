using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBrand.Modules
{
    public class FacebookRedirectModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
        }

        void BeginRequest(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.UserAgent.Contains("Facebook"))
            {
                string escapedFragment = HttpContext.Current.Request.QueryString["_escaped_fragment_"];
                if (!string.IsNullOrEmpty(escapedFragment))
                {
                    HttpContext.Current.Response.Redirect(VirtualPathUtility.ToAbsolute("~/#!" + escapedFragment));
                }
            }
        }

        public void Dispose()
        {
            
        }
    }
}