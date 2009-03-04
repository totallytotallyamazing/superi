using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;

public partial class Galleries : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GalleryList list = new GalleryList(true);
        rPictures.DataSource = list;
        rPictures.DataBind();
    }

    protected void rPictures_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Gallery item = (Gallery)e.Item.DataItem;
        HyperLink hlPicture = (HyperLink)e.Item.FindControl("hlPicture");
        HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");

        hlPicture.ImageUrl = WebSession.GalleryImagesFolder.Replace("~/", WebSession.BaseUrl) + item.Picture;
        hlTitle.Text = item.Titles[WebSession.Language];
        hlTitle.NavigateUrl = hlPicture.NavigateUrl = WebSession.BaseUrl + "multimedia/images/" + item.ID;
    }
}
