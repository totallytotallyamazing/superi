using System;
//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
using Superi.Features;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private string _MetaTags = "";
    private string mainTitle = "";

    public int NavigationID
    {
        get
        {
            return WebSession.NavigationID;
        }
    }

    protected string CurrentUrl
    {
        get { return Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.IndexOf("404;") + 4); }
    }

    protected string MetaTags
    {
        get { return _MetaTags; }
        set { _MetaTags = value; }
    }

    protected string MainTitle
    {
        get { return mainTitle; }
        set { mainTitle = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        WebSession.DisplaySubMenu = true;
        WebSession.ContentWidth = 580;
        if (NavigationID > 0)
        {
            Navigation navigation = new Navigation(NavigationID);
            if (!string.IsNullOrEmpty(navigation.Description))
                MetaTags += "<meta name=\"description\" content=\"" + navigation.Description + "\" />" + Environment.NewLine;
            if (!string.IsNullOrEmpty(navigation.Keywords))
                MetaTags += "<meta name=\"keywords\" content=\"" + navigation.Keywords + "\" />" + Environment.NewLine;

            if (navigation.Texts != null && navigation.Texts.Items.Count > 0)
            {
                Page.Title = navigation.Texts[WebSession.Language];
                mainTitle = navigation.Texts[WebSession.Language];
            }
            else if (!string.IsNullOrEmpty(navigation.Text))
            {
                Page.Title = navigation.Text;
                mainTitle = navigation.Text;
            }
            if (navigation.Name == "contacts")
                WebSession.ContentWidth = 651;

            if (navigation.AdditionalTitles != null && navigation.AdditionalTitles.Items.Count > 0)
                Page.Title += " " + navigation.AdditionalTitles[WebSession.Language];
        }
        else if (WebSession.TextID > 0)
        {
            Text text = new Text(WebSession.TextID);
            if (text.Names != null && text.Names.Items.Count > 0)
            {
                Page.Title = text.Names[WebSession.Language];
                mainTitle = text.Names[WebSession.Language];
            }
            else
            {
                Page.Title = text.Name;
                mainTitle = text.Name;
            }
        }
        else if(WebSession.ArticleID>0)
        {
            Superi.Features.Article article = new Superi.Features.Article(WebSession.ArticleID);
            if (article.Titles != null && article.Titles.Items.Count > 0)
            {
                Page.Title = article.Titles[WebSession.Language];
                mainTitle = article.Titles[WebSession.Language];
            }
            else
            {
                Page.Title = article.Title;
                mainTitle = article.Title;
            }
        }

    }
}