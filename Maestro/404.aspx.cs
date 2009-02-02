using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;
using Superi.Features;
using System.Text.RegularExpressions;

public partial class _404 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProcessLanguage();
        WebSession.TextID = int.MinValue;
        WebSession.ArticleID = int.MinValue;
        WebSession.NavigationID = int.MinValue;
        ProcessNavigationRedirection(null);
        //ProcessTextRedirection();
        //ProcessArticleRedirection();
        //ProcessDownload();
    }

    #region Redirection processors
    //private void ProcessTextRedirection()
    //{
    //    if (Request.Url.AbsoluteUri.ToLower().IndexOf("/text/") > -1)
    //    {
    //        string textAlias = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/text/") + 6);   //Request.Url.Segments[Request.Url.Segments.Length - 1];
    //        Superi.Features.Text text = new Superi.Features.Text(textAlias);
    //        WebSession.TextID = text.ID;
    //        Server.Transfer("texts.aspx?name=" + textAlias);
    //    }
    //}

    private string GetPath(string Url)
    {
        string url = Url.Substring(Url.IndexOf(";") + 1);
        Uri uri = new Uri(url);
        string result = uri.AbsolutePath;
        if (result.IndexOf("/maestro/") != -1)
            result = result.Substring(9);
        else
            result = result.Substring(1);
        return result;

    }

    private void NavigationRedirect(Navigation navigation)
    {
        if (navigation.TextID > 0)
        {
            Text text = new Text(navigation.TextID);
            WebSession.NavigationID = navigation.ID;
            Server.Transfer("texts.aspx?name=" + text.Alias);
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
        else if (navigation.ProductGroupID > 0)
        {
            WebSession.NavigationID = navigation.ID;
            Server.Transfer("products.aspx?groupid=" + navigation.ProductGroupID);
        }
        else if (navigation.SingleMenuPage)
        {
            WebSession.NavigationID = navigation.ID;
            Server.Transfer("Objects.aspx");
        }
    }

    private void ProcessNavigationRedirection(string Path)
    {
        string path = "";
        if (Path == null)
            path = GetPath(Request.Url.AbsoluteUri);
        else
            path = GetPath(Path);
        Navigation navigation = Navigations.GetLatestByPath(path);
        if (navigation.ID > 0)
        {
            if (navigation.Path == path)
                NavigationRedirect(navigation);
            else
            {
                string lastSegment = path.Substring(path.LastIndexOf("/") + 1);
                if (!string.IsNullOrEmpty(lastSegment))
                {
                    if (navigation.ArticleScopeID > 0)
                    {
                        Article article = new Article(lastSegment);
                        if (article.ID > 0)
                        {
                            WebSession.ArticleID = article.ID;
                            Server.Transfer("Article.aspx?name=" + lastSegment);
                        }
                    }
                    if (navigation.SingleMenuPage)
                    {
                        lastSegment = path.Substring(path.IndexOf("objects/") + 8);
                        if (lastSegment.IndexOf(".gif") == -1)
                        {
                            string navigationName = "";
                            string pageNumber = "";
                            if (lastSegment.IndexOf("/") > -1)
                            {
                                navigationName = lastSegment.Substring(0, lastSegment.IndexOf("/"));
                                pageNumber = lastSegment.Substring(lastSegment.IndexOf("/") + 1);
                            }
                            else
                            {
                                Regex regex = new Regex("^\\d+$");
                                if (regex.IsMatch(lastSegment))
                                    pageNumber = lastSegment;
                                else
                                    navigationName = lastSegment;
                            }
                            string queryString = "";
                            if (!string.IsNullOrEmpty(navigationName))
                                queryString += "name=" + navigationName + "&";
                            if (!string.IsNullOrEmpty(pageNumber))
                                queryString += "page=" + pageNumber;

                            Navigation segmentNavigation = new Navigation(navigationName);
                            WebSession.NavigationID = segmentNavigation.ID > 0 ? segmentNavigation.ID : navigation.ID;
                            Server.Transfer("Objects.aspx?" + queryString);
                        }
                    }
                    if (!string.IsNullOrEmpty(navigation.Page))
                    {
                        string redirectUrl = navigation.Page + "?segment=" + lastSegment;
                        WebSession.NavigationID = navigation.ID;
                        Server.Transfer(redirectUrl);
                    }
                }
            }
        }
        else
        {
            string navAlias = path.Substring(path.LastIndexOf("/") + 1);
            Text text = new Text(navAlias);
            if (text.ID > 0)
            {
                WebSession.TextID = text.ID;
                Server.Transfer("texts.aspx?name=" + navAlias);
            }
        }


    }

    //private void ProcessArticleRedirection()
    //{
    //    if (Request.Url.AbsoluteUri.ToLower().IndexOf("/articleid/") > -1)
    //    {
    //        string articleAlias = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/articleid/") + 11);
    //        Article article = new Article(articleAlias);
    //        WebSession.ArticleID = article.ID;
    //        Server.Transfer("Article.aspx?name=" + articleAlias);
    //    }
    //}

    private void ProcessLanguage()
    {
        string url = Request.Url.AbsoluteUri;
        if (url.IndexOf("lang=") > -1)
        {
            string lang = url.Substring(url.IndexOf("lang=") + 5);
            WebSession.Language = lang;
            HttpCookie cookie = new HttpCookie("language", lang);
            cookie.Path = "/";
            Response.Cookies.Add(cookie);
            string path = url.Replace("/lang=" + lang, ""); 
            //Response.Redirect(path);
            if (GetPath(url).Replace("lang=" + lang, "") == "")
            {
                Server.Transfer("default.aspx");
            }
            ProcessNavigationRedirection(path);
            //string path = url.Substring(url.IndexOf("404;") + 4).Replace("/lang=" + lang, "");
           // Response.Redirect(path);
        }
    }

    //private void ProcessDownload()
    //{
    //    string url = Request.Url.AbsoluteUri;
    //    if(url.IndexOf("download:")>-1)
    //    {
    //        string fileName = url.Substring(url.IndexOf("download:") + 9);
    //        Server.Transfer("Download.aspx?item=" + fileName);
    //    }
    //}

    #endregion
}
