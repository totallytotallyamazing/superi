Sys.Mvc.ValidatorRegistry.validators.remote = function(rule) {
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

        var newUrl = ((url.indexOf('?') < 0) ? (url + '?') : (url + '&'))
                     + encodeURIComponent(parameterName) + '=' + encodeURIComponent(value);

        var result = true;
        var completedCallback = function(data) {
            var responseData = data;
            if (responseData != 'true') {
                var newMessage = (responseData == 'false' ? message : responseData);
                context.fieldContext.addError(newMessage);
                result = false;
            }
        };

        $.ajax({ url: newUrl, success: completedCallback, async: false });
        return result;
    };
};
