using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourPage : System.Web.UI.Page
{
    protected Tour SelectedTour
    {
        get 
        {
            if (TourID > 0)
            { 
                TourDataContext context = new TourDataContext();
                Tour result = context.Tours.SingleOrDefault(t => t.ID == TourID);
                return result;
            }
            return null;
        }
    }

    protected int TourID
    {
        get
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
                return int.MinValue;
            return int.Parse(Request.QueryString["id"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}
