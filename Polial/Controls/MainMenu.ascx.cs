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

public partial class Controls_MainMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NavigationList list = new NavigationList(int.MinValue, false);
        rItems.DataSource = list;
        rItems.DataBind();
    }
}
