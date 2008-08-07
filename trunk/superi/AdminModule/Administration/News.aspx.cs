using System;
//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
using Superi.Features;

public partial class Administration_News : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		btnUpdate.Click += btnUpdate_Click;

		if (!Page.IsPostBack)
		{
			cDate.SelectedDate = DateTime.Now;
			cDate.VisibleDate = DateTime.Now;
			phEdit.Visible = false;
		}
		
	}

	void btnUpdate_Click(object sender, EventArgs e)
	{
		int newsItemID = int.Parse(hfNewsItemID.Value);
		if (newsItemID > 0)
		{
			NewsItem newsItem = new NewsItem(newsItemID);
			newsItem.Description = fckeDescription.Value;
			newsItem.ShortDescription = fckeShortDescription.Value;
			newsItem.EntryDate = cDate.SelectedDate;
			newsItem.Alias = tbAlias.Text;
			newsItem.Save();
			phEdit.Visible = true;
		}
	}

	protected void gwNews_SelectedIndexChanged(object sender, EventArgs e)
	{
		int newsItemID = int.Parse(gwNews.SelectedRow.Cells[0].Text);
		hfNewsItemID.Value = newsItemID.ToString();
		if (newsItemID > 0)
		{
			NewsItem newsItem = new NewsItem(newsItemID);
			fckeDescription.Value = newsItem.Description;
			fckeShortDescription.Value = newsItem.ShortDescription;
			cDate.SelectedDate = newsItem.EntryDate;
			cDate.VisibleDate = newsItem.EntryDate;
			tbAlias.Text = newsItem.Alias;
			phEdit.Visible = true;
		}
	}
}
