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

public partial class ProductDetails : System.Web.UI.Page
{
    private int BookId
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["segment"]))
                return int.Parse(Request.QueryString["segment"]);
            return int.MinValue;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        LinkCss();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if(BookId>0)
        {
            Book book = new Book(BookId);
            iPicture.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?w=200&h=311&kp=0&loc=products&file=" +
                                book.Picture;
            twTitle.ResourceId = book.NameTextID;
            twSubTitle.ResourceId = book.SubTitleTextId;
            twDescription.ResourceId = book.DescriptionTextID;
            twAdditionalInfo.ResourceId = book.AdditionalInfoTextId;
            hlPublisher.Text = new Resource(book.PublisherTextId)[WebSession.Language];
            hlPublisher.NavigateUrl = book.PublisherUrl;
            hlPublisher.Target = "_blank";
            Page.Title = book.Names[WebSession.Language];
        }
    }

    private void LinkCss()
    {
        HtmlLink link = new HtmlLink();
        link.Attributes.Add("rel", "Stylesheet");
        link.Href = "css/productProperties.css";
        phStyles.Controls.Add(link);
    }
}
