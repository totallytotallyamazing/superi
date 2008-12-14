using System;
using System.Collections.Generic;
using System.Web;
using Superi.Shop;
using System.Data;

/// <summary>
/// Summary description for Voucher
/// </summary>
public class Voucher:Product
{
    private int productId = int.MinValue;

    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public Voucher()
    {
        Load(int.MinValue);
    }

    public Voucher(int Id)
    {
        Load(Id);
    }

    public Voucher(DataRow dr)
    {
        Load(dr);
    }

    public override bool Load(DataRow dr)
    {
        base.Load(dr);
        LoadProductId();
        return true;
    }

    public override bool Load(int Id)
    {
        base.Load(Id);
        LoadProductId();
        return true;
    }

    public override bool Save()
    {
        base.Save();
        SaveProductId();
        return true;
    }

    public override bool Remove()
    {
        DeleteProductId();
        return base.Remove();
    }

    private void LoadProductId()
    {
        string tmp = ProductPropertyValues.Get(ID, ProductPropertyTypes.ProductId);
        if (!string.IsNullOrEmpty(tmp))
            productId = int.Parse(tmp);
    }

    private void SaveProductId()
    {
        ProductPropertyValues.Set(ID, ProductPropertyTypes.ProductId, productId.ToString());
    }

    private void DeleteProductId()
    {
        ProductPropertyValues.Delete(ID, ProductPropertyTypes.ProductId);
    }
}
