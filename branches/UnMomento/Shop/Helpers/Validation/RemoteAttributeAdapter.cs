using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Helpers.Validation
{
    public class RemoteAttributeAdapter : DataAnnotationsModelValidator<RemoteAttribute>
    {
        public RemoteAttributeAdapter(ModelMetadata metadata,
                                      ControllerContext context,
                                      RemoteAttribute attribute) :
            base(metadata, context, attribute) { }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            ModelClientValidationRule rule = new ModelClientValidationRule()
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "remote"
            };

            rule.ValidationParameters["url"] = Attribute.GetUrl(ControllerContext);
            rule.ValidationParameters["parameterName"] = Attribute.ParameterName;
            return new ModelClientValidationRule[] { rule };
        }
    }
}
