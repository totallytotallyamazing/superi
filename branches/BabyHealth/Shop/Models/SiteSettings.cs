using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class SiteSettings
    {
        public decimal EuroRate { get; set; }
        public decimal DollarRate { get; set; }
        public decimal RubleRate { get; set; }
        public string ReceiverMail { get; set; }
        public int PageSize { get; set; }
    }
}
