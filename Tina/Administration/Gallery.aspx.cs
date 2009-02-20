using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicContext;

public partial class Administration_Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList ddlAlbums = (DropDownList)FormView1.FindControl("ddlAlbums");
        if (ddlAlbums != null)
        {
            Musics.MusicDataContext context = new Musics.MusicDataContext();
            List<Album> albums = context.Albums.Select(al => al).ToList();
            ddlAlbums.Items.Add(new ListItem("-", "0"));
            foreach (var item in albums)
            {
                ddlAlbums.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowState == DataControlRowState.Edit)
        {
            DropDownList ddlAlbums = (DropDownList)e.Row.FindControl("ddlAlbums");
            if (ddlAlbums != null)
            {
                Musics.MusicDataContext context = new Musics.MusicDataContext();
                List<Album> albums = context.Albums.Select(al => al).ToList();
                ddlAlbums.Items.Add(new ListItem("-", "0"));
                foreach (var item in albums)
                {
                    ddlAlbums.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                }
            }
        }
    }
}
