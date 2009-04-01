using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Administration_Controls_EditDiskDescription : System.Web.UI.UserControl
{
    public int DiskId
    {
        get
        {
            if (ViewState["diskId"] != null)
                return Convert.ToInt32(ViewState["diskId"]);
            return int.MinValue;
        }
        set { ViewState["diskId"] = value; }
    }

    public delegate void SaveClikEventHandler(object sender, EventArgs e);

    public SaveClikEventHandler SaveClick;

    protected virtual void OnSaveClick(EventArgs e)
    {
        if (SaveClick != null)
            SaveClick(this, e);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        PublishProperties();
    }

    private void PublishProperties()
    {
        if (DiskId > 0)
        {
            Disk disk = new Disk(DiskId);
            reAdditionalInfo.TextID = disk.AdditionalInfoTextId;
            reDescription.TextID = disk.DescriptionTextID;
        }
        else
        {
            reAdditionalInfo.TextID = int.MinValue;
            reDescription.TextID = int.MinValue;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (DiskId > 0)
        {
            Disk disk = new Disk(DiskId);
            disk.DescriptionTextID = reDescription.Values.Save();
            disk.AdditionalInfoTextId = reAdditionalInfo.Values.Save();
            disk.Save();
        }
        OnSaveClick(e);
    }
}
