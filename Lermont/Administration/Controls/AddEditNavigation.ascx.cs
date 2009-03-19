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
using System.Web.Services;

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

    public bool AddMode
    {
        get 
        { 
            if(ViewState["EditMode"]!=null)
                return Convert.ToBoolean(ViewState["EditMode"]);
            return false;
        }
        set { ViewState["EditMode"] = value; }
    }


    public event EventHandler OnNavigationSaving;
    public event EventHandler OnNavigationSaved;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (NavigationID > 0)
        {
            Navigation navigation = new Navigation(NavigationID);
            reTitle.TextID = navigation.NameTextID;
            tbName.Text = navigation.Name;
            cbDisplay.Checked = navigation.IncludeInMenu;
            if (navigation.TextID > 0)
            {
                tcTabs.ActiveTabIndex = 0;
                Text text = new Text(navigation.TextID);
                tbTextID.Text = text.Alias;
                tbTextID.ToolTip = text.ID.ToString();
            }
            else
            {
                tcTabs.ActiveTabIndex = 1;
                tbPage.Text = navigation.Page;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        TextList list = new TextList(true);
        lbTexts.DataSource = list;
        lbTexts.DataTextField = "Name";
        lbTexts.DataValueField = "ID";
        lbTexts.DataBind();
    }

    protected void bSave_Click(object sender, EventArgs e)
    {
        if (OnNavigationSaving != null)
            OnNavigationSaving(this, new EventArgs());
        Navigation navigation = null;
        if (!AddMode)
            navigation = new Navigation(NavigationID);
        else
            navigation = new Navigation();

        navigation.Name = tbName.Text;
        navigation.NameTextID = reTitle.ResourceId;
        switch (tcTabs.TabIndex)
        {
            case 0:
                if (!string.IsNullOrEmpty(hfTextId.Value))
                    navigation.TextID = int.Parse(hfTextId.Value);
                break;
            case 1:
                navigation.Page = tbPage.Text;
                break;
        }
        if (AddMode)
            navigation.ParentID = NavigationID;
        navigation.IncludeInMenu = cbDisplay.Checked;
        navigation.Save();
        if (OnNavigationSaved != null)
            OnNavigationSaved(this, new EventArgs());
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scr", "addingComplete();", true);
    }
}