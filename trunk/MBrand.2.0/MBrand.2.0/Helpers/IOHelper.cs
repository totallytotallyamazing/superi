using System;
using System.IO;
using System.Web;
using System.Threading;

namespace MBrand.Helpers
{
    public static class IOHelper
    {
        public static void DeleteFile(string relativePath, string fileName, int count = 0)
        {
            string absolutePath = HttpContext.Current.Server.MapPath(relativePath);
            try
            {
                File.Delete(Path.Combine(absolutePath, fileName));
            }
            catch (Exception)
            {
                if (count >= 10)
                {
                    return;
                }
                Thread.Sleep(500);
                DeleteFile(relativePath, fileName, count + 1);
            }
        }

        public static string CreateAbsolutePath(string relativePath, string fileName)
        {
            return Path.Combine(HttpContext.Current.Server.MapPath(relativePath), fileName);
        }

        public static void SaveFile(this HttpPostedFileBase file, string relativePath, string fileName)
        {
            file.SaveAs(CreateAbsolutePath(relativePath, fileName));
        }

        public static string GetUniqueFileName(string relativePath, string initialName)
        {
            string result = initialName;
            string filePath = HttpContext.Current.Server.MapPath(relativePath);

            filePath = Path.Combine(filePath, initialName);

            if (File.Exists(filePath))
            {
                string newFileName = MakeNewFileName(initialName);
                result = GetUniqueFileName(relativePath, newFileName);
            }
            return result;
        }

        private static string MakeNewFileName(string fileName)
        {
            string result = fileName;
            if (Path.HasExtension(fileName))
            {

                string ext = Path.GetExtension(fileName);
                result = Path.GetFileNameWithoutExtension(fileName) + "1" + ext;
            }
            else
                result += "1";
            return result;
        }
    }
}