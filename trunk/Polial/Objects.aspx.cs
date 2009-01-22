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

public partial class Objects : System.Web.UI.Page
{
    private int GalleryId
    {
        get
        {
            if(!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                string queryString = Request.QueryString["name"];
                Navigation navigation = new Navigation(queryString);
                return navigation.ID;
            }
            return int.MinValue;
        }
    }


    private int CurrentPage
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                return int.Parse(Request.QueryString["page"]);
            return 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        PagedDataSource dataSource = new PagedDataSource();
        dataSource.DataSource = GalleryId > 0 ? new GalleryItemList(GalleryId) : new GalleryItemList(true);
        dataSource.PageSize = 12;
        dataSource.AllowPaging = true;
        dataSource.CurrentPageIndex = CurrentPage;

        WebSession.NavigationHolder.Controls.Clear();
        Controls_Paging paging = (Controls_Paging)LoadControl("~/Controls/Paging.ascx");
        paging.PageCount = dataSource.PageCount;
        paging.DisplayFirstButtom = paging.DisplayPreviousButton = !dataSource.IsFirstPage;
        paging.DisplayNextButton = paging.DisplayLastButton = !dataSource.IsLastPage;
        WebSession.NavigationHolder.Controls.Add(paging);
        rObjects.DataSource = dataSource;
        rObjects.DataBind();
    }

    protected void rObjects_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        GalleryItem item = (GalleryItem)e.Item.DataItem;

        HyperLink hlPreview = (HyperLink)e.Item.FindControl("hlPreview");
        Image iLogo = (Image)e.Item.FindControl("iLogo");
        Literal lTitle = (Literal)e.Item.FindControl("lTitle");
        Literal lClient = (Literal)e.Item.FindControl("lClient");
        Literal lAddress = (Literal)e.Item.FindControl("lAddress");
        Literal lYear = (Literal)e.Item.FindControl("lYear");
        Literal lSquare = (Literal)e.Item.FindControl("lSquare");
        Literal lWorkKinds = (Literal)e.Item.FindControl("lWorkKinds");

        string title = "";
        if(item.Titles!=null && item.Titles.Items.Count>0)
            title = item.Titles[WebSession.Language];
    
        string client = "";
        string address = "";
        string year = "";
        string square = "";
        string workKinds = "";

        if (item.SubTitleTextId > 0)
        {
            string value = item.SubTitles[WebSession.Language];
            
            char[] sep = {'%'};

            string[] values = value.Split(sep);
            client = values[0];
            address = values[1];
            year = values[2];
            square = values[3];
            workKinds = values[4];
        }

        if (!string.IsNullOrEmpty(item.Preview))
        {
            hlPreview.ImageUrl = WebSession.GalleryImagesFolder.Replace("~/", WebSession.BaseUrl) + item.Preview;
            hlPreview.Attributes.Add("rel", "lightbox");
            hlPreview.NavigateUrl = WebSession.GalleryImagesFolder.Replace("~/", WebSession.BaseUrl) + item.Picture;
            hlPreview.Text = title;
        }
        else
            hlPreview.Visible = false;
        if (!string.IsNullOrEmpty(item.Url))
        {
            iLogo.AlternateText = client;
            iLogo.ImageUrl = WebSession.ClientLogosFolder.Replace("~/", WebSession.BaseUrl) + item.Url;
        }
        else
            iLogo.Visible = false;
        lTitle.Text = title;
        lClient.Text = client;
        lAddress.Text = address;
        lYear.Text = year;
        lSquare.Text = square;
        lWorkKinds.Text = workKinds;
    }
}
