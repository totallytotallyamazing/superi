using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Videos : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        VideosDataContext context = new VideosDataContext();
        ReorderList1.DataBind();
        HiddenField hfSortOrder = (HiddenField)FormView1.FindControl("hfSortOrder");
        hfSortOrder.Value = context.Videos.Count().ToString();
    }
}
