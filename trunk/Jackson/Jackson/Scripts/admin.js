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
                'width', '0'
            );
            location.href = location.href;
        }
    });

    $("#items").sortable({
        disabled: true
    });

    $("#enableSort").click(function () {
        this.style.display = "none";
        $("#items").sortable("enable");
        document.getElementById("sortCompleted").style.display = "inline";
    });

    $("#sortCompleted").click(function () {
        $("#items").sortable("disable");
        var completeLink = this;
        completeLink.setAttribute("disabled", "disabled");
        var order = $.map($("#items li"), function (a, index) {
            return $(a).data("id");
        });

        $.ajax({
            url: "/api/Items/Sort/" + GroupId,
            type: "POST",
            contentType: "application/json",
            accepts: "application/json",
            data: JSON.stringify(order),
        }).success(function () {
            completeLink.style.display = "none";
            document.getElementById("enableSort").style.display = "inline";
            completeLink.removeAttribute("disabled");
        });
    });

    $("#enableSelection").click(function (evt) {
        this.style.display = "none";
        document.getElementById("cancelSelection").style.display = "inline";
        $("#content #items a")
            .unbind()
            .click(function (evt) {
                var li = $(this).closest("li");
                li.toggleClass("selected");
                if (li.hasClass("selected")) {
                    li
                        .attr("draggable", true)
                        .bind("dragstart", function (evt) {
                            var items = $.map($("#content #items li.selected"), function (a, index) {
                                return $(a).data("id");
                            });
                            var dataToSend = JSON.stringify(items);
                            evt.originalEvent.dataTransfer.setData("Text", dataToSend);
                        });
                } else {
                    li
                        .attr("draggable", false)
                        .unbind("dragstart");
                }

            });
        $("#mainMenu .bar-content a")
            .bind("dragover", function (evt) {
                //alert("dragover");
                evt.preventDefault();
            })
            .bind("dragenter", function (evt) {
                evt.preventDefault();
                //alert("enter");
            })
            .bind("drop", function (evt) {
                var items = evt.originalEvent.dataTransfer.getData("Text");
                var moveTo = $(evt.target).data("url");
                $.ajax({
                    url: "/api/Items/Move?moveTo=" + moveTo,
                    type: "PUT",
                    contentType: "application/json",
                    accepts: "application/json",
                    data: items,
                    success: function() {
                        location.href = "/" + moveTo;
                    }
                });
            });
    });

    $("#cancelSelection").click(function (evt) {
        this.style.display = "none";
        $("#content #items a").unbind();
        hookDefaultItemClick();
        document.getElementById("enableSelection").style.display = "inline";
        $("#content #items li.selected")
            .removeClass("selected")
            .attr("draggable", false)
            .unbind("dragstart");

        $("#mainMenu .bar-content a")
            .unbind("dragover")
            .unbind("dragenter")
            .unbind("drop");
    });
});

function groupDeleted() { location.href = location.href; }