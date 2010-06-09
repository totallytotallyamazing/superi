using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public static class ContextExtension
    {
        public static Content GetContent(this ContentStorage context, string contentUrl)
        {
            return context.Contents.Where(sc => sc.Name == contentUrl).Select(sc => sc).FirstOrDefault();
        }

        public static Content GetContent(this ContentStorage context, string contentName, string Culture)
        {
            return context.Contents.Where(sc => sc.Name == contentName && sc.Language == Culture).Select(sc => sc).FirstOrDefault();
        }

        public static void UpdateContent(this ContentStorage context, string contentUrl, string text, string title, string keywords, string description)
        {
            Content content = context.Contents.Where(sc => sc.Name == contentUrl).Select(sc => sc).First();
            content.Text = text;
            content.Title = title;
            content.Keywords = keywords;
            content.Description = description;
            context.SaveChanges();
        }

        public static void UpdateContent(this ContentStorage context, string contentName, string language, string text, string title, string keywords, string description)
        {
            Content content = context.Contents.Where(sc => sc.Name == contentName && sc.Language == language).Select(sc => sc).First();
            content.Text = text;
            content.Title = title;
            content.Keywords = keywords;
            content.Description = description;
            context.SaveChanges();
        }
    }
}
