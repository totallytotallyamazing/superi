using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Superi.Common;

public partial class Controls_CheckOutControl : System.Web.UI.UserControl
{
    private HtmlTableCell cell;
    private HtmlTableRow row;

    protected void Page_Load(object sender, EventArgs e)
    {
       Render();
    }

    protected void Render()
    {
        foreach (CartItem cartItem in Cart.Items)
        {
            row = new HtmlTableRow();
            if (cartItem.Type == ItemCartType.Book)
            {
                Book book = new Book(cartItem.ID);
                cell = new HtmlTableCell();
                cell.InnerHtml = book.Names[WebSession.Language];
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = book.Price.ToString("N");
                row.Cells.Add(cell);
            }
            else if (cartItem.Type == ItemCartType.Disk)
            {
                Disk disk = new Disk(cartItem.ID);
                cell = new HtmlTableCell();
                cell.InnerHtml = disk.Names[WebSession.Language];
                row.Cells.Add(cell);

                cell = new HtmlTableCell();
                cell.InnerHtml = disk.Price.ToString("N");
                row.Cells.Add(cell);
            }
            else if (cartItem.Type == ItemCartType.Membership)
            { 
            
            }
            tblCheckout.Rows.Add(row);
        }
    }
}
