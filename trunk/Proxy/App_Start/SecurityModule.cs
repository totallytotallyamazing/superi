using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BrsmProxy.App_Start
{
    public class SecurityModule :IHttpModule
    {

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
        }

        void BeginRequest(object sender, EventArgs e)
        {
            string allowedIPs = WebConfigurationManager.AppSettings["AllowerIPs"];
            bool permit = true;
            if(allowedIPs != "*")
            {
                permit = allowedIPs.Split(';').Contains(HttpContext.Current.Request.UserHostAddress);
            }
            if (!permit)
            {
                throw new HttpException(403, "Access denied");
            }
        }
    }
}