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
using Superi.CustomControls;
using Superi.Features;

public partial class Administration_Galleries : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }

    protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName == "InsertItem")
        {
            FileUpload fuPicture = (FileUpload) ((LinkButton) e.CommandSource).NamingContainer.FindControl("fuPicture");
            //TextBox tbTitle = (TextBox)((LinkButton)e.CommandSource).NamingContainer.FindControl("tbTitle");
            ResourceEditor reTitles = (ResourceEditor)((LinkButton)e.CommandSource).NamingContainer.FindControl("reTitles");
            if(reTitles.Values.Items.Count>0 || fuPicture.HasFile)
            {
                Gallery gallery = new Gallery();
                gallery.TitleTextId = reTitles.Values.Save();
                gallery.Save();
                if (fuPicture.HasFile)
                {
                    string path = Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
                    string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
                    fuPicture.SaveAs(path + "g" + gallery.ID + extPicture);
                    gallery.Picture = "g" + gallery.ID + extPicture;
                    gallery.Save();
                }
            }
        }
    }

    protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
    {

    }

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        int itemId = int.Parse(e.Keys["ID"].ToString());
        FileUpload fuPicture = (FileUpload) GridView1.Rows[GridView1.EditIndex].FindControl("fuPicture");
        ResourceEditor reTitles = (ResourceEditor)GridView1.Rows[GridView1.EditIndex].FindControl("reTitle");
        Gallery item = new Gallery(itemId);
        item.TitleTextId = reTitles.Values.Save();
        if(fuPicture.HasFile)
        {
            
            if(!string.IsNullOrEmpty(item.Picture))
                RemovePicture(item.Picture);
            string path = Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
            string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
            fuPicture.SaveAs(path + "g" + item.ID + extPicture);
            item.Picture = "g" + item.ID + extPicture;
            item.Save();
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int itemId = int.Parse(e.Keys["ID"].ToString());
        Gallery item = new Gallery(itemId);
        RemovePicture(item.Picture);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.DataItem != null)
        {
            Gallery item = (Gallery)e.Row.DataItem;
            Image iPicture = (Image)e.Row.FindControl("iPicture");
            iPicture.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?w=305&h=200&file=" + item.Picture;
            if (e.Row.RowState == DataControlRowState.Edit)
            {
                ResourceEditor reTitles = (ResourceEditor) e.Row.FindControl("reTitle");
                reTitles.TextID = item.TitleTextId;
            }
            else
            {
                if(item.Titles!=null && item.Titles.Items.Count>0)
                {
                    Literal lTitle = (Literal)e.Row.FindControl("lTitle");
                    lTitle.Text = item.Titles["RU"];
                }
            }
        }
    }
}
