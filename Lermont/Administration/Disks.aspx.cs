using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Features;
using Superi.Common;

public partial class Administration_Disks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["resourceControlCount"] = 0;
        lbAdd.Attributes.Add("onclick", "setAction('addEditDisk')");
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ReorderList1.DataBind();
    }

    private void RemovePicture(string FileName)
    {
        if (!string.IsNullOrEmpty(FileName))
        {
            string path = Server.MapPath(WebSession.ProductsImagesFolder) + "\\";
            File.Delete(path + FileName);
        }
    }

    protected void lbAdd_Click(object sender, EventArgs e)
    {
        baeMain.DiskId = int.MinValue;

    }

    protected void ReorderList1_ItemDataBound(object sender, AjaxControlToolkit.ReorderListItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            DataRowView disk = (DataRowView)e.Item.DataItem;
            DataRow row = disk.Row;
            Literal lTitle = (Literal)e.Item.FindControl("lTitle");
            LinkButton lbEdit = (LinkButton)e.Item.FindControl("lbEdit");
            LinkButton lbDelete = (LinkButton)e.Item.FindControl("lbDelete");
            LinkButton lbDescription = (LinkButton)e.Item.FindControl("lbDescription");

            lbDelete.CommandArgument = row["ID"].ToString();
            lbEdit.CommandArgument = row["ID"].ToString();
            lbDescription.CommandArgument = row["ID"].ToString();

            lbEdit.Attributes.Add("onclick", "setAction('addEditDisk')");
            lbDescription.Attributes.Add("onclick", "setAction('editDescription')");
            lTitle.Text = new Resource(Convert.ToInt32(row["NameTextID"]))["RU"];
            //book.Names["RU"];

            lbDelete.Attributes.Add("onclick", "return confirmDelete()");
        }
    }
    protected void ReorderList1_ItemCommand(object sender, AjaxControlToolkit.ReorderListCommandEventArgs e)
    {
        int diskId = int.Parse(e.CommandArgument.ToString());
        Disk disk = new Disk(diskId);
        switch (e.CommandName)
        {
            case "DeleteDisk":
                RemovePicture(disk.Picture);
                disk.Remove();
                ReorderList1.DataBind();
                break;
            case "EditDisk":
                baeMain.DiskId = disk.ID;
                break;
            case "EditDescription":
                ebdMain.DiskId = disk.ID;
                break;
        }
    }
}
