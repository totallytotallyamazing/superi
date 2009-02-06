using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Globalization;
using Superi.Common;

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

    private object GetPropertyValue(string PropertyName, object Item)
    {

        Type type = Item.GetType();
        BindingFlags flags = BindingFlags.GetProperty;
        object value = type.InvokeMember(PropertyName, flags, null, Item, null);
        return value;
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
        int teamId = Convert.ToInt32(e.CommandArgument);
        GamesDataContext context = new GamesDataContext();
        Team team = context.Teams.SingleOrDefault(f => f.ID == teamId);
        context.Teams.DeleteOnSubmit(team);
        context.SubmitChanges();
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
        context.Games.InsertOnSubmit(game);
        context.SubmitChanges();
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Team team = (Team)GetPropertyValue("Team", e.Item.DataItem);
            Label lTeam = (Label)e.Item.FindControl("lTeam");
            Image iTeamLogo = (Image)e.Item.FindControl("iTeamLogo");
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
        GamesDataContext context = new GamesDataContext();
        var game = context.Games.SingleOrDefault(f => f.ID == gameId);
        CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");
        game.Date = DateTime.Parse(tbDate.Text, culture);
        game.Played = cbPlayed.Checked;
        if (!string.IsNullOrEmpty(tbHostCount.Text))
            game.HostCount = int.Parse(tbHostCount.Text);
        else
            game.HostCount = null;
        if (!string.IsNullOrEmpty(tbTeamCount.Text))
            game.TeamCount = int.Parse(tbTeamCount.Text);
        else
            game.TeamCount = null;
        game.TeamID = int.Parse(ddlTeams.SelectedValue);
       // context.Games.Attach(game, true);
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
}