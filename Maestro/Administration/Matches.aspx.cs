using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Matches : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbCreate.Attributes.Add("onclick", "return false;");
        GamesDataContext context = new GamesDataContext();
        var teams = from tms in context.Teams select new { tms.ID, tms.Names };
        
        foreach (var item in teams)
        {
            ddlTeams.Items.Add(new ListItem(item.Names["RU"], item.ID.ToString())); 
        }
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            System.Reflection.in
            Label lName = (Label)e.Row.FindControl("lName");
            Team team = (Team)e.Row.DataItem;
            lName.Text = team.Names["RU"];
        }
    }
}
