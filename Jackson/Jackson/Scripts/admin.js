$(function () {
    $("#addMenu").editable('/Admin/AddGroup', {
        type: 'text',
        name: 'name',
        onblur: 'ignore',
        cssclass: 'add-group',
        placeholder: 'Добавить раздел',
        callback: function () {
            location.href = location.href;
        }
    });
});

function groupDeleted() { location.href = location.href; }