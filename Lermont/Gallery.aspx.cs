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

public partial class Gallery : System.Web.UI.Page
{
    private int itemCount = 0;

    private int GalleryId
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                return int.Parse(Request.QueryString["id"]);
            return int.MinValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Superi.Features.Gallery gallery = new Superi.Features.Gallery(GalleryId);
        Page.Title = gallery.Title;
        GalleryItemList list = new GalleryItemList(GalleryId);
        rItems.DataSource = list;
        rItems.DataBind();
    }

    protected void rGalleries_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            GalleryItem item = (GalleryItem)e.Item.DataItem;
            HyperLink hlImage = (HyperLink)e.Item.FindControl("hlImage");
            Panel pImageHolder = (Panel) e.Item.FindControl("pImageHolder");
            if(itemCount%4==0)
                pImageHolder.CssClass = "firstGalleryItem";
            else
                pImageHolder.CssClass = "galleryItem";
            hlImage.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?w=120&h=80&file=" + item.Picture;
            hlImage.Text = item.Title;
            hlImage.Attributes.Add("rel", "lightbox[g]");
            hlImage.NavigateUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?dim=600&file=" + item.Picture;
            itemCount++;
        }   
    }
}
