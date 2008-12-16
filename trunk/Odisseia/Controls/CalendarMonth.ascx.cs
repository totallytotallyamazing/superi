using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Controls_CalendarMonth : System.Web.UI.UserControl
{
    public delegate void DateChangedEventHandler(object sender, EventArgs e);
    public event DateChangedEventHandler DateChanged;

    protected virtual void OnDateChanged(EventArgs e)
    {
        if (DateChanged != null)
            DateChanged(this, e);
    }

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
        set 
        { 
            ViewState["year"] = value;
            OnDateChanged(new EventArgs());
        }
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
        PublishCalendar();
    }

    private void PublishCalendar()
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
        lMonth.Text = GetMonthName(Month);
    }

    protected void rWednesday_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            LinkButton lbDay = (LinkButton)e.Item.FindControl("lbDay");
            PlaceHolder phSelectedDate = (PlaceHolder)e.Item.FindControl("phSelectedDate");
            int day = (int)e.Item.DataItem;
            if (SelectedDate.Day == day && SelectedDate.Month == Month)
                phSelectedDate.Visible = true;
            lbDay.Text = day.ToString();
            lbDay.CommandArgument = day.ToString();
            lbDay.Click += new EventHandler(lbDay_Click);
        }
        
    }

    void lbDay_Click(object sender, EventArgs e)
    {
        LinkButton lbDay = (LinkButton) sender;
        SelectedDate = new DateTime(Year, Month, Convert.ToInt32(lbDay.CommandArgument));
        PublishCalendar();
        OnDateChanged(e);
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

    private string GetMonthName(int Month)
    {
        switch (Month)
        {
            case 1:
                return "январь";
            case 2:
                return "февраль";
            case 3:
                return "март";
            case 4:
                return "апрель";
            case 5:
                return "май";
            case 6:
                return "июнь";
            case 7:
                return "июль";
            case 8:
                return "август";
            case 9:
                return "сентябрь";
            case 10:
                return "октябрь";
            case 11:
                return "ноябрь";
            case 12:
                return "декабрь";
            default:
                return string.Empty;
        }
    }
}
