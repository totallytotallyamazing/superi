using Backload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Jackson.Models;

namespace Jackson.Controllers
{
    public class FilesController : Controller
    {
        private SiteContext _context = null;

        public FilesController(SiteContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Upload()
        {
            FileUploadHandler handler = new FileUploadHandler(Request, this);
            handler.StoreFileRequestFinished += handler_StoreFileRequestFinished;
            ActionResult result = await handler.HandleRequestAsync();
            
            return result;
        }

        void handler_StoreFileRequestFinished(object sender, Backload.Eventing.Args.StoreFileRequestEventArgs e)
        {
            var status = e.Param.FileStatusItem;
            var groupUrl = status.ObjectContext;
            var group = _context.Groups.First(g => g.Url == groupUrl);

            var item = new Item
            {
                Group = group,
                ImageUrl = status.FileName,
                ThumbnailUrl = status.ThumbnailName,
            };
            _context.Items.Add(item);
            _context.SaveChanges();
        }

    }
}
