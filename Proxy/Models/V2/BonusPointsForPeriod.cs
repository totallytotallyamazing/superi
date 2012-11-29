using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrsmProxy.Models.V2
{
    public class BonusPointsForPeriod
    {
        [DataMember]
        public BonusPoint BonusPoints { get; set; }

        [DataMember]
        public TimePeriod TimePeriod { get; set; }
    }

    public enum TimePeriod
    {
        Total,
        ThisWeek,
        ThisMonth,
        ThisQuarter,
        LastWeek,
        LastMonth,
        LastQuarter
    }
}
