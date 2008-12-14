using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Controls_SubMenu : UserControl
{
    private bool _hasItems = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebSession.NavigationID > 0)
        {
            NavigationList navigationList = new NavigationList(WebSession.NavigationID, false);
            Navigation navigation = new Navigation(WebSession.NavigationID);
            if (navigation.ParentID > 0)
            {
                Navigation pNavigation = new Navigation(navigation.ParentID);
                navigationList = pNavigation.ParentID > 0
                                     ? new NavigationList(pNavigation.ParentID, false)
                                     : new NavigationList(navigation.ParentID, false);
            }

            if (navigationList.Count > 0)
            {
                rItems.DataSource = navigationList;
                rItems.ItemDataBound += rItems_ItemDataBound;
                rItems.DataBind();
                _hasItems = true;
            }
            else
                _hasItems = false;
        }
    }

    void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Navigation navigation = (Navigation) e.Item.DataItem;
        if(navigation.ChildrenIncludedOnly.Count>0)
        {
            Repeater repeater = (Repeater) e.Item.FindControl("rSubItems");
            repeater.DataSource = navigation.ChildrenIncludedOnly;
            repeater.DataBind();
        }
    }

     protected void Page_PreRender(object sender, EventArgs e)
     {
         Visible = WebSession.DisplaySubMenu && _hasItems;
     }
}
