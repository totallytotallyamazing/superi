using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicContext;
using System.IO;

public partial class Administration_Gallery : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlAlbums.Items.Clear();
            Musics.MusicDataContext context = new Musics.MusicDataContext();
            List<Album> albums = context.Albums.Select(al => al).ToList();
            ddlAlbums.Items.Add(new ListItem("Имидж", "0"));
            ddlAlbums.Items.Add(new ListItem("Галерея", "-1"));
            foreach (var item in albums)
                ddlAlbums.Items.Add(new ListItem(item.Name, item.ID.ToString()));
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ReorderList1.DataBind();
    }


    protected void InsertButton_Click(object sender, EventArgs e)
    {
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        GalleryContext.Gallery gallery = new GalleryContext.Gallery();
        gallery.AlbumID = int.Parse(Request.Form[ddlAlbums.UniqueID]);
        gallery.Picture = fuPicture.UploadedFile;
        gallery.Thumbnail = fuPreview.UploadedFile;
        //gallery.Title = TitleTextBox.Text;
        context.Galleries.InsertOnSubmit(gallery);
        context.SubmitChanges();
        gallery.SortOrder = gallery.ID;
        context.SubmitChanges();
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath("~/Images/Gallery/") + PicturePath;
            File.Delete(path);
        }
    }


    protected void ReorderList1_ItemCommand(object sender, AjaxControlToolkit.ReorderListCommandEventArgs e)
    {
        int galleryId = Convert.ToInt32(e.CommandArgument);
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        GalleryContext.Gallery gallery = context.Galleries.SingleOrDefault(gl => gl.ID == galleryId);
        RemovePicture(gallery.Picture);
        RemovePicture(gallery.Thumbnail);
        context.Galleries.DeleteOnSubmit(gallery);
        context.SubmitChanges();
    }
}