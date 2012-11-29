using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BrsmProxy.Models;

namespace BrsmProxy.Models
{
    [ServiceContract(Namespace = "http://loyalty.eps.lt/2012/08/public")]
    public interface IPublicService
    {
        [OperationContract]
        Profile GetProfile(string pan);

        [OperationContract]
        Profile GetProfileByCustomProperty(string propertyId, string value);

        [OperationContract]
        Profile GetProfileByDefaultProperty(string value);
    }
}