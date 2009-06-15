
function tableChanged(dictionary, field) {
    var fieldSegments = field.name.split("_");

    var fieldName = fieldSegments[0];
    var id = fieldSegments[1];

    dictionary[id] = { key: fieldName, value: field.value };
}

function collectChanges(dictionary, hiddenId) {
    var hidden = $get(hiddenId);
    hidden.value = Sys.Serialization.JavaScriptSerializer.serialize(dictionary);
    return true;
}
