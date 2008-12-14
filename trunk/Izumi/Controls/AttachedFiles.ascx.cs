using System;
using Superi.Features;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Controls_AttachedFiles : System.Web.UI.UserControl
{
    protected int ItemType
    {
        get
        {
            int itemType = int.MinValue;
            if (WebSession.NavigationID > 0)
                itemType = 1;
            else if (WebSession.TextID > 0)
                itemType = 2;
            else if (WebSession.ArticleID > 0)
                itemType = 3;
            return itemType;
        }        

    }

    protected int ItemId
    {
        get
        {
            if (WebSession.NavigationID > 0)
                return WebSession.NavigationID;
            if (WebSession.TextID > 0)
                return WebSession.TextID;
            if (WebSession.ArticleID > 0)
                return WebSession.ArticleID;
            return int.MinValue;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AttachableFileList fileList = new AttachableFileList(ItemId, ItemType, WebSession.Language);
        rItems.DataSource = fileList;
        rItems.DataBind();
    }
}
