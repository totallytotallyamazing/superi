using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using Superi.Shop;

public partial class Administration_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form[hfGroupID.UniqueID]))
        {
            hfGroupID.Value = Request.Form[hfGroupID.UniqueID];
            TextBox GroupIDTextBox = (TextBox)fwProduct.FindControl("GroupIDTextBox");
            string script = "document.getElementById('" + GroupIDTextBox.ClientID + "').value = " + Request.Form[hfGroupID.UniqueID] + ";";
            Page.ClientScript.RegisterStartupScript(GetType(), "scr", script, true);
        }
        btnAddGroup.Attributes.Add("onclick", "return checkGroupName();");
        btnAddRootGroup.Attributes.Add("onclick", "return checkGroupName();");
        btnRemovePicture.Click += btnRemovePicture_Click;
        btnUpdate.Click += btnUpdate_Click;
        twGroups.SelectedNodeChanged += twGroups_SelectedNodeChanged;
        gwProducts.SelectedIndexChanged += gwProducts_SelectedIndexChanged;
    }

    void gwProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        int productID = int.Parse(gwProducts.SelectedRow.Cells[0].Text);
        hfProductSelected.Value = productID.ToString();
    }

    void twGroups_SelectedNodeChanged(object sender, EventArgs e)
    {
        hfProductSelected.Value = "";
        hfGroupID.Value = twGroups.SelectedValue;
        int id;
        if (!int.TryParse(hfGroupID.Value, out id))
            id = 0;
        TextBox GroupIDTextBox = (TextBox)fwProduct.FindControl("GroupIDTextBox");
        string script = "document.getElementById('" + GroupIDTextBox.ClientID + "').value = " + id + ";";
        Page.ClientScript.RegisterStartupScript(GetType(), "scr", script, true);
    }

    void btnUpdate_Click(object sender, EventArgs e)
    {
        if (fuPicture.HasFile)
        {
            int productID = int.Parse(hfProductSelected.Value);
            Product product = productID > 0 ? new Product(productID) : new Product();

            product.NameTextID = reName.Values.Save();

            string path = Server.MapPath(DefaultValues.ProductsImagesFolder) + "\\";

            if (!string.IsNullOrEmpty(product.Picture))
                RemovePicture(product.Picture);
            string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
            fuPicture.SaveAs(path + product.ID + extPicture);

            product.Picture = product.ID + extPicture;
            product.Save();
        }
        else
        {
            Response.Write("<script type=\"text/javascript\">alert('Ќевозможно сохранить продукт без изображени€');</script>");
        }


    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath(DefaultValues.ProductsImagesFolder) + PicturePath;
            File.Delete(path);
        }
    }

    void btnRemovePicture_Click(object sender, EventArgs e)
    {
        int articleID = int.Parse(hfProductSelected.Value);
        if (articleID > 0)
        {
            Product product = new Product(articleID);
            RemovePicture(product.Picture);
            product.Picture = string.Empty;
            product.Save();
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        twGroups.Nodes.Clear();
        ProductGroupList groupList = new ProductGroupList(true);
        int id;
        if (!int.TryParse(hfGroupID.Value, out id))
            id = 0;

        divGrids.Visible = (id > 0);

        foreach (ProductGroup scope in groupList)
        {
            TreeNode node = new TreeNode(scope.Name, scope.ID.ToString());
            twGroups.Nodes.Add(node);
            if (scope.ID == id)
                node.ImageUrl = "~/Administration/Images/currentFolder.jpg";
            else
                node.ImageUrl = "~/Administration/Images/folder.jpg";
            if (scope.SubGroups.Count > 0)
                ProcessNode(scope, node);
        }
        twGroups.ExpandAll();

        int groupID;
        if (!int.TryParse(hfProductSelected.Value, out groupID))
        {
            phEdit.Visible = false;
            groupID = 0;
        }

        if (groupID > 0)
        {
            phEdit.Visible = true;
            Product product = new Product(groupID);
            reName.TextID = product.NameTextID;

            btnRemovePicture.Visible = false;
            iPicture.Visible = false;
            if (!string.IsNullOrEmpty(product.Picture))
            {
                btnRemovePicture.Visible = true;
                iPicture.Visible = true;
                iPicture.ImageUrl = DefaultValues.ProductsImagesFolder + product.Picture;
            }
            phEdit.Visible = true;
        }


    }

    private void ProcessNode(ProductGroup GroupItem, TreeNode Node)
    {
        int id;
        if (!int.TryParse(hfGroupID.Value, out id))
            id = 0;

        foreach (ProductGroup group in GroupItem.SubGroups)
        {
            TreeNode node = new TreeNode(group.Name, group.ID.ToString());
            if (group.ID == id)
                node.ImageUrl = "~/Administration/Images/currentFolder.jpg";
            else
                node.ImageUrl = "~/Administration/Images/folder.jpg";
            Node.ChildNodes.Add(node);
            if (group.SubGroups.Count > 0)
                ProcessNode(group, node);
        }
    }

    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        int id;
        if (!int.TryParse(hfGroupID.Value, out id))
            id = 0;

        ProductGroup group = new ProductGroup();
        if (id > 0)
            group.ParentID = id;
        group.Name = tbGroupName.Text;
        group.Save();
    }
    protected void btnAddRootGroup_Click(object sender, EventArgs e)
    {
        ProductGroup group = new ProductGroup();
        group.Name = tbGroupName.Text;
        group.Save();
    }
    protected void btnRemoveScopes_Click(object sender, EventArgs e)
    {
        foreach (TreeNode node in twGroups.Nodes)
        {
            if (node.ChildNodes.Count > 0)
            {
                RemoveSubNodes(node);
            }
            if (node.Checked)
            {
                int id = int.Parse(node.Value);
                //ProductGroup group = new ProductGroup(id);
                //group.Remove();
                RemoveProductGroupByHand(id);
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
                //ProductGroup scope = new ProductGroup(id);
                //scope.Remove();
                RemoveProductGroupByHand(id);
            }
        }
    }

    private void RemoveProductGroupByHand(int id)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AppData"].ToString());
        using (conn)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ProductGroups where id=" + id;
            cmd.ExecuteNonQuery();
        }
    }
}
