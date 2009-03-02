using System;
using System.IO;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;
using System.Data;

public partial class Administration_Articles : System.Web.UI.Page
{
    #region Common page events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form[ihNodeID.UniqueID]))
        {
            ihNodeID.Value = Request.Form[ihNodeID.UniqueID];
            TextBox ScopeIDTextBox = (TextBox)fwNewArticle.FindControl("ScopeIDTextBox");
            string script = "document.getElementById('" + ScopeIDTextBox.ClientID + "').value = " + Request.Form[ihNodeID.UniqueID] + ";";
            Page.ClientScript.RegisterStartupScript(GetType(), "scr", script, true);
        }
        btnAddScope.Attributes.Add("onclick", "return checkScopeName();");
        btnAddRootScope.Attributes.Add("onclick", "return checkScopeName();");
        btnRemovePicture.Click += btnRemovePicture_Click;
        btnUpdate.Click += btnUpdate_Click;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        twScopes.Nodes.Clear();
        ArticleScopeList scopeList = new ArticleScopeList(true);
        int id;
        if (!int.TryParse(ihNodeID.Value, out id))
            id = 0;

        divGrids.Visible = (id > 0);
        if (id == 2)
        {
            ReorderList1.Visible = true;
            gwArticles.Visible = false;
        }
        else
        {
            ReorderList1.Visible = false;
            gwArticles.Visible = true;
        }
        foreach (ArticleScope scope in scopeList)
        {
            TreeNode node = new TreeNode(scope.Name, scope.ID.ToString());
            twScopes.Nodes.Add(node);
            if (scope.ID == id)
                node.ImageUrl = "~/Administration/Images/currentFolder.jpg";
                else
                node.ImageUrl = "~/Administration/Images/folder.jpg";
            if (scope.SubItems.Count > 0)
                ProcessNode(scope, node);
        }
        twScopes.ExpandAll();


        int articleID;
        if (!int.TryParse(hfArticleSelected.Value, out articleID))
        {
            phEdit.Visible = false;
            articleID = 0;
        }

        if (articleID > 0)
        {
            phEdit.Visible = true;
            ArticleScope scope = new ArticleScope(int.Parse(ihNodeID.Value));
            if (scope.Name == "новости")
                phLargePicture.Visible = phShort.Visible = false;
            else
                phLargePicture.Visible = phShort.Visible = true;
            Article article = new Article(articleID);
            reTitle.DefaultValue = article.Title;
            reTitle.TextID = article.TitleTextID;
            reShortDescription.DefaultValue = article.ShortDescription;
            reShortDescription.TextID = article.ShortDescriptionTextID;
            reDescription.DefaultValue = article.Description;
            reDescription.TextID = article.DescriptionTextID;

            btnRemovePicture.Visible = false;
            iPicture.Visible = false;
            if (!string.IsNullOrEmpty(article.TitlePicture))
            {
                btnRemovePicture.Visible = true;
                iPicture.Visible = true;
                iPicture.ImageUrl = WebSession.ArticlesImagesFolder + article.TitlePicture;
            }
            phEdit.Visible = true;
        }
        ReorderList1.DataBind();

    }
    #endregion

    #region Scopes related methods and events
    private void ProcessNode(ArticleScope ScopeItem, TreeNode Node)
    {
        int id;
        if (!int.TryParse(ihNodeID.Value, out id))
            id = 0;

        foreach (ArticleScope scope in ScopeItem.SubItems)
        {
            TreeNode node = new TreeNode(scope.Name, scope.ID.ToString());
            if (scope.ID == id)
                node.ImageUrl = "~/Administration/Images/currentFolder.jpg";
            else
                node.ImageUrl = "~/Administration/Images/folder.jpg";
            Node.ChildNodes.Add(node);
            if (scope.SubItems.Count > 0)
                ProcessNode(scope, node);
        }
    }

    protected void twScopes_SelectedNodeChanged(object sender, EventArgs e)
    {
        hfArticleSelected.Value = "";
        ihNodeID.Value = twScopes.SelectedValue;
        int id;
        if (!int.TryParse(ihNodeID.Value, out id))
            id = 0;
        TextBox scopeIDTextBox = (TextBox)fwNewArticle.FindControl("ScopeIDTextBox");
        string script = "document.getElementById('" + scopeIDTextBox.ClientID + "').value = " + id + ";";
        Page.ClientScript.RegisterStartupScript(GetType(), "scr", script, true);
        //scopeIDTextBox.Text = id.ToString();
    }

    protected void btnAddScope_Click(object sender, EventArgs e)
    {
        int id;
        if (!int.TryParse(ihNodeID.Value, out id))
            id = 0;

        ArticleScope scope = new ArticleScope();
        if (id > 0)
            scope.ParentID = id;
        scope.Name = tbScopeName.Text;
        scope.Save();
    }

    protected void btnRemoveScopes_Click(object sender, EventArgs e)
    {
        foreach (TreeNode node in twScopes.Nodes)
        {
            if (node.ChildNodes.Count > 0)
            {
                RemoveSubNodes(node);
            }
            if (node.Checked)
            {
                int id = int.Parse(node.Value);
                ArticleScope scope = new ArticleScope(id);
                scope.Remove();
            }
        }
    }

    private void RemoveSubNodes(TreeNode Node)
    {
        foreach (TreeNode node in Node.ChildNodes)
        {
            if (node.ChildNodes.Count > 0)
            {
                RemoveSubNodes(node);
            }
            if (node.Checked)
            {
                int id = int.Parse(node.Value);
                ArticleScope scope = new ArticleScope(id);
                scope.Remove();
            }
        }
    }

    protected void btnAddRootScope_Click(object sender, EventArgs e)
    {
        ArticleScope scope = new ArticleScope();
        scope.Name = tbScopeName.Text;
        scope.Save();
    }
    #endregion

    #region Articles related methods and events
    void btnUpdate_Click(object sender, EventArgs e)
    {
        int articleID = int.Parse(hfArticleSelected.Value);
        Article article;
        if (articleID > 0)
            article = new Article(articleID);
        else
            article = new Article();
        
        article.Title = reTitle.DefaultValue;
        reTitle.TextID = article.TitleTextID;
        article.TitleTextID = reTitle.Values.Save();
        article.ShortDescription = reShortDescription.DefaultValue;
        reShortDescription.TextID = article.ShortDescriptionTextID;
        article.ShortDescriptionTextID = reShortDescription.Values.Save();
        article.Description = reDescription.DefaultValue;
        reDescription.TextID = article.DescriptionTextID;
        article.DescriptionTextID = reDescription.Values.Save();

        string path = Server.MapPath(WebSession.ArticlesImagesFolder) + "\\";
        if (fuPicture.HasFile)
        {
            if (!string.IsNullOrEmpty(article.TitlePicture))
                RemovePicture(article.TitlePicture);
            string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
            fuPicture.SaveAs(path + article.ID + extPicture);

            article.TitlePicture = article.ID + extPicture;
        }
        if (fuLargePicture.HasFile)
        {
            if (!string.IsNullOrEmpty(article.Picture))
                RemovePicture(article.Picture);
            article.Picture = fuLargePicture.Save();
        }
        article.Save();
        phEdit.Visible = false;
        hfArticleSelected.Value = string.Empty;
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath(WebSession.ArticlesImagesFolder) + PicturePath;
            File.Delete(path);
        }
    }
    
    void btnRemovePicture_Click(object sender, EventArgs e)
    {
        int articleID = int.Parse(hfArticleSelected.Value);
        if (articleID > 0)
        {
            Article article = new Article(articleID);
            RemovePicture(article.TitlePicture);
            article.TitlePicture = string.Empty;
            article.Save();
        }
    }

    protected void gwArticles_SelectedIndexChanged(object sender, EventArgs e)
    {
        int articleID = int.Parse(gwArticles.SelectedRow.Cells[0].Text);
        hfArticleSelected.Value = articleID.ToString();
    }
    protected void ReorderList1_ItemDataBound(object sender, AjaxControlToolkit.ReorderListItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            DataRowView article = (DataRowView)e.Item.DataItem;
            DataRow row = article.Row;
            Literal lTitle = (Literal)e.Item.FindControl("lTitle");
            LinkButton lbEdit = (LinkButton)e.Item.FindControl("lbEdit");
            LinkButton lbDelete = (LinkButton)e.Item.FindControl("lbDelete");

            lbDelete.CommandArgument = row["ID"].ToString();
            lbEdit.CommandArgument = row["ID"].ToString();

            Resource res = new Resource(Convert.ToInt32(row["TitleTextID"]));
            if (res.Items.Count > 0)
                lTitle.Text = res["RU"];
            else
                lTitle.Text = row["Alias"].ToString();
        }
    }
    protected void ReorderList1_ItemCommand(object sender, AjaxControlToolkit.ReorderListCommandEventArgs e)
    {
        int articleId = int.Parse(e.CommandArgument.ToString());
        Article article = new Article(articleId);
        switch (e.CommandName)
        {
            case "DeleteArticle":
                RemovePicture(article.Picture);
                RemovePicture(article.TitlePicture);
                article.Remove();
                ReorderList1.DataBind();
                break;
            case "EditArticle":
                hfArticleSelected.Value = articleId.ToString();
                break;
        }
    }

    #endregion
}
