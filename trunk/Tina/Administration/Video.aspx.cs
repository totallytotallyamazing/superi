using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.CustomControls;
using VideoContext;
using Videos;

public partial class Administration_Video : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "InsertItem")
        {
            TextBox NameTextBox = (TextBox)e.Item.FindControl("NameTextBox");
            FolderUpload fuImage = (FolderUpload)e.Item.FindControl("fuImage");
            FolderUpload fuSource = (FolderUpload)e.Item.FindControl("fuSource");
            DropDownList ddlAlbum = (DropDownList)e.Item.FindControl("ddlAlbum");

            Video video = new Video();
            video.Name = NameTextBox.Text;
            video.Image = fuImage.UploadedFile;
            video.Source = fuSource.UploadedFile;
            video.AlbumID = int.Parse(ddlAlbum.SelectedValue);
            VideoDataContext context = new VideoDataContext();
            context.Videos.InsertOnSubmit(video);
            context.SubmitChanges();
        }
        //if (e.CommandName == "Edit")
        //{
        //    DropDownList ddlAlbum = (DropDownList)e.Item.FindControl("ddlAlbum");
        //    int videoId = Convert.ToInt32(e.CommandArgument);
        //    VideoDataContext context = new VideoDataContext();
        //    Video video = context.Videos.SingleOrDefault(v => v.ID == videoId);
        //    ddlAlbum.SelectedValue = video.AlbumID.ToString();
        //}
        if (e.CommandName == "UpdateItem")
        {
            DropDownList ddlAlbum = (DropDownList)e.Item.FindControl("ddlAlbum");
            TextBox NameTextBox = (TextBox)e.Item.FindControl("NameTextBox");
            int videoId = Convert.ToInt32(e.CommandArgument);
            VideoDataContext context = new VideoDataContext();
            Video video = context.Videos.SingleOrDefault(v => v.ID == videoId);
            video.Name = NameTextBox.Text;
            video.AlbumID = Convert.ToInt32(ddlAlbum.SelectedValue);
            context.SubmitChanges();
            lwVideos.EditIndex = -1;
        }
    }
}
