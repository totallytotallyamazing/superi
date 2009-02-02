using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;

public partial class Controls_MainMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NavigationList list = new NavigationList(true, false);
        rItems.DataSource = list;
        rItems.DataBind();
    }


    protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Navigation navigation = (Navigation)e.Item.DataItem;
            HyperLink hlItem = (HyperLink)e.Item.FindControl("hlItem");

            hlItem.Text = navigation.Texts[WebSession.Language];
            if (WebSession.NavigationID != navigation.ID)
                hlItem.NavigateUrl = WebSession.BaseUrl + navigation.Path;
            else
                hlItem.CssClass = "currentMenuItem";
        }
    }
}
