using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Controls_CartControl : System.Web.UI.UserControl
{



    protected void Page_Load(object sender, EventArgs e)
    {
        lCount.Text = Cart.Items.Count.ToString();
    }
}
