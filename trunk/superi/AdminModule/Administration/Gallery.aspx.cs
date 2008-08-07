using System;
using System.IO;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.CustomControls;

public partial class Administration_Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 12; i++)
        {
            //  GalleryUpload galleryUpload = (GalleryUpload)
            phUpload.Controls.Add(LoadControl("~/administration/controls/galleryupload.ascx"));
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
            //if(e.Row.RowState == DataControlRowState.Normal || e.Row.RowState==DataControlRowState.Alternate || e.Row.RowState==DataControlRowState.Selected)
            //{
            //    GalleryItem item = (GalleryItem) e.Row.DataItem;
            //    Image iPreview = (Image) e.Row.FindControl("iPreview");
            //    iPreview.ImageUrl = DefaultValues.GalleryImagesFolder + item.Preview;
            //}
            //if(e.Row.RowState==DataControlRowState.Edit || e.Row.RowState==DataControlRowState.Insert)
            {
                GalleryItem item = (GalleryItem)e.Row.DataItem;
                Image iPreview = (Image)e.Row.FindControl("iPreview");
                iPreview.ImageUrl = WebSession.GalleryImagesFolder + item.Preview;
            }
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
        foreach (GalleryUpload galleryUpload in phUpload.Controls)
        {
            if(galleryUpload.Picture.HasFile && galleryUpload.Preview.HasFile)
            {
                GalleryItem item = new GalleryItem();
                item.Save();
                string path = Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
                string extPicture = galleryUpload.Picture.FileName.Substring(galleryUpload.Picture.FileName.LastIndexOf("."));
                galleryUpload.Picture.SaveAs(path + item.ID + extPicture);

                item.Picture = item.ID + extPicture;

                string extPreview = galleryUpload.Preview.FileName.Substring(galleryUpload.Preview.FileName.LastIndexOf("."));
                galleryUpload.Preview.SaveAs(path + "pr_" + item.ID + extPreview);

                item.Preview = "pr_" + item.ID + extPreview;
                item.Save();
            }
        }
    }
    protected void gwGallery_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void gwGallery_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int itemId = int.Parse(e.Keys["ID"].ToString());
        GalleryItem item = new GalleryItem(itemId);
        RemovePicture(item.Picture);
        RemovePicture(item.Preview);
    }
}
