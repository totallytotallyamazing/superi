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
        GridView1.DataBind();
    }
}
