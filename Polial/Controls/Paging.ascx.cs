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

public partial class Controls_Paging : System.Web.UI.UserControl
{
    private int pageCount = 0;
    private bool displayFirstButtom = false;
    private bool displayPreviousButton = false;
    private bool displayNextButton = false;
    private bool displayLastButton = false;

    private int CurrentPage
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                return int.Parse(Request.QueryString["page"]);
            return 0;
        }
    }


    private string NavigationName
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["name"]))
                return Request.QueryString["name"];
            return string.Empty;
        }
    }

    public int PageCount
    {
        get { return pageCount; }
        set { pageCount = value; }
    }

    public bool DisplayFirstButtom
    {
        get { return displayFirstButtom; }
        set { displayFirstButtom = value; }
    }

    public bool DisplayPreviousButton
    {
        get { return displayPreviousButton; }
        set { displayPreviousButton = value; }
    }

    public bool DisplayNextButton
    {
        get { return displayNextButton; }
        set { displayNextButton = value; }
    }

    public bool DisplayLastButton
    {
        get { return displayLastButton; }
        set { displayLastButton = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        hlFirst.NavigateUrl = WebSession.BaseUrl + "objects" +
                              ((!string.IsNullOrEmpty(NavigationName)) ? "/" + NavigationName : "");
        hlPrevious.NavigateUrl = WebSession.BaseUrl + "objects" +
                     ((!string.IsNullOrEmpty(NavigationName)) ? "/" + NavigationName : "") +
                     ((CurrentPage) > 0 ? "/" + (CurrentPage-1) : "");
        hlNext.NavigateUrl = WebSession.BaseUrl + "objects" +
                             ((!string.IsNullOrEmpty(NavigationName)) ? "/" + NavigationName : "") + "/" +
                             (CurrentPage + 1);

        hlLast.NavigateUrl = WebSession.BaseUrl + "objects" +
                             ((!string.IsNullOrEmpty(NavigationName)) ? "/" + NavigationName : "") + "/" +
                             (PageCount - 1);

        hlFirst.ImageUrl = WebSession.BaseImageUrl + "first.jpg";
        hlPrevious.ImageUrl = WebSession.BaseImageUrl + "prev.jpg";
        hlNext.ImageUrl = WebSession.BaseImageUrl + "next.jpg";
        hlLast.ImageUrl = WebSession.BaseImageUrl + "last.jpg";

        hlFirst.Visible = DisplayFirstButtom;
        hlPrevious.Visible = DisplayPreviousButton;
        hlNext.Visible = DisplayNextButton;
        hlLast.Visible = DisplayLastButton;

        if (PageCount > 1)
        {
            ArrayList pages = new ArrayList(PageCount);
            for (int i = 0; i < PageCount; i++)
                pages.Add(i);
            rPages.DataSource = pages;
            rPages.DataBind();
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {



    }
    protected void rPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int pageNumber = (int) e.Item.DataItem;
            HyperLink hlPage = (HyperLink) e.Item.FindControl("hlPage");
            Literal lCurrentPage = (Literal) e.Item.FindControl("lCurrentPage");

            if (pageNumber == CurrentPage)
            {
                hlPage.Visible = false;
                lCurrentPage.Text = (pageNumber + 1).ToString();
            }
            else
            {
                lCurrentPage.Visible = false;
                hlPage.NavigateUrl = WebSession.BaseUrl + "objects" +
                                     ((!string.IsNullOrEmpty(NavigationName)) ? "/" + NavigationName : "") +
                                     (pageNumber > 0 ? "/" + pageNumber : "");
                hlPage.Text = (pageNumber + 1).ToString();
            }
        }
    }
}
