using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for Cart
/// </summary>
public static class Cart
{
    public static void AddItem(CartItem item)
    {
        if (HttpContext.Current.Cache["cartItems"] == null)
            HttpContext.Current.Cache["cartItems"] = new CartItemList();
        CartItemList list = (HttpContext.Current.Cache["cartItems"] as CartItemList);
        list.Add(item);
    }

    public static CartItemList Items
    {
        get
        {
            if (HttpContext.Current.Cache["cartItems"] == null)
                return new CartItemList();
            return (HttpContext.Current.Cache["cartItems"] as CartItemList);
        }
    }

    public static void RemoveItem(CartItem item)
    {
        for (int i = Items.Count - 1; i >= 0; i--)
        {
            if (item.ID == Items[i].ID)
                Items.Remove(Items[i]);
        }
    }
}