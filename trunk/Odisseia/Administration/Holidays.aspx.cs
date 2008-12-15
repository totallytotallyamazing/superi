using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Administration_Holidays : System.Web.UI.Page
{
    private int SelectedMont
    { 
        get
        {
            if (!string.IsNullOrEmpty(ddlMonth.SelectedValue))
                return int.Parse(ddlMonth.SelectedValue);
            return int.MinValue;
        }
    }

    private int SelectedDay
    {
        get 
        {
            if (!string.IsNullOrEmpty(Request.Form[ddlDay.UniqueID]))
                return int.Parse(Request.Form[ddlDay.UniqueID]);
            return int.MinValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ddlMonth_SelectedIndexChanged(sender, e);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        PublishHolidays();
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SelectedMont > 0)
        {
            ddlDay.Items.Clear();
            int daysInMonth = DateTime.DaysInMonth(2009, SelectedMont);
            for (int i = 0; i < daysInMonth; i++)
            {
                ddlDay.Items.Add(new ListItem((i + 1).ToString(), (i + 1).ToString()));
            }
        }
    }

    private void PublishHolidays()
    {
        EventList eventList = new EventList(true);
        gwHolidays.DataSource = eventList;
        gwHolidays.DataBind();
    }

    protected void bAdd_Click(object sender, EventArgs e)
    {
        Event ev = new Event();
        ev.Name = tbName.Text;
        ev.StartDate = new DateTime(1900, SelectedMont, SelectedDay);
        ev.Save();
    }

    protected void gwHolidays_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");
            HyperLink hlDescription = (HyperLink)e.Row.FindControl("hlDescription");
            Label lDay = (Label)e.Row.FindControl("lDay");
            Label lMonth = (Label)e.Row.FindControl("lMonth");
            Event ev = (Event)e.Row.DataItem;
            hlDescription.NavigateUrl = "javascript:openPopupWindow('PopUps/EditEventDescription.aspx?id=" + ev.Id + "', 800, 500)";
            lbDelete.CommandArgument = ev.Id.ToString();
            lDay.Text = ev.StartDate.Value.Day.ToString();
            lMonth.Text = ev.StartDate.Value.Month.ToString();
        }
    }
    
    protected void gwHolidays_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteItem")
        {
            int eventId = Convert.ToInt32(e.CommandArgument);
            Event ev = new Event(eventId);
            ev.Remove();
        }
    }
}
