using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Zamov.Models
{
    public static class Utils
    {
        public static string CreateTranslationXml(Dictionary<string, string> translations)
        {
            XmlDocument document = new XmlDocument();
            //XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "ISO-8859-1", null);
            //document.AppendChild(declaration);
            XmlElement node = document.CreateElement("root");
            document.AppendChild(node);
            foreach (string key in translations.Keys)
            {
                XmlElement item = document.CreateElement("translation");
                XmlAttribute lang = document.CreateAttribute("lang");
                lang.Value = key;
                XmlAttribute translation = document.CreateAttribute("translation");
                translation.Value = translations[key];
                item.Attributes.Append(lang);
                item.Attributes.Append(translation);
                node.AppendChild(item);
            }
            return document.OuterXml;
        }
    }
}
