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
                id = 0;
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
    }

    public void ReloadNodes()
    {
        twPages.Nodes.Clear();
        TreeNode node = new TreeNode(WebSession.BaseUrl, int.MinValue.ToString());
        //NavigationList navigationList = new NavigationList(int.MinValue);
        twPages.Nodes.Add(node);
        ProcessNode(int.MinValue, node);
        //foreach (Navigation navigation in navigationList)
        //{
        //    TreeNode node = new TreeNode(navigation.Name, navigation.ID.ToString());
        //    twPages.Nodes.Add(node);
        //    if (navigation.ID == CurrentNavigationID)
        //        node.ImageUrl = "~/Administration/Images/arrow_on_white.gif";
        //    else
        //        node.ImageUrl = "~/Administration/Images/blank7.jpg";
        //    if (navigation.Children.Count > 0)
        //        ProcessNode(navigation, node);
        //}
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

        OnSelectecIndexChanged(new EventArgs());
    }
}
