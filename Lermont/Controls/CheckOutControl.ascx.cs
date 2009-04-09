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
    private decimal sum = 0;

    private void UpdateCart()
    {
        if (IsPostBack)
        {
            foreach (RepeaterItem rItem in rCheckOut.Items)
            {
                CheckBox cbBuy = (CheckBox)rItem.FindControl("cbRemoveFromCart");
                if (cbBuy.Checked)
                {
                    CartItem cItem = new CartItem();
                    cItem.ID = int.Parse(cbBuy.Attributes["cbvalue"]);
                    cItem.Type = ItemCartType.Book;
                    Cart.RemoveItem(cItem);
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateCart();

        CartItemList cartItemList = Cart.Items;
        rCheckOut.DataSource = cartItemList;
        rCheckOut.DataBind();




        //foreach (RepeaterItem item in rCheckOut.FooterTemplate.InstantiateIn();)
        //{
        //    Literal lSum = (Literal)item.FindControl("lSum");
        //    if (lSum != null)
        //        lSum.Text = sum.ToString("N");
        //}

    }


    protected void rCheckOut_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string title = string.Empty;
            string price = string.Empty;

            Literal lTitle = (Literal)e.Item.FindControl("lTitle");
            Literal lPrice = (Literal)e.Item.FindControl("lPrice");
            Literal lType = (Literal)e.Item.FindControl("lType");
            CheckBox cbBuy = (CheckBox)e.Item.FindControl("cbRemoveFromCart");




            CartItem cartItem = (CartItem)e.Item.DataItem;
            if (cartItem.Type == ItemCartType.Book)
            {
                Book book = new Book(cartItem.ID);
                title = book.Names[WebSession.Language];
                price = book.Price.ToString("N");
                sum += book.Price;
            }
            else if (cartItem.Type == ItemCartType.Disk)
            {
                Disk disk = new Disk(cartItem.ID);
                title = disk.Names[WebSession.Language];
                price = disk.Price.ToString("N");
                sum += disk.Price;
            }
            else if (cartItem.Type == ItemCartType.Membership)
            {

            }

            cbBuy.Attributes["cbvalue"] = cartItem.ID.ToString();

            lTitle.Text = title;
            lPrice.Text = price;
            lType.Text = cartItem.Type.ToString();
        }

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.Footer)
        {
            Literal lSum = (Literal)e.Item.FindControl("lSum");
            if (lSum != null)
                lSum.Text = sum.ToString("N");
        }
    }
}
