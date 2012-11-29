using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BrsmProxy.Models.V2
{
    public sealed class BonusPoint
    {
        [DataMember]
        public string BonusPointId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Balance { get; set; }
    }
}