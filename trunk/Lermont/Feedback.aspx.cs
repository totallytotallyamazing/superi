using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;
using Superi.CustomControls;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class Feedback : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        rlComment.Language = WebSession.Language;
        rlName.Language = WebSession.Language;
        rbPostComment.Language = WebSession.Language;
        revEmail.ErrorMessage = new Text("wrongEmail").TextResource[WebSession.Language];
    }

    protected void rbPostComment_Click(object sender, EventArgs e)
    {
        FAQ comment = new FAQ();
        comment.Question = tbComment.Text;
        comment.Email = tbEmail.Text;
        comment.Name = tbName.Text;
        comment.Display = false;
        comment.Save();
        SendMail();
    }

    protected void Page_PreRender()
    {
        PublishComments();
    }

    private void PublishComments()
    {
        FAQList list = FAQs.Get(true);
        rComments.DataSource = list;
        rComments.DataBind();
    }

    public void SendMail()
    {
        SmtpClient client = new SmtpClient(WebSession.SmtpServer);
        client.Credentials = new NetworkCredential(WebSession.SmtpAccount, WebSession.SmptPassword);
        MailMessage message = new MailMessage(WebSession.NotificationsSource, WebSession.DefaultNotificationsReceiver);
        message.IsBodyHtml = true;
        message.BodyEncoding = Encoding.GetEncoding("koi8-r");
        message.Subject = "Новый отзыв на сайте " + WebSession.BaseUrl;
        StringBuilder sbBody = new StringBuilder();
        sbBody.AppendFormat("На сайт {0} был добавлен отзыв следующего содержания:<br />", WebSession.BaseUrl);
        sbBody.Append(tbComment.Text);
        sbBody.Append("<br /><br />");
        sbBody.AppendFormat("Для управления отзывами воспользуйтесь <a href={0}/administration/feedback.aspx>этой</a> ссылкой.", WebSession.BaseUrl);
        message.Body = sbBody.ToString();
        client.Send(message);
    }

    protected void rComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            (e.Item.FindControl("rlName") as ResourceLabel).Language = WebSession.Language;
            (e.Item.FindControl("rlComment") as ResourceLabel).Language = WebSession.Language;
            FAQ faq = (FAQ)e.Item.DataItem;

            Label lName = (Label)e.Item.FindControl("lName");
            Label lEmail = (Label)e.Item.FindControl("lEmail");
            HyperLink hlEmail = (HyperLink)e.Item.FindControl("hlEmail");
            Literal lComment = (Literal)e.Item.FindControl("lComment");

            lName.Text = faq.Name;
            if (string.IsNullOrEmpty(faq.Email))
                hlEmail.Visible = lEmail.Visible = false;
            else
            {
                hlEmail.NavigateUrl = "mailto:" + faq.Email;
                hlEmail.Text = faq.Email;
            }
            lComment.Text = faq.Question;
       }
    }
}
