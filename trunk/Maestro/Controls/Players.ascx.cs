using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.Common;
using System.Data;
using System.Text.RegularExpressions;

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
        LinkButton lbPicture = (LinkButton)e.Item.FindControl("lbPicture");
        LinkButton lbName = (LinkButton)e.Item.FindControl("lbName");
        Image iPicture = (Image)e.Item.FindControl("iPicture");
        if (!string.IsNullOrEmpty(item.TitlePicture))
        {
            iPicture.ImageUrl = WebSession.ArticlesImagesFolder + item.TitlePicture;
            lbName.CommandArgument = lbPicture.CommandArgument = item.ID.ToString();
            if (item.Titles.Items.Count > 0)
                lbName.Text = item.Titles[WebSession.Language];
        }
        else
            e.Item.Visible = false;
    }

    protected void rPlayers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int articleId = Convert.ToInt32(e.CommandArgument);
        Article article = new Article(articleId);
        iArticlePicture.Visible = false;
        if (!string.IsNullOrEmpty(article.Picture))
        {
            iArticlePicture.Visible = true;
            iArticlePicture.ImageUrl = WebSession.BaseUrl + "MakeThumbnail.aspx?loc=article&dim=500&file=" + article.Picture;
        }
        
        lDetails.Text = article.Descriptions[WebSession.Language];
        string shortText = article.ShortDescriptions[WebSession.Language];
        shortText = shortText.Replace(Environment.NewLine, "<br />");
        Regex ex = new Regex("(?:\\A|<br />)(.*?\\:)");
        lText.Text = ex.Replace(shortText, WrapString); 
    }
        
    private static string WrapString(Match M)
    {
        return M.Value.Replace(M.Groups[1].Value, "<b>" + M.Groups[1] + "</b>");
    }
}
