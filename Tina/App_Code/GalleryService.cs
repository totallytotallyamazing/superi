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
        var result = from gallery in context.Galleries orderby gallery.SortOrder select new { gallery.Title, gallery.Thumbnail, gallery.Picture };
        return result;
    }

    [WebMethod]
    public int GetPageNumber(int id)
    {
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        int count = context.Galleries.Where(gl=>gl.AlbumID == id).Count();
        int result = count / 30;
        if (count % 30 > 0)
            result++;
        return result;
    }

    [WebMethod]
    public object GetPhotosPage(int id, int pageNumber)
    {
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        var result = (from gallery
                          in context.Galleries
                      where gallery.AlbumID == id
                      orderby gallery.SortOrder
                      select new
                      {
                          gallery.Title,
                          gallery.Thumbnail,
                          gallery.Picture
                      }).Skip(pageNumber * 30).Take(30);
        return result;
    }

    [WebMethod]
    public object GetPhotosByAlbumId(int id)
    {
        Galleria.GalleryDataContext context = new Galleria.GalleryDataContext();
        var result = (from gallery in context.Galleries where gallery.AlbumID == id orderby gallery.SortOrder select new { gallery.Title, gallery.Thumbnail, gallery.Picture }).Take(30);
        return result;
    }
}

