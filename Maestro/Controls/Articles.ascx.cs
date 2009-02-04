using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;
using Superi.CustomControls;

public partial class Controls_Articles : System.Web.UI.UserControl
{
    public int ArticleScopeId
    {
        get 
        {
            if (ViewState["articleScopeId"] != null)
                return Convert.ToInt32(ViewState["articleScopeId"]);
            return int.MinValue;
        }
        set { ViewState["articleScopeId"] = value; }
    }

    public string ArticleScopeName
    {
        get
        {
            if (ViewState["articleScopeName"] != null)
                return Convert.ToString(ViewState["articleScopeName"]);
            return null; 
        }
        set { ViewState["articleScopeName"] = value; }
    }

    public bool BodyAsDescription
    {
        get
        {
            if (ViewState["bodyAsDescription"] != null)
                return Convert.ToBoolean(ViewState["bodyAsDescription"]);
            return false;
        }
        set { ViewState["bodyAsDescription"] = value; }
    }

    public int MaxDescriptionChars
    {
        get
        {
            if (ViewState["maxDescriptionChars"] != null)
                return Convert.ToInt32(ViewState["maxDescriptionChars"]);
            return int.MinValue;
        }
        set { ViewState["maxDescriptionChars"] = value; }
    }

    public int MaxDescriptionCharsFirst
    {
        get
        {
            if (ViewState["maxDescriptionCharsFirst"] != null)
                return Convert.ToInt32(ViewState["maxDescriptionCharsFirst"]);
            return int.MinValue;
        }
        set { ViewState["maxDescriptionCharsFirst"] = value; }
    }

    public bool SeparateFirstArticle
    {
        get
        {
            if (ViewState["separateFirstArticle"] != null)
                return Convert.ToBoolean(ViewState["separateFirstArticle"]);
            return false;
        }
        set { ViewState["separateFirstArticle"] = value; }
    }

    public string DefaultImageUrl
    {
        get
        {
            if (ViewState["defaultImageUrl"] != null)
                return Convert.ToString(ViewState["defaultImageUrl"]);
            return null;
        }
        set { ViewState["defaultImageUrl"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ArticleList list = new ArticleList(ArticleScopeId);
        rItems.DataSource = list;
        rItems.DataBind();
    }

    protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Article article = (Article)e.Item.DataItem;
        Image iPicture = (Image)e.Item.FindControl("iPicture");
        Literal lTitle = (Literal)e.Item.FindControl("lTitle");
        Label lDate = (Label)e.Item.FindControl("lDate");
        Literal lText = (Literal)e.Item.FindControl("lText");
        ResourceLinkButton rlbDetails = (ResourceLinkButton)e.Item.FindControl("rlbDetails");
        rlbDetails.Language = WebSession.Language;
        if (string.IsNullOrEmpty(article.Picture))
            iPicture.ImageUrl = DefaultImageUrl;
        else
            iPicture.ImageUrl = WebSession.ArticlesImagesFolder + article.Picture;

        lTitle.Text = article.Titles[WebSession.Language];
        lDate.Text = article.EntryDate.ToShortDateString();
        if (BodyAsDescription)
        {
            int maxCahrs = MaxDescriptionChars;
            if (SeparateFirstArticle && e.Item.ItemIndex == 0)
                maxCahrs = MaxDescriptionCharsFirst;
            string articleText = article.Descriptions[WebSession.Language];
            if (articleText.Length > maxCahrs)
            {
                lText.Text = articleText.Substring(0, maxCahrs) + "...";
            }
            else
                lText.Text = articleText;
        }
        else
            lText.Text = article.ShortDescriptions[WebSession.Language];

        rlbDetails.CommandArgument = article.ID.ToString();
            
    }
    protected void rItems_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        Article article = new Article(articleId);
        lDetails.Text = article.Descriptions[WebSession.Language];
    }
}