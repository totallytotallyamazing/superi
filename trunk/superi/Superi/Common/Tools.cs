using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Superi.Common
{
    public class Tools
    {

        public static object GetPropertyValue(string PropertyName, object Item)
        {
            Type type = Item.GetType();
            BindingFlags flags = BindingFlags.GetProperty;
            object value = type.InvokeMember(PropertyName, flags, null, Item, null);
            return value;
        } 
    }
}
