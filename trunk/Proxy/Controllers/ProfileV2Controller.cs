using BrsmProxy.Models.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrsmProxy.Controllers
{
    public class ProfileV2Controller : ApiController
    {
        IPublicService _serviceClient = null;

        public ProfileV2Controller()
        {

        }

        public Profile GetProfileByAnyCardNumber(string id)
        {
            return new Profile();
        }

        public BonusPointRangedPromotionInfo[] GetBonusPointRangedPromotionInformation(string profileId)
        {
            return new BonusPointRangedPromotionInfo[] { new BonusPointRangedPromotionInfo() };
        }

        [HttpPost]
        public void SetProfileProperties(SetProfileRequest request) 
        { 
            
        }

        public BonusAdjustOperationsResult GetBonusAdjustOperations(string profileId, string pageToken, DateTime from, DateTime to)
        {
            return new BonusAdjustOperationsResult();
        }

        public ReceiptsResult GetReceipts(string profileId, string pageToken, DateTime from, DateTime to)
        {
            return new ReceiptsResult();
        }
    }

    class SetProfileRequest
    {
        public string ProfileId { get; set; }
        public Property[] ChangedProperties { get; set; }
    }
}
