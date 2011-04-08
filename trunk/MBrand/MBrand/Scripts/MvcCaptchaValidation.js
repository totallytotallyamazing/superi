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

        //        var newUrl = ((url.indexOf('?') < 0) ? (url + '?') : (url + '&'))
        //                     + encodeURIComponent(parameterName) + '=' + encodeURIComponent(value);

        var captchaGuid = document.getElementById("captcha-guid").value;

        var body = encodeURIComponent(parameterName) + '=' + encodeURIComponent(value);
        body += "&captcha-guid=" + captchaGuid;

        //newUrl = newUrl + "&guid=" + captchaGuid;

        var completedCallback = function(executor) {
            if (executor.get_statusCode() != 200) {
                return;
            }

            var responseData = executor.get_responseData();
            if (responseData != 'true') {
                var newMessage = (responseData == 'false' ? message : responseData);
                context.fieldContext.addError(newMessage);
                if (typeof (window.OnCaptchaValidationError) !== "undefined") {
                    window.OnCaptchaValidationError();
                }
            }
        };

        var r = new Sys.Net.WebRequest();
        r.set_url(url);
        r.set_httpVerb('POST');
        r.set_body(body);
        r.add_completed(completedCallback);
        r.invoke();
        return true;
    };
};
