﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using Zamov.Models;
using System.IO;

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

        public static string CreateTranslationXml(List<TranslationItem> translations)
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("root");
            document.AppendChild(root);
            foreach (var translationItem in translations)
            {
                XmlElement item = document.CreateElement("translation");
                XmlAttribute language = document.CreateAttribute("Language");
                language.Value = translationItem.Language;
                XmlAttribute itemIdAttribute = document.CreateAttribute("ItemId");
                itemIdAttribute.Value = translationItem.ItemId.ToString();
                XmlAttribute translationItemTypeId = document.CreateAttribute("TranslationItemTypeId");
                translationItemTypeId.Value = ((int)translationItem.ItemType).ToString();
                XmlAttribute translation = document.CreateAttribute("Translation");
                translation.Value = translationItem.Translation;
                item.Attributes.Append(language);
                item.Attributes.Append(itemIdAttribute);
                item.Attributes.Append(translationItemTypeId);
                item.Attributes.Append(translation);
                root.AppendChild(item);
            }
            return document.OuterXml;
        }

        public static string CreateUpdatesXml(this Dictionary<string, Dictionary<string, string>> updates)
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("root");
            document.AppendChild(root);
            foreach (string key in updates.Keys)
            {
                Dictionary<string, string> itemUpdates = updates[key];
                XmlElement item = document.CreateElement("item");
                XmlAttribute itemIdAttribute = document.CreateAttribute("Id");
                itemIdAttribute.Value = key;
                item.Attributes.Append(itemIdAttribute);
                foreach (string itemKey in itemUpdates.Keys)
                {
                    XmlAttribute itemAttribute = document.CreateAttribute(itemKey);
                    itemAttribute.Value = itemUpdates[itemKey];
                    item.Attributes.Append(itemAttribute);
                }
                root.AppendChild(item);
            }
            return document.OuterXml;
        }

        public static List<Dictionary<string, object>> QureyUploadedXls(string fileName)
        {
            DataSet result = new DataSet();
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;";

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            OleDbCommand command = new OleDbCommand("Select * from [Sheet1$]", connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(result);

            DataTable table = result.Tables[0];
            List<Dictionary<string, object>> importedItems = new List<Dictionary<string, object>>();
            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, object> item = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                    item.Add(column.ColumnName, row[column]);
                importedItems.Add(item);
            }
            connection.Close();
            File.Delete(fileName);
            return importedItems;
        }
    }
}
