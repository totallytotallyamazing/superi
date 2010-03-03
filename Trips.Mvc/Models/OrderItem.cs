using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trips.Mvc.Models
{
    public class OrderItem
    {
        public long CarId { get; set; }
        public long Year { get; set; }
        public long Class { get; set; }
        public int Quantity { get; set; }
        public string AdModel { get; set; }
        public string ImageSource { get; set; }
    }
}
