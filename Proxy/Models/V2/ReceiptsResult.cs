﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public class ReceiptsResult
    {
        [DataMember]
        Receipt[] Receipts { get; set; }
    }
}
