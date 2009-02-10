using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;

public partial class Practices : System.Web.UI.Page
{
    private int CurrentPage
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["segment"]))
                return int.Parse(Request.QueryString["segment"]);
            return 0; 
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        LinkCss();
        PublishItems();
    }

    private void LinkCss()
    {
        HtmlLink link = new HtmlLink();
        link.Attributes.Add("rel", "Stylesheet");
        link.Href = "css/practices.css";
        Page.Controls.Add(link);
    }

    private void PublishItems()
    {
        PagedDataSource dataSource = new PagedDataSource();
        dataSource.DataSource = new ArticleList(1, true);
        dataSource.PageSize = 7;
        dataSource.AllowPaging = true;
        dataSource.CurrentPageIndex = CurrentPage;
        pPages.PageCount = dataSource.PageCount;
        //ArticleList articleList = new ArticleList(1, true);
        rItems.DataSource = dataSource;
        rItems.DataBind();
    }

    protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rImages = (Repeater) e.Item.FindControl("rImages");
            Literal lPracticeText = (Literal) e.Item.FindControl("lPracticeText");
            Article article = (Article) e.Item.DataItem;

            lPracticeText.Text = article.Descriptions[WebSession.Language];
            AttachableFileList fileList = new AttachableFileList(article.ID, ItemTypes.Article, null);
            rImages.ItemDataBound += rImages_ItemDataBound;
            rImages.DataSource = fileList;
            rImages.DataBind();
        }
    }

    protected void rImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Image iPicture = (Image) e.Item.FindControl("iPicture");
            AttachableFile file = (AttachableFile) e.Item.DataItem;

            iPicture.CssClass = "practicePicture";
            iPicture.ImageUrl = "MakeThumbnail.aspx?loc=practice&w=180&h=179&file=" + file.FileName;
            iPicture.AlternateText = file.FileName;
        }
    }
}
