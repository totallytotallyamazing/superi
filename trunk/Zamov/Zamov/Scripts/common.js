function fadeScreenOut() {
    $(".shader").css("display", "block");
}

function fadeScreenIn() {
    $(".shader").css("display", "none");
}


function tableChanged(dictionary, field) {
    var fieldSegments = field.name.split("_");

    var fieldName = fieldSegments[0];
    var id = fieldSegments[1];
    if (dictionary[id] == null) {
        dictionary[id] = {};
    }
    if (field.type == "checkbox") {
        dictionary[id][fieldName] = field.checked;
    }
    else {
        dictionary[id][fieldName] = field.value;
    }
}

function collectChanges(dictionary, hiddenId) {
    var hidden = $get(hiddenId);
    hidden.value = Sys.Serialization.JavaScriptSerializer.serialize(dictionary);
    return true;
}

function failureCallback(error) {
    alert('Error occured during Ajax call');
}
