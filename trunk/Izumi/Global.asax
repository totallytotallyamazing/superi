<%@ Application Language="C#" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

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

    protected void Application_BeginRequest(Object sender, EventArgs e)
    {

        //ProcessTextRedirection();
        //ProcessNavigationRedirection();
        //ProcessNewsPagesRedirection();
        //ProcessNewsRedirection();

    }


    #region Redirection processors
/*
    void ProcessTextRedirection()
    {
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("/text/") > -1)
        {
            //Response.Write(Request.Url.AbsoluteUri);
            string textAlias = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/text/") + 6);   //Request.Url.Segments[Request.Url.Segments.Length - 1];
            Context.RewritePath("texts.aspx?name=" + textAlias);
        }
    }
*/

/*
    void ProcessNavigationRedirection()
    {
     //   if (Request.Url.AbsoluteUri.ToLower().IndexOf("/navigation/") > -1)
        {
            //Response.Write(Request.Url.AbsoluteUri);

            string navAlias = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.LastIndexOf("/")+1);

            Superi.Features.Navigation navigation = new Superi.Features.Navigation(navAlias);
            if (navigation.ID > 0)
            {
                if (navigation.TextID > 0)
                {
                    Superi.Features.Text text = new Superi.Features.Text(navigation.TextID);
                    Context.RewritePath("texts.aspx?name=" + text.Alias + "&nid=" + navigation.ID);
                }
                else if (!string.IsNullOrEmpty(navigation.Page))
                {
                    string redirectUrl = navigation.Page;
                    if (redirectUrl.IndexOf("?") > -1)
                        redirectUrl += "&nid=" + navigation.ID;
                    else
                        redirectUrl += "?nid=" + navigation.ID;
                    Context.RewritePath(redirectUrl);
                }
                else if (navigation.ArticleScopeID > 0)
                {
                    Context.RewritePath("articles.aspx?scopeid=" + navigation.ArticleScopeID + "&nid=" + navigation.ID);
                }
            }
        }
    }
*/

/*
    void ProcessNewsPagesRedirection()
    {
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("/page/") > -1)
        {
            string pageNumber = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/page/") + 6);   //Request.Url.Segments[Request.Url.Segments.Length - 1];
            Context.RewritePath("default.aspx?page=" + pageNumber);
        }
    }
*/

/*
    void ProcessNewsRedirection()
    {
        if (Request.Url.AbsoluteUri.ToLower().IndexOf("/news/") > -1)
        {
            string newsItemAlias = Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.ToLower().IndexOf("/news/") + 6);   //Request.Url.Segments[Request.Url.Segments.Length - 1];
            Context.RewritePath("NewsItem.aspx?name=" + newsItemAlias);
        }
    }
*/
    #endregion
       
</script>
