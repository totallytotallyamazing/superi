using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using Zamov.Models;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Text;
using System.Collections;

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

        public static List<Dictionary<string, object>> QureyUploadedXls(string fileName, int dealerId)
        {
            DataSet result = GetExcelDataSetInterop(fileName);

            List<Dictionary<string, object>> importedItems = result.Tables[0].ToDictionaryList();

            File.Delete(fileName);
            return importedItems;
        }

        private static DataSet GetExcelDataSetOleDb(string fileName)
        {
            DataSet result = new DataSet();
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;";

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            OleDbCommand command = new OleDbCommand("Select * from [Sheet1$]", connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(result);
            connection.Close();
            return result;
        }

        private static DataSet GetExcelDataSetInterop(string fileName)
        {
            Application oXL;
            Workbook oWB;
            Worksheet oSheet;
            Range oRng;
            oXL = new ApplicationClass();
            try
            {
                //  creat a Application object
                //   get   WorkBook  object
                oWB = oXL.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);

                //   get   WorkSheet object 
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Sheets[1];
                foreach (Worksheet ws in oWB.Sheets)
                { }
                System.Data.DataTable dt = new System.Data.DataTable("dtExcel");
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                DataRow dr;

                StringBuilder sb = new StringBuilder();
                int jValue = oSheet.UsedRange.Cells.Columns.Count;
                int iValue = oSheet.UsedRange.Cells.Rows.Count;
                List<string> columns = new List<string>();
                for (int i = 1; i <= jValue; i++)
                {
                    oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, i];
                    columns.Add(oRng.Text.ToString());
                }

                //  get data columns
                for (int j = 0; j < jValue; j++)
                {
                    dt.Columns.Add(columns[j], System.Type.GetType("System.String"));
                }

                //  get data in cell
                for (int i = 2; i <= iValue; i++)
                {
                    dr = ds.Tables["dtExcel"].NewRow();
                    for (int j = 1; j <= jValue; j++)
                    {
                        oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j];
                        string strValue = oRng.Text.ToString();
                        dr[columns[j - 1]] = strValue;
                    }
                    ds.Tables["dtExcel"].Rows.Add(dr);
                }
                return ds;
            }
            catch { return null; }
            finally
            {
                oXL.Quit();
            }
        }

        public static List<Dictionary<string, object>> ToDictionaryList(this System.Data.DataTable table)
        {
            List<Dictionary<string, object>> importedItems = new List<Dictionary<string, object>>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Dictionary<string, object> item = new Dictionary<string, object>();
                foreach (DataColumn column in table.Columns)
                    item.Add(column.ColumnName, row[column]);
                importedItems.Add(item);
            }
            return importedItems;
        }

        private static void MarkImportedCorrespondences(List<Dictionary<string, object>> importedItems, int dealerId)
        {
            List<Product> products = new List<Product>();
            List<Group> groups = new List<Group>();
            using (ZamovStorage context = new ZamovStorage())
            {
                products = (from product in context.Products
                            where product.Deleted == false && product.Dealer.Id == dealerId
                            select product).ToList();

                groups = (from g in context.Groups where g.Dealer.Id == dealerId select g).ToList();
            }
            foreach (var item in importedItems)
            {

            }
        }
    }
}
