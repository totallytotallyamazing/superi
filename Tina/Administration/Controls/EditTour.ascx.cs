using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Controls_EditTour : System.Web.UI.UserControl
{
    public int TourID
    {
        get 
        {
            if (ViewState["TourID"] != null)
                return Convert.ToInt32(ViewState["TourID"]);
            return int.MinValue;
        }
        set { ViewState["TourID"] = value; EnsureChildControls(); UpdateForm(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private Tour GetByID(int ID)
    {
        TourDataContext context = new TourDataContext();
        Tour tour = context.Tours.SingleOrDefault(t => t.ID == TourID);
        return tour;
    }

    private void UpdateForm()
    {
        if(TourID>0)
        {
            Tour tour = GetByID(TourID);
            tbCities.Text = tour.LeftText;
            tbTextTitle.Text = tour.RightTitle;
            tbSubTitle.Text = tour.RightSubTitle;
            fcText.Value = tour.RightText;
        }
    }

    public void Save()
    { 
        TourDataContext context = new TourDataContext();
        Tour tour = context.Tours.SingleOrDefault(t => t.ID == TourID);
        tour.RightText = fcText.Value;
        tour.LeftText = tbCities.Text;
        tour.RightTitle = tbTextTitle.Text;
        tour.RightSubTitle = tbSubTitle.Text;
        context.SubmitChanges();
    }
}
