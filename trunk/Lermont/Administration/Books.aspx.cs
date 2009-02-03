using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Superi.Features;

public partial class Administration_Books : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["resourceControlCount"] = 0;
        lbAdd.Attributes.Add("onclick", "setAction('addEditBook')");
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int bookId = int.Parse(e.CommandArgument.ToString());
        Book book = new Book(bookId);
        switch (e.CommandName)
        {
            case "DeleteBook":
                RemovePicture(book.Picture);
                book.Remove();
                GridView1.DataBind();
                break;
            case "EditBook":
                baeMain.BookId = book.ID;
                break;
            case "EditDescription":
                ebdMain.BookId = book.ID;
                break;
        }
    }

    private void RemovePicture(string FileName)
    {
        if (!string.IsNullOrEmpty(FileName))
        {
            string path = Server.MapPath(WebSession.ProductsImagesFolder) + "\\";
            File.Delete(path + FileName);
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            Book book = (Book) e.Row.DataItem;
            Literal lTitle = (Literal) e.Row.FindControl("lTitle");
            LinkButton lbEdit = (LinkButton) e.Row.FindControl("lbEdit");
            LinkButton lbDelete = (LinkButton) e.Row.FindControl("lbDelete");
            LinkButton lbDescription = (LinkButton)e.Row.FindControl("lbDescription");

            lbDelete.CommandArgument = book.ID.ToString();
            lbEdit.CommandArgument = book.ID.ToString();
            lbDescription.CommandArgument = book.ID.ToString();

            lbEdit.Attributes.Add("onclick", "setAction('addEditBook')");
            lbDescription.Attributes.Add("onclick", "setAction('editDescription')");
            lTitle.Text = book.Names["RU"];

            lbDelete.Attributes.Add("onclick", "return confirmDelete()");
        }
    }

    protected void lbAdd_Click(object sender, EventArgs e)
    {
        baeMain.BookId = int.MinValue;
        
    }

    protected void ReorderList1_ItemDataBound(object sender, AjaxControlToolkit.ReorderListItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            DataRowView book = (DataRowView)e.Item.DataItem;
            DataRow row = book.Row;
            Literal lTitle = (Literal)e.Item.FindControl("lTitle");
            LinkButton lbEdit = (LinkButton)e.Item.FindControl("lbEdit");
            LinkButton lbDelete = (LinkButton)e.Item.FindControl("lbDelete");
            LinkButton lbDescription = (LinkButton)e.Item.FindControl("lbDescription");

            lbDelete.CommandArgument = row["ID"].ToString();
            lbEdit.CommandArgument = row["ID"].ToString();
            lbDescription.CommandArgument = row["ID"].ToString();

            lbEdit.Attributes.Add("onclick", "setAction('addEditBook')");
            lbDescription.Attributes.Add("onclick", "setAction('editDescription')");
            lTitle.Text = new Resource(Convert.ToInt32(row["NameTextID"]))["RU"];
                //book.Names["RU"];

            lbDelete.Attributes.Add("onclick", "return confirmDelete()");
        }
    }
}
