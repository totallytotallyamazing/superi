using System;
using MBrand.Models;
using System.Collections.Generic;
using System.Linq;

namespace MBrand.Utils
{
    public class OpenGraph
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }

    public static class UrlParser
    {
        private static Dictionary<string, Func<string[], OpenGraph>> navigation = new Dictionary<string, Func<string[], OpenGraph>>{
                                                                   {"works", ProcessWorks},
                                                                   {"feedback", a=>new OpenGraph{Title = "Обратная связь"}},
                                                                   {"secretLink", ProcessSecretLink}
                                                               };

        public static OpenGraph GetTitle(string url)
        {
            var result = new OpenGraph();
            string[] path = url.Split('/');
            for (int i = 0; i < path.Length; i++)
            {
                string item = path[i];
                if (!string.IsNullOrEmpty(item))
                {
                    if (navigation.ContainsKey(item))
                    {
                        result = navigation[item](path.Skip(i+1).ToArray());
                    }
                    break;
                }
            }
            result.Url = "http://www.eugene-miller.com/#!" + url;
            return result;
            
        }

        public static OpenGraph ProcessWorks(string[] path)
        {
            var result = new OpenGraph();
            if (path.Length == 1)
            {
                var sectionName = path[0];
                using (ContentContainer context = new ContentContainer())
                {
                    result.Title = context.Contents.OfType<WorkGroup>().First(c => c.Name == sectionName).Title;
                }
            }
            else if(path.Length == 2)
            {
                var workName = path[1];
                using (ContentContainer context = new ContentContainer())
                {
                    Work work = context.Contents.OfType<Work>().First(w => w.Name == workName);
                    result.Title = work.Description;
                    result.Image = "http://www.eugene-miller.com/Content/workImages/" + work.Image;
                }
            }
            return result;
        }

        public static OpenGraph ProcessSecretLink(string[] path)
        {
            var result = new OpenGraph();
            if (path.Length == 0)
            {
                result.Title = "Секретная ссылка";
            }
            else
            {
                int secretId = int.Parse(path[0]);
                using (ContentContainer context = new ContentContainer())
                {
                    var secret  =context.Secrets.First(s => s.Id == secretId);
                    result.Title = secret.Title;
                    result.Image = "http://www.eugene-miller.com/Content/secret/preview/" + secret.FileName;
                }
            }
            return result;
        }

    }
}