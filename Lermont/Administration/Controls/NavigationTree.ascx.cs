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
using Superi.Common;

public partial class Administration_Controls_NavigationTree : System.Web.UI.UserControl
{
    private int selectedIndex = int.MinValue;

    public int SelectedIndex
    {
        get { return selectedIndex; }
        set { selectedIndex = value; }
    }

    public string CssClass
    {
        get { return twPages.CssClass; }
        set { twPages.CssClass = value; }
    }

    private int CurrentNavigationID
    {
        get
        {
            int id;
            if (!int.TryParse(ihNodeID.Value, out id))
                id = int.MinValue;
            return id;
        }
    }

    public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);

    public event SelectedIndexChangedEventHandler SelectecIndexChanged;

    protected virtual void OnSelectecIndexChanged(EventArgs e)
    {
        if (SelectecIndexChanged != null)
            SelectecIndexChanged(this, e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ReloadNodes();
        if (CurrentNavigationID < 0)
        {
            ibProperties.ImageUrl = "~/Administration/Images/inactiveProperties.jpg";
            ibProperties.Enabled = false;
        }
        else
        {
            ibProperties.ImageUrl = "~/Administration/Images/properties.jpg";
            ibProperties.Enabled = true;
        }
    }

    public void ReloadNodes()
    {
        twPages.Nodes.Clear();
        TreeNode node = new TreeNode(WebSession.BaseUrl, int.MinValue.ToString());
        if(CurrentNavigationID == int.MinValue)
            node.ImageUrl = "~/Administration/Images/arrow_on_white.gif";
        twPages.Nodes.Add(node);
        ProcessNode(int.MinValue, node);
        twPages.ExpandAll();
    }

    private void ProcessNode(int ParentId, TreeNode Node)
    {
        NavigationList list = new NavigationList(ParentId);
        foreach (Navigation navigation in list)
        {
            TreeNode node = new TreeNode(navigation.Name, navigation.ID.ToString());
            if (navigation.ID == CurrentNavigationID)
                node.ImageUrl = "~/Administration/Images/arrow_on_white.gif";
            else
                node.ImageUrl = "~/Administration/Images/blank7.jpg";
            Node.ChildNodes.Add(node);
            if (navigation.Children.Count > 0)
                ProcessNode(navigation.ID, node);
        }
    }

    protected void twPages_SelectedNodeChanged(object sender, EventArgs e)
    {
        ihNodeID.Value = twPages.SelectedValue;
        SelectedIndex = CurrentNavigationID;
        aeNav.NavigationID = CurrentNavigationID;
        OnSelectecIndexChanged(new EventArgs());
    }


    protected void MoveNavigationUp(object sender, ImageClickEventArgs e)
    {
        Navigation navigation = new Navigation(CurrentNavigationID);
        NavigationList navigationList;
        if (navigation.ParentID > 0)
            navigationList = new NavigationList(navigation.ParentID);
        else
            navigationList = new NavigationList(true);
        Navigation navigationPrevious = null;
        foreach (Navigation navigationItem in navigationList)
        {
            if (navigationItem.ID == navigation.ID)
                break;
            navigationPrevious = navigationItem;
        }

        if (navigationPrevious != null)
        {
            navigation.SortOrder += navigationPrevious.SortOrder;
            navigationPrevious.SortOrder = navigation.SortOrder - navigationPrevious.SortOrder;
            navigation.SortOrder -= navigationPrevious.SortOrder;
            navigation.Save();
            navigationPrevious.Save();
        }
    }

    protected void MoveNavigationDown(object sender, ImageClickEventArgs e)
    {
        Navigation navigation = new Navigation(CurrentNavigationID);
        NavigationList navigationList;
        if (navigation.ParentID > 0)
            navigationList = new NavigationList(navigation.ParentID);
        else
            navigationList = new NavigationList(true);
        Navigation navigationNext = null;

        bool next = false;
        foreach (Navigation navigationItem in navigationList)
        {
            if (next)
            {
                navigationNext = navigationItem;
                break;
            }
            if (navigationItem.ID == navigation.ID)
                next = true;
        }

        if (navigationNext != null)
        {
            navigation.SortOrder += navigationNext.SortOrder;
            navigationNext.SortOrder = navigation.SortOrder - navigationNext.SortOrder;
            navigation.SortOrder -= navigationNext.SortOrder;
            navigation.Save();
            navigationNext.Save();
        }
    }


    protected void MoveToParent(object sender, ImageClickEventArgs e)
    {

    }

    protected void MakeChildOfPrevious(object sender, ImageClickEventArgs e)
    {

    }

    protected void InitNavigationPopUp(object sender, ImageClickEventArgs e)
    {
        aeNav.NavigationID = CurrentNavigationID;
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "showProps", "showNavigationPropterties()", true);
    }
}
