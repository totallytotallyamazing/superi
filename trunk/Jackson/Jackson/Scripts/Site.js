var current;
$(function () {
    $.address.crawlable(true);
    $.address.change(function (href) {
        if (href.value.length > 2 && $("#modalOverlay:visible").length == 0)
        {
            showImage(href.value);
        }
    });

    hookDefaultItemClick();

    $("a.topLink").click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, "fast");
        return false;
    }).fadeOut(0);

    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('a.topLink').fadeIn();
        } else {
            $('a.topLink').fadeOut();
        }
    });

    $("#phone").inputmask("(999)999-99-99", {
        oncomplete: function () {
            $(".phone a").removeAttr("disabled");
        },
        onclear: function() {
            $(".phone a").attr("disabled", "disabled");
        },
        onincomplete: function () {
            $(".phone a").attr("disabled", "disabled");
        },

        clearIncomplete: true
    });

    $(".phone a").click(function() {
        $(".phone a").css("visibility", "hidden")
            .attr("disabled", "disabled");

        var url = escape(document.getElementById("largeImage").src);
        var phone = escape(document.getElementById("phone").value);
        $.ajax({
            url: "/api/Items/NotifyMiller?url=" + url + "&phone=" + phone,
            contentType: "application/json",
            accepts: "application/json",
            type: "POST",
            success: function() {
                $(".phone a").hide(0);
                $(".phone span").show(0);
            }
        });
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

function hookDefaultItemClick() {
    $("#content #items a").click(function (evt) {
        var href = parseHref(this.href);
        showImage(href);
        current = this;
    });
}

function showImage(href) {
    $(".phone a").show(0);
    $(".phone span").hide(0);
    var overlay = document.getElementById("modalOverlay");
    $("#largeImage").attr("src", href)
    .bind('load', function () {
        $(this).unbind("load");
        adjustImagePopup(overlay, this);
        });
    document.getElementById("largeImage").src = href;
    overlay.style.display = "block";

    var innerHref = location.href;

    if (location.href.indexOf("#") >= 0)
    {
        innerHref = location.href.substr(0, location.href.indexOf("#"));
    }

    location.href = innerHref + "#!" + href;
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

    var innerHref = location.href;

    if (location.href.indexOf("#") >= 0) {
        innerHref = location.href.substr(0, location.href.indexOf("#"));
        location.href = innerHref + "#";
    }
}