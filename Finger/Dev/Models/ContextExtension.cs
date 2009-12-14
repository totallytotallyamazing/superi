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
    }
}
