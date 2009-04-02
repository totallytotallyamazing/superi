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

public partial class ProductsDisk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkCss();
        DiskList diskList = new DiskList(true);
        rBooks.DataSource = diskList;
        rBooks.DataBind();
    }

    private void LinkCss()
    {
        HtmlLink link = new HtmlLink();
        link.Attributes.Add("rel", "Stylesheet");
        link.Href = "css/books.css";
        Page.Controls.Add(link);
    }

    protected void rBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Disk disk = (Disk)e.Item.DataItem;
            HyperLink hlCover = (HyperLink)e.Item.FindControl("hlCover");
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
            HyperLink hlNewBook = (HyperLink)e.Item.FindControl("hlNewBook");
            Literal lSubTitle = (Literal)e.Item.FindControl("lSubTitle");
            HyperLink hlPublisher = (HyperLink)e.Item.FindControl("hlPublisher");
            Literal lDescription = (Literal)e.Item.FindControl("lDescription");
            Label tbPrice = (Label)e.Item.FindControl("tbPrice");


            string navigateUrl = WebSession.BaseUrl + "workshop/product_details/" + disk.ID;

            hlCover.Text = disk.Names[WebSession.Language];
            hlCover.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?loc=products&h=159&w=110&kp=0&file=" + disk.Picture;
            hlCover.NavigateUrl = navigateUrl;

            hlTitle.Text = disk.Names[WebSession.Language];
            hlTitle.NavigateUrl = navigateUrl;

            hlNewBook.Visible = disk.NewBook;

            tbPrice.Text = disk.Price.ToString("N");

            hlNewBook.NavigateUrl = navigateUrl;

            lSubTitle.Text = new Resource(disk.SubTitleTextId)[WebSession.Language];

            hlPublisher.Text = new Resource(disk.PublisherTextId)[WebSession.Language];
            hlPublisher.NavigateUrl = disk.PublisherUrl;

            lDescription.Text = disk.ShortDescriptions[WebSession.Language];
        }
    }
}
