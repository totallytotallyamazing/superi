using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.IO;

namespace Dev.Helpers
{
    public class MailHelper
    {
        public static bool SendMessage(string from, List<MailAddress> to, string body, string subject, bool isBodyHtml)
        {
            SmtpClient client = new SmtpClient();
            bool result = true;
            try
            {
                MailMessage message = new MailMessage();
                message.Body = body;
                message.Subject = subject;
                to.ForEach(t => message.To.Add(t));
                message.From = new MailAddress("no-reply@elena-finger.com");
                message.IsBodyHtml = isBodyHtml;
                client.Send(message);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SendTemplate(string from, List<MailAddress> to, string template, bool isBodyHtml)
        {
            return SendTemplate(from, to, string.Empty, template, string.Empty, isBodyHtml, null);
        }


        public static bool SendTemplate(string from, List<MailAddress> to, string subject, string template, string Language, bool isBodyHtml, params object[] replacements)
        {
            string languageFolder = (string.IsNullOrEmpty(Language)) ? string.Empty : Language + "/";
            string filePath = HttpContext.Current.Server.MapPath("~/Content/MailTemplates/" + languageFolder + template);
            FileStream file = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string body = reader.ReadToEnd();
            string formattedBody = (replacements != null && replacements.Length > 0) ? string.Format(body, replacements) : body;
            reader.Close();
            return SendMessage(from, to, formattedBody, subject, isBodyHtml);
        }
    }
}
