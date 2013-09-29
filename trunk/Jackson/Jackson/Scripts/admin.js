$(function () {
    $("#addMenu").editable('/Admin/AddGroup', {
        type: 'text',
        name: 'name',
        onblur: 'ignore',
        cssclass: 'add-group',
        placeholder: 'Добавить раздел',
        callback: function (data) {
            var href = "/" + data.replace(/"/gi, "");
            location.href = href;
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
        $("#items").sortable("disable");
        var completeLink = this;
        completeLink.setAttribute("disabled", "disabled");
        var order = $.map($("#items li"), function(a, index) {
            return $(a).data("id");
        });

        $.ajax({            
            url: "/api/Items/Sort/" + GroupId,
            type: "Post",
            contentType: "application/json",
            accepts: "application/json",
            data: JSON.stringify(order),
        }).success(function() {
            completeLink.style.display = "none";
            document.getElementById("enableSort").style.display = "inline";
            completeLink.removeAttribute("disabled");
        });
    });
});

function groupDeleted() { location.href = location.href; }