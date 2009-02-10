using System;
using System.IO;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;

public enum ArticleEditorModes{Article, Practice}

public partial class Administration_Controls_ArticlesEditor : System.Web.UI.UserControl
{
    public int ScopeId
    {
        get
        {
            if (ViewState["ScopeId"] == null)
                return 0;
            return Convert.ToInt32(ViewState["ScopeId"]);
        }
        set
        {
            ViewState["ScopeId"] = value;
            Parameter parameter = new Parameter("ScopeID", TypeCode.Int32, value.ToString());
            ObjectDataSource1.SelectParameters.Clear();
            ObjectDataSource1.SelectParameters.Add(parameter);
        }
    }

    public ArticleEditorModes ArticleEditorMode
    {
        get
        {
            if (ViewState["Mode"] == null)
                return ArticleEditorModes.Article;
            return (ArticleEditorModes)ViewState["Mode"];
        }
        set { ViewState["Mode"] = value; }
    }

    
    private void InitControl()
    {        
        btnRemovePicture.Click += btnRemovePicture_Click;
        btnUpdate.Click += btnUpdate_Click;
        Visible = true;
        if (ArticleEditorMode == ArticleEditorModes.Practice)
        {
            for (int i = 0; i < 5; i++)
            {
                pImages.Controls.Add(new FileUpload());
            }            
        }
    }

    protected void dlImages_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        AttachableFile file = new AttachableFile(id);
        RemovePracticeImage(file.FileName);
        file.Remove();
    }

    private void RemovePracticeImage(string FileName)
    {
        string path = Server.MapPath(WebSession.ArticlesImagesFolder) + "\\";
        File.Delete(path + FileName);
    }

    protected void dlImages_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        ImageButton ibPicture = (ImageButton)e.Item.FindControl("ibPicture");
        AttachableFile file = (AttachableFile) e.Item.DataItem;

        ibPicture.CommandArgument = file.Id.ToString();
        ibPicture.ImageUrl = WebSession.ArticlesImagesFolder.Replace("~", WebSession.BaseUrl) + file.FileName;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        InitControl();
    }

    protected void Page_LoadCompete(object sender, EventArgs e)
    {
        ihNodeID.Value = ScopeId.ToString();
    }



    protected void Page_PreRender(object sender, EventArgs e)
    {
        int articleID;
        if (!int.TryParse(hfArticleSelected.Value, out articleID))
        {
            phEdit.Visible = false;
            phPractice.Visible = false;
            articleID = 0;
        }

        if (articleID > 0)
        {
            Article article = new Article(articleID);
            if (ArticleEditorMode==ArticleEditorModes.Article)
            {
                phEdit.Visible = true;
                reTitle.DefaultValue = article.Title;
                reTitle.TextID = article.TitleTextID;
                reShortDescription.DefaultValue = article.ShortDescription;
                reShortDescription.TextID = article.ShortDescriptionTextID;
                reDescription.DefaultValue = article.Description;
                reDescription.TextID = article.DescriptionTextID;

                btnRemovePicture.Visible = false;
                iPicture.Visible = false;
                if (!string.IsNullOrEmpty(article.TitlePicture))
                {
                    btnRemovePicture.Visible = true;
                    iPicture.Visible = true;
                    iPicture.ImageUrl = WebSession.ArticlesImagesFolder + article.TitlePicture;
                }
                phEdit.Visible = true;
                
            }
            else
            {
                phPractice.Visible = true;
                rePracticeText.TextID = article.DescriptionTextID;
                PublishDataList(article.ID);
            }
        }
        if (ScopeId <= 0)
            Visible = false;
    }

    private void PublishDataList(int ArticleId)
    {
        AttachableFileList fileList = new AttachableFileList(ArticleId, (int)ItemTypes.Article, null);
        dlImages.DataSource = fileList;
        dlImages.DataBind();
    }

    protected void bUpdate_Click(object sender, EventArgs e)
    {
        int articleID = int.Parse(hfArticleSelected.Value);
        Article article = articleID > 0 ? new Article(articleID) : new Article();

        article.DescriptionTextID = rePracticeText.Values.Save();
        article.Save();
        foreach (FileUpload fileUpload in pImages.Controls)
        {
            if(fileUpload.HasFile)
            {
                AttachableFile file = new AttachableFile();
                file.ItemType = (int)ItemTypes.Article;
                file.ItemId = article.ID;
                file.Save();
                file.FileName = SaveFile(file.Id, fileUpload);
                file.Save();
            }
        }
    }

    private string SaveFile(int Id, FileUpload fileUpload)
    {
        string path = Server.MapPath(WebSession.ArticlesImagesFolder) + "\\";
        string extention = fileUpload.FileName.Substring(fileUpload.FileName.LastIndexOf("."));
        fileUpload.SaveAs(path + Id + extention);
        return Id + extention;
    }

    void btnUpdate_Click(object sender, EventArgs e)
    {
        int articleID = int.Parse(hfArticleSelected.Value);
        Article article = articleID > 0 ? new Article(articleID) : new Article();

        article.Title = reTitle.DefaultValue;
        reTitle.TextID = article.TitleTextID;
        article.TitleTextID = reTitle.Values.Save();
        article.ShortDescription = reShortDescription.DefaultValue;
        reShortDescription.TextID = article.ShortDescriptionTextID;
        article.ShortDescriptionTextID = reShortDescription.Values.Save();
        article.Description = reDescription.DefaultValue;
        reDescription.TextID = article.DescriptionTextID;
        article.DescriptionTextID = reDescription.Values.Save();

        string path = Server.MapPath(WebSession.ArticlesImagesFolder) + "\\";
        if (fuPicture.HasFile)
        {
            if (!string.IsNullOrEmpty(article.TitlePicture))
                RemovePicture(article.TitlePicture);
            string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
            fuPicture.SaveAs(path + article.ID + extPicture);

            article.TitlePicture = article.ID + extPicture;
        }
        article.Save();
    }

    private void RemovePicture(string PicturePath)
    {
        if (!string.IsNullOrEmpty(PicturePath))
        {
            string path = Server.MapPath(WebSession.ArticlesImagesFolder) + PicturePath;
            File.Delete(path);
        }
    }

    protected void btnRemovePicture_Click(object sender, EventArgs e)
    {
        int articleID = int.Parse(hfArticleSelected.Value);
        if (articleID > 0)
        {
            Article article = new Article(articleID);
            RemovePicture(article.TitlePicture);
            article.TitlePicture = string.Empty;
            article.Save();
        }
    }

    protected void gwArticles_SelectedIndexChanged(object sender, EventArgs e)
    {
        int articleID = int.Parse(gwArticles.SelectedRow.Cells[0].Text);
        hfArticleSelected.Value = articleID.ToString();
    }

}
