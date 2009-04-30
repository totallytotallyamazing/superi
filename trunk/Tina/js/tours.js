function processTours(response) {
    EndRequestHandler();
    for (var i in response) {
        appendSubMenuItem(createMenuItem(response[i].Name + "(" + response[i].Year + ")", tourClicked).attr({ tourId: response[i].ID, image: "images/TourImages/" + response[i].BackgroundImage }));
    }
    $("#subMenu ul li a").eq(0).toggleClass("subMenuItemActive");
    var attrs = new Object();
    attrs.target = $("#subMenu ul li a").eq(0);
    tourClicked(attrs);
}

function onRetriveToursFail(arg1, arg2, arg3) {
    alert('tours fail');
    EndRequestHandler();
}

function tourClicked(attrs) {
    var tourId = $(attrs.target).parent().attr("tourId");
    $.get("Tour.aspx?id=" + tourId, tourLoaded);
    $(attrs.target).attr("class", "subMenuItemActive");
}

function tourLoaded(data) {
    $("#tourContainer").css("display", "block").html(data);
    $(".tourPics ul li a").fancybox({ 'overlayShow': true });
    $(".tourPics ul li a img").bind("load", function(el) {
        var pdt = $(".galleryPlaceHolder").height() / 2 - $(".thumbs").height() / 2;
        if (pdt > 0)
            $(".thumbs").css("padding-top", pdt);
        else
            $(".thumbs").css("padding-top", 0);
        $(el.target).fadeTo("fast", 0.6);
    })
    .bind("mouseover", function(el) { $(el.target).fadeTo("fast", 1); })
    .bind("mouseout", function(el) { $(el.target).fadeTo("fast", 0.6); })
    $("#fancy_close").mouseover(function() { $("#fancy_close").css("background-image", "url(images/fancybox/fancyCloseboxOver.png)") })
    $("#fancy_close").mouseout(function() { $("#fancy_close").css("background-image", "url(images/fancybox/fancyClosebox.png)") })
}