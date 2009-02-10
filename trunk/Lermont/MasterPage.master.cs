using System;
using Superi.Features;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private string _MetaTags = "";

    protected string CurrentUrl
    {
        get
        {
            if (Request.Url.AbsoluteUri.IndexOf("404;")>-1)
                return Request.Url.AbsoluteUri.Substring(Request.Url.AbsoluteUri.IndexOf("404;") + 4).Replace("/lang="+WebSession.Language, "");
            return Request.Url.AbsoluteUri;
        }
    }

    protected string MetaTags
    {
        get { return _MetaTags; }
        set { _MetaTags = value; }
    }

    private void ResetSessionValues()
    {
        WebSession.TextID = int.MinValue;
        WebSession.NavigationID = int.MinValue;
        WebSession.ArticleID = int.MinValue;
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptInclude("master",WebSession.BaseUrl + "js/master.js");
        Page.ClientScript.RegisterClientScriptInclude("jquery", WebSession.BaseUrl + "js/jquery.js");
        Page.ClientScript.RegisterClientScriptInclude("pngFix", WebSession.BaseUrl + "js/jquery.pngFix.js");
        Page.ClientScript.RegisterClientScriptInclude("galleria", WebSession.BaseUrl + "js/jquery.galleria.js");
        Page.ClientScript.RegisterClientScriptInclude("fancybox", WebSession.BaseUrl + "js/jquery.fancybox.js");

        HtmlLink global = new HtmlLink();
        global.Attributes["rel"] = "Stylesheet";
        global.Href = WebSession.BaseUrl + "css/global.css";
        Page.Header.Controls.Add(global);

        HtmlLink fancy = new HtmlLink();
        fancy.Attributes["rel"] = "Stylesheet";
        fancy.Href = WebSession.BaseUrl + "css/fancy.css";
        Page.Header.Controls.Add(fancy);

        /*
            <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/global.css" %>" />
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/fancy.css" %>" />
    <script type="text/javascript" src="<%= WebSession.BaseUrl %>js/jquery.js"></script>
    <script type="text/javascript" src="<%= WebSession.BaseUrl %>js/jquery.pngFix.js"></script>
    <script type="text/javascript" src="<%= WebSession.BaseUrl %>js/jquery.fancybox.js"></script>
         */

    }

    private void PublishSessionValues()
    {
        ResetSessionValues();
        if (!string.IsNullOrEmpty(Request.QueryString["nid"]))
            WebSession.NavigationID = Convert.ToInt32(Request.QueryString["nid"]);
        if (!string.IsNullOrEmpty(Request.QueryString["aid"]))
            WebSession.ArticleID = Convert.ToInt32(Request.QueryString["aid"]);
        if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
            WebSession.TextID = Convert.ToInt32(Request.QueryString["tid"]);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    { 
        if (Membership.GetUser() == null)
        {
            pLoginStatus.Visible = false;
            pLogin.Visible = true;
        }
        else
        {
            pLogin.Visible = false;
            pLoginStatus.Visible = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //bLogOut.Attributes.Add("onclick", "return logOut()");
        bLogin.Attributes.Add("onclick", "return logIn()");
        if (WebSession.NavigationID > 0)
        {
            Navigation navigation = new Navigation(WebSession.NavigationID);
            if (!string.IsNullOrEmpty(navigation.Description))
                MetaTags += "<meta name=\"description\" content=\"" + navigation.Description + "\" />" + Environment.NewLine;
            if (!string.IsNullOrEmpty(navigation.Keywords))
                MetaTags += "<meta name=\"keywords\" content=\"" + navigation.Keywords + "\" />" + Environment.NewLine;

            if (navigation.Texts != null && navigation.Texts.Items.Count > 0)
                Page.Title = navigation.Texts[WebSession.Language];
            else if (!string.IsNullOrEmpty(navigation.Text))
                Page.Title = navigation.Text;
        }
        else if (WebSession.TextID > 0)
       {
            Text text = new Text(WebSession.TextID);
            if (text.Names != null && text.Names.Items.Count > 0)
                Page.Title = text.Names[WebSession.Language];
            else
                Page.Title = text.Name;
        }
        else if(WebSession.ArticleID>0)
        {
            Article article = new Article(WebSession.ArticleID);
            if (article.Titles != null && article.Titles.Items.Count > 0)
                Page.Title = article.Titles[WebSession.Language];
            else
                Page.Title = article.Title;
        }
    }
    protected void bLogOut_Click(object sender, EventArgs e)
    {
        //FormsAuthentication.SignOut();
    }
    protected void bRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Register.aspx");
    }
}