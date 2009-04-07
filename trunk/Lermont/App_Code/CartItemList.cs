using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartItemList
/// </summary>
public class CartItemList:List<CartItem>
{
    public CartItemList()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Equals(CartItem a, CartItem b)
    {
        if (a.ID == b.ID)
            return true;
        return false;
    }
}
