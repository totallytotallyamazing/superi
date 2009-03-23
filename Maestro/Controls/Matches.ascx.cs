using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;

public partial class Controls_Matches : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GamesDataContext context = new GamesDataContext();
        var games = (from gms in context.Games orderby gms.Played, gms.Date descending
                    select new 
                    {
                        TeamTextId = gms.Team.NameTextId, 
                        Played = gms.Played, 
                        HostCount = gms.HostCount, 
                        TeamCount = gms.TeamCount, 
                        Date = gms.Date, 
                        Logo = gms.Team.Logo
                    }).Take(10);

        rMatches.DataSource = games;
        rMatches.DataBind();
    }
    protected void rMatches_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Controls_Match mMatch = (Controls_Match)e.Item.FindControl("mMatch");
        object dataItem = e.Item.DataItem;
        mMatch.TeamTextId = Convert.ToInt32(Tools.GetPropertyValue("TeamTextId", dataItem));
        mMatch.Played = Convert.ToBoolean(Tools.GetPropertyValue("Played", dataItem));
        mMatch.HostCount = Convert.ToInt32(Tools.GetPropertyValue("HostCount", dataItem));
        mMatch.TeamCount = Convert.ToInt32(Tools.GetPropertyValue("TeamCount", dataItem));
        mMatch.MatchDate = Convert.ToDateTime(Tools.GetPropertyValue("Date", dataItem));
        mMatch.ImageUrl = Convert.ToString(Tools.GetPropertyValue("Logo", dataItem));
    }
}