<%@ WebHandler Language="C#" Class="VoucherBackground" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

public class VoucherBackground : IHttpHandler {

    
    public void ProcessRequest (HttpContext context) {
        Image image = Image.FromFile(context.Server.MapPath("~/images/voucherBg.jpg"));
        Image uah = Image.FromFile(context.Server.MapPath("~/images/uah.png"));
        Bitmap bmp = new Bitmap(210, 130);
        Graphics graphics = Graphics.FromImage(bmp);
        graphics.DrawImage(image, 0, 0, 210, 130);
        Font drawFont = new Font("Arial", 35);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        SolidBrush drawBrush1 = new SolidBrush(ColorTranslator.FromHtml("#E9A100"));
        SizeF amountSize = graphics.MeasureString(GetAmount(context).ToString(), drawFont);

        int textX = (int)(105 - (27 + amountSize.Width) / 2);
        int textY = (int)(65 - amountSize.Height / 2);
        int uahX = (int)(textX + amountSize.Width);
        //int uahY = 54;
        graphics.DrawString(GetAmount(context).ToString(), drawFont, drawBrush, textX, textY);
        graphics.DrawString(GetAmount(context).ToString(), drawFont, drawBrush1, textX + 1, textY + 1);
        graphics.DrawImage(uah, uahX, 53);
        
        context.Response.ContentType = "image/jpeg";

        MemoryStream imageStream = new MemoryStream();

        // put the image into the memory stream
        bmp.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] imageContent = new Byte[imageStream.Length];
        imageStream.Position = 0;
        imageStream.Read(imageContent, 0, (int)imageStream.Length);
        
        context.Response.BinaryWrite(imageContent);
    }

    private int GetAmount(HttpContext context)
    {
        if (!string.IsNullOrEmpty(context.Request.QueryString["am"]))
            return int.Parse(context.Request.QueryString["am"]);
        return 0;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}