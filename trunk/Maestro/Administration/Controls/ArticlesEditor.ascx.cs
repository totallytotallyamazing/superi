using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Features;
using Superi.Common;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        

        btnRemovePicture.Click += btnRemovePicture_Click;
        btnUpdate.Click += btnUpdate_Click;
        Visible = true;
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
            articleID = 0;
        }

        if (articleID > 0)
        {
            phEdit.Visible = true;
            Article article = new Article(articleID);
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
        if (ScopeId <= 0)
            Visible = false;
    }

    void btnUpdate_Click(object sender, EventArgs e)
    {
        int articleID = int.Parse(hfArticleSelected.Value);
        Article article;
        if (articleID > 0)
            article = new Article(articleID);
        else
            article = new Article();

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

    void btnRemovePicture_Click(object sender, EventArgs e)
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
