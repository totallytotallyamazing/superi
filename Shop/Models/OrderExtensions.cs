using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public static class OrderExtensions
    {
        public static float GetTotalAmount(this IEnumerable<OrderItem> order)
        {
            return order.Sum(oi => oi.Quantity * oi.Price);
        }

        public static string GetPaymentProperty(this Order order, string fieldName)
        {
            string result = string.Empty;
            if (order.PaymentPropertyValues.Count > 0)
            {
                PaymentPropertyValue property = order.PaymentPropertyValues.FirstOrDefault(pp => pp.PaymentProperty.FieldName == fieldName);
                if (property != null)
                    result = property.Value;
            }
            return result;
        }
    }
}
