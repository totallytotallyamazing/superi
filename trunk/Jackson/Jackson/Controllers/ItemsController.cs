using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
