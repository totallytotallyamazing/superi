using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public enum ItemCartType
{
    Membership = 0,
    Book = 1,
    Disk = 2 
}

/// <summary>
/// Summary description for CartItem
/// </summary>
public class CartItem
{
    public int ID{get; set;}
    public ItemCartType Type { get; set; }
}
