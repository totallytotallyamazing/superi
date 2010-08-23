Sys.Mvc.ValidatorRegistry.validators.captcha = function(rule) {
    var url = rule.ValidationParameters.url;
    var parameterName = rule.ValidationParameters.parameterName;
    var message = rule.ErrorMessage;

    return function(value, context) {
        if (!value || !value.length) {
            return true;
        }

        if (context.eventName != 'blur' && context.eventName != 'submit') {
            return true;
        }

        var captchaGuid = document.getElementById("captcha_guid").value;

        var body = null;
        eval('body = {' + encodeURIComponent(parameterName) + ' : "' + encodeURIComponent(value) + '", "captcha-guid": "' + captchaGuid + '"}');

        var result = true;

        var completedCallback = function(data) {
            var responseData = data;
            if (responseData != 'true') {
                var newMessage = (responseData == 'false' ? message : responseData);
                context.fieldContext.addError(newMessage);
                if (typeof (window.OnCaptchaValidationError) !== "undefined") {
                    window.OnCaptchaValidationError();
                }
                result = false;
            }
        };


        $.ajax({ type: "POST", url: url, success: completedCallback, async: false, data: body });

        return result;
    };
};
