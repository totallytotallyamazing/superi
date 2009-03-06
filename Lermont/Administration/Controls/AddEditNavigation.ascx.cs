using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Administration_Controls_AddEditNavigation : System.Web.UI.UserControl
{
    public int NavigationID
    {
        get 
        {
            if (ViewState["NavigationID"] != null)
                return Convert.ToInt32(ViewState["NavigationID"]);
            return int.MinValue;
        }
        set { ViewState["NavigationID"] = value; }
    }


    public event EventHandler OnNavigationSaving;
    public event EventHandler OnNavigationSaved;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }

    protected void bSave_Click(object sender, EventArgs e)
    {
        if (OnNavigationSaving != null)
            OnNavigationSaving(this, new EventArgs());


        if (OnNavigationSaved != null)
            OnNavigationSaved(this, new EventArgs());
    }

    protected void bCreateText_Click(object sender, EventArgs e)
    {

    }
}
