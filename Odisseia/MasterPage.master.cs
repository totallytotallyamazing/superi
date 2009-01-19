using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using Superi.Features;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibHoliday_Click(object sender, EventArgs e)
    {
        pHolidays.Visible = true;
    }

    [WebMethod]
    public static string GetHolidays(string str)
    {
        return str;
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
        return str;
        //return result;
    }
}
