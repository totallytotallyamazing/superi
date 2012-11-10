using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace BrsmProxy.Models
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public sealed class Profile
    {
        [DataMember]
        public Property[] Properties { get; set; }

        [DataMember]
        public BonusPoint[] BonusPoints { get; set; }

        [DataMember]
        public BonusPointOperation[] LastBonusAdjustOperations { get; set; }

        [DataMember]
        public Receipt[] LastReceipts { get; set; }
    }

    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public sealed class Property
    {
        [DataMember]
        public string PropertyId { get; set; }

        [DataMember]
        public string Value { get; set; }
    }

    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public sealed class BonusPoint
    {
        [DataMember]
        public string BonusPointId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Balance { get; set; }
    }

    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public sealed class BonusPointOperation
    {
        [DataMember]
        public string BonusPointId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime OperationDate { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string TransactionId { get; set; }

        [DataMember]
        public DateTime? From { get; set; }

        [DataMember]
        public DateTime? To { get; set; }

        [DataMember]
        public decimal Amount { get; set; }
    }

    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public sealed class Receipt
    {
        [DataMember]
        public string TransactionId { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string TerminalId { get; set; }

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
    }

    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public sealed class Promotion
    {
        [DataMember]
        public string PromotionId { get; set; }

        [DataMember]
        public string ExternalName { get; set; }
    }
}
