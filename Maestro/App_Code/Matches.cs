﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Superi.Common;

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
        
        var games = from gms in context.Games where gms.Played
                    orderby gms.Played, gms.Date descending
                    select new
                    {
                        TeamName = gms.Team.Names[Language],
                        HostCount = gms.HostCount,
                        TeamCount = gms.TeamCount,
                        Date = gms.Date,
                        Logo = WebSession.BaseImageUrl + "Logos/" + gms.Team.Logo
                    };

        return games.ToList();
        
    }

}

