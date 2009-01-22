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

public partial class Controls_Navigation : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Navigation startNavigation = new Navigation(WebSession.NavigationID);
        char[] sep = { '/' };
        string[] preParts = startNavigation.Path.Split(sep);
        ArrayList parts = new ArrayList();
        foreach (string s in preParts)
        {
            if (!string.IsNullOrEmpty(s))
                parts.Add(s);
        }
        int parentId = int.MinValue;
        NavigationList navigationList = new NavigationList(false);
        foreach (string s in parts)
        {
            Navigation navigation = new Navigation(s, parentId);
            if (navigation.ID > 0)
            {
                parentId = navigation.ID;
                navigationList.Add(navigation);
            }
        }
        if (navigationList.Count > 1)
        {
            rItems.DataSource = navigationList;
            rItems.DataBind();
        }
    }

    protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Navigation navigation = (Navigation) e.Item.DataItem;
            HyperLink hlNavigationItem = (HyperLink) e.Item.FindControl("hlNavigationItem");
            hlNavigationItem.Text = navigation.Texts[WebSession.Language];
            hlNavigationItem.NavigateUrl = WebSession.BaseUrl + navigation.Path;
        }
    }
}
