using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/11/public")]
    public class ReceiptLine
    {
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public decimal ProductQuantity { get; set; }
        [DataMember]
        public decimal ProductPrice { get; set; }
    }
}
