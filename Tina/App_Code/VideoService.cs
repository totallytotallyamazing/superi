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
    public object GetVideos(int AlbumId)
    {
        VideoDataContext context = new VideoDataContext();
        object videos;
        if(AlbumId==0)
            videos = from vid in context.Videos orderby vid.AlbumID descending select new { vid.Source, vid.Name, vid.Image };
        else
            videos = from vid in context.Videos where vid.AlbumID == AlbumId orderby vid.AlbumID descending select new { vid.Source, vid.Name, vid.Image };
        return videos;
    }
}

