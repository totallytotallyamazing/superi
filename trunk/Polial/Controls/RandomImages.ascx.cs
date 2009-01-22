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

public partial class Controls_RandomImages : System.Web.UI.UserControl
{
    private int GalleryId
    {
        get
        {
            if(WebSession.NavigationID>0)
            {
                Navigation navigation = new Navigation(WebSession.NavigationID);
                if(navigation.Name == "objects")
                    return int.MinValue;
                return navigation.ID;
            }
            return int.MinValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GalleryItemList list = GalleryItems.GetRandom(3, GalleryId);
        if(list.Count == 0)
            list = GalleryItems.GetRandom(3);
        rImages.DataSource = list;
        rImages.DataBind();
    }
    protected void rImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        GalleryItem item = (GalleryItem) e.Item.DataItem;
        HyperLink hlRandomImage = (HyperLink) e.Item.FindControl("hlRandomImage");

        hlRandomImage.ImageUrl = WebSession.BaseImageUrl + "GalleryImages/" + item.Preview;
        hlRandomImage.Text = "";
        string suffix = "";
        if(item.GalleryID>0)
        {
            Navigation navigation = new Navigation(item.GalleryID);
            suffix = "/" + navigation.Name;
        }
        hlRandomImage.NavigateUrl = WebSession.BaseUrl + "objects" + suffix;
    }
}
