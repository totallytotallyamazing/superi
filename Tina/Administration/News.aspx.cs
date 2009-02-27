using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Superi.CustomControls;
using System.Globalization;

public partial class Administration_News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pEdit.Visible = false;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        pEdit.Visible = true;
        int newsItemId = Convert.ToInt32(GridView1.SelectedDataKey.Value);
        NewsDataContext context = new NewsDataContext();
        NewsItem item = context.NewsItems.SingleOrDefault(ni => ni.ID == newsItemId);
        fcText.Value = item.ShortText;
        fcDescription.Value = item.Text;
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath("~/Images/News/") + PicturePath;
            File.Delete(path);
        }
    }



    protected void bSave_Click(object sender, EventArgs e)
    {
        int newsItemId = Convert.ToInt32(GridView1.SelectedDataKey.Value);
        NewsDataContext context = new NewsDataContext();
        NewsItem item = context.NewsItems.SingleOrDefault(ni => ni.ID == newsItemId);
        item.ShortText = fcText.Value;
        item.Text = fcDescription.Value;
        context.SubmitChanges();
        pEdit.Visible = false;
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        FolderUpload fuPicture = (FolderUpload)GridView1.Rows[e.RowIndex].FindControl("fuPicture");
        if (fuPicture != null && fuPicture.HasFile)
        {
            int newsItemId = Convert.ToInt32(e.Keys["ID"]);
            NewsDataContext context = new NewsDataContext();
            NewsItem item = context.NewsItems.SingleOrDefault(ni => ni.ID == newsItemId);
            if (!string.IsNullOrEmpty(item.Picture))
                RemovePicture(item.Picture);
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pEdit.Visible = false;
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int newsItemId = Convert.ToInt32(e.Keys["ID"]);
        NewsDataContext context = new NewsDataContext();
        NewsItem item = context.NewsItems.SingleOrDefault(ni => ni.ID == newsItemId);
        if (!string.IsNullOrEmpty(item.Picture))
            RemovePicture(item.Picture);
    }

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        NewsItem item = new NewsItem();
        CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");

        item.Date = DateTime.Parse(tbDate.Text, culture);
        item.Title = TitleTextBox.Text;
        item.Archive = ArchiveCheckBox.Checked;
        item.Award = false;
        item.Picture = fuPicture.UploadedFile;

        NewsDataContext context = new NewsDataContext();
        context.NewsItems.InsertOnSubmit(item);
        context.SubmitChanges();
    }
}
