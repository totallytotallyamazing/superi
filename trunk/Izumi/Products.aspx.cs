using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Superi.Shop;

public partial class Products : Page
{
    private int GroupID
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["groupid"]))
                return int.Parse(Request.QueryString["groupid"]);
            else
                return int.MinValue;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        ProductList productList = new ProductList(GroupID);
        if(WebSession.NavigationID==50 || WebSession.NavigationID == 57)
        {
            phAlco.Visible = true;
            rAlco.DataSource = productList;
            rAlco.ItemDataBound += rAlco_ItemDataBound;
            rAlco.DataBind();
        }
        else
        {
            phAlco.Visible = false;
            rProducts.DataSource = productList;
            rProducts.ItemDataBound += rProducts_ItemDataBound;
            rProducts.DataBind();
        }
    }

    void rAlco_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Product product = (Product)e.Item.DataItem;
        Literal lAlcoName = (Literal)e.Item.FindControl("lAlcoName");
        try
        {
            lAlcoName.Text = product.Names[WebSession.Language];
        }
        catch (Exception)
        {
            lAlcoName.Text = product.Name;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        WebSession.ContentWidth = 600;
    }

    void rProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Product product = (Product) e.Item.DataItem;
        //Image pictureControl = (Image) e.Item.FindControl("iPicture");
        HtmlGenericControl container = (HtmlGenericControl)e.Item.FindControl("divContainer");
        HtmlGenericControl priceSpacer = (HtmlGenericControl)e.Item.FindControl("productPriceSpacer");
        Literal lName = (Literal) e.Item.FindControl("lName");
        System.Drawing.Image image = null;
        try
        {
            image =
                System.Drawing.Image.FromFile(Server.MapPath(DefaultValues.ProductsImagesFolder + product.Picture));
            //pictureControl.ImageUrl = DefaultValues.ProductsImagesFolder + product.Picture;
            //pictureControl.Width = image.Width;
            //pictureControl.Height = image.Height;
            container.Style["width"] = image.Width + "px";
            container.Style["height"] = image.Height + "px";
            container.Style["background-image"] = "url(" + DefaultValues.BaseImageUrl + "ProductImages/" + product.Picture + ")";

        }
        catch (Exception)
        {
            container.Style["display"] = "none";
        }
        finally
        {
            if (image != null)
                image.Dispose();
        }
        try
        {
            lName.Text = product.Names[WebSession.Language];
        }
        catch (Exception)
        {
            lName.Text = product.Name;
        }
        //priceSpacer.Style["height"] = image.Height - 40 + "px";
        //pictureControl.AlternateText = product.Names[WebSession.Language];
    }
}
