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

public partial class Administration_Controls_TextEditor : System.Web.UI.UserControl
{
    public int TextId
    {
        get
        {
            if (ViewState["TextId"] == null)
                return 0;
            return Convert.ToInt32(ViewState["TextId"]);
        }
        set
        {
            ViewState["TextId"] = value;
        }
    }

    public bool DisplayTitle
    {
        get
        {
            if (ViewState["DisplayTitle"] == null)
                return true;
            return Convert.ToBoolean(ViewState["DisplayTitle"]);
        }
        set
        {
            ViewState["DisplayTitle"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        reName.Visible = DisplayTitle;
        PreRender += Administration_Controls_TextEditor_PreRender;
        Visible = true;
        if (TextId > 0)
        {
            Text text = new Text(TextId);
            reText.TextID = text.TextID;
            reText.DefaultValue = text.Value;
            if(DisplayTitle)
                reName.TextID = text.NameTextId;
        }
    }

    void Administration_Controls_TextEditor_PreRender(object sender, EventArgs e)
    {
        if (TextId > 0)
        {
            Text text = new Text(TextId);
            reText.TextID = text.TextID;
            reText.DefaultValue = text.Value;
            if(DisplayTitle)
                reName.TextID = text.NameTextId;
        }
        if (TextId <= 0)
            Visible = false; 

    }


    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    public void Save()
    {
        if (TextId > 0)
        {
            Text text = new Text(TextId);
            reText.TextID = text.TextID;
            text.Value = reText.DefaultValue;
            text.TextID = reText.Values.Save();
            if(DisplayTitle)
                text.NameTextId = reName.Values.Save();
            text.Save();
        }
    }
}
