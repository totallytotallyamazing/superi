function processVideos(response) {
    EndRequestHandler();
    for (var i in response) {
        $.preloadImages("images/albumimages/" + response[i].Image);
        appendSubMenuItem(createMenuItem(response[i].Name, subMenuItemClickedVideo).attr({ source: response[i].Source, image: "images/VideoImages/" + response[i].Image }));
    }
    if (currentAlbumId > 0)
        appendSubMenuItem(createMenuItem("Все", clearVideoFilter).css("float", "right"));
}

function subMenuItemClickedVideo(attrs){
    cleanUp();
    swapImage($(attrs.target).parent().attr("image"), imageSwappedVideo);
    updateSubMenuStyles();
    $(attrs.target).attr("class", "subMenuItemActive");
    updateSubMenuClickHandlers(subMenuItemClickedVideo);
}

function clearVideoFilter() {
    cleanUp();
    $("#subMenu ul").empty();
    swapImage("images/video.jpg");
    VideoService.GetVideos(currentAlbumId, processVideos, onRetriveVideosFail);
}

function imageSwappedVideo() {
    stopPromo();
    var source = $(".subMenuItemActive").parent().attr("source");
    $(".videoPlaceHolder").draggable().css("display", "block").flash({ allowscriptaccess: "never", src: "Embed/player.swf", width: "480", height: "360", allowfullscreen: true, flashvars: {autostart:'true', skin: "embed/stylish.swf", file: "http://tinakarol.ua/Videos/" + source} });
}

function onRetriveVideosFail() {
    alert("videos fail");
}