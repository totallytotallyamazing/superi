using System;
using System.IO;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Administration_Gallery : System.Web.UI.Page
{
    private int SelectedGallery
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.Form[ddlGalleries.UniqueID]))
                return int.Parse(Request.Form[ddlGalleries.UniqueID]);
            return int.MinValue;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            PublishGalleryList();
        for (int i = 0; i < 12; i++)
        {
            //  GalleryUpload galleryUpload = (GalleryUpload)
            FileUpload fuPicture = new FileUpload();
            phUpload.Controls.Add(fuPicture);
        }

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        gwGallery.DataBind();
    }

    protected void gwGallery_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            GalleryItem item = (GalleryItem)e.Row.DataItem;
            Image iPreview = (Image)e.Row.FindControl("iPreview");
            iPreview.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?w=305&h=200&file=" + item.Picture;
        }
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath(WebSession.GalleryImagesFolder) + PicturePath;
            File.Delete(path);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        foreach (FileUpload fileUpload in phUpload.Controls)
        {
            if (fileUpload.HasFile)
            {
                GalleryItem item = new GalleryItem();
                item.GalleryID = SelectedGallery;
                item.Save();
                string path = Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
                string extPicture = fileUpload.FileName.Substring(fileUpload.FileName.LastIndexOf("."));
                fileUpload.SaveAs(path + item.ID + extPicture);

                item.Picture = item.ID + extPicture;

                item.Save();
            }
        }
    }
    protected void gwGallery_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int itemId = int.Parse(e.Keys["ID"].ToString());
        GalleryItem item = new GalleryItem(itemId);
        RemovePicture(item.Picture);
    }

    private void PublishGalleryList()
    {
        GalleryList list = Galleries.Get();
        foreach (Gallery gallery in list)
        {
            ddlGalleries.Items.Add(new ListItem(gallery.Titles["RU"], gallery.ID.ToString()));
        }
    }
}
