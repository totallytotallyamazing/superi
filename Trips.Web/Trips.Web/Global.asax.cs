using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace Trips.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }



        public string DefaultCulture
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultLanguage"];
            }
        }

        HttpCookie CreateLangCookie(string lang)
        {
            HttpCookie cookie = new HttpCookie("lang", lang);
            cookie.Expires = DateTime.Now.AddYears(1);
            return cookie;
        }

        void InitCulture(string toCulture)
        {
            string culture;
            if (string.IsNullOrEmpty(toCulture))
            {
                if (Request.Cookies["lang"] == null)
                {
                    Response.Cookies.Set(CreateLangCookie(DefaultCulture));
                    culture = DefaultCulture;
                }
                else
                {
                    culture = Request.Cookies["lang"].Value;
                }
            }
            else
            {
                culture = toCulture;
            }

            if (Thread.CurrentThread.CurrentUICulture.Name != culture)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
            }
            if (Thread.CurrentThread.CurrentCulture.Name != culture)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            }
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Path.EndsWith(".aspx"))
            {
                string toCulture = null;
                if (Request.QueryString["lang"] != null)
                {
                    Response.Cookies.Set(CreateLangCookie(Request.QueryString["lang"]));
                    toCulture = Request.QueryString["lang"];
                }
                InitCulture(toCulture);
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}