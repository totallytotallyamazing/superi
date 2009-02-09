using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Match : System.Web.UI.UserControl
{
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
            return 0;
        }
        set { ViewState["hostCount"] = value; }
    }

    public int TeamCount
    {
        get
        {
            if (ViewState["teamCount"] != null)
                return Convert.ToInt32(ViewState["teamCount"]);
            return 0;
        }
        set { ViewState["teamCount"] = value; }
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

    protected string matchMainClass = "match";

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Played)
            matchMainClass = "matchPlayed";
        if(TeamTextId>0)
        {
            GamesDataContext context = new GamesDataContext();
            Team team = from t = context.Teams 
        }
    }
}
