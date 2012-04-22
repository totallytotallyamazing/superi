using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace Shop.Helpers.Validation
{
    public class CaptchaAttributeAdapter : DataAnnotationsModelValidator<CaptchaAttribute>
    {
        public CaptchaAttributeAdapter(ModelMetadata metadata,
                                      ControllerContext context,
                                      CaptchaAttribute attribute) :
            base(metadata, context, attribute) { }


        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            ModelClientValidationRule rule = new ModelClientValidationRule()
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "captcha"
            };

            rule.ValidationParameters["url"] = Attribute.GetUrl(ControllerContext);
            return new ModelClientValidationRule[] { rule };
        }
    }
}
