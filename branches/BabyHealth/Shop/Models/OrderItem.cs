using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class OrderItem
    {
        List<ProductAttributeValue> selectedAttributes = new List<ProductAttributeValue>();

        public int ProductId { get; set; }
        public string Name { get; set; }
        public List<ProductAttributeValue> SelectedAttributes { get { return selectedAttributes; } }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
    }
}