<%@ Application Language="C#" %>
<%@ Import Namespace="Superi.Features" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        //if (!FileExists())
        //{
        //    ProcessLanguage();
        //    //WebSession.TextID = int.MinValue;
        //    //WebSession.ArticleID = int.MinValue;
        //    //WebSession.NavigationID = int.MinValue;
        //    ProcessNavigationRedirection(null);
        //}
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    private bool FileExists()
    {
        bool result = false;
        string filePath = Server.MapPath(Request.Url.AbsolutePath);
        result = File.Exists(filePath);
        if (!result)
            result = File.Exists(filePath + "default.aspx");
        return result;
    }

    private string GetPath(string Url)
    {
        string url = Url.Substring(Url.IndexOf(";") + 1);
        Uri uri = new Uri(url);
        string result = uri.AbsolutePath;
        if (result.ToLower().IndexOf("/lermont/") != -1)
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
            //WebSession.NavigationID = navigation.ID;
            Context.RewritePath("texts.aspx?nid=" + navigation.ID + "&name=" + text.Alias);
            //Server.Transfer("texts.aspx?nid=" + navigation.ID + "&name=" + text.Alias);
        }
        else if (!string.IsNullOrEmpty(navigation.Page))
        {
            string redirectUrl = navigation.Page;
            //WebSession.NavigationID = navigation.ID;
            Response.Redirect(redirectUrl);
        }
        else if (navigation.ArticleScopeID > 0)
        {
            //WebSession.NavigationID = navigation.ID;
            Server.Transfer("articles.aspx?scopeid=" + navigation.ArticleScopeID);
        }
        else if (navigation.ProductGroupID > 0)
        {
           // WebSession.NavigationID = navigation.ID;
            Server.Transfer("products.aspx?nid=" + navigation.ID + "&groupid=" + navigation.ProductGroupID);
        }
        else if (navigation.SingleMenuPage)
        {
            //WebSession.NavigationID = navigation.ID;
            Server.Transfer("Objects.aspx?nid=" + navigation.ID);
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
                            //WebSession.ArticleID = article.ID;
                            Server.Transfer("Article.aspx?aid=" + article.ID + "&name=" + lastSegment);
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
                            int navigationId = segmentNavigation.ID > 0 ? segmentNavigation.ID : navigation.ID;
                            //WebSession.NavigationID = segmentNavigation.ID > 0 ? segmentNavigation.ID : navigation.ID;
                            Server.Transfer("Objects.aspx?nid=" + navigationId + "&" + queryString);
                        }
                    }
                    if (!string.IsNullOrEmpty(navigation.Page))
                    {
                        string redirectUrl = navigation.Page + "?nid=" + navigation.ID + "&segment=" + lastSegment;
                        //WebSession.NavigationID = navigation.ID;
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
                //WebSession.TextID = text.ID;
                Server.Transfer("texts.aspx?tid=" + text.ID + "&name=" + navAlias);
            }
        }


    }

    private void ProcessLanguage()
    {
        string url = Request.Url.AbsoluteUri;
        if (url.IndexOf("lang=") > -1)
        {
            string lang = url.Substring(url.IndexOf("lang=") + 5);
           // WebSession.Language = lang;
            HttpCookie cookie = new HttpCookie("language", lang);
            cookie.Path = "/";
            Response.Cookies.Add(cookie);
            string path = url.Replace("/lang=" + lang, ""); //url.Substring(url.IndexOf("404;") + 4).Replace("/lang=" + lang, "");
            ProcessNavigationRedirection(path);
        }
    }
       
</script>
