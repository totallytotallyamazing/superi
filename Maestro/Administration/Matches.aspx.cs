using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Reflection;
using System.Globalization;
using Superi.Common;
using Superi.CustomControls;
//using System.

public partial class Administration_Matches : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbCreate.Attributes.Add("onclick", "return false;");
    }

    private void PublishTeamsDropDown()
    {
        ddlTeams.Items.Clear();
        GamesDataContext context = new GamesDataContext();
        var teams = from tms in context.Teams select new { tms.ID, tms.Names };

        foreach (var item in teams)
        {
            ddlTeams.Items.Add(new ListItem(item.Names["RU"], item.ID.ToString()));
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        DataList1.DataBind();
        GridView1.DataBind();
        PublishTeamsDropDown();
    }

    protected void bCreate_Click(object sender, EventArgs e)
    {
        Team team = new Team();
        team.NameTextId = reName.Values.Save();
        team.Logo = fuLogo.Save();
        GamesDataContext context = new GamesDataContext();
        context.Teams.InsertOnSubmit(team);
        context.SubmitChanges();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "DeleteTeam":
                int teamId = Convert.ToInt32(e.CommandArgument);
                GamesDataContext context = new GamesDataContext();
                Team team = context.Teams.SingleOrDefault(f => f.ID == teamId);
                context.Teams.DeleteOnSubmit(team);
                context.SubmitChanges();
                break;
            case "EditName":
                GridView1.EditIndex = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex;
                break;
        }
    }

    protected void lbAdd_Click(object sender, EventArgs e)
    {
        GamesDataContext context = new GamesDataContext();
        Game game = new Game();
        CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");
        game.Date = DateTime.Parse(tbAddDate.Text, culture);
        game.Played = cbPlayed.Checked;
        if (!string.IsNullOrEmpty(tbHostCount.Text))
            game.HostCount = int.Parse(tbHostCount.Text);
        if (!string.IsNullOrEmpty(tbTeamCount.Text))
            game.TeamCount = int.Parse(tbTeamCount.Text);
        game.TeamID = int.Parse(ddlTeams.SelectedValue);
        game.HostCommentsTextID = reHostComments.ResourceId;
        game.TeamCommentsTextID = reTeamComments.ResourceId;
        game.HostFaultsTextID = reHostFaults.ResourceId;
        game.TeamFaultsTextID = reTeamFaults.ResourceId;
        game.DetailsTextID = int.MinValue;
        context.Games.InsertOnSubmit(game);
        context.SubmitChanges();
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Team team = (Team)Tools.GetPropertyValue("Team", e.Item.DataItem);
            Label lTeam = (Label)e.Item.FindControl("lTeam");
            Image iTeamLogo = (Image)e.Item.FindControl("iTeamLogo");
            LinkButton lbEditDescription = (LinkButton)e.Item.FindControl("lbEditDescription");
            lbEditDescription.Attributes.Add("onclick", "SetAction('EditDescription')");
            iTeamLogo.ImageUrl = WebSession.BaseImageUrl + "Logos/" + team.Logo;
            lTeam.Text = team.Names["RU"];
        }
        if (e.Item.ItemType == ListItemType.EditItem)
        {
            DropDownList ddlTeams = (DropDownList)e.Item.FindControl("ddlTeams");
            HiddenField hfTeamId = (HiddenField)e.Item.FindControl("hfTeamId");
            GamesDataContext context = new GamesDataContext();
            var teams = from tms in context.Teams select new { tms.ID, tms.Names };

            foreach (var item in teams)
                ddlTeams.Items.Add(new ListItem(item.Names["RU"], item.ID.ToString()));
            ddlTeams.SelectedValue = hfTeamId.Value;
        }
    }

    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        int gameId = Convert.ToInt32(e.CommandArgument);
        TextBox tbHostCount = (TextBox)e.Item.FindControl("tbHostCount");
        TextBox tbTeamCount = (TextBox)e.Item.FindControl("tbTeamCount");
        DropDownList ddlTeams = (DropDownList)e.Item.FindControl("ddlTeams");
        TextBox tbDate = (TextBox)e.Item.FindControl("tbDate");
        CheckBox cbPlayed = (CheckBox)e.Item.FindControl("cbPlayed");
        ResourceEditor reHostComments = (ResourceEditor)e.Item.FindControl("reHostComments");
        ResourceEditor reTeamComments = (ResourceEditor)e.Item.FindControl("reTeamComments");
        ResourceEditor reHostFaults = (ResourceEditor)e.Item.FindControl("reHostFaults");
        ResourceEditor reTeamFaults = (ResourceEditor)e.Item.FindControl("reTeamFaults");
        GamesDataContext context = new GamesDataContext();
        var game = context.Games.SingleOrDefault(f => f.ID == gameId);
        CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");
        game.Date = DateTime.Parse(tbDate.Text, culture);
        game.Played = cbPlayed.Checked;
        game.HostCommentsTextID = reHostComments.ResourceId;
        game.TeamCommentsTextID = reTeamComments.ResourceId;
        game.HostFaultsTextID = reHostFaults.ResourceId;
        game.TeamFaultsTextID = reTeamFaults.ResourceId;
        if (!string.IsNullOrEmpty(tbHostCount.Text))
            game.HostCount = int.Parse(tbHostCount.Text);
        else
            game.HostCount = null;
        if (!string.IsNullOrEmpty(tbTeamCount.Text))
            game.TeamCount = int.Parse(tbTeamCount.Text);
        else
            game.TeamCount = null;
        game.TeamID = int.Parse(ddlTeams.SelectedValue);
        context.SubmitChanges();
        DataList1.EditItemIndex = -1;
    }

    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = e.Item.ItemIndex;
    }

    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        int gameId = Convert.ToInt32(e.CommandArgument);
        GamesDataContext context = new GamesDataContext();
        var game = context.Games.SingleOrDefault(f => f.ID == gameId);
        context.Games.DeleteOnSubmit(game);
        context.SubmitChanges();
    }

    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = -1;
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if(e.CommandName=="EditDescription")
        {
            int gameID = Convert.ToInt32(e.CommandArgument);
            GamesDataContext context = new GamesDataContext();
            Game game = context.Games.SingleOrDefault(f => f.ID == gameID);
            reDetails.TextID = game.DetailsTextID;
            hfGameId.Value = gameID.ToString();
        }
    }

    protected void bSaveDescription_Click(object source, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hfGameId.Value))
        {
            int gameID = int.Parse(hfGameId.Value);
            GamesDataContext context = new GamesDataContext();
            Game game = context.Games.SingleOrDefault(f => f.ID == gameID);
            game.DetailsTextID = reDetails.ResourceId;
            context.SubmitChanges();
        }
    }
}