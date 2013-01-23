using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/11/public")]
    public class BonusPointsForPeriod
    {
        [DataMember]
        public BonusPoint BonusPoints { get; set; }

        [DataMember]
        public TimePeriod Period { get; set; }
    }

    [DataContract(Namespace = "http://loyalty.eps.lt/2012/11/public")]
    public enum TimePeriod
    {
        [EnumMember]
        Total,
        [EnumMember]
        ThisWeek,
        [EnumMember]
        ThisMonth,
        [EnumMember]
        ThisQuarter,
        [EnumMember]
        LastWeek,
        [EnumMember]
        LastMonth,
        [EnumMember]
        LastQuarter
    }
}
