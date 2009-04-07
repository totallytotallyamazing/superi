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
        if(Items!=null && Items.Contains(item, new CartItemComparer()))
            Items.Remove(item);
    }
}

public class CartItemComparer : IEqualityComparer<CartItem>
{
    public bool Equals(CartItem a, CartItem b)
    {
        if (a.ID == b.ID)
            return true;
        return false;
    }

    public int GetHashCode(CartItem obj)
    {
        return obj.ID.GetHashCode();
    }

}
