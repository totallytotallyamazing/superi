using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;

public partial class Administration_Settings : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        SqlDataSource1.ConnectionString = AppData.ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
