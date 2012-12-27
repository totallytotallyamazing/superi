using BrsmProxy.Models.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Web.Http;

namespace BrsmProxy.Controllers
{
    public class ProfileV2Controller : ApiController
    {
        IPublicService _serviceClient = null;

        public ProfileV2Controller()
        {
            _serviceClient = GetServiceChannel();
        }

        public Profile GetProfileByAnyCardNumber(string id)
        {
            var result =  _serviceClient.GetProfileByAnyCardNumber(id);
            return result;
        }

        public BonusPointRangedPromotionInfo[] GetBonusPointRangedPromotionInformation(string profileId)
        {
            return _serviceClient.GetBonusPointRangedPromotionInformation(profileId);
        }

        [HttpPost]
        public void SetProfileProperties(SetProfileRequest request) 
        {
            _serviceClient.SetProfileProperties(request.ProfileId, request.ChangedProperties);
        }

        public BonusAdjustOperationsResult GetBonusAdjustOperations(string profileId, string pageToken, DateTime from, DateTime to)
        {
            return _serviceClient.GetBonusAdjustOperations(profileId, pageToken, from, to);
        }

        public ReceiptsResult GetReceipts(bool receipts, string profileId, string pageToken, DateTime from, DateTime to)
        {
            return _serviceClient.GetReceipts(profileId, pageToken, from, to);
        }

        private IPublicService GetServiceChannel()
        {
            var binding = new WSHttpBinding(SecurityMode.Message);
            binding.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic128;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            binding.Security.Message.EstablishSecurityContext = false;
            binding.Security.Message.NegotiateServiceCredential = false;

            var address = new EndpointAddress(new Uri("http://91.220.114.71:8998/public"), new DnsEndpointIdentity("EpsLoyBackOffice"));

            var factory = new ChannelFactory<IPublicService>(binding, address);
            factory.Credentials.ClientCertificate.Certificate = new X509Certificate2(System.Web.HttpContext.Current.Server.MapPath("~/brsm.pfx"), "aaaa");
            factory.Credentials.ServiceCertificate.DefaultCertificate = new X509Certificate2(System.Web.HttpContext.Current.Server.MapPath("~/Server.cer"));
            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            var client = factory.CreateChannel();
            return client;
        }
    }

    public class SetProfileRequest
    {
        public string ProfileId { get; set; }
        public Property[] ChangedProperties { get; set; }
    }
}
