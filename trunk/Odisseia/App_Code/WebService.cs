using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections;
using Superi.Features;
using System.Web.UI;
using System.Runtime.Serialization.Json;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WebService : System.Web.Services.WebService
{
    [WebMethod]
    public EventList GetHolidays()
    {
        return new EventList(true);
    }

    [WebMethod]
    public EventList FilterHolidays(string Filter)
    {
        EventList result = new EventList(false);
        foreach (Event ev in new EventList(true))
        {
            if (ev.Name.ToLower().IndexOf(Filter) > -1)
                result.Add(ev);
        }
        return result;
    }

}