using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public sealed class Promotion
    {
        [DataMember]
        public string PromotionId { get; set; }

        [DataMember]
        public string ExternalName { get; set; }
    }
}