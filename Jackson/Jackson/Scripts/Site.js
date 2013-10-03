var current;

$(function () {
    hookDefaultItemClick();

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

function hookDefaultItemClick() {
    $("#content #items a").click(function (evt) {
        var href = parseHref(this.href);
        showImage(href);
        current = this;
    });
}

function showImage(href) {
    var overlay = document.getElementById("modalOverlay");
    $("#largeImage").attr("src", href)
    .bind('load', function () {
        $(this).unbind("load");
        adjustImagePopup(overlay, this);
        });
    document.getElementById("largeImage").src = href;
    overlay.style.display = "block";
}

function adjustImagePopup(overlay, image) {
    if(!image){
        image = document.getElementById("largeImage");
    }
    image.style.height = "992px";
    var popup = document.getElementById("imagePopup");
    popup.style.width = overlay.offsetWidth + "px";
    popup.style.height = overlay.offsetHeight + "px";
    var size = getClientDimensions();
    if (size.height - 150 < image.offsetHeight)
    {
        image.style.height = (size.height - 150) + "px";
        document.getElementById("arrows").style.top = (image.offsetHeight / 2) + "px";
    }
}

function getClientDimensions(){
    var w=window.innerWidth
|| document.documentElement.clientWidth
|| document.body.clientWidth;

    var h=window.innerHeight
    || document.documentElement.clientHeight
    || document.body.clientHeight; 

    return {width: w, height:h};
}

function parseHref(href) {
    return href.substr(href.indexOf("#!") + 2);
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