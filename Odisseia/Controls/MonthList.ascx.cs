using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;

public partial class Controls_MonthList : System.Web.UI.UserControl
{
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

    public delegate void MonthChangedEventHandler(object sender, EventArgs e);
    public event MonthChangedEventHandler MonthChanged;

    protected virtual void OnMonthChanged(EventArgs e)
    {
        if (MonthChanged != null)
            MonthChanged(this, e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        PublishControl();
    }

    protected void rMonthList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int monthNumber = Convert.ToInt32(e.Item.DataItem);
        LinkButton lbMonth = (LinkButton)e.Item.FindControl("lbMonth");
        
        lbMonth.Text = CommonTools.GetMonthName(monthNumber, true);
        lbMonth.CommandArgument = monthNumber.ToString();
        HtmlGenericControl divMonth = (HtmlGenericControl)e.Item.FindControl("divMonth");
        if (monthNumber == Month)
            divMonth.Attributes["class"] = "monthListItemContainer selectedMonth";
        else
            divMonth.Attributes["class"] = "monthListItemContainer";

    }

    protected void rMonthList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int month = Convert.ToInt32(e.CommandArgument);
        Month = month;
        PublishControl();
        OnMonthChanged(new EventArgs());
    }

    private void PublishControl()
    {
        ArrayList dataSource = new ArrayList();
        for (int i = 1; i <= 12; i++)
        {
            dataSource.Add(i);
        }
        rMonthList.DataSource = dataSource;
        rMonthList.DataBind();
    }
}
