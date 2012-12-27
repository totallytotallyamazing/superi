using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public class BonusPointOperation
    {
        [DataMember]
        public string BonusPointId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime OperationDate { get; set; }
        [DataMember]
        public string TransactionId { get; set; }
        [DataMember]
        public int Amount { get; set; }
    }
}