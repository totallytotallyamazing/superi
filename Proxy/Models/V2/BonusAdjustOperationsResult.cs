using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrsmProxy.Models.V2
{
    public class BonusAdjustOperationsResult
    {
        [DataMember]
        BonusPointOperation[] BonusPointOperations { get; set; }
        [DataMember]
        public string NextPageToken { get; set; }
    }
}
