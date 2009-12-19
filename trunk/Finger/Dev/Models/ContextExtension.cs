using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dev.Models
{
    public static class ContextExtension
    {
        public static SiteContent GetContent(this DataStorage context, string contentUrl)
        {
            return context.SiteContent.Where(sc => sc.Url == contentUrl).Select(sc => sc).FirstOrDefault();
        }

        public static SiteContent GetContent(this DataStorage context, string contentName, string Culture)
        {
            return context.SiteContent.Where(sc => sc.Name == contentName && sc.Language == Culture).Select(sc => sc).FirstOrDefault();
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

        public static void UpdateContent(this DataStorage context, string contentName, string language, string text, string title, string subTitle, string keywords, string description)
        {
            SiteContent content = context.SiteContent.Where(sc => sc.Name == contentName && sc.Language == language).Select(sc => sc).First();
            content.Text = text;
            content.Title = title;
            content.Keywords = keywords;
            content.Description = description;
            content.SubTitle = subTitle;
            context.SaveChanges();
        }
    }
}
