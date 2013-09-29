$(function () {
    var current;

    $("#content #items a").click(function (evt) {
        var href = parseHref(this.href);
        showImage(href);
        current = this;
    });

    $("#leftArrow, #rightArrow").click(function (evt) {
        var dir = this.getAttribute("data-dir");
        var next = getNextItem(current, dir);
        if (next) {
            current = next;
            var href = parseHref(next.href);
            showImage(href);
        }
    });

    $("#modalOverlay, #closePopup").click(closePopup);
    $("#arrows, #imageContainer").click(function(evt) {
        evt.stopPropagation();
    });

    $(window).resize(function() {
        adjustImagePopup(document.getElementById("modalOverlay"));
    });
});

function showImage(href) {
    document.getElementById("largeImage").src = href;
    var overlay = document.getElementById("modalOverlay");
    overlay.style.display = "block";
    adjustImagePopup(overlay);
}

function adjustImagePopup(overlay) {
    var popup = document.getElementById("imagePopup");
    popup.style.width = overlay.offsetWidth + "px";
    popup.style.height = overlay.offsetHeight + "px";
}

function parseHref(href) {
    return href.replace("#!/", "");
}

function getNextItem(item, dir) {
    if (item.tagName.toLowerCase() == "a") {
        if (dir == "left") {
            return $(item).closest("li").prev().find("a").get(0);
        } else {
            return $(item).closest("li").next().find("a").get(0);
        }
    }
}

function closePopup() {
    document.getElementById("modalOverlay").style.display = "none";
}