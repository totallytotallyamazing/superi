using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OboutInc.Flyout2;
using Superi.Features;

public enum DayDisplayMode { Large, Small }

public partial class Controls_ThisDay : System.Web.UI.UserControl
{
    public DayDisplayMode Mode
    {
        get 
        {
            if (ViewState["mode"] == null)
                return DayDisplayMode.Small;
            return (DayDisplayMode)ViewState["mode"];
        }
        set { ViewState["mode"] = value; }
    }

    public DateTime Date
    {
        get
        {
            if (ViewState["date"] == null)
                return DateTime.Today;
            return (DateTime)ViewState["date"];
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
        switch (Mode)
        { 
            case DayDisplayMode.Large:
                pDay.Visible=false;
                pDate.CssClass = "todayDateLarge";
                pHolidays.CssClass = "todayHolidaysLarge";
                break;
        }

        lDay.Text = GetDayName(Date);
        lMonth.Text = GetMonthName(Date);
        lDate.Text = Date.Day.ToString();
        DateTime startDateFrom = new DateTime(1900, Date.Month, Date.Day, 0, 0, 0);
        DateTime startDateTo = new DateTime(1900, Date.Month, Date.Day, 23, 59, 59);
        EventList holdays = new EventList(null, null, null, startDateFrom, startDateTo, null, null);
        rHolidays.DataSource = holdays;
        rHolidays.DataBind();
    }

    private string GetMonthName(DateTime Date)
    {
        switch (Date.Month)
        { 
            case 1:
                return "января";
            case 2:
                return "февраля";
            case 3:
                return "марта";
            case 4:
                return "апреля";
            case 5:
                return "мая";
            case 6:
                return "июня";
            case 7:
                return "июля";
            case 8:
                return "августа";
            case 9:
                return "сентября";
            case 10:
                return "октября";
            case 11:
                return "ноября";
            case 12:
                return "декабря";
            default:
                return string.Empty;
        }
    }

    protected void rHolidays_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Flyout fDescription = (Flyout)e.Item.FindControl("fDescription");
        Literal lDescription = (Literal)fDescription.FindControl("lDescription");
        HyperLink hlHoliday = (HyperLink)e.Item.FindControl("hlHoliday");
        Event holiday = (Event)e.Item.DataItem;
        hlHoliday.Text = holiday.Name;
        lDescription.Text = holiday.Description;
    }

    private string GetDayName(DateTime Date)
    {
        switch (Date.DayOfWeek)
        { 
            case DayOfWeek.Monday:
                return "Пон.";
            case DayOfWeek.Tuesday:
                return "Втр.";
            case DayOfWeek.Wednesday:
                return "Срд.";
            case DayOfWeek.Thursday:
                return "Чтв.";
            case DayOfWeek.Friday:
                return "Птн.";
            case DayOfWeek.Saturday:
                return "Суб.";
            case DayOfWeek.Sunday:
                return "Вск.";
            default:
                return string.Empty;
        }
    }
}
