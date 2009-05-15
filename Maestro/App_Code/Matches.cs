using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Superi.Common;
using Superi.Features;

/// <summary>
/// Summary description for Matches
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class Matches : System.Web.Services.WebService
{
    [WebMethod]
    public object GetArchive(string Language)
    {
        GamesDataContext context = new GamesDataContext();

        var games = (from gms in context.Games
                     where gms.Played
                     orderby gms.Played, gms.Date descending
                     select new
                     {
                         gms.ID,
                         TeamName = gms.Team.Names[Language],
                         HostCount = gms.HostCount,
                         TeamCount = gms.TeamCount,
                         Date = gms.Date,
                         DateString = gms.Date.Value.Year.ToString() + gms.Date.Value.Month.ToString() + gms.Date.Value.Day.ToString(),
                         Logo = WebSession.BaseImageUrl + "Logos/" + gms.Team.Logo
                     });//.ToDictionary(gms => gms.Date.Value.Year.ToString() + gms.Date.Value.Month.ToString() + gms.Date.Value.Day.ToString());

        return games.ToList();
    }

    [WebMethod]
    public string GetDescription(int DescriptionID, string Language)
    {
        string result = "";
        Resource resource = new Resource(DescriptionID);
        if(resource.Items.Count>0 && resource[Language]!=null)
            result = resource[Language];
        return result;
    }
}

