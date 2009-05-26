using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Pandemiia.Models
{
    public static class TagExtention
    {
        public static string GetTagsXml(this List<Tag> tags, string basePath)
        {
            XmlDocument document = new XmlDocument();
            XmlElement tagsNode = document.CreateElement("tags");
            document.AppendChild(tagsNode);
            foreach (Tag tag in tags)
            {
                EntitiesDataContext context = new EntitiesDataContext();
                int tagCount = context.EntityTagMappings.Select(etm=>etm).Where(etm=>etm.TagID==tag.ID).Count();
                XmlElement a = document.CreateElement("a");
                XmlAttribute href = document.CreateAttribute("href");
                href.Value = basePath + tag.TagName;
                a.Attributes.Append(href);
                XmlAttribute style = document.CreateAttribute("style");
                style.Value = (14).ToString();
                a.Attributes.Append(style);
                //XmlAttribute color = document.CreateAttribute("color");
                //color.Value = "0x848484";
                //a.Attributes.Append(color);
                //XmlAttribute hicolor = document.CreateAttribute("hicolor");
                //hicolor.Value = "0xFFFFFF";
                //a.Attributes.Append(hicolor);
                a.AppendChild(document.CreateTextNode(tag.TagName));
                tagsNode.AppendChild(a);
            }
            return document.OuterXml.Replace("\"", "'");
        }
    }
}
