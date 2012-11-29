using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public sealed class Property
    {
        [DataMember]
        public string PropertyId { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}