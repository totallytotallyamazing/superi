using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;

public partial class tst : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptInclude("master", WebSession.BaseUrl + "js/master.js");
        Page.ClientScript.RegisterClientScriptInclude("jquery", WebSession.BaseUrl + "js/jquery.js");
        Page.ClientScript.RegisterClientScriptInclude("pngFix", WebSession.BaseUrl + "js/jquery.pngFix.js");
        Page.ClientScript.RegisterClientScriptInclude("galleria", WebSession.BaseUrl + "js/jquery.galleria.js");
        Page.ClientScript.RegisterClientScriptInclude("fancybox", WebSession.BaseUrl + "js/jquery.fancybox.js");


        

    }
}
