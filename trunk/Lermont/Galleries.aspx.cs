using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Features;
using Superi.Common;

public partial class Galleries : System.Web.UI.Page
{
    private int itemCount=0;

    private int GalleryId
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["segment"]))
                return int.Parse(Request.QueryString["segment"]);
            return int.MinValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (GalleryId > 0)
        {
            GalleryItemList list = new GalleryItemList(GalleryId);
            rItems.DataSource = list;
            rItems.DataBind();
        }
        else
        {
            GalleryList list = new GalleryList(true);
            rGalleries.DataSource = list;
            rGalleries.DataBind();
            phGalleries.Visible = true;
            phGallery.Visible = false;
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (GalleryId > 0)
        {
            Superi.Features.Gallery gallery = new Superi.Features.Gallery(GalleryId);
            Page.Title = gallery.Titles[WebSession.Language];
        }
    }

    protected void rGalleries_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            Superi.Features.Gallery gallery = (Superi.Features.Gallery)e.Item.DataItem;
            HyperLink hlImage = (HyperLink)e.Item.FindControl("hlImage");
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");

            hlImage.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?w=280&h=200&file=" + gallery.Picture;//WebSession.GalleryImagesFolder.Replace("~/", WebSession.BaseUrl) + gallery.Picture;
            hlImage.Text = gallery.Titles[WebSession.Language];
            hlTitle.Text = gallery.Titles[WebSession.Language];

            hlImage.NavigateUrl = WebSession.BaseUrl + "workshop/photos/" + gallery.ID;
            hlTitle.NavigateUrl = WebSession.BaseUrl + "workshop/photos/" + gallery.ID;
        }
    }

    protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            GalleryItem item = (GalleryItem)e.Item.DataItem;
            HyperLink hlImage = (HyperLink)e.Item.FindControl("hlImage");
            Panel pImageHolder = (Panel)e.Item.FindControl("pImageHolder");
            if (itemCount % 4 == 0)
                pImageHolder.CssClass = "firstGalleryItem";
            else
                pImageHolder.CssClass = "galleryItem";
            hlImage.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?w=120&h=80&file=" + item.Picture;
            hlImage.Text = item.Title;
            hlImage.Attributes.Add("rel", "fancybox");
            hlImage.NavigateUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?dim=600&file=" + item.Picture;
            itemCount++;
        }
    }
}
