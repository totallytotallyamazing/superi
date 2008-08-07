using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Shop;

public partial class Administration_ProductGroupsPopUp : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        twGroups.Nodes.Clear();
        ProductGroupList groupList = new ProductGroupList(true);

        foreach (ProductGroup group in groupList)
        {
            TreeNode node = new TreeNode(group.Name, group.ID.ToString());
            node.NavigateUrl = "javascript:returnDataToOpener(" + group.ID + ")";
            twGroups.Nodes.Add(node);
            if (group.SubGroups.Count > 0)
                ProcessNode(group, node);
        }
        twGroups.ExpandAll();
    }

    private void ProcessNode(ProductGroup ScopeItem, TreeNode Node)
    {
        foreach (ProductGroup group in ScopeItem.SubGroups)
        {
            TreeNode node = new TreeNode(group.Name, group.ID.ToString());
            Node.ChildNodes.Add(node);
            node.NavigateUrl = "javascript:returnDataToOpener(" + group.ID + ")";
            if (group.SubGroups.Count > 0)
                ProcessNode(group, node);
        }
    }

}
