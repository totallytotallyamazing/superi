using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/11/public")]
    public class Receipt
    {
        [DataMember]
        public string TransactionId { get; set; }
        [DataMember]
        public string CardNumber { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string TerminalId { get; set; }
        [DataMember]
        public string ShopAddress { get; set; }
        [DataMember]
        public string ShopId { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public decimal Discount { get; set; }
        [DataMember]
        public BonusPoint[] BonusPoints { get; set; }
        [DataMember]
        public Promotion[] Promotions { get; set; }
        [DataMember]
        public ReceiptLine[] ReceiptLines { get; set; }
    }
}