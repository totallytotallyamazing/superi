using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Texts : System.Web.UI.Page
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
            twContent.TextName = TextAlias;
        else if (TextID > 0)
            twContent.TextID = TextID;
    }
}
