using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lady.Models
{
    public class OrderItem
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public List<ProductAttributeValue> SelectedAttributes { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}