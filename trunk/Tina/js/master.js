function cleanUp() {
    $("#flashContainer").empty();
    $(".videoPlaceHolder").empty().css("display", "none");
    $(".songsPlaceHolder").css("display", "none");
}

function appendSubMenuItem(item) {
    item.appendTo("#subMenu ul");
}

function updateSubMenuStyles() {
    $("#subMenu ul li a").attr("class", "subMenuItem");
}

function updateSubMenuClickHandlers(clickHanler) {
    $("#subMenu ul li a").unbind("click", clickHanler).parent().unbind("click", clickHanler);
    $(".subMenuItem").bind("click", clickHanler);
}

function getSubMenu() {
    return $("#subMenu ul");
}

function createMenuItem(name, clickHandler) {
    if (clickHandler)
        return $('<li><a class="subMenuItem" href="#">' + name + '</a></li>').bind("click", clickHandler);
    else
        return $('<li><a class="subMenuItem" href="#">' + name + '</a></li>'); 
}

$(document).ready(function() {
    $("#menu li").not(".currentSection").mouseover(menuOver).mouseout(menuOut).click(menuClicked);
    $(".currentSection").css("font-size", "26px");
    $(".newBackground, .currentBackground").css("display", "none");
    $(".currentBackground").attr("src", "Images/AlbumImages/nochenka.png").fadeIn(1000);
    loadContent($(".currentSection").attr("section"));
});

function menuOver(el) {
    $(el.toElement).css("text-decoration", "underline");
}

function menuOut(el) {
    $(el.fromElement).css("text-decoration", "none");
}

function menuClicked(el) {
    cleanUp();
    var targetElem = $(el.target)
    if (targetElem.attr("class") !== "currentSection") {
        var firstElem = $(".currentSection");
        firstElem.attr("class", "").css("font-size", "16px");
        targetElem.css({ "font-size": "0px", "text-decoration": "none" }).attr("class", "currentSection").insertBefore(firstElem).animate({ fontSize: "26px" }, "slow");
        $("#menu li").unbind("click", menuClicked).unbind("mouseover", menuOver).unbind("mouseout", menuOut);
        $("#menu li").not(".currentSection").mouseover(function(el) { $(el.toElement).css("text-decoration", "underline") }).mouseout(function(el) { $(el.fromElement).css("text-decoration", "none"); }).click(menuClicked);
        swapImage($(el.target).attr("image"));
        loadContent(targetElem.attr("section"));
        $("#subMenu ul").empty();
        $(".songsPlaceHolder ul").empty().css("display", "none");
    }
}

function swapImage(imageName, callbackHandler) {

    var newBg = $(".newBackground");
    var oldbg = $(".currentBackground");
    oldbg.fadeOut(500, function() {
        var oldbg = $(".currentBackground");
        oldbg.attr("class", "newBackground");
        newBg.attr("src", imageName).attr("class", "currentBackground").fadeIn(500, callbackHandler);
    }).attr("src", "");
}

function loadContent(section) {
    switch (section) {
        case "music":
            Music.GetAlbums(processAlbums, onRetriveAlbumsFail);
            break;
        case "photo":
            break;
        case "video":
            VideoService.GetVideos(processVideos, onRetriveVideosFail);
            break;
        case "news":
            break;
    }
}