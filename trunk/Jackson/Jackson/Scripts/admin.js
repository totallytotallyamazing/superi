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
        done: function () {
            $('#progressBar').css(
                'width', '0'
            );
            location.reload();
        }
    });

    $("#items, .bar-content").sortable({
        disabled: true
    });

    var editabjeEvent = null;

    $("#sortMenu").click(function() {
        $("#mainMenu .bar-content *[data-url]").editable("/Admin/RenameGroup", {
            type: 'text',
            name: 'title',
            onblur: 'ignore',
            cssclass: 'add-group',
            placeholder: 'Переименовать раздел',
            callback: function(data, settings) {
                var href = "/" + data.replace(/"/gi, "");
                location.href = href;
                editabjeEvent = settings.event;
                location.reload();
            }
        });
        this.style.display = "none";
        document.getElementById("endSortMenu").style.display = "inline";
        $("#mainMenu .bar-content").sortable("enable");
    });

    $("#endSortMenu").click(function() {
        $("#mainMenu .bar-content").sortable("disable");
        $("#mainMenu .bar-content *[data-url]").unbind(editabjeEvent);
        var endLink = this;
        endLink.setAttribute("disabled", "disabled");
        var order = $.map($("#mainMenu .bar-content *[data-url]"), function(a) {
            return $(a).data("url");
        });

        $.ajax({
            url: "/api/Items/SortGroups/",
            type: "POST",
            contentType: "application/json",
            accepts: "application/json",
            data: JSON.stringify(order),
        }).success(function() {
            endLink.style.display = "none";
            document.getElementById("sortMenu").style.display = "inline";
            endLink.removeAttribute("disabled");
        });

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
        var order = $.map($("#items li"), function (a) {
            return $(a).data("id");
        });

        $.ajax({
            url: "/api/Items/Sort/" + window.GroupId,
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

    $("#enableSelection").click(function () {
        this.style.display = "none";
        document.getElementById("cancelSelection").style.display = "inline";
        $("#trashCan")
            .show(0)
            .bind("dragover dragenter", function (evt) {
                if ($("#content #items li.selected").length > 0) {
                    evt.preventDefault();
                }
            })
            .bind("drop", function (evt) {
                var items = evt.originalEvent.dataTransfer.getData("Text");
                deleteItems(items);
            });

        document.getElementById("trashCan").style.display = "block";
        $("#content #items a")
            .unbind()
            .click(function (evt) {
                evt.preventDefault();
                var li = $(this).closest("li");
                li.toggleClass("selected");
                if (li.hasClass("selected")) {
                    li
                        .attr("draggable", true)
                        .bind("dragstart", function (evt) {
                            var items = $.map($("#content #items li.selected"), function (a) {
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
            .bind("dragover dragenter", function (evt) {
                if ($("#content #items li.selected").length > 0) {
                    evt.preventDefault();
                }
            })
            .bind("drop", function (evt) {
                var items = evt.originalEvent.dataTransfer.getData("Text");
                var moveTo = $(evt.target).data("url");
                $.ajax({
                    url: "/api/Items/Move?moveFrom=" + window.GroupId + "&moveTo=" + moveTo,
                    type: "PUT",
                    contentType: "application/json",
                    accepts: "application/json",
                    data: items,
                    success: function () {
                        location.href = "/" + moveTo;
                    }
                });
            });
    });

    $("#cancelSelection").click(function () {
        document.getElementById("trashCan").style.display = "none";
        this.style.display = "none";
        $("#content #items a").unbind();
        hookDefaultItemClick();
        document.getElementById("enableSelection").style.display = "inline";
        $("#content #items li.selected")
            .removeClass("selected")
            .attr("draggable", false)
            .unbind("dragstart");

        $("#trashCan")
            .hide(0)
            .unbind();

        $("#mainMenu .bar-content a")
            .unbind("dragover")
            .unbind("dragenter")
            .unbind("drop");
    });

    $(document).keydown(function(e) {
        if (e.keyCode == 8 || e.keyCode == 46) {
            e.preventDefault();
            var items = $.map($("#content #items li.selected"), function (a) {
                return $(a).data("id");
            });
            if (items.length > 0) {
                var dataToSend = JSON.stringify(items);
                deleteItems(dataToSend);
            }
        }
    });
});

function groupDeleted() { location.reload(); }

function sayOk() { alert("Готово"); }

function deleteItems(items) {
       $.ajax({
                    url: "/api/Items/Delete",
                    type: "DELETE",
                    contentType: "application/json",
                    accepts: "application/json",
                    data: items,
                    success: function () {
                        location.href = location.href;
                    }
                });
    
}