using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Music : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((HiddenField)FormView2.FindControl("hfAlbumID")).Value = DropDownList1.SelectedValue;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        GridView1.DataBind();
        GridView2.DataBind(); 
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((HiddenField)FormView2.FindControl("hfAlbumID")).Value = DropDownList1.SelectedValue;
    }
    protected void FormView2_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        Response.Write("!");
    }
}
