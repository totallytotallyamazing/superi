using System;
using Superi.Features;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;



public partial class Controls_SubMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NavigationList list = null;
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("objects") > -1)
        {
            rItems.DataSource = Navigations.GetGalleryBinded();
            rItems.DataBind();
        }
        else
        {
            list = new NavigationList(WebSession.NavigationID, false);
            if (list.Count > 0)
            {
                rItems.DataSource = list;
                rItems.DataBind();
            }
            else
            {
                Navigation navigation = new Navigation(WebSession.NavigationID);
                if (navigation.ParentID > 0)
                {
                    list = new NavigationList(navigation.ParentID, false);
                    if (list.Count > 0)
                    {
                        rItems.DataSource = list;
                        rItems.DataBind();
                    }
                    else
                        Visible = false;
                }
                else
                    Visible = false;
            }
        }

    }
    protected void rItems_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        Navigation navigation = (Navigation)e.Item.DataItem;
        HyperLink hlSubMenuItem = (HyperLink)e.Item.FindControl("hlSubMenuItem");
        HtmlGenericControl liSubMenuItem = (HtmlGenericControl)e.Item.FindControl("liSubMenuItem");

        hlSubMenuItem.Text = navigation.Texts[WebSession.Language];                                                                                                                     
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("objects") < 0)                                                                                               
        {
            hlSubMenuItem.NavigateUrl = WebSession.BaseUrl + navigation.Path;
            liSubMenuItem.Attributes.Add("onclick", "location.href = '" + WebSession.BaseUrl + navigation.Path + "'");
        }
        else
        {
            hlSubMenuItem.NavigateUrl = WebSession.BaseUrl + "objects/" + navigation.Name;
            liSubMenuItem.Attributes.Add("onclick", "location.href = '" + WebSession.BaseUrl + "objects/" + navigation.Name + "'");
        }
    }
}
