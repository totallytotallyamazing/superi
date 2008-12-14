using System;
using Superi.Features;

public partial class Administration_UploadPdf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(fuPdf.HasFile)
        {
            System.IO.File.Delete(Server.MapPath("~/UserFiles/File/menu_Izumi.pdf"));
            fuPdf.SaveAs(Server.MapPath("~/UserFiles/File/menu_Izumi.pdf"));
        }
        else
            Response.Write("<script type=\"text/javascript\">alert('Âûבונטעו פאיכ')</script>");

        
    }
}
