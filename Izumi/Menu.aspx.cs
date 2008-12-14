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

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Navigation navigation = new Navigation(WebSession.NavigationID);
        dlItems.DataSource = navigation.ChildrenIncludedOnly;
        dlItems.ItemDataBound += dlItems_ItemDataBound;
        dlItems.DataBind();
        
    }

    void dlItems_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Navigation navigation = (Navigation)e.Item.DataItem;
        //Image pictureControl = (Image) e.Item.FindControl("iPicture");
        HtmlGenericControl container = (HtmlGenericControl)e.Item.FindControl("divMenuItem");
        HtmlGenericControl nameSpacer = (HtmlGenericControl)e.Item.FindControl("menuNameSpacer");
        if (!string.IsNullOrEmpty(navigation.Picture))
        {
            System.Drawing.Image image =
                System.Drawing.Image.FromFile(Server.MapPath(DefaultValues.MenuImagesFolder + navigation.Picture));
            //pictureControl.ImageUrl = DefaultValues.ProductsImagesFolder + product.Picture;
            //pictureControl.Width = image.Width;
            //pictureControl.Height = image.Height;
            container.Style["width"] = image.Width + "px";
            container.Style["height"] = image.Height + "px";
            container.Style["background-image"] = "url(" + DefaultValues.BaseImageUrl + "MenuImages/" +
                                                  navigation.Picture + ")";
            nameSpacer.Style["height"] = image.Height - 30 + "px";
            image.Dispose();
        }
        container.Attributes.Add("onclick",
                                 "javascript:window.location='" + DefaultValues.BaseUrl + navigation.Name + "'");
        
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        WebSession.DisplaySubMenu = false;
    }
}
