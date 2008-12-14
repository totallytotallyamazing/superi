using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Controls_CalendarMonth : System.Web.UI.UserControl
{
    public DateTime SelectedDate
    {
        get
        {
            if (ViewState["selectedDate"] == null)
                return DateTime.Now;
            return Convert.ToDateTime(ViewState["selectedDate"]);
        }
        set { ViewState["selectedDate"] = value; }
    }

    public int Year
    {
        get 
        {
            if (ViewState["year"] == null)
                return DateTime.Today.Year;
            return Convert.ToInt32(ViewState["year"]);
        }
        set { ViewState["year"] = value; }
    }

    public int Month
    {
        get
        {
            if (ViewState["month"] == null)
                return DateTime.Today.Month;
            return Convert.ToInt32(ViewState["month"]);
        }
        set { ViewState["month"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        rMonday.DataSource = GenerateWeek(1);
        rMonday.DataBind();
        rTuesday.DataSource = GenerateWeek(2);
        rTuesday.DataBind();
        rWednesday.DataSource = GenerateWeek(3);
        rWednesday.DataBind();
        rThursday.DataSource = GenerateWeek(4);
        rThursday.DataBind();
        rFriday.DataSource = GenerateWeek(5);
        rFriday.DataBind();
        rSaturday.DataSource = GenerateWeek(6);
        rSaturday.DataBind();
        rSunday.DataSource = GenerateWeek(7);
        rSunday.DataBind();
    }

    protected void rWednesday_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            HyperLink hlDay = (HyperLink)e.Item.FindControl("hlDay");
            int day = (int)e.Item.DataItem;
            hlDay.Text = day.ToString();
        }
        
    }

    private ArrayList GenerateWeek(int DayNumber)
    {
        ArrayList result = new ArrayList();
        DateTime date = new DateTime(Year, Month, 1);
        DateTime firstDay = date.AddDays(DayNumber - (int)date.DayOfWeek);
        for (int i = 0; i < 5; i++)
        {
            if (firstDay.Month != Month)
                result.Add(null);
            else
                result.Add(firstDay.Day);
            firstDay = firstDay.AddDays(7);
        }
        return result;
    }
}
