using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Vouchers
/// </summary>
public static class Vouchers
{
    public static VoucherList Get()
    {
        return new VoucherList(true);
    }

    public static VoucherList Get(int ProductId)
    {
        return new VoucherList(ProductId);
    }

    public static void Update(int Id, int Price)
    {
        Voucher voucher = new Voucher(Id);
        voucher.Price = Price;
        voucher.Save();
    }

    public static void Insert(int ProductId, int Price)
    {
        Voucher voucher = new Voucher();
        voucher.ProductId = ProductId;
        voucher.Price = Price;
        voucher.Save();
    }
}
