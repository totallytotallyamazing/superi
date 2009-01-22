using System;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Controls_ExtraLeftMenu : System.Web.UI.UserControl
{
    private bool _hasItems = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        NavigationList navigationList = GetOnlyExcluded(new NavigationList(WebSession.NavigationID, true));
        Navigation navigation = new Navigation(WebSession.NavigationID);
        if (navigation.ParentID > 0)
        {
            Navigation pNavigation = new Navigation(navigation.ParentID);
            navigationList = pNavigation.ParentID > 0
                                 ? GetOnlyExcluded(new NavigationList(pNavigation.ParentID, true))
                                 : GetOnlyExcluded(new NavigationList(navigation.ParentID, true));
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

    void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Navigation navigation = (Navigation)e.Item.DataItem;
        if (navigation.ChildrenIncludedOnly.Count > 0)
        {
            Repeater repeater = (Repeater)e.Item.FindControl("rSubItems");
            repeater.DataSource = navigation.ChildrenIncludedOnly;
            repeater.DataBind();
        }
    }

    private NavigationList GetOnlyExcluded(NavigationList list)
    {
        NavigationList excludedOnly = new NavigationList(false);
        foreach (Navigation nav in list)
        {
            if (!nav.IncludeInMenu)
                excludedOnly.Add(nav);
        }
        return excludedOnly;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        Navigation navigation = new Navigation(WebSession.NavigationID);
        Visible = (navigation.Name.ToLower() == "menu" && _hasItems);
    }
}
