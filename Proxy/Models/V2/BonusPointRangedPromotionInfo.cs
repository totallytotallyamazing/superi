using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrsmProxy.Models.V2
{
    [DataContract(Namespace = "http://loyalty.eps.lt/2012/11/public")]
    public class BonusPointRangedPromotionInfo
    {
        [DataMember]
        public string PromotionName { get; set; }

        [DataMember]
        public string PromotionId { get; set; }

        [DataMember]
        public string BonusPointIdForRewardCalculation { get; set; }

        [DataMember]
        public RewardType RewardType { get; set; }

        [DataMember]
        public decimal CurrentReward { get; set; }

        RewardStep[]  PromotionRewardSteps { get; set; }

    }

    [DataContract(Namespace = "http://loyalty.eps.lt/2012/11/public")]
    public enum RewardType
    {
        [EnumMember]
        PercentDiscount,
        [EnumMember]
        MoneyDiscount
    }
}
