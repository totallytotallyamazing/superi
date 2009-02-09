using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Matches : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GamesDataContext context = new GamesDataContext();
        var games = from gms in context.Games select new {gms.ID, gms.Team.NameTextId, gms.Played, gms.HostCount, gms.TeamCount, gms.Date};
        
        //foreach (var item in games)
        //{
            
        //}
    }
}