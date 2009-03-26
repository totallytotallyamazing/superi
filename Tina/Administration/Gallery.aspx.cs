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
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlAlbums.Items.Clear();
        Musics.MusicDataContext context = new Musics.MusicDataContext();
        List<Album> albums = context.Albums.Select(al => al).ToList();
        ddlAlbums.Items.Add(new ListItem("Имидж", "0"));
        ddlAlbums.Items.Add(new ListItem("Галерея", "-1"));
        foreach (var item in albums)
            ddlAlbums.Items.Add(new ListItem(item.Name, item.ID.ToString()));
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        gvGallery.DataBind();
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowState == DataControlRowState.Edit || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)))
        {
            DropDownList ddlAlbums = (DropDownList)e.Row.FindControl("ddlAlbums");
            if (ddlAlbums != null)
            {
                Musics.MusicDataContext context = new Musics.MusicDataContext();
                List<Album> albums = context.Albums.Select(al => al).ToList();
                ddlAlbums.Items.Add(new ListItem("Имидж", "0"));
                ddlAlbums.Items.Add(new ListItem("Галерея", "-1"));
                foreach (var item in albums)
                    ddlAlbums.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
        }
    }

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        GalleryContext.Gallery gallery = new GalleryContext.Gallery();
        gallery.AlbumID = int.Parse(Request.Form[ddlAlbums.UniqueID]);
        gallery.Picture = fuPicture.UploadedFile;
        gallery.Thumbnail = fuPreview.UploadedFile;
        gallery.Title = TitleTextBox.Text;
        context.Galleries.InsertOnSubmit(gallery);
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

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int galleryId = Convert.ToInt32(e.Keys["ID"]);
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        GalleryContext.Gallery gallery = context.Galleries.SingleOrDefault(gl => gl.ID == galleryId);
        RemovePicture(gallery.Picture);
        RemovePicture(gallery.Thumbnail);
    }
}