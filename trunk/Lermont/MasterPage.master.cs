using System;
using Superi.Features;
using System.Web.Security;

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