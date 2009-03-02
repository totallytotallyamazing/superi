using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Administration_Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GalleryList list = new GalleryList(true);
            foreach (Gallery item in list)
            {
                ListItem listItem = new ListItem(item.Titles["RU"], item.ID.ToString());
                ddlGalleries.Items.Add(listItem);
            }
        }
    }

    protected void PagePreRender(object sender, EventArgs e)
    {

        GridView1.DataBind();
    }
}
