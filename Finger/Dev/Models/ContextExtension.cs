using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dev.Models
{
    public static class ContextExtension
    {
        public static SiteContent GetContent(this DataStorage context, string contextUrl)
        {
            return context.SiteContent.Where(sc => sc.Url == contextUrl).Select(sc => sc).FirstOrDefault();
        }

        public static void UpdateContext(this DataStorage context, string contentUrl, string text, string title, string keywords, string description)
        {
            SiteContent content = context.SiteContent.Where(sc => sc.Url == contentUrl).Select(sc => sc).First();
            content.Text = text;
            content.Title = title;
            content.Keywords = keywords;
            content.Description = description;
            context.SaveChanges();
        }
    }
}
