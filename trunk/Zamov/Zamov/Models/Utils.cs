﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Zamov.Models
{
    public static class Utils
    {
        public static string CreateTranslationXml(int itemId, ItemTypes itemType, Dictionary<string, string> translations)
        {
            XmlDocument document = new XmlDocument();
            XmlElement node = document.CreateElement("root");
            document.AppendChild(node);
            foreach (string key in translations.Keys)
            {
                XmlElement item = document.CreateElement("translation");
                XmlAttribute language = document.CreateAttribute("Language");
                language.Value = key;
                XmlAttribute itemIdAttribute = document.CreateAttribute("ItemId");
                itemIdAttribute.Value = itemId.ToString();
                XmlAttribute translationItemTypeId = document.CreateAttribute("TranslationItemTypeId");
                translationItemTypeId.Value = ((int)itemType).ToString();
                XmlAttribute translation = document.CreateAttribute("Translation");
                translation.Value = translations[key];
                item.Attributes.Append(language);
                item.Attributes.Append(itemIdAttribute);
                item.Attributes.Append(translationItemTypeId);
                item.Attributes.Append(translation);
                node.AppendChild(item);
            }
            return document.OuterXml;
        }
    }
}
