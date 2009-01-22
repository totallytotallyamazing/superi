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

public partial class Administration_Controls_NavigationTree : System.Web.UI.UserControl
{
    private int selectedIndex = int.MinValue;

    public int SelectedIndex
    {
        get { return selectedIndex; }
        set { selectedIndex = value; }
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
        NavigationList navigationList = new NavigationList(int.MinValue);

        foreach (Navigation navigation in navigationList)
        {
            TreeNode node = new TreeNode(navigation.Texts["RU"], navigation.ID.ToString());
            node.ToolTip = node.ImageToolTip = navigation.Texts["RU"];
            twPages.Nodes.Add(node);
            if (navigation.ID == CurrentNavigationID)
                node.ImageUrl = "~/Administration/Images/arrow_on_white.gif";
            else
                node.ImageUrl = "~/Administration/Images/blank7.jpg";
            if (navigation.Children.Count > 0)
                ProcessNode(navigation, node);
        }
        twPages.ExpandAll();
    }

    private void ProcessNode(Navigation NavItem, TreeNode Node)
    {
        foreach (Navigation navigation in NavItem.Children)
        {
            TreeNode node = new TreeNode(navigation.Texts["RU"], navigation.ID.ToString());
            node.ToolTip = node.ImageToolTip = navigation.Texts["RU"];
            if (navigation.ID == CurrentNavigationID)
                node.ImageUrl = "~/Administration/Images/arrow_on_white.gif";
            else
                node.ImageUrl = "~/Administration/Images/blank7.jpg";
            Node.ChildNodes.Add(node);
            if (navigation.Children.Count > 0)
                ProcessNode(navigation, node);
        }
    }

    protected void twPages_SelectedNodeChanged(object sender, EventArgs e)
    {
        ihNodeID.Value = twPages.SelectedValue;
        SelectedIndex = CurrentNavigationID;

        OnSelectecIndexChanged(new EventArgs());
    }
}
