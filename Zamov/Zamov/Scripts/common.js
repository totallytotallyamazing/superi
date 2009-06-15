
function tableChanged(dictionary, field) {
    var fieldSegments = field.name.split("_");

    var fieldName = fieldSegments[0];
    var id = fieldSegments[1];

    dictionary[id] = eval('{ '+fieldName+': fieldName}');
}

function collectChanges(dictionary, hiddenId) {
    var hidden = $get(hiddenId);
    hidden.value = Sys.Serialization.JavaScriptSerializer.serialize(dictionary);
    return true;
}
