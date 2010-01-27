using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tina.Web.Models
{
    public class GalleryImagePresentation
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Picture { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
    }
}
