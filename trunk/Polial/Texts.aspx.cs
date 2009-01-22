using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Features;

public partial class Texts : Page
{
    private int TextID
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                return int.Parse(Request.QueryString["id"]);
            return int.MinValue;
        }
    }

    private string TextAlias
    {
        get { return Request.QueryString["name"]; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextAlias))
            twText.TextName = TextAlias;
        else if (TextID > 0)
            twText.TextID = TextID;
        if(WebSession.NavigationHolder!=null && WebSession.NavigationHolder.Controls.Count>0)
        {
            if(WebSession.NavigationHolder.Controls[0].GetType().Name!="Controls_Navigation")
            {
                WebSession.NavigationHolder.Controls.Clear();
                WebSession.NavigationHolder.Controls.Add(LoadControl("~/Controls/Navigation.ascx"));
            }
        }

    }
}
