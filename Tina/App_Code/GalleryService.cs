using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for GalleryService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class GalleryService : System.Web.Services.WebService
{
    [WebMethod]
    public object GetPhotos()
    {
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        var result = from gallery in context.Galleries select new { gallery.Title, gallery.Thumbnail, gallery.Picture };
        return result;
    }

    [WebMethod]
    public object GetPhotosByAlbumId(int id)
    {
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        var result = from gallery in context.Galleries where gallery.AlbumID == id select new { gallery.Title, gallery.Thumbnail, gallery.Picture };
        return result;
    }
}

