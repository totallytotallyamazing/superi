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
}
