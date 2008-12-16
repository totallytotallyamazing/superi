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
    }

    void cmMonth_DateChanged(object sender, EventArgs e)
    {
        tdHolidays.Date = cmMonth.SelectedDate;
    }
}
