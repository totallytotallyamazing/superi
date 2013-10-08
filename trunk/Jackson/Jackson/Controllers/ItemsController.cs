using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using Jackson.Models;

namespace Jackson.Controllers
{
    public class ItemsController : ApiController
    {
        private readonly SiteContext _context;

        public ItemsController(SiteContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public void NotifyMiller([FromUri]string url, [FromUri]string phone)
        {
            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            message.To.Add("miller.kak.miller@gmail.com");
            message.Subject = "m-j - Перезвони по футболке";
            message.Body = string.Format("<div>Телефон: {0}</div><div><img src=\"{1}\" /></div>", phone, url);
            message.IsBodyHtml = true;
            client.Send(message);
            message.Dispose();
        }

        [HttpPost]
        public void Sort(string id, [FromBody]int[] order)
        {
            var items = _context.Items.Where(i => i.Group.Url == id).ToList();

            for (int i = 0; i < order.Length; i++)
            {
                var item = items.Single(it => it.Id == order[i]);
                item.SortOrder = i;
            }

            _context.SaveChanges();
        }

        [HttpPost]
        public void SortGroups([FromBody]string[] order)
        {
            var groups = _context.Groups.ToList();

            for (int i = 0; i < order.Length; i++)
            {
                var item = groups.First(it => it.Url == order[i]);
                item.SortOrder = i;
            }

            _context.SaveChanges();
        }

        [HttpPut]
        public void Move([FromUri]string moveFrom, [FromUri]string moveTo, [FromBody]int[] items)
        {
            var sql = string.Format("SELECT * FROM Item WHERE Id IN ({0})", string.Join(", ", items));
            var itemsToMove = _context.Items.SqlQuery(sql);

            var group = _context.Groups.SingleOrDefault(g => g.Url == moveTo);

            if (group != null)
            {
                foreach (var item in itemsToMove.ToArray())
                {
                    MoveFiles(item, moveFrom, moveTo);
                    
                    item.Group_Id = group.Id;
                }
            }

            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete([FromBody]int[] items)
        {
            var sql = string.Format("SELECT * FROM Item WHERE Id IN ({0})", string.Join(", ", items));
            var itemsToDelete = _context.Items.SqlQuery(sql);

            foreach (var item in itemsToDelete.ToArray())
            {
                DeleteImages(item);
                _context.Items.Remove(item);
            }

            _context.SaveChanges();
        }

        private void DeleteImages(Item item)
        {
            string filesPath = HostingEnvironment.MapPath("~/Files");
            string imagePath = Path.Combine(filesPath, item.Group.Url, item.ImageUrl);
            string thumbPath = Path.Combine(filesPath, item.Group.Url, "_thumbs", item.ThumbnailUrl);

            File.Delete(imagePath);
            File.Delete(thumbPath);
        }

        private void MoveFiles(Item item, string fromGroup, string toGroup)
        {
            string filesPath = HostingEnvironment.MapPath("~/Files");
            string imagePath = Path.Combine(filesPath, fromGroup, item.ImageUrl);
            string thumbPath = Path.Combine(filesPath, fromGroup, "_thumbs", item.ThumbnailUrl);

            string newImageFolder = Path.Combine(filesPath, toGroup);
            if (!Directory.Exists(newImageFolder))
            {
                Directory.CreateDirectory(newImageFolder);
            }

            string newThumbsFolder = Path.Combine(newImageFolder, "_thumbs");
            if (!Directory.Exists(newThumbsFolder))
            {
                Directory.CreateDirectory(newThumbsFolder);
            }

            string newImagePath = Path.Combine(newImageFolder, item.ImageUrl);
            string newThumbPath = Path.Combine(newThumbsFolder, item.ThumbnailUrl);

            File.Move(imagePath, newImagePath);
            File.Move(thumbPath, newThumbPath);

        }

    }
}