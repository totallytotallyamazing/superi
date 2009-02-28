using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections;
using Musics;

/// <summary>
/// Summary description for Music
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Music : System.Web.Services.WebService
{
    [WebMethod]
    public object GetAlbums()
    {
        MusicDataContext context = new MusicDataContext();
        var albums = from al in context.Albums select new { al.ID, al.Name, al.Image, al.Year, al.InvertColors, al.PhotoImage };
        //DateTime stop = DateTime.Now.AddSeconds(10);
        //while (DateTime.Now<stop)
        //{ ;}
        return albums.ToList();
    }

    [WebMethod]
    public object GetAlbumSongs(int AlbumID)
    {
        MusicDataContext context = new MusicDataContext();
        var songs = from sn in context.Songs where (sn.AlbumId.Value == AlbumID) select new { sn.Name, sn.Source };
        return songs.ToList();
    }
}

