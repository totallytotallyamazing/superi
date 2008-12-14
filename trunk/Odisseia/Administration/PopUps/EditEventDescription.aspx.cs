using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Administration_PopUps_EditEventDescription : System.Web.UI.Page
{
    private int EventId
    {
        get 
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                return int.Parse(Request.QueryString["id"]);
            return int.MinValue;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (EventId > 0)
        {
            Event ev = new Event(EventId);
            fcDescription.Value = ev.Description;
        }
    }

    protected void bSave_Click(object sender, EventArgs e)
    {
        if (EventId > 0)
        {
            Event ev = new Event(EventId);
            ev.Description = fcDescription.Value;
            ev.Save();
        }
        Response.Write("<script type=\"text/javascript\">window.close()</script>");
    }
}
