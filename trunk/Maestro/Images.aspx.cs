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
    const int PAGE_SIZE = 36;

    private int GalleryId
    {
        get
        {
            int galleryId = 0;
            string segment = Request.QueryString["segment"];
            if (string.IsNullOrEmpty(segment))
                return -1;
            else if (segment.IndexOf("/") == -1 && segment.IndexOf("p") == -1)
            {
                if (int.TryParse(segment, out galleryId))
                    return galleryId;
                else
                    return 0;
            }
            else if (segment.IndexOf("/") == -1)
                return -1;

            char[] sep = { '/' };
            string[] segmentParts = segment.Split(sep);
            if (int.TryParse(segmentParts[0], out galleryId))
                return galleryId;
            else
                return 0;
        }
    }

    private int CurrentPage
    {
        get
        {
            string segment = Request.QueryString["segment"];
            if (string.IsNullOrEmpty(segment))
                return 0;
            else if ((segment.IndexOf("/") == -1 && segment.IndexOf("p") == -1))
                return 0;
            else if (segment.IndexOf("/") == -1)
                return int.Parse(segment.Replace("p", ""));

            char[] sep = { '/' };
            string[] segmentParts = segment.Split(sep);
            return int.Parse(segmentParts[1].Replace("p", ""));
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GalleryItemList list = new GalleryItemList(GalleryId);
        PagedDataSource pdsGaleryItems = new PagedDataSource();
        pdsGaleryItems.PageSize = PAGE_SIZE;
        pdsGaleryItems.DataSource = list;
        pdsGaleryItems.AllowPaging = true;
        pPages.PageCount = pdsGaleryItems.PageCount;
        pdsGaleryItems.CurrentPageIndex = pPages.CurrentPage = CurrentPage;
        if (GalleryId > 0)
            pPages.BasePath = WebSession.BaseUrl + "multimedia/images/" + GalleryId + "/p";
        else
            pPages.BasePath = WebSession.BaseUrl + "multimedia/images/p";

        rPictures.DataSource = pdsGaleryItems;
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
        if (GalleryId > 0)
            hlTitle.CssClass = "mediaPicture";
        else
            hlTitle.Target = "_blank";
        hlTitle.NavigateUrl = hlPicture.NavigateUrl = WebSession.GalleryImagesFolder.Replace("~/", WebSession.BaseUrl) + item.Picture;
        hlPicture.ImageUrl = WebSession.GalleryImagesFolder.Replace("~/", WebSession.BaseUrl) + item.Preview;
        hlTitle.ToolTip = hlPicture.ToolTip = hlTitle.Text = item.Titles[WebSession.Language];
    }
}