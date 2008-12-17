using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Holidays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cmMonth.DateChanged+=new Controls_CalendarMonth.DateChangedEventHandler(cmMonth_DateChanged);
        mlMonthes.MonthChanged += new Controls_MonthList.MonthChangedEventHandler(mlMonthes_MonthChanged);
    }

    void mlMonthes_MonthChanged(object sender, EventArgs e)
    {
        cmMonth.Month = mlMonthes.Month;
        if (mlMonthes.Month >= DateTime.Today.Month)
            cmMonth.Year = DateTime.Today.Year;
        else
            cmMonth.Year = DateTime.Today.Year + 1;
        cmMonth.PublishCalendar();
    }

    void cmMonth_DateChanged(object sender, EventArgs e)
    {
        tdHolidays.Date = cmMonth.SelectedDate;
        weWeek.CurrentDate = cmMonth.SelectedDate;
    }
}
