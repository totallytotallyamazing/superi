using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.ServiceModel.Syndication;
using Pandemiia.Models;

namespace Pandemiia.Controllers
{
    public class RssController : Controller
    {
        //
        // GET: /Rss/

        public ActionResult Feed()
        {
            using(EntitiesDataContext context = new EntitiesDataContext())
            {
                List<SyndicationItem> items = 
                    (
                    from item in context.Entities orderby item.Date descending
                    select new SyndicationItem(
                        item.Title, 
                        item.Description, 
                        new Uri("http://pandemic.com.ua/Home/EntityDetails/" + item.ID), 
                        item.ID.ToString(),
                        new DateTimeOffset(item.Date.Value))                               
                        ).ToList();

                DateTimeOffset lastUpdated = items.OrderByDescending(item=>item.LastUpdatedTime).Select(item=>item.LastUpdatedTime).First();

                SyndicationFeed feed = new SyndicationFeed("Pandemic - экспериментальное творчество", 
                    "", 
                    new Uri("http://pandemic.com.ua"), "PandemicComUaRss", lastUpdated);

                feed.Items = items;

                return new RssActionResult { Feed = feed };
            }
        }

    }
}
