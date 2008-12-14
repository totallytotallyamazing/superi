using System;
using Superi.Features;
//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using Superi.Features;

public partial class Texts : System.Web.UI.Page
{
    private int TextID
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                return int.Parse(Request.QueryString["id"]);
            else
                return int.MinValue;
        }
    }

    private string TextAlias
    {
        get { return Request.QueryString["name"]; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Text text;
        if (!string.IsNullOrEmpty(TextAlias))
        {
            twText.TextName = TextAlias;
            text = new Text(TextAlias);
        }
        else if (TextID > 0)
        {
            twText.TextID = TextID;
            text = new Text(TextID);
        }
        //Page.Title = text.Name;
    }
}
