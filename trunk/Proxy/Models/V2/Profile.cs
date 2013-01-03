using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/11/public")]
    public class Profile
    {
        [DataMember]
        public string ProfileId { get; set; }

        [DataMember]
        Property[] Properties { get; set; }

        [DataMember]
        BonusPointsForPeriod[] BonusPoints { get; set; }
    }
}