using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Tina.Web.Models;

namespace Tina.Web
{
    /// <summary>
    /// Summary description for RichService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RichService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<GalleryImagePresentation> GetGallery(int albumId)
        {
            using (TinaDataContext context = new TinaDataContext())
            {
                return context.Gallery
                    .Where(gi => gi.AlbumId == albumId)
                    .OrderBy(gi => gi.SortOrder)
                    .Select(gi => new GalleryImagePresentation
                    {
                        AlbumId = gi.AlbumId,
                        Id = gi.Id,
                        Picture = gi.Picture,
                        Thumbnail = gi.Thumbnail,
                        Title = gi.Title
                    }).ToList();
            }
            //return new List<GalleryImagePresentation>
            //{
            //    new GalleryImagePresentation{ Picture="one"},
            //    new GalleryImagePresentation{ Picture="two"},
            //    new GalleryImagePresentation{ Picture="three"},
            //    new GalleryImagePresentation{ Picture="four"},
            //    new GalleryImagePresentation{ Picture="five"}
            //};
        }
    }
}
