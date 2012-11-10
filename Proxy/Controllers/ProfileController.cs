using BrsmProxy.Models;
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
    public class ProfileController : ApiController
    {
        IPublicService _serviceClient = null;

        public ProfileController()
        {
            _serviceClient = GetServiceChannel();
        }

        // GET api/profile/5
        public Profile Get(string id)
        {
            return _serviceClient.GetProfile(id);
        }

        //GET api/profile/?propertyId=xxx&value=yyy
        public Profile GetByCustomProperty(string propertyId, string value)
        {
            return _serviceClient.GetProfileByCustomProperty(propertyId, value);
        }

        public Profile GetByDefaultProperty(string value)
        { 
            return _serviceClient.GetProfileByDefaultProperty(value);
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
}
