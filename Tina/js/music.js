

function processAlbums(response) {
    EndRequestHandler();
    for (var i in response) {
        $.preloadImages("images/albumimages/" + response[i].Image);
        appendSubMenuItem(createMenuItem(response[i].Name + "(" + response[i].Year + ")", subMenuItemClicked).attr({ albumId: response[i].ID, image: "images/albumimages/" + response[i].Image, photoImage: "images/albumimages/" + response[i].PhotoImage, invertColors: response[i].InvertColors }));
    }
//    if (historyCallback) {
//        $("[albumId='" + photoAlbumId + "'] a").toggleClass("subMenuItemActive");
//        photoAlbumId = 0;
//        historyCallback = false;
//    }
}

function subMenuItemClicked(attrs) {
    cleanUp();
    BeginRequestHandler();
    swapImage($(attrs.target).parent().attr("image"), imageSwapped);
    updateSubMenuStyles();
    $(attrs.target).attr("class", "subMenuItemActive");
    updateSubMenuClickHandlers(subMenuItemClicked);
    $(".songsPlaceHolder ul").empty();
}

function imageSwapped() {
    var albumID = $(".subMenuItemActive").parent().attr("albumId");
    currentAlbumId = albumID;
    Music.GetAlbumSongs(albumID, songsRetreived, onRetriveSongsFail);
}

function songsRetreived(response) {
    EndRequestHandler();
    $(".songsPlaceHolder").css("display", "block");
    $(".songsPlaceHolder ul").css("display", "block");
    $("#footerMenu a").css("display", "inline");
    var invertColors = ($(".subMenuItemActive").parent().attr("invertColors") == "true");
    if (invertColors)
        $(".songsPlaceHolder").addClass("songsPlaceHolderInverted")
    for (var i in response) {
        var name = response[i].Name;
        var source = response[i].Source;
        if (i == 7) {
            $("<br />").appendTo(".songsPlaceHolder ul");
            $("<li path='" + source + "'>" + name + "</li>").appendTo(".songsPlaceHolder ul").mouseover(songOver).mouseout(songOut).animate({ marginLeft: "10px" }, 500).click(songClicked).wrap('<div style="float:left; clear:both; height:20px; margin-right:0px;">');
        }
        else {
            $("<li path='" + source + "'>" + name + "</li>").appendTo(".songsPlaceHolder ul").mouseover(songOver).mouseout(songOut).animate({ marginLeft: "10px" }, 500).click(songClicked).wrap('<div style="float:left; margin-right:0px;">');
        }
    }
    $("<br />").appendTo($(".songsPlaceHolder ul div").eq(5));
}

function songOver(el) {
    $(el.toElement).css("text-decoration", "underline")
}

function songOut(el) {
    $(el.fromElement).css("text-decoration", "none") 
}

function songClicked(attrs){
    $("#flashContainer").empty();
    var source = $(attrs.target).attr("path")
    $("#flashContainer").flash({ src: "Embed/xspf_jukebox.swf", flashvars: {allowscriptaccess: "never", track_title: "title", track_url: "Songs/" + source, autoplay: true, repeat: false} });
    resetSongs(attrs.target);
    var invertColors = ($(".subMenuItemActive").parent().attr("invertColors") == "true");
    var bgUrl = "images/playShadow.png";
    if (invertColors)
        bgUrl = "images/playShadowBlack.png";
    var buttonUrl = "images/stopButton.gif";
    if (invertColors)
        buttonUrl = "images/stopButtonBlack.gif";
    $(attrs.target).unbind("click", songClicked).bind("click", stopPlaying).css("background-image", "url(" + buttonUrl + ")").parent().css("background", "transparent url(" + bgUrl + ")");
    $(attrs.target).parent().unbind("click", songClicked);
}

function stopPlaying(attrs) {
    var invertColors = ($(".subMenuItemActive").parent().attr("invertColors") == "true");
    var buttonUrl = "images/playButton.png";
    if (invertColors)
        buttonUrl = "images/playButtonBlack.png";
    $("#flashContainer").empty();
    $(attrs.target).unbind("click", stopPlaying).bind("click", songClicked).css("background-image", "url(" + buttonUrl + ")").parent().css("background", "transparent");
}

function resetSongs(el) {
    var invertColors = ($(".subMenuItemActive").parent().attr("invertColors") == "true");
    var buttonUrl = "images/playButton.png";
    if (invertColors)
        buttonUrl = "images/playButtonBlack.png";
    $(".songsPlaceHolder ul div li").unbind("click", stopPlaying).unbind("click", songClicked).click(songClicked).css("background-image", "url(" + buttonUrl + ")").parent().css("background", "transparent");
}

function showAlbumPhoto() {
    currentAlbumId = $(".subMenuItemActive").parent().attr("albumId");
    var albumPhoto = $(".subMenuItemActive").parent().attr("photoImage");
    swapImage(albumPhoto);
    targetElem = $($("[section='photo']"));
    var firstElem = $(".currentSection");
    firstElem.attr("class", "").css("font-size", "16px");
    var veryFirstElem = $("#menu li").eq(0);
    targetElem.css({ "font-size": "0px", "text-decoration": "none" }).attr("class", "currentSection").insertBefore(veryFirstElem).animate({ fontSize: "26px" }, "slow");
    $("#menu li").unbind("click", menuClicked).unbind("mouseover", menuOver).unbind("mouseout", menuOut);
    $("#menu li").not(".currentSection").mouseover(function(el) { $(el.toElement).css("text-decoration", "underline") }).mouseout(function(el) { $(el.fromElement).css("text-decoration", "none"); }).click(menuClicked);
    $("#subMenu ul").empty();
    $(".songsPlaceHolder ul").empty().css("display", "none");
    loadContent(targetElem.attr("section"));
    $("#footerMenu a").css("display", "none");
    $("#flashContainer").empty();
}

function showAlbumVideo() {
    currentAlbumId = $(".subMenuItemActive").parent().attr("albumId");
    var albumPhoto = $(".subMenuItemActive").parent().attr("photoImage");
    swapImage(albumPhoto);
    targetElem = $($("[section='video']"));
    var firstElem = $(".currentSection");
    firstElem.attr("class", "").css("font-size", "16px");
    var veryFirstElem = $("#menu li").eq(0);
    targetElem.css({ "font-size": "0px", "text-decoration": "none" }).attr("class", "currentSection").insertBefore(veryFirstElem).animate({ fontSize: "26px" }, "slow");
    $("#menu li").unbind("click", menuClicked).unbind("mouseover", menuOver).unbind("mouseout", menuOut);
    $("#menu li").not(".currentSection").mouseover(function(el) { $(el.toElement).css("text-decoration", "underline") }).mouseout(function(el) { $(el.fromElement).css("text-decoration", "none"); }).click(menuClicked);
    $("#subMenu ul").empty();
    $(".songsPlaceHolder ul").empty().css("display", "none");
    loadContent(targetElem.attr("section"));
    $("#footerMenu a").css("display", "none");
    $("#flashContainer").empty();
}

function onRetriveAlbumsFail() {
    alert("albums fail");
}

function onRetriveSongsFail() {
    alert("songs fail");
}