using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zamov.Models;

namespace Zamov.Helpers
{
    public class PSortByProductNameAsc : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return x.Name.CompareTo(y.Name);
        }
    }

    public class PSortByProductNameDesc : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return y.Name.CompareTo(x.Name);
        }
    }

    public class PSortByPriceAsc : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return x.Price.CompareTo(y.Price);
        }
    }
    public class PSortByPriceDesc : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return y.Price.CompareTo(x.Price);
        }
    }

////////////////////////////
    
    public class SortByProductNameAsc : IComparer<ProductSearchPresentation>
    {
        public int Compare(ProductSearchPresentation x, ProductSearchPresentation y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return x.Name.CompareTo(y.Name);
        }
    }

    public class SortByProductNameDesc : IComparer<ProductSearchPresentation>
    {
        public int Compare(ProductSearchPresentation x, ProductSearchPresentation y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return y.Name.CompareTo(x.Name);
        }
    }

    public class SortByDealerNameAsc : IComparer<ProductSearchPresentation>
    {
        public int Compare(ProductSearchPresentation x, ProductSearchPresentation y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return x.DealerName.CompareTo(y.DealerName);
        }
    }
    public class SortByDealerNameDesc : IComparer<ProductSearchPresentation>
    {
        public int Compare(ProductSearchPresentation x, ProductSearchPresentation y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return y.DealerName.CompareTo(x.DealerName);
        }
    }

    public class SortByPriceAsc : IComparer<ProductSearchPresentation>
    {
        public int Compare(ProductSearchPresentation x, ProductSearchPresentation y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return x.Price.CompareTo(y.Price);
        }
    }
    public class SortByPriceDesc : IComparer<ProductSearchPresentation>
    {
        public int Compare(ProductSearchPresentation x, ProductSearchPresentation y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else if (y == null)
                return 1;
            else
                return y.Price.CompareTo(x.Price);
        }
    }
}
