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

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkCss();
        BookList bookList = new BookList(true);
        rBooks.DataSource = bookList;
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
        if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Book book = (Book) e.Item.DataItem;
            HyperLink hlCover = (HyperLink)e.Item.FindControl("hlCover");
            HyperLink hlTitle = (HyperLink) e.Item.FindControl("hlTitle");
            HyperLink hlNewBook = (HyperLink) e.Item.FindControl("hlNewBook");
            Literal lSubTitle = (Literal) e.Item.FindControl("lSubTitle");
            HyperLink hlPublisher = (HyperLink) e.Item.FindControl("hlPublisher");
            Literal lDescription = (Literal)e.Item.FindControl("lDescription");
            Label tbPrice = (Label)e.Item.FindControl("tbPrice");

            
            string navigateUrl = WebSession.BaseUrl + "workshop/product_details/" + book.ID;
            
            hlCover.Text = book.Names[WebSession.Language];
            hlCover.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?loc=products&h=159&w=110&kp=0&file=" + book.Picture;
            hlCover.NavigateUrl = navigateUrl;

            hlTitle.Text = book.Names[WebSession.Language];
            hlTitle.NavigateUrl = navigateUrl;

            hlNewBook.Visible = book.NewBook;

            tbPrice.Text = book.Price.ToString("N");

            hlNewBook.NavigateUrl = navigateUrl;

            lSubTitle.Text = new Resource(book.SubTitleTextId)[WebSession.Language];

            hlPublisher.Text = new Resource(book.PublisherTextId)[WebSession.Language];
            hlPublisher.NavigateUrl = book.PublisherUrl;

            lDescription.Text = book.ShortDescriptions[WebSession.Language];
        }
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem rItem in rBooks.Items)
        {
            CheckBox cbBuy = (CheckBox)rItem.FindControl("cbBuy");
            if (cbBuy.Checked)
            {
                CartItem cItem = new CartItem();
                cItem.ID = int.Parse(cbBuy.Attributes["cbvalue"]);
                cItem.Type = ItemCartType.Book;
                Cart.AddItem(cItem);
            }
        }
    }
}
