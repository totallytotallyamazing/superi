using System;
using System.Web;
using Superi.Features;

public partial class _404 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebSession.TextID = int.MinValue;
        WebSession.ArticleID = int.MinValue;
        ProcessLanguage();
        ProcessTextRedirection();
        ProcessNavigationRedirection();
        ProcessArticleRedirection();
        ProcessDownload();
    }

    #region Redirection processors
    private void ProcessTextRedirection()
    {
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("/text/") > -1)
        {
            //Response.Write(Request.Url.AbsoluteUri);
            string textAlias = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/text/") + 6);   //Request.Url.Segments[Request.Url.Segments.Length - 1];
            Text text = new Text(textAlias);
            WebSession.TextID = text.ID;
            Server.Transfer("texts.aspx?name=" + textAlias);
            //Context.RewritePath("texts.aspx?name=" + textAlias);
        }
    }

    private void ProcessNavigationRedirection()
    {
        //   if (Request.Url.AbsoluteUri.ToLower().IndexOf("/navigation/") > -1)
        {
            //Response.Write(Request.Url.AbsoluteUri);
            WebSession.NavigationID = int.MinValue;

            string navAlias = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.LastIndexOf("/") + 1);

            Superi.Features.Navigation navigation = new Superi.Features.Navigation(navAlias);
            if (navigation.ID > 0)
            {
                if (navigation.TextID > 0)
                {
                    Superi.Features.Text text = new Superi.Features.Text(navigation.TextID);
                    WebSession.NavigationID = navigation.ID;
                    Server.Transfer("texts.aspx?name=" + text.Alias);
                 //   Context.RewritePath("texts.aspx?name=" + text.Alias);
                }
                else if (!string.IsNullOrEmpty(navigation.Page))
                {
                    string redirectUrl = navigation.Page;
                    WebSession.NavigationID = navigation.ID;
                    Server.Transfer(redirectUrl);
                }
                else if (navigation.ArticleScopeID > 0)
                {
                    WebSession.NavigationID = navigation.ID;
                    Server.Transfer("articles.aspx?scopeid=" + navigation.ArticleScopeID);
                }
                else if(navigation.ProductGroupID>0)
                {
                    WebSession.NavigationID = navigation.ID;
                    Server.Transfer("products.aspx?groupid=" + navigation.ProductGroupID);
                }
                else if(navigation.SingleMenuPage)
                {
                    WebSession.NavigationID = navigation.ID;
                    Server.Transfer("Menu.aspx");
                }
            }
            else
            {
                Superi.Features.Text text = new Superi.Features.Text(navAlias);
                if (text.ID > 0)
                {
                    WebSession.TextID = text.ID;
                    Server.Transfer("default.aspx?name=" + navAlias);
                }
            }
        }
    }

/*
    private void ProcessNewsPagesRedirection()
    {
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("/page/") > -1)
        {
            string pageNumber = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/page/") + 6);   //Request.Url.Segments[Request.Url.Segments.Length - 1];
            Context.RewritePath("default.aspx?page=" + pageNumber);
        }
    }
*/

/*
    private void ProcessNewsRedirection()
    {
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("/news/") > -1)
        {
            string newsItemAlias = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/news/") + 6);   //Request.Url.Segments[Request.Url.Segments.Length - 1];
            Context.RewritePath("NewsItem.aspx?name=" + newsItemAlias);
        }
    }
*/

    private void ProcessArticleRedirection()
    {
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("/articleid/") > -1)
        {
            string articleAlias = Server.UrlDecode(Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/articleid/") + 11));   //Request.Url.Segments[Request.Url.Segments.Length - 1];
            Superi.Features.Article article = new Superi.Features.Article(articleAlias);
            WebSession.ArticleID = article.ID;
            Server.Transfer("Article.aspx?name=" + articleAlias);
        }
    }

    private void ProcessLanguage()
    {
        string url = Request.Url.AbsoluteUri;
        if (url.IndexOf("lang=") > -1)
        {
            string lang = url.Substring(url.IndexOf("lang=")+5);
            WebSession.Language = lang;
            HttpCookie cookie = new HttpCookie("language", lang);
            cookie.Path = "/";
            Response.Cookies.Add(cookie);
            string path = url.Substring(url.IndexOf("404;") + 4).Replace("/lang="+lang, "");
            Response.Redirect(path);
        }
    }

    private void ProcessDownload()
    {
        string url = Request.Url.AbsoluteUri;
        if(url.IndexOf("download:")>-1)
        {
            string fileName = url.Substring(url.IndexOf("download:") + 9);
            Server.Transfer("Download.aspx?item=" + fileName);
        }
    }

    #endregion

}
