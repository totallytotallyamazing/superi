using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrsmProxy.Models.V2
{
    public class RewardStep
    {
        [DataMember]
        public int StepFrom { get; set; }
        [DataMember]
        public int StepTo { get; set; }
        [DataMember]
        public decimal RewardAmount { get; set; }
    }
}
