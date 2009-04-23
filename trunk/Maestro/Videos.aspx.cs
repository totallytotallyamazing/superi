using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Common;

public partial class Videos : System.Web.UI.Page
{
    const int PAGE_SIZE = 6;

    private int CurrentPage
    {
        get 
        {
            if (!string.IsNullOrEmpty(Request.QueryString["segment"]))
                return Convert.ToInt32(Request.QueryString["segment"].Replace("p",""));
            return 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        VideosDataContext context = new VideosDataContext();
        List<Video> videos = context.Videos.Select(vid => vid).OrderByDescending(vid=>vid.ID).Skip(CurrentPage*PAGE_SIZE).Take(PAGE_SIZE).ToList();
        int videosCount = context.Videos.Count();
        int pageNumber = videosCount / PAGE_SIZE;
        if (videosCount % PAGE_SIZE > 0)
            pageNumber++;
        pPages.PageCount = pageNumber;
        pPages.CurrentPage = CurrentPage;
        pPages.BasePath = WebSession.BaseUrl + "multimedia/video/p";
        rVideos.DataSource = videos;
        rVideos.DataBind();
    }
}
