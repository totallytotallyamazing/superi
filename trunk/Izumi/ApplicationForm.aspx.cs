using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mail;

public partial class ApplicationForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["cp"] = "ApplicationForm.aspx";
       // btnSubmit.Attributes.Add("onclick", "return validateForm()");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Uri uri = new Uri(DefaultValues.BaseUrl+"mails/ApplicationForm.aspx");
        HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(uri);
        StringBuilder ResponseString;
        webRequest.Method = "GET";
        bool success = false;
        try
        {
            WebResponse response = webRequest.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            ResponseString = new StringBuilder(reader.ReadToEnd());
            foreach (string s in Request.Form.AllKeys)
            {
                if (s[0] == 'i' || s[0] == 't')
                {
                    switch(Request.Form[s])
                    {
                        case "yes":
                            ResponseString.Replace("*" + s + "*", "да");
                            break;
                        case "no":
                            ResponseString.Replace("*" + s + "*", "нет");
                            break;
                        case "own":
                            ResponseString.Replace("*" + s + "*", "собственное");
                            break;
                        case "hire":
                            ResponseString.Replace("*" + s + "*", "арендуемое");
                            break;
                        default:
                            ResponseString.Replace("*" + s + "*", Request.Form[s]);
                            break;
                    }
                }
            }
            SendMail(ResponseString.ToString());
            success = true;
        }
        catch (Exception ex)
        {
            success = false;
            Trace.Write("fuck", "mail fucked", ex);
        }
        if (success)
            Response.Redirect(DefaultValues.BaseUrl + "send_success");
        else
            Response.Redirect(DefaultValues.BaseUrl + "send_failed");
    }

    private void SendMail(string body)
    {
        MailMessage message = new MailMessage("franchising@ukrmore.com.ua", "superi@inbox.ru");
        message.Body = body;
        message.Subject = "Franchise";
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("mail.izumi.com.ua");
        //client.Credentials = new NetworkCredential("webmaster@izumi.com.ua", "rhcp43");
        client.Send(message);
    }
}
