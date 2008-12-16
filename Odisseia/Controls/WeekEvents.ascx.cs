using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Controls_WeekEvents : System.Web.UI.UserControl
{
    public DateTime CurrentDate
    {
        get 
        {
            if (ViewState["date"] == null)
                return DateTime.Today;
            return Convert.ToDateTime(ViewState["date"]);
        }
        set { ViewState["date"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        PublishControl();
    }

    private void PublishControl()
    {
        int substractDays;
        if (((int)(CurrentDate.DayOfWeek)) == 0)
            substractDays = -6;
        else
        {
            substractDays = -((int)(CurrentDate.DayOfWeek))+1;
        }
        DateTime firstDate = CurrentDate.AddDays(substractDays);
        ArrayList dataSource = new ArrayList();
        dataSource.Add(firstDate);
        for (int i = 1; i < 7; i++)
        {
            dataSource.Add(firstDate.AddDays(i));
        }
        rDays.DataSource = dataSource;
        rDays.DataBind();
    }

    protected void rDays_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Controls_ThisDay tdDate = (Controls_ThisDay)e.Item.FindControl("tdDate");
        DateTime date = (DateTime)e.Item.DataItem;
        tdDate.Date = date;
    }
}
