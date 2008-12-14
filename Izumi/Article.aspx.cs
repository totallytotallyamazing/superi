using System;
using System.Web.UI;

public partial class Article : Page
{
    private string Alias
    {
        get { return Request.QueryString["name"]; }
    }

    private int ArticleID
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                return int.Parse(Request.QueryString["id"]);
            else
                return int.MinValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        Superi.Features.Article article = null;
        if (!string.IsNullOrEmpty(Alias))
            article = new Superi.Features.Article(Alias);
        else if (ArticleID > 0)
            article = new Superi.Features.Article(ArticleID);
        if (article != null)
        {
            if (article.Descriptions != null && article.Descriptions.Items.Count > 0)
                lContent.Text = article.Descriptions[WebSession.Language];
            else
                lContent.Text = article.Description;
            if (article.Titles != null && article.Titles.Items.Count > 0)
                Page.Title = article.Titles[WebSession.Language];
            else
                Page.Title = article.Title;
        }
    }
}
