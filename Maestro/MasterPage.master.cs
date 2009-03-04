using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;
using Superi.Features;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private string _MetaTags = "";

    public int NavigationID
    {
        get
        {
            return WebSession.NavigationID;
        }
    }

    protected string CurrentUrl
    {
        get
        {
            if (Request.Url.AbsoluteUri.IndexOf("404;") > -1)
                return Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.IndexOf("404;") + 4).Replace("/lang=" + WebSession.Language, "");
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/"));
        }
    }

    protected string MetaTags
    {
        get { return _MetaTags; }
        set { _MetaTags = value; }
    }

    
    protected void Page_Init(object sender, EventArgs e)
    {
        smMain.Services.Add(new ServiceReference(WebSession.BaseUrl + "Services/Matches.asmx"));
        lTitle.Text = Page.Title;
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("default.aspx") > -1)
            WebSession.NavigationID = int.MinValue;
        if (NavigationID > 0)
        {
            Navigation navigation = new Navigation(NavigationID);
            if (!string.IsNullOrEmpty(navigation.Description))
                MetaTags += "<meta name=\"description\" content=\"" + navigation.Description + "\" />" + Environment.NewLine;
            if (!string.IsNullOrEmpty(navigation.Keywords))
                MetaTags += "<meta name=\"keywords\" content=\"" + navigation.Keywords + "\" />" + Environment.NewLine;

            if (navigation.Texts != null && navigation.Texts.Items.Count > 0)
            {
                Page.Title = lTitle.Text = navigation.Texts[WebSession.Language];
            }
            else if (!string.IsNullOrEmpty(navigation.Text))
                Page.Title = lTitle.Text = navigation.Text;
        }
        else if (WebSession.TextID > 0)
        {
            Text text = new Text(WebSession.TextID);
            if (text.Names != null && text.Names.Items.Count > 0)
                Page.Title = lTitle.Text = text.Names[WebSession.Language];
            else
                Page.Title = lTitle.Text = text.Name;
        }
        else if (WebSession.ArticleID > 0)
        {
            Article article = new Article(WebSession.ArticleID);
            if (article.Titles != null && article.Titles.Items.Count > 0)
                Page.Title = lTitle.Text = article.Titles[WebSession.Language];
            else
                Page.Title = lTitle.Text = article.Title;
        }

        hlEN.NavigateUrl = CurrentUrl + "/lang=EN";
        hlUA.NavigateUrl = CurrentUrl + "/lang=UA";
        hlRU.NavigateUrl = CurrentUrl + "/lang=RU";
        hlRU.ImageUrl = WebSession.BaseImageUrl + "RU.jpg";
        hlUA.ImageUrl = WebSession.BaseImageUrl + "UA.jpg";
        hlEN.ImageUrl = WebSession.BaseImageUrl + "EN.jpg";
    }
}
