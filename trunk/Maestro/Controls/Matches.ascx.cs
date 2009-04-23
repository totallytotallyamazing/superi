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
        List<Game> games = context.Games.Select(gms => gms).OrderBy(gms => gms.Played).OrderByDescending(gms => gms.Date).Take(8).ToList<Game>();
        rMatches.DataSource = games;
        rMatches.DataBind();
    }

    protected void rMatches_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Controls_Match mMatch = (Controls_Match)e.Item.FindControl("mMatch");
        Game dataItem = (Game)e.Item.DataItem;
        mMatch.TeamTextId = (dataItem.Team.NameTextId!=null)?dataItem.Team.NameTextId.Value:int.MinValue;
        mMatch.Played = dataItem.Played;
        mMatch.HostCount = (dataItem.HostCount!=null)?dataItem.HostCount.Value:int.MinValue;
        mMatch.TeamCount = (dataItem.TeamCount!=null)?dataItem.TeamCount.Value:int.MinValue;
        mMatch.MatchDate = dataItem.Date.Value;
        mMatch.ImageUrl = dataItem.Team.Logo;
        mMatch.DescriptionTextID = dataItem.DetailsTextID;
    }
}