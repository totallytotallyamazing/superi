using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections;

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
        var albums = from al in context.Albums select new { al.ID, al.Name, al.Image, al.Year };
        return albums.ToList();
    }

}

