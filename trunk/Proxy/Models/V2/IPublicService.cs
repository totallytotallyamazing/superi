using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace BrsmProxy.Models.V2
{
    [ServiceContract(Namespace = "http://loyalty.eps.lt/2012/11/public")]
    public interface IPublicService
    {
        [OperationContract]
        BonusAdjustOperationsResult GetBonusAdjustOperations(string profileId, string pageToken, DateTime from, DateTime to);

        [OperationContract]
        Profile GetProfileByAnyCardNumber(string cardNumber);

        [OperationContract]
        BonusPointRangedPromotionInfo[] GetBonusPointRangedPromotionInformation(string profileId);

        [OperationContract]
        void SetProfileProperties(string profileId, Property[] changedProperties);

        [OperationContract]
        ReceiptsResult GetReceipts(string profileId, string pageToken, DateTime from, DateTime to);
    }
}