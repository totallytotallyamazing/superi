using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Videos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VideosDataContext context = new VideosDataContext();
        List<Video> videos = context.Videos.Select(vid => vid).ToList();
    }
}
