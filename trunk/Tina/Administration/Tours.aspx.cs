using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Administration_Tours : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbAdd_Click(object sender, EventArgs e)
    {
        TourDataContext context = new TourDataContext();
        Tour tour = new Tour();
        tour.Name = tbTitle.Text;
        tour.LeftTextColor = tbBackground.Text;
        tour.BlackText = cbBlackText.Checked;
        tour.BackgroundImage = fuBackgroundImage.UploadedFile;
        if (!string.IsNullOrEmpty(tbYear.Text))
            tour.Year = int.Parse(tbYear.Text);
        context.Tours.InsertOnSubmit(tour);
        context.SubmitChanges();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ReorderList1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Tour tour = (Tour)e.Row.DataItem;
            Panel pBgColor = (e.Row.FindControl("pBgColor") as Panel);
            if (pBgColor != null)
                pBgColor.Style["background-color"] = tour.LeftTextColor;

            LinkButton lbDescription = (e.Row.FindControl("lbDescription") as LinkButton);
            if (lbDescription != null)
                lbDescription.Attributes["onclick"] = "SetAction('EditDescription');";
        }
    }

    protected void InsertButton_Click(object sender, EventArgs e)
    {
        TourDataContext context = new TourDataContext();
        TourPicture picture = new TourPicture();
        picture.TourID = int.Parse(ddlTours.SelectedValue);
        picture.Picture = fuPicture.UploadedFile;
        picture.Preview = fuPreview.UploadedFile;
        picture.SortOrder = context.TourPictures.Count() + 1;
        context.TourPictures.InsertOnSubmit(picture);
        context.SubmitChanges();
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath("~/Images/Gallery/Tours/") + PicturePath;
            File.Delete(path);
        }
    }

    protected void ReorderList1_ItemCommand(object sender, AjaxControlToolkit.ReorderListCommandEventArgs e)
    {
        int tourID = Convert.ToInt32(e.CommandArgument);
        TourDataContext context = new TourDataContext();
        TourPicture tourPicture = context.TourPictures.SingleOrDefault(t => t.ID == tourID);
        RemovePicture(tourPicture.Picture);
        RemovePicture(tourPicture.Preview);
        context.TourPictures.DeleteOnSubmit(tourPicture);
        context.SubmitChanges();
    }

    protected void bSave_Click(object sender, EventArgs e)
    {
        tpDetails.Save();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditDescription")
        {
            int tourID = Convert.ToInt32(e.CommandArgument);
            tpDetails.TourID = tourID;
        }
    }
}
