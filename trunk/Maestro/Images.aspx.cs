using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;

public partial class Images : System.Web.UI.Page
{
    private int GalleryId
    {
        get 
       { 
            int galleryId = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["segment"]))
            {
                if (int.TryParse(Request.QueryString["segment"], out galleryId))
                    return galleryId;
                return 0;
            }
            return -1;
                
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GalleryItemList list = new GalleryItemList(GalleryId);
        rPictures.DataSource = list;
        rPictures.DataBind();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (GalleryId > 0)
        {
            Gallery gallery = new Gallery(GalleryId);
            Page.Title = gallery.Titles[WebSession.Language];
            (Master.FindControl("lTitle") as Literal).Text = gallery.Titles[WebSession.Language];
        }
    }

    protected void rPictures_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        GalleryItem item = (GalleryItem)e.Item.DataItem;
        HyperLink hlPicture = (HyperLink)e.Item.FindControl("hlPicture");
        HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");

        hlTitle.NavigateUrl = hlPicture.NavigateUrl = WebSession.GalleryImagesFolder.Replace("~/", WebSession.BaseUrl) + item.Picture;
        hlPicture.ImageUrl = WebSession.GalleryImagesFolder.Replace("~/", WebSession.BaseUrl) + item.Preview;
        hlTitle.ToolTip = hlPicture.ToolTip = hlTitle.Text = item.Titles[WebSession.Language];
        
        //ClientScript.RegisterStartupScript(this.GetType(), "fbox", "$(document).ready(function(){$('.payer a').fancybox({'overlayShow':true});});", true);
    }
}