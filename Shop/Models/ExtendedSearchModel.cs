using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class ExtendedSearchModel
    {
        public string Phrase { get; set; }
        public int? CategoryId { get; set; }
        public int? SizeId { get; set; }
        public float? PriceFrom { get; set; }
        public float? PriceTo { get; set; }
        public int? ContentId { get; set; }
        public int? BrandId { get; set; }
    }
}