using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;
using System.Data;

public partial class Controls_Players : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = AppData.GetDataSet("select * from Articles where ScopeId=2 order by SortOrder");
        ArticleList list = new ArticleList(ds.Tables[0]);
        rPlayers.DataSource = list;
        rPlayers.DataBind();
    }

    protected void rPlayers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Article item = (Article)e.Item.DataItem;
        //ImageButton ibPicture = (ImageButton)e.Item.FindControl("ibPicture");
        LinkButton lbPicture = (LinkButton)e.Item.FindControl("lbPicture");
        LinkButton lbName = (LinkButton)e.Item.FindControl("lbName");
        Image iPicture = (Image)e.Item.FindControl("iPicture");
        iPicture.ImageUrl = WebSession.ArticlesImagesFolder + item.TitlePicture;
//        ibPicture.OnClientClick = "ibClientClick('" + lbName.UniqueID + "', '" + item.ID + "')";
        //ibPicture.ImageUrl = WebSession.ArticlesImagesFolder + item.TitlePicture;
        lbName.CommandArgument = lbPicture.CommandArgument = item.ID.ToString();
        if(item.Titles.Items.Count>0)
            lbName.Text = item.Titles[WebSession.Language];
    }

    protected void rPlayers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        Article article = new Article(articleId);
        iArticlePicture.Visible = false;
        if (!string.IsNullOrEmpty(article.Picture))
        {
            iArticlePicture.Visible = true;
            iArticlePicture.ImageUrl = WebSession.ArticlesImagesFolder.Replace("~/", WebSession.BaseUrl) + article.Picture;
        }
        lDetails.Text = article.Descriptions[WebSession.Language];
        lText.Text = article.ShortDescriptions[WebSession.Language];
    }
}
