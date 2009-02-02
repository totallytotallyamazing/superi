using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Administration_ArticlesPopUp : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        twScopes.Nodes.Clear();
        ArticleScopeList scopeList = new ArticleScopeList(true);

        foreach (ArticleScope scope in scopeList)
        {
            TreeNode node = new TreeNode(scope.Name, scope.ID.ToString());
            node.NavigateUrl = "javascript:returnDataToOpener(" + scope.ID + ")";
            twScopes.Nodes.Add(node);
            if (scope.SubItems.Count > 0)
                ProcessNode(scope, node);
        }
        twScopes.ExpandAll();
    }

    private void ProcessNode(ArticleScope ScopeItem, TreeNode Node)
    {
        foreach (ArticleScope scope in ScopeItem.SubItems)
        {
            TreeNode node = new TreeNode(scope.Name, scope.ID.ToString());
            Node.ChildNodes.Add(node);
            node.NavigateUrl = "javascript:returnDataToOpener(" + scope.ID + ")";
            if (scope.SubItems.Count > 0)
                ProcessNode(scope, node);
        }
    }
}
