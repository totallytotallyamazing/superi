using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Helpers
{
    public static class LinqHelper
    {
        public static bool In<T>(this T value, params T[] values)
        {
            if (value == null)
                return false;
            foreach (var val in values)
            {
                if (value.Equals(val))
                    return true;
            }
            return false;
        }
    }
}