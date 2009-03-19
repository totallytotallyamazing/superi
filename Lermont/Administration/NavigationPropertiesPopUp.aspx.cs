using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_NavigationPropertiesPopUp : System.Web.UI.Page
{
    private int CurrentNavigationID
    {
        get 
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                return int.Parse(Request.QueryString["id"]);
            return int.MinValue;
        }
    }

    private bool AddMode
    {
        get {
            if (!string.IsNullOrEmpty(Request.QueryString["add"]))
                Convert.ToBoolean(Request.QueryString["add"]);
            return false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        aeNav.NavigationID = CurrentNavigationID;
        aeNav.AddMode = AddMode;
    }
}
