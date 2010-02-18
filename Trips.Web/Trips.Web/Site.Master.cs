using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace Trips.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {

        void InitLanguageLink()
        {
            string lang = (CultureInfo.CurrentUICulture.Name == "ru-RU") ? "en-US" : "ru-RU";

            if (Request.QueryString["lang"] == null)
            {
                string separator = (string.IsNullOrEmpty(Request.Url.Query)) ? "?" : "&";
                LanguageSwitch.NavigateUrl = "~/" + Request.Url.PathAndQuery + separator + "lang=" + lang;
            }
            else
            {
                string currentLang = CultureInfo.CurrentUICulture.Name;
                LanguageSwitch.NavigateUrl = "~/" + Request.Url.PathAndQuery.Replace(currentLang, lang);
            }
        }

        void InitControls()
        {
            InitLanguageLink();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitControls();
        }
    }
}
