﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
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
            case DayDisplayMode.Small:
                pDay.Visible = true;
                pDate.CssClass = "todayDateSmall";
                pHolidays.CssClass = "todayHolidaysSmall";
                break;
        }

        lDay.Text = GetDayName(Date);
        lMonth.Text = CommonTools.GetMonthName(Date.Month, false);
        lDate.Text = Date.Day.ToString();
        DateTime startDateFrom = new DateTime(1900, Date.Month, Date.Day, 0, 0, 0);
        DateTime startDateTo = new DateTime(1900, Date.Month, Date.Day, 23, 59, 59);
        EventList holdays = new EventList(null, null, null, startDateFrom, startDateTo, null, null);
        rHolidays.DataSource = holdays;
        rHolidays.DataBind();
    }

    protected void rHolidays_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal lDescription = (Literal)e.Item.FindControl("lDescription");
        HtmlGenericControl divDescription = (HtmlGenericControl)e.Item.FindControl("divDescription");
        HyperLink hlHoliday = (HyperLink)e.Item.FindControl("hlHoliday");
        hlHoliday.Attributes.Add("onclick", "showDescription('" + divDescription.ClientID + "', this)");
        hlHoliday.Attributes.Add("onmouseover", "descriptionMouseOver()");
        hlHoliday.Attributes.Add("onmouseout", "descriptionMouseOut('" + divDescription.ClientID + "')");
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
