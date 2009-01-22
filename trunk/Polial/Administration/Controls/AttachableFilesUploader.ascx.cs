using System;
using System.Collections.Generic;
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

public partial class Administration_Controls_AttachableFilesUploader : System.Web.UI.UserControl
{
    private AttachableFilesResource filesResource = null;
    private int fileId = int.MinValue;
    private int itemId = int.MinValue;
    private int itemType = int.MinValue;
    protected bool isFirstDiv=true;
    private bool ftime = true;

    public AttachableFilesResource FilesResource
    {
        get { return filesResource; }
        set { filesResource = value; }
    }

    public int FileId
    {
        get { return fileId; }
        set { fileId = value; }
    }

    public int ItemId
    {
        get { return itemId; }
        set { itemId = value; }
    }

    public int ItemType
    {
        get { return itemType; }
        set { itemType = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        rFiles.ItemDataBound+=rFiles_ItemDataBound;
        string langList="";
        foreach (Language language in new LanguageList(true))
        {
            langList += "'" + language.Code + "',";
        }
        char[] chars = { ',' };
        langList = langList.TrimEnd(chars);
        Page.ClientScript.RegisterArrayDeclaration("langs", langList);

        if (FileId > 0)
            filesResource = new AttachableFilesResource(fileId);
        rLanguages.DataSource = new LanguageList(true);
        rLanguages.DataBind();
        rFiles.DataSource = new LanguageList(true);
        rFiles.DataBind();

        Page.ClientScript.RegisterStartupScript(GetType(), "strt"+ClientID, "toggleDivs('RU','"+ClientID+"');", true);
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {

    }

    protected void rFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        string currentLanguage = ((Language) e.Item.DataItem).Code;
        Administration_Controls_AttachableFileUploader afuFile = (Administration_Controls_AttachableFileUploader)e.Item.FindControl("afuFile");
        if(filesResource!=null)
        {
            //Administration_Controls_AttachableFileUploader afuFile = (Administration_Controls_AttachableFileUploader)e.Item.FindControl("afuFile");
            AttachableFile file = filesResource[currentLanguage];
            afuFile.Title = file.Title;
        }
        afuFile.Language = currentLanguage;
        if (isFirstDiv && !ftime)
            isFirstDiv = false;
        if (ftime)
            ftime = false;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        AttachableFilesResource resource = new AttachableFilesResource();
        if (FileId > 0)
        {
            resource = new AttachableFilesResource(FileId);
            resource.Clean(Server.MapPath(WebSession.AttachableFilesFolder) + "\\");
        }
        foreach (RepeaterItem item in rFiles.Controls)
        {
            Administration_Controls_AttachableFileUploader afuFile =
                (Administration_Controls_AttachableFileUploader) item.FindControl("afuFile");
            AttachableFile file = new AttachableFile();
            if (afuFile.File.HasFile)
            {
                file.ItemId = ItemId;
                file.ItemType = ItemType;
                file.Title = afuFile.Title;
                file.Language = afuFile.Language;
                file.Save();
                string extension = afuFile.File.FileName.Substring(afuFile.File.FileName.LastIndexOf("."));
                string path = Server.MapPath(WebSession.AttachableFilesFolder)+"\\";
                afuFile.File.SaveAs(path + file.Id + extension);
                file.FileName = file.Id + extension;
                resource.Add(afuFile.Language, file);
            }
        }   
        resource.Save();
    }

}