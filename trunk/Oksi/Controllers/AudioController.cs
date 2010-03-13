using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Oksi.Models;
using System.Text;

namespace Oksi.Controllers
{
    public class AudioController : Controller
    {
        public ActionResult Index()
        {
            using (DataStorage context = new DataStorage())
            {
                List<Album> albums = context.Albums.Include("Songs")
                    .OrderByDescending(a=>a.Year).ToList();
                return View(albums); 
            }
        }

        public ActionResult SongList()
        {
            using (DataStorage context = new DataStorage())
            {
                List<Song> songs = context.Songs.Include("Album")
                    .OrderByDescending(s=>s.Album.Year)
                    .ThenBy(s=>s.TrackNumber).ToList();
                StringBuilder sb = new StringBuilder();
                sb.Append("var songs = new Array();");
                int i = 0;
                foreach (var item in songs)
                {
                    sb.AppendFormat("songs[{0}] = {{ name: \"{1}\", url: \"{2}\", album: \"{3}\" }};",
                        i, item.Title, item.Source, item.Album.Title
                        );
                    i++;
                }
                sb.Append(Environment.NewLine);
                sb.Append("function getSongs() {return songs;}");
                return Content(sb.ToString(), "text/javascript");
            }
        }
    }
}
