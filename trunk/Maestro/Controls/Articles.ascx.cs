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
    #region Properties
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

    public bool DisplayDate
    {
        get
        {
            if (ViewState["displayDate"] != null)
                return Convert.ToBoolean(ViewState["displayDate"]);
            return false;
        }
        set { ViewState["displayDate"] = value; }
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

    public bool ZoomImage
    {
        get
        {
            if (ViewState["zoomImage"] != null)
                return Convert.ToBoolean(ViewState["zoomImage"]);
            return false;
        }
        set { ViewState["zoomImage"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
      //  rlbClose.Language = WebSession.Language;
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
        Panel pText = (Panel)e.Item.FindControl("pText");
        Panel pTitle = (Panel)e.Item.FindControl("pTitle");
        HyperLink hlPicture = (HyperLink)e.Item.FindControl("hlPicture");
        rlbDetails.Language = WebSession.Language;
        string picturePrefix = WebSession.BaseUrl + "MakeThumbnail.aspx?w=76&h=76&loc=article&ha=c&va=m&kp=1&file=";
        if (ZoomImage)
        {
            iPicture.Visible = false;
            hlPicture.Visible = true;

            if (string.IsNullOrEmpty(article.TitlePicture))
                hlPicture.ImageUrl = DefaultImageUrl.Replace("~/", WebSession.BaseUrl);
            else
            {
                hlPicture.NavigateUrl = WebSession.ArticlesImagesFolder + article.Picture;
                hlPicture.ImageUrl = picturePrefix + article.TitlePicture;
            }
        }
        else
        {
            hlPicture.Visible = false;
            iPicture.Visible = true;
            if (string.IsNullOrEmpty(article.TitlePicture))
                iPicture.ImageUrl = DefaultImageUrl;
            else
                iPicture.ImageUrl = picturePrefix + article.TitlePicture;
        }
        lTitle.Text = article.Titles[WebSession.Language];
        if (DisplayDate)
            lDate.Visible = true;
        else
            lDate.Visible = false;
        lDate.Text = article.EntryDate.ToString("dd.MM.yyyy");
        if (SeparateFirstArticle)
        {
            pTitle.CssClass = "articleTitleFirst";
            lDate.CssClass = "articleDateFirst";
        }

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
            lText.Text = article.ShortDescriptions[WebSession.Language].Replace(Environment.NewLine, "<br />");

        rlbDetails.CommandArgument = article.ID.ToString();
            
    }
    protected void rItems_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        Article article = new Article(articleId);
        iArticlePicture.Visible = false;
        if(!string.IsNullOrEmpty(article.Picture))
        {
            iArticlePicture.Visible = true;
            iArticlePicture.ImageUrl = WebSession.ArticlesImagesFolder.Replace("~/", WebSession.BaseUrl) + article.Picture;
        }
        lDetails.Text = article.Descriptions[WebSession.Language];
    }
}