var currentAlbumId = 0;
var historyAlbumId = 0;
var photoAlbumId = 0;
var videoId = 0;
var historyCallback = false;

$.history.callback = function(reinstate, cursor) {
    historyAlbumId = reinstate.albumId;
    photoAlbumId = reinstate.photoAlbumId;
    videoId = reinstate.videoId;
    historyCallback = true;
    var sec = $("[section=" + reinstate.section + "]");
    if (sec.attr("class") == "currentSection") {
        loadContent(reinstate.section);
    }
    else {
        sec.click();
    }
}

$(document).ready(function() {
    $("#menu li").not(".currentSection").mouseover(menuOver).mouseout(menuOut).click(menuClicked);
    $(".currentSection").css("font-size", "26px");
    $(".newBackground, .currentBackground").css("display", "none");
    $(".currentBackground").fadeIn(1000);
    $("#contactsFull").dialog({ dialogClass: "contacts", draggable: true, resizable: false, autoOpen: false, height: 300, width: 230, minHeight: 300, position: [$("#main").position().left + 780, 350] });
    $("#newsTextContainer").dialog({ dialogClass: "contacts", draggable: false, resizable: false, autoOpen: false, height: 600, width: 900, modal: true });
});

function BeginRequestHandler() {
    $("#loadingContainer").css("display", "block");
    $("html, body").css("overflow", "hidden")
    var vpWidth = $("body").width();
    var vpHeight = $("body").height();
    $(".myShadow").css("left", Math.floor(vpWidth / 2 - 60)).css("top", Math.floor(vpHeight / 2 - 30)).css("display", "block");
    $("#loadingSign").css("left", Math.floor(vpWidth / 2 - 50)).css("top", Math.floor(vpHeight / 2 - 20)).css("display", "block");
    $("#loading").css("display", "block");
}

function EndRequestHandler() {
    $("html, body").css("overflow", "");
    $("#loadingContainer").css("display", "none");
    $(".myShadow").css("display", "none");
    $("#loadingSign").css("display", "none");
    $("#loading").css("display", "none");
}

function openContacts() {
    $("#contactsFull").dialog("open");
}

function closeDialog(el) {
    $("#contactsFull").css("display", "none");
}

function cleanUp() {
    $("#flashContainer").empty();
    $(".videoPlaceHolder").empty().css("display", "none");
    $(".songsPlaceHolder").css("display", "none");
    $(".galleryPlaceHolder").css("display", "none");
    $(".thumbs").empty();
    $('#gallery').css("display", "none")
    $("#footerMenu a").css("display", "none");
    $("#newsContent").empty();
    $("#newsContainer").css("display", "none");
    $(".songsPlaceHolder").removeClass("songsPlaceHolderInverted");
    currentAlbumId = 0;
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
        return $('<li><a class="subMenuItem">' + name + '</a></li>').bind("click", clickHandler);
    else
        return $('<li><a class="subMenuItem">' + name + '</a></li>');
}

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
        var veryFirstElem = $("#menu li").eq(0);
        firstElem.attr("class", "").css("font-size", "16px");
        targetElem.css({ "font-size": "0px", "text-decoration": "none" }).attr("class", "currentSection").insertBefore(veryFirstElem).animate({ fontSize: "26px" }, "slow");
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
    //if(!historyCallback)
  //  $.history({ section: section, albumId:0, photoAlbumId:0, videoId:0 });
    BeginRequestHandler();
    switch (section) {
        case "music":
            Music.GetAlbums(processAlbums, onRetriveAlbumsFail);
            break;
        case "photo":
            GalleryService.GetPhotosByAlbumId(currentAlbumId, loadImages, loadImagesFail);
            break;
        case "video":
            VideoService.GetVideos(currentAlbumId, processVideos, onRetriveVideosFail);
            break;
        case "news":
            News.GetPageCount(processNews, onRetriveNewsFail);
            break;
    }
}