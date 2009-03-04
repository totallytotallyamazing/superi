using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;

public partial class Administration_Pages : Page
{
	private int TextID
	{
		get
		{ 
			int result;
            if (string.IsNullOrEmpty(Request.Form[tbTextID.UniqueID]))
			{
				if (!string.IsNullOrEmpty(tbTextID.Text))
				{
                    if (int.TryParse(tbTextID.Text, out result))
						return result;
					else
						return int.MinValue;
				}
				else
					return int.MinValue;
			}
			else
			{
                if (int.TryParse(Request.Form[tbTextID.UniqueID], out result))
					return result;
				else
					return int.MinValue;
			}
		}
	}

    private int ArticleScopeID
    {
        get
        {
            int result;
            if (string.IsNullOrEmpty(Request.Form[tbArticleScopeID.UniqueID]))
            {
                if (!string.IsNullOrEmpty(tbArticleScopeID.Text))
                {
                    if (int.TryParse(tbArticleScopeID.Text, out result))
                        return result;
                    else
                        return int.MinValue;
                }
                else
                    return int.MinValue;
            }
            else
            {
                if (int.TryParse(Request.Form[tbArticleScopeID.UniqueID], out result))
                    return result;
                else
                    return int.MinValue;
            }
        }
    }

    private int ProductGroupID
    {
        get
        {
            int result;
            if (string.IsNullOrEmpty(Request.Form[tbProductGroupID.UniqueID]))
            {
                if (!string.IsNullOrEmpty(tbProductGroupID.Text))
                {
                    if (int.TryParse(tbProductGroupID.Text, out result))
                        return result;
                    else
                        return int.MinValue;
                }
                else
                    return int.MinValue;
            }
            else
            {
                if (int.TryParse(Request.Form[tbProductGroupID.UniqueID], out result))
                    return result;
                else
                    return int.MinValue;
            }
        }
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

	protected void Page_Load(object sender, EventArgs e)
	{
		btnDelete.Attributes.Add("onclick", "return confirm('Вы уверены?');");
		rbPage.Attributes.Add("onclick", "adjustContentDivsVisibility();");
		rbText.Attributes.Add("onclick", "adjustContentDivsVisibility();");
        rbArticles.Attributes.Add("onclick", "adjustContentDivsVisibility();");
        rbProductGroup.Attributes.Add("onclick", "adjustContentDivsVisibility()");
        rbSingleMenuPage.Attributes.Add("onclick", "adjustContentDivsVisibility()");
		btnAddNode.Attributes.Add("onclick", "return validateForm();");
		btnAddSub.Attributes.Add("onclick", "return validateForm();");
		btnSave.Attributes.Add("onclick", "return validateForm();");
	    ibPicture.Attributes.Add("onclick", "return removeImageConfirm()");
        ibPicture.Click += ibPicture_Click;

        reNames.LanguageList = new LanguageList(true);
        
	}

    void ibPicture_Click(object sender, ImageClickEventArgs e)
    {
        Navigation navigation = new Navigation(CurrentNavigationID);
        if(navigation.ID>0 && !string.IsNullOrEmpty(navigation.Picture))
            RemovePicture(navigation.Picture);
        navigation.Picture = "";
        navigation.Save();
    }

    private void SaveNavigation(Navigation Item)
    {
        if (cbSeparator.Checked)
            Item.IsSeparator = true;
        Item.Name = tbName.Text;
        Item.NameTextID = reNames.Values.Save();
        Item.Text = tbText.Text;
        Item.Description = tbDescription.Text;
        Item.Keywords = tbKeywords.Text;
        Item.IncludeInMenu = cbIncludeInMenu.Checked;
        Item.TextID = int.MinValue;
        Item.Page = "";
        Item.ArticleScopeID = int.MinValue;
        Item.ProductGroupID = int.MinValue;
        Item.SingleMenuPage = rbSingleMenuPage.Checked;
        if (rbText.Checked)
            Item.TextID = TextID;
        if (rbPage.Checked)
            Item.Page = tbPage.Text;
        if (rbArticles.Checked)
            Item.ArticleScopeID = ArticleScopeID;
        if (rbProductGroup.Checked)
            Item.ProductGroupID = ProductGroupID;
        SavePicture(Item);
        Item.Save();
    }

	protected void Page_PreRender(object sender, EventArgs e)
	{
		twPages.Nodes.Clear();
		NavigationList navigationList = new NavigationList(int.MinValue);

		foreach (Navigation navigation in navigationList)
		{
			TreeNode node = new TreeNode(navigation.Name, navigation.ID.ToString());
			twPages.Nodes.Add(node);
            if (navigation.ID == CurrentNavigationID)
				node.ImageUrl = "~/Administration/Images/arrow_on_white.gif";
			else
				node.ImageUrl = "~/Administration/Images/blank7.jpg";
			if (navigation.Children.Count > 0)
				ProcessNode(navigation, node);
		}
		twPages.ExpandAll();

	    LoadContent();
	}

	private void ProcessNode(Navigation NavItem, TreeNode Node)
	{

		foreach (Navigation navigation in NavItem.Children)
		{
			TreeNode node = new TreeNode(navigation.Name, navigation.ID.ToString());
            if (navigation.ID == CurrentNavigationID)
				node.ImageUrl = "~/Administration/Images/arrow_on_white.gif";
			else
				node.ImageUrl = "~/Administration/Images/blank7.jpg";
			Node.ChildNodes.Add(node);
			if (navigation.Children.Count > 0)
				ProcessNode(navigation, node);
		}
	}

	protected void btnAddNode_Click(object sender, EventArgs e)
	{
		Navigation navigation = new Navigation();
        SaveNavigation(navigation);
	}
	protected void btnAddSub_Click(object sender, EventArgs e)
	{
		Navigation navigation = new Navigation();
        navigation.ParentID = CurrentNavigationID;
        SaveNavigation(navigation);
	}

	protected void twPages_SelectedNodeChanged(object sender, EventArgs e)
	{
		tbTextID.Text = "";
		tbPage.Text = "";
	    tbProductGroupID.Text = "";
	    tbArticleScopeID.Text = "";
	    tbDescription.Text = "";
	    tbKeywords.Text = "";
        
		ihNodeID.Value = twPages.SelectedValue;

     //   LoadContent();
	}

    private void LoadContent()
    {
        Navigation navigation = new Navigation(CurrentNavigationID);
        if (navigation.ID > 0)
        {
            tbName.Text = navigation.Name;
            tbText.Text = navigation.Text;
            if (navigation.NameTextID > 0)
                reNames.TextID = navigation.NameTextID;
            rbArticles.Checked = false;
            rbPage.Checked = false;
            rbProductGroup.Checked = false;
            rbSingleMenuPage.Checked = false;
            rbText.Checked = false;
            if (navigation.TextID > 0)
            {
                rbText.Checked = true;
                tbTextID.Text = navigation.TextID.ToString();
            }
            else if (!string.IsNullOrEmpty(navigation.Page))
            {
                rbPage.Checked = true;
                tbPage.Text = navigation.Page;
            }
            else if (navigation.ArticleScopeID > 0)
            {
                rbArticles.Checked = true;
                tbArticleScopeID.Text = navigation.ArticleScopeID.ToString();
            }
            else if (navigation.ProductGroupID > 0)
            {
                rbProductGroup.Checked = true;
                tbProductGroupID.Text = navigation.ProductGroupID.ToString();
            }
            else
                rbSingleMenuPage.Checked = navigation.SingleMenuPage;
            cbSeparator.Checked = navigation.IsSeparator;
            tbDescription.Text = navigation.Description;
            tbKeywords.Text = navigation.Keywords;
            cbIncludeInMenu.Checked = navigation.IncludeInMenu;

            if (!string.IsNullOrEmpty(navigation.Picture))
                ibPicture.ImageUrl = WebSession.MenuImagesFolder + navigation.Picture;
            else
                  ibPicture.ImageUrl = "";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
	{
        Navigation navigation = new Navigation(CurrentNavigationID);
        RemovePicture(navigation.Picture);
		navigation.Remove();
	}



    private void SavePicture(Navigation Item)
    {
        string path = Server.MapPath(WebSession.MenuImagesFolder) + "\\";
        if (fuPicture.HasFile)
        {
            if (!string.IsNullOrEmpty(Item.Picture))
                RemovePicture(Item.Picture);
            string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
            fuPicture.SaveAs(path + Item.ID + extPicture);

            Item.Picture= Item.ID + extPicture;
        }
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath(WebSession.MenuImagesFolder) + PicturePath;
            File.Delete(path);
        }
    }

	protected void btnSave_Click(object sender, EventArgs e)
	{
        Navigation navigation = new Navigation(CurrentNavigationID);
        SaveNavigation(navigation);
	}

    protected void btnUp_Click(object sender, EventArgs e)
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
	protected void btnDown_Click(object sender, EventArgs e)
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
}
