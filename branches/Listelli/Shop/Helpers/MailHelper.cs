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

        private static int _portionSize = 10;

        private static IEnumerable<List<MailAddress>> SplitMailAdresses(List<MailAddress> source)
        {
            int numberOfPortions;
            if (source.Count % _portionSize > 0)
                numberOfPortions = (source.Count / _portionSize) + 1;
            else
                numberOfPortions = (source.Count / _portionSize);
            
            List<MailAddress>[] portions = new List<MailAddress>[numberOfPortions];

            for (int i = 0; i < source.Count; i++)
            {
                int currentPortion = i / _portionSize;
                var currentItem = source[i];

                if (portions[currentPortion] == null)
                    portions[currentPortion] = new List<MailAddress>();

                portions[currentPortion].Add(currentItem);
            }

            return portions;
        }

        public static bool SendMessage(List<MailAddress> to, string body, string subject, bool isBodyHtml)
        {
            SmtpClient client = new SmtpClient();
            bool result = true;
            try
            {
                var portions = SplitMailAdresses(to);
                foreach (List<MailAddress> mailAddresses in portions)
                {
                    MailMessage message = new MailMessage();
                    message.Headers["Content-Base"] = "http://listelli.ua";
                    message.Body = body;
                    message.Subject = subject;

                    mailAddresses.ForEach(t => message.To.Add(t));
                    message.From = new MailAddress("news@listelli.ua","Listelli");
                    message.IsBodyHtml = isBodyHtml;
                    client.Send(message);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SendTemplate(List<MailAddress> to, string template, bool isBodyHtml)
        {
            return SendTemplate(to, string.Empty, template, string.Empty, isBodyHtml, null);
        }

        public static bool SendTemplate(List<MailAddress> to, string subject, string template, string Language, bool isBodyHtml, params object[] replacements)
        {
            string languageFolder = (string.IsNullOrEmpty(Language)) ? string.Empty : Language + "/";
            string filePath = HttpContext.Current.Server.MapPath("~/Content/MailTemplates/" + languageFolder + template);
            FileStream file = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string body = reader.ReadToEnd();
            string formattedBody = (replacements != null && replacements.Length > 0) ? string.Format(body, replacements) : body;
            reader.Close();
            return SendMessage(to, formattedBody, subject, isBodyHtml);
        }

        public static bool SendFeedbackTemplate(List<MailAddress> to, string subject, string template, string Language, bool isBodyHtml, params object[] replacements)
        {
            string languageFolder = (string.IsNullOrEmpty(Language)) ? string.Empty : Language + "/";
            string filePath = HttpContext.Current.Server.MapPath("~/Content/MailTemplates/" + languageFolder + template);
            FileStream file = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            string body = reader.ReadToEnd();
            string formattedBody = (replacements != null && replacements.Length > 0) ? string.Format(body, replacements) : body;
            reader.Close();
            return SendMessage(to, formattedBody, subject, isBodyHtml);
        }
    }
}