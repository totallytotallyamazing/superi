using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Pandemiia.Models
{
    public enum UnificatorPositionMode { Prefix, Postfix }

    public static class Utils
    {
        #region Path
        public static string GetFilterPath(string sourceName, string typeName)
        {
            string basePath = VirtualPathUtility.ToAbsolute("~/Filter/{0}/{1}");
            return string.Format(basePath, sourceName, typeName);
        }
        #endregion

        #region Entities
        private static string ConvertTypeName(string typeName)
        {
            string type = "";
            if (typeName != null)
            {
                switch (typeName.ToLower())
                {
                    case "image":
                        type = "Изображения";
                        break;
                    case "video":
                        type = "Видео";
                        break;
                    case "music":
                        type = "Музыка";
                        break;
                    case "reading":
                        type = "Чтиво";
                        break;
                    case "other":
                        type = "Другое";
                        break;
                }
            }
            return type;
        }

        public static List<Entity> GetFilteredList(string source, string typeName, int? pageNumber, out int totalCount)
        {
            EntitiesDataContext context = new EntitiesDataContext();
            int startIndex = (pageNumber == null || pageNumber == 0) ? 1 : pageNumber.Value;
            startIndex--; 
            startIndex *= Settings.PageSize;
            int entitiesCount = Settings.PageSize;
            string type = ConvertTypeName(typeName);
            List<Entity> entities;
            if (string.IsNullOrEmpty(source))
            {
                if (string.IsNullOrEmpty(type))
                    entities = context.Entities.Select(e => e)
                        .OrderByDescending(e=>e.Date)
                        .ToList();
                else
                    entities = context.Entities.Select(e => e)
                        .OrderByDescending(e => e.Date)
                        .Where(e => e.EntityType.Name == type)
                        .ToList();
            }
            else
            {
                if(string.IsNullOrEmpty(type))
                    entities = context.Entities.Select(e => e)
                        .OrderByDescending(e => e.Date)
                        .Where(e => e.EntitySource.Name == source)
                        .ToList();
                else
                    entities = context.Entities.Select(e => e)
                        .OrderByDescending(e => e.Date)
                        .Where(e => (e.EntitySource.Name == source && e.EntityType.Name == type))
                        .ToList();
            }
            totalCount = entities.Count;
            return entities.Skip(startIndex).Take(entitiesCount).ToList();
        }

        public static List<Entity> GetEntityPage(int? pageNumber)
        {
            int i;
            return GetFilteredList(null, null, pageNumber, out i);
        }
        #endregion

        #region UploadFiles

        const string DEFAULT_UNIFICATOR = "_";

        public static string Unificator = DEFAULT_UNIFICATOR;
        public static bool UnificateIncrementally = true;

        public static string ServerPath(string uploadFolder)
        {
            return AppDomain.CurrentDomain.BaseDirectory + uploadFolder.Replace("/", Path.DirectorySeparatorChar.ToString()) + Path.DirectorySeparatorChar;
        }

        public static UnificatorPositionMode UnificatorPosition = UnificatorPositionMode.Postfix;

        public static string GetUniqueFileName(string uploadFolder, string fileName, string initialFileName)
        {
            string result = fileName;
            if (System.IO.File.Exists(ServerPath(uploadFolder) + fileName))
            {
                result = GetUniqueFileName(uploadFolder, AddUnificator(fileName, initialFileName), initialFileName);
            }
            return result;
        }

        private static string AddUnificator(string fileName, string initialFileName)
        {
            string result = initialFileName;
            if (UnificateIncrementally)
            {
                if (UnificatorPosition == UnificatorPositionMode.Prefix)
                {
                    if (initialFileName == fileName)
                    {
                        result = "1" + Unificator + fileName;
                    }
                    else
                    {
                        int fileNameIndex = fileName.IndexOf(fileName);
                        string currentUnificator = fileName.Substring(0, fileNameIndex);
                        int currentIncrement = int.Parse(currentUnificator.Replace(Unificator, ""));
                        currentIncrement++;
                        result = currentIncrement + Unificator + fileName;
                    }
                }
                else
                {
                    string currentUnificator;
                    int currentIncrement;
                    int lastIndexBeforeExt = fileName.LastIndexOf(".");
                    int lastIndexBeforeExtOriginal = initialFileName.LastIndexOf(".");
                    bool noExtension = false;
                    if (lastIndexBeforeExt == -1)
                    {
                        lastIndexBeforeExt = fileName.Length - 1;
                        noExtension = true;
                    }

                    if (initialFileName == fileName)
                    {
                        if (noExtension)
                            result = fileName + Unificator + "1";
                        else
                            result = fileName.Insert(lastIndexBeforeExt, Unificator + "1");
                    }
                    else
                    {
                        if (noExtension)
                        {
                            currentUnificator = fileName.Substring(fileName.Length - 1);
                            currentIncrement = int.Parse(currentUnificator.Replace(Unificator, ""));
                            currentIncrement++;
                            result = fileName + Unificator + currentIncrement;
                        }
                        else
                        {
                            string file = initialFileName.Substring(0, initialFileName.LastIndexOf("."));
                            int length = initialFileName.Length - lastIndexBeforeExt;
                            currentUnificator = fileName.Substring(file.Length, length);
                            currentIncrement = int.Parse(currentUnificator.Replace(Unificator, ""));
                            currentIncrement++;
                            result = initialFileName.Insert(lastIndexBeforeExtOriginal, Unificator + currentIncrement);
                        }
                    }
                }
            }
            else
            {
                if (UnificatorPosition == UnificatorPositionMode.Prefix)
                {
                    result = Unificator + initialFileName;
                }
                else
                {
                    if (fileName.LastIndexOf(".") == -1)
                    {
                        result = fileName + Unificator;
                    }
                    else
                    {
                        result = fileName.Insert(fileName.LastIndexOf("."), Unificator);
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
