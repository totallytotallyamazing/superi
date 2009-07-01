using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;
using Superi.Features;

public partial class Controls_Match : System.Web.UI.UserControl
{
    #region Properties
    public bool Played
    {
        get
        {
            if (ViewState["played"] != null)
                return Convert.ToBoolean(ViewState["played"]);
            return false;
        }
        set { ViewState["played"] = value; }
    }

    public int HostCount
    {
        get
        {
            if (ViewState["hostCount"] != null)
                return Convert.ToInt32(ViewState["hostCount"]);
            return int.MinValue;
        }
        set { ViewState["hostCount"] = value; }
    }

    public int TeamCount
    {
        get
        {
            if (ViewState["teamCount"] != null)
                return Convert.ToInt32(ViewState["teamCount"]);
            return int.MinValue;
        }
        set { ViewState["teamCount"] = value; }
    }

    public string ImageUrl
    {
        get
        {
            if (ViewState["imageUrl"] != null)
                return Convert.ToString(ViewState["imageUrl"]);
            return null;
        }
        set { ViewState["imageUrl"] = value; }
    }

    public DateTime MatchDate
    {
        get
        {
            if (ViewState["matchDate"] != null)
                return Convert.ToDateTime(ViewState["matchDate"]);
            return DateTime.Now;
        }
        set { ViewState["matchDate"] = value; }
    }

    public int TeamTextId
    {
        get
        {
            if (ViewState["teamTextId"] != null)
                return Convert.ToInt32(ViewState["teamTextId"]);
            return 0;
        }
        set { ViewState["teamTextId"] = value; }
    }

    public int DescriptionTextID
    {
        get
        {
            if (ViewState["DescriptionTextID"] != null)
                return Convert.ToInt32(ViewState["DescriptionTextID"]);
            return 0;
        }
        set { ViewState["DescriptionTextID"] = value; }
    }
    #endregion

    protected string matchMainClass = "match";
    protected string matchAttributes = "";

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (MatchDate.Date == DateTime.Now.Date)
            matchMainClass = "currentMatch";
        if (Played)
            matchMainClass = "matchPlayed";
        if (TeamTextId > 0)
            lTeam.Text = new Resource(TeamTextId)[WebSession.Language];
        lDate.Text = MatchDate.ToString("dd.MM.yyyy");
        lMaestro.Text = "Маестро";
        if (HostCount > 0)
            lHostCount.Text = HostCount.ToString();
        if (TeamCount > 0)
            lTeamCount.Text = TeamCount.ToString();
        if (!string.IsNullOrEmpty(ImageUrl))
            iTeam.ImageUrl = WebSession.BaseImageUrl + "logos/" + ImageUrl;
        else
            iTeam.ImageUrl = WebSession.BaseImageUrl + "noLogo.png";
        if (DescriptionTextID > 0)
        {
            matchAttributes = "style=\"cursor:pointer\" onclick=\"displayDescription(" + DescriptionTextID + ")\"";
        }
    }
}
