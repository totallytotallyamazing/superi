using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Videos;

/// <summary>
/// Summary description for VideoService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]
public class VideoService : System.Web.Services.WebService
{

    [WebMethod]
    public object GetVideos()
    {
        VideoDataContext context = new VideoDataContext();
        var videos = from vid in context.Videos select new { vid.Source, vid.Name, vid.Image };
        return videos;
    }
}

