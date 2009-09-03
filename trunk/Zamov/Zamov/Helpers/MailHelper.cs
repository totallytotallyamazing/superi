using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Zamov.Helpers
{
    public static class MailHelper
    {
        private static SmtpClient PrepareClient()
        {
            SmtpClient client = new SmtpClient(ApplicationData.ZamovSmtpHost);
            client.Credentials = new NetworkCredential("info@zamov.net", "cde32wsx");
            return client;
        }

        public static bool SendMessage(string from, List<MailAddress> to, string body, bool isBodyHtml)
        {
            SmtpClient client = PrepareClient();
            bool result = true;
            try
            {
                MailMessage message = new MailMessage();
                message.Body = body;
                to.ForEach(t => message.To.Add(t));
                message.From = new MailAddress(from);
                message.IsBodyHtml = isBodyHtml;
                client.Send(message);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SendTemplate(string from, List<MailAddress> to, string template ,bool isBodyHtml)
        { 
            string filePath = HttpContext.Current.Server.MapPath("~/Content/MailTemplates/" + template);
            FileStream file = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string body = reader.ReadToEnd();
            reader.Close();
            return SendMessage(from, to, body, isBodyHtml);
        }
    }
}
