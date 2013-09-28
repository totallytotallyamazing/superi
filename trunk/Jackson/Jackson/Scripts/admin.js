$(function () {
    $("#addMenu").editable('/api/Group', {
        type: 'text',
        name: 'name',
        onblur: 'ignore',
        cssclass: 'add-group',
        placeholder: 'Добавить раздел',
        callback: function () {
            location.href = location.href;
        }
    });

    $("#upload").fileupload({
        autoUpload: true,
        progressall: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progressBar').css(
                'width',
                progress + '%'
            );
        },
        singleFileUploads: false,
        done: function (e, data) {
            $('#progressBar').css(
                'width','0'
            );
            location.href = location.href;
        }
    });

    $("#items").sortable({
        disabled: true});

    $("#enableSort").click(function() {
        this.style.display = "none";
        $("#items").sortable("enable");
        document.getElementById("sortCompleted").style.display = "inline";
    });

    $("#sortCompleted").click(function() {
        this.style.display = "none";
        document.getElementById("enableSort").style.display = "inline";
        $("#items").sortable("disable");


        var order = $.map($("#items li"), function(a, index) {
            return $(a).data("id");
        });

        $.ajax({            
            url: "/api/Items/Sort/" + GroupId,
            type: "Post",
            contentType: "application/json",
            accepts: "application/json",
            data: JSON.stringify(order)            
        });
    });
});

function groupDeleted() { location.href = location.href; }