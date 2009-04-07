using System;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;

public partial class Controls_MainMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NavigationList navigationList = new NavigationList(int.MinValue, false);
        rItems.DataSource = navigationList;
        rItems.DataBind();
    }

    protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Navigation navigation = (Navigation) e.Item.DataItem;
            HyperLink hlItem = (HyperLink) e.Item.FindControl("hlItem");
            Literal lItem = (Literal) e.Item.FindControl("lItem");
            Panel pItem = (Panel) e.Item.FindControl("pItem");
            bool current = (navigation.ID == WebSession.NavigationID && Request.Url.AbsoluteUri.ToLower().IndexOf("default.aspx") == -1);
            if(!current)
            {
                lItem.Visible = false;
                hlItem.Visible = true;
                hlItem.Text = navigation.Texts[WebSession.Language];
                pItem.Attributes.Add("onmouseover", "this.style.backgroundImage='url(\"images/menuHover.jpg\")'");
                pItem.Attributes.Add("onmouseout", "this.style.backgroundImage=''");
                hlItem.NavigateUrl = WebSession.BaseUrl + navigation.Path;
            }
            else
            {
                lItem.Visible = false;
                hlItem.Visible = true;
                hlItem.Text = navigation.Texts[WebSession.Language];
                pItem.CssClass = "mainMenuItemActive";
            }
        }
    }
}
