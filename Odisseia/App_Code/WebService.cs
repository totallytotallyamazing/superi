using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections;
using Superi.Features;
using System.Web.UI;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WebService : System.Web.Services.WebService
{
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public Hashtable GetHolidays()
    {
        //return str;
        Hashtable result = new Hashtable();
        char oldLetter = '#';
        char newLetter;
        EventList holidays = new EventList(true);
        foreach (Event holiday in holidays)
        {
            newLetter = holiday.Name[0];
            Pair pair = new Pair();
            pair.First = holiday.Name;
            pair.Second = holiday.Id;
            if (oldLetter != newLetter)
                oldLetter = newLetter;
            result[oldLetter] = pair;
        }
        //return str;
        return result;
    }

}

