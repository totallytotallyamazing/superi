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
using Superi.Features;

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
        Navigation navigation = null;
        if (NavigationID > 0)
            navigation = new Navigation(NavigationID);
        else
            navigation = new Navigation();

        navigation.Name = tbName.Text;
        navigation.NameTextID = reTitle.ResourceId;

        if (rbText.Checked)
        {
            navigation.TextID = int.Parse(tbTextID.ToolTip);
            navigation.Save();
        }
        else if (rbPage.Checked)
        {
            navigation.Page = tbPage.Text;
            navigation.Save();
        }

        if (OnNavigationSaved != null)
            OnNavigationSaved(this, new EventArgs());
    }

    protected void bCreateText_Click(object sender, EventArgs e)
    {
        Text text = new Text();
        text.Name = tbNewTextTitle.Text;
        text.Save();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "textCreated", "setValue(" + text.ID + ", '" + text.Name + "')", true);
    }
}