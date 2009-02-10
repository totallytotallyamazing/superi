using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Image=System.Drawing.Image;
using Superi.Common;

public partial class MakeThumbnail : Page
{
    private int MaxDimension
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["dim"]))
                return int.Parse(Request.QueryString["dim"]);
            return int.MinValue;
        }
    }

    private int Width
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["w"]))
                return int.Parse(Request.QueryString["w"]);
            return int.MinValue;
        }
    }

    private int Height
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["h"]))
                return int.Parse(Request.QueryString["h"]);
            return int.MinValue;
        }
    }

    private string ImageLocationPath
    {
        get
        {
            switch (Request.QueryString["loc"])
            {
                case "practice":
                    return Server.MapPath(WebSession.ArticlesImagesFolder) + "\\";
                case "article":
                    return Server.MapPath(WebSession.ArticlesImagesFolder) + "\\";
                case "gallery":
                    return Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
                case "products":
                    return Server.MapPath(WebSession.ProductsImagesFolder) + "\\";
                default:
                    return Server.MapPath(WebSession.GalleryImagesFolder) + "\\";
            }
        }
    }

    private HorizontalAlign HAlign
    {
        get
        {
            switch (Request.QueryString["ha"])
            {
                case "l":
                    return HorizontalAlign.Left;
                case "r":
                    return HorizontalAlign.Right;
                case "c":
                    return HorizontalAlign.Center;
                default:
                    return HorizontalAlign.Center;
            }
        }
    }

    private VerticalAlign VAlign
    {
        get
        {
            switch (Request.QueryString["va"])
            {
                case "t":
                    return VerticalAlign.Top;
                case "b":
                    return VerticalAlign.Bottom;
                case "m":
                    return VerticalAlign.Middle;
                default:
                    return VerticalAlign.Middle;
            }
        }
    }

    private bool KeepProportions
    {
        get { return string.IsNullOrEmpty(Request.QueryString["kp"]); }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string file = Request.QueryString["file"];
        if (file.IndexOf("?") > -1)
            file = file.Substring(0, file.IndexOf("?"));
        Image image = Image.FromFile(ImageLocationPath + file);
        Bitmap thumbnailImage;
        if(MaxDimension<=0)
        {
            thumbnailImage = ProcessDimensions(image);
        }
        else
        {
            thumbnailImage = ProcessMaxDimension(image);
        }
        DrawImage(thumbnailImage);
        image.Dispose();
        
    }

    private void DrawImage(Bitmap thumbnailImage)
    {
        MemoryStream imageStream = new MemoryStream();

        // put the image into the memory stream
        thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

        // make byte array the same size as the image
        byte[] imageContent = new Byte[imageStream.Length];

        // rewind the memory stream
        imageStream.Position = 0;

        // load the byte array with the image
        imageStream.Read(imageContent, 0, (int)imageStream.Length);

        // return byte array to caller with image type
        Response.ContentType = "image/jpeg";
        Response.BinaryWrite(imageContent);
        //image.Dispose();
    }

    private Bitmap ProcessDimensions(Image image)
    {
        Bitmap thumbnailImage = new Bitmap(Width, Height);
        Graphics graphics = Graphics.FromImage(thumbnailImage);
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        int sourceWidth;
        int sourceHeight;
        if (KeepProportions)
        {
            if (Width > Height)
            {
                sourceWidth = image.Width;
                sourceHeight = (image.Width*Height)/Width;
                if (image.Height < sourceHeight)
                {
                    sourceWidth = (sourceHeight*Width)/Height;
                }
            }
            else if (Height > Width)
            {
                sourceHeight = image.Height;
                sourceWidth = (image.Height*Width)/Height;
                if (sourceWidth > image.Width)
                {
                    sourceHeight = (sourceWidth*Height)/Width;
                }
            }
            else
            {
                if (image.Width > image.Height)
                {
                    sourceHeight = image.Height;
                    sourceWidth = (image.Height*Width)/Height;
                    if (sourceWidth > image.Width)
                    {
                        sourceHeight = (sourceWidth*Height)/Width;
                    }
                }
                else if (image.Height > image.Width)
                {
                    sourceWidth = image.Width;
                    sourceHeight = (image.Width*Height)/Width;
                    if (image.Height < sourceHeight)
                    {
                        sourceWidth = (sourceHeight*Width)/Height;
                    }
                }
                else
                {
                    sourceHeight = image.Height;
                    sourceWidth = image.Width;
                }
            }
        }
        else
        {
            sourceWidth = image.Width;
            sourceHeight = image.Height;
        }
        int sourceHOffset = 0;
        int sourceVOffset = 0;

        //if(sourceWidth<image.Width)
        switch (HAlign)
        {
            case HorizontalAlign.Left:
                sourceHOffset = 0;
                break;
            case HorizontalAlign.Center:
                sourceHOffset = (image.Width - sourceWidth)/2;
                break;
            case HorizontalAlign.Right:
                sourceHOffset = image.Width - sourceWidth;
                break;
        }

        switch (VAlign)
        {
            case VerticalAlign.Top:
                sourceVOffset = 0;
                break;
            case VerticalAlign.Middle:
                sourceVOffset = (image.Height - sourceHeight) / 2;
                break;
            case VerticalAlign.Bottom:
                sourceVOffset = image.Height - sourceHeight;
                break;
        }
           
        //if (sourceHeight > image.Height)

        Rectangle sourceRctangle = new Rectangle(sourceHOffset, sourceVOffset, sourceWidth, sourceHeight);
        Rectangle destinationRectangle = new Rectangle(0, 0, Width, Height);

        graphics.DrawImage(image, destinationRectangle, sourceRctangle, GraphicsUnit.Pixel);
        return thumbnailImage;
    }

    private Bitmap ProcessMaxDimension(Image image)
    {
        int width;
        int height;
        if (image.Width > image.Height)
        {
            width = MaxDimension;
            height = (MaxDimension * image.Height) / image.Width;

        }
        else if (image.Height > image.Width)
        {
            height = MaxDimension;
            width = (MaxDimension * image.Width) / image.Height;
        }
        else
            width = height = MaxDimension;
        Bitmap thumbnailImage = new Bitmap(width, height);
        Graphics graphics = Graphics.FromImage(thumbnailImage);
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        graphics.DrawImage(image, 0, 0, thumbnailImage.Width, thumbnailImage.Height);
        return thumbnailImage;

    }

    ///  <summary>
    /// Required, but not used
    /// </summary>
    /// <returns>true</returns>
    public bool ThumbnailCallback()
    {
        return true;
    }
}
