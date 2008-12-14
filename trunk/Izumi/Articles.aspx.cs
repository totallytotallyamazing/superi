using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Superi.Features;

public partial class Articles : Page
{
    private int ScopeID
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["scopeid"]))
                return int.Parse(Request.QueryString["scopeid"]);
            return int.MinValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ArticleList articleList = new ArticleList(ScopeID);
        rArticles.DataSource = articleList;
        rArticles.ItemDataBound += rArticles_ItemDataBound;
        rArticles.DataBind();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
       // WebSession.ContentWidth = 651;
    }

    void rArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal lTitle = (Literal)e.Item.FindControl("lTitle");
        Image iPicture = (Image)e.Item.FindControl("iPicture");
        Literal lText = (Literal)e.Item.FindControl("lText");
        HtmlTableCell topTr = (HtmlTableCell) e.Item.FindControl("topTr");
        HtmlGenericControl divCutter = (HtmlGenericControl) e.Item.FindControl("divCutter");

        Superi.Features.Article article = (Superi.Features.Article)e.Item.DataItem;

        if (article.Titles != null && article.Titles.Items.Count > 0)
            lTitle.Text = article.Titles[WebSession.Language];
        else
            lTitle.Text = article.Title;

        if (!string.IsNullOrEmpty(article.TitlePicture))
            iPicture.ImageUrl = DefaultValues.ArticlesImagesFolder + article.TitlePicture;
        else
            iPicture.ImageUrl = DefaultValues.ArticlesImagesFolder + "unknown.jpg";

        try
        {
            System.Drawing.Image image =
            System.Drawing.Image.FromFile(Server.MapPath(DefaultValues.ArticlesImagesFolder + article.TitlePicture));
            topTr.Style["height"] = (image.Height - 20) + "px";
            divCutter.Style["height"] = (image.Height - 20) + "px";
            image.Dispose();
        }
        catch (Exception)
        {
            System.Drawing.Image image =
            System.Drawing.Image.FromFile(Server.MapPath(DefaultValues.ArticlesImagesFolder + "unknown.jpg"));
            iPicture.ImageUrl = DefaultValues.ArticlesImagesFolder + "unknown.jpg";
            topTr.Style["height"] = (image.Height - 20) + "px";
            divCutter.Style["height"] = (image.Height - 20) + "px";
            image.Dispose();
        }
        iPicture.Style["border"] = "1px solid black";

        if (article.ShortDescriptions != null && article.ShortDescriptions.Items.Count > 0)
            lText.Text = article.ShortDescriptions[WebSession.Language];
        else
            lText.Text = article.ShortDescription;
    }
}
