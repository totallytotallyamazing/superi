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

    protected void ShowArchive(object sender, EventArgs e)
    {

        GamesDataContext context = new GamesDataContext();
        var games = from gms in context.Games
                    orderby gms.Date descending
                    select new
                    {
                        TeamTextId = gms.Team.NameTextId,
                        HostCount = gms.HostCount,
                        TeamCount = gms.TeamCount,
                        Date = gms.Date,
                        Logo = gms.Team.Logo,
                        TeamComments = gms.TeamComments,
                        HostComments = gms.HostComments,
                        TeamFaults = gms.TeamFaults,
                        HostFaults = gms.HostFaults
                    };

        rMatches.DataSource = games;
        rMatches.DataBind();
        hfShowArchive.Value = "1";
    }
    
    protected void Page_Init(object sender, EventArgs e)
   {
      // smMain.ScriptPath = Request.Url.GetLeftPart(UriPartial.Scheme) + Request.Url.Host + WebSession.VirtualDirectoryName + "Ajax";
       smMain.Services.Add(new ServiceReference(Request.Url.GetLeftPart(UriPartial.Scheme) + Request.Url.Host + WebSession.VirtualDirectoryName + "Services/Matches.asmx"));
        
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

    protected void rMatches_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal lHostCount = (Literal)e.Item.FindControl("lHostCount");
        Literal lTeamCount = (Literal)e.Item.FindControl("lTeamCount");
        Literal lDate = (Literal)e.Item.FindControl("lDate");
        Literal lTeamName = (Literal)e.Item.FindControl("lTeamName");
        Literal lHostGoals = (Literal)e.Item.FindControl("lHostGoals");
        Literal lTeamGoals = (Literal)e.Item.FindControl("lTeamGoals");
        Literal lHostFaults = (Literal)e.Item.FindControl("lHostFaults");
        Literal lTeamFaults = (Literal)e.Item.FindControl("lTeamFaults");
        object dataItem = e.Item.DataItem;
        Resource teamName = new Resource(Convert.ToInt32(Tools.GetPropertyValue("TeamTextId", dataItem)));
        lTeamName.Text = teamName[WebSession.Language];
        lHostCount.Text = Convert.ToInt32(Tools.GetPropertyValue("HostCount", dataItem)).ToString();
        lTeamCount.Text = Convert.ToInt32(Tools.GetPropertyValue("TeamCount", dataItem)).ToString();
        lDate.Text = Convert.ToDateTime(Tools.GetPropertyValue("Date", dataItem)).ToString("dd.MM.yyyy");
        Resource teamGoals = Tools.GetPropertyValue("TeamComments", dataItem) as Resource;
        Resource hostGoals = Tools.GetPropertyValue("HostComments", dataItem) as Resource;
        Resource teamFaults = Tools.GetPropertyValue("TeamFaults", dataItem) as Resource;
        Resource hostFaults = Tools.GetPropertyValue("HostFaults", dataItem) as Resource;
        if (hostGoals.Items.Count > 0)
            lHostGoals.Text = hostGoals[WebSession.Language];
        if (teamGoals.Items.Count > 0)
            lTeamGoals.Text = teamGoals[WebSession.Language];
        if (hostFaults.Items.Count > 0)
            lHostFaults.Text = hostFaults[WebSession.Language];
        if (teamFaults.Items.Count > 0)
            lTeamFaults.Text = teamFaults[WebSession.Language];
    }
}
