var albumFromHistory = null;

function albumsCleanUp() {
    $("#flashContainer").empty();
    $(".videoPlaceHolder").empty().css("display", "none");
    $(".songsPlaceHolder").css("display", "none");
    $(".galleryPlaceHolder").css("display", "none");
    $(".thumbs center").empty();
    $('#gallery').css("display", "none")
}

// Init album list
function processAlbums(response) {
    EndRequestHandler();
    for (var i in response) {
        $.preloadImages("images/albumimages/" + response[i].Image);
        appendSubMenuItem(createMenuItem(response[i].Name + "(" + response[i].Year + ")", subMenuItemClicked).attr({ albumId: response[i].ID, image: "images/albumimages/" + response[i].Image, photoImage: "images/albumimages/" + response[i].PhotoImage, invertColors: response[i].InvertColors }));
    }
//    if (albumFromHistory != null) {
//        $("[albumId='" + albumFromHistory + "'] a").click();
//        albumFromHistory = null;
//    }
}

// Album entry clicked
function subMenuItemClicked(attrs) {
    var albumID = $(attrs.target).parent().attr("albumId");
    //setHistoryCallback("music/" + albumID, albumHistoryCallback);
    cleanUp();
    BeginRequestHandler();
    swapImage($(attrs.target).parent().attr("image"), imageSwapped);
    updateSubMenuStyles();
    $(attrs.target).attr("class", "subMenuItemActive");
    updateSubMenuClickHandlers(subMenuItemClicked);
    $(".songsPlaceHolder ul").empty();
    fillFooterLinks(0);
}

function albumHistoryCallback(hash) {
    albumFromHistory = hash.substring(hash.indexOf("/")+1);
    alert(albumFromHistory);
    cleanUp();
    $("#subMenu ul").empty();
    BeginRequestHandler();
    $("#menu li").removeClass("currentSection").css("font-size", "16px");
    $("#menu li").not(".currentSection").mouseover(menuOver).mouseout(menuOut).click(menuClicked);
    
    Music.GetAlbums(processAlbums, onRetriveAlbumsFail);
    //loadContent("music");
}

//Album image updated
function imageSwapped() {
    var albumID = $(".subMenuItemActive").parent().attr("albumId");
    currentAlbumId = albumID;
    Music.GetAlbumSongs(albumID, songsRetreived, onRetriveSongsFail);
}

//Album songs loaded from server
function songsRetreived(response) {
    EndRequestHandler();
    fillSongsPlaceHolder(response, songClicked, "songsLi");
}

function videoClicked(attrs) {
    $(".songsPlaceHolder ul").empty();
    $(".songsPlaceHolder ul").css("display", "none");
    $("#flashContainer").empty();
    var source = $(attrs.target).attr("path");
    var image = $(attrs.target).attr("image");
    $(".videoPlaceHolder").draggable().css("display", "none").flash({ allowscriptaccess: "never", src: "Embed/player.swf", width: "480", height: "360", allowfullscreen: true, flashvars: { autostart: "true", skin: "embed/stylish.swf", file: "http://tinakarol.ua/Videos/" + source} });
    stopPromo();
    swapImage(image, albumImageSwappedVideo)
}

function albumImageSwappedVideo() {
    $(".videoPlaceHolder").draggable().css("display", "block");
}

function showAlbumPhotos() {
    albumsCleanUp();
    BeginRequestHandler();
    var albumImage = $(".subMenuItemActive").parent().attr("photoImage");
    swapImage(albumImage, albumPhotoSwapped);
    fillFooterLinks(1);
}

function showAlbumTracks() {
    var image = $(".subMenuItemActive").parent().attr("image");
    swapImage(image);
    albumsCleanUp();
    BeginRequestHandler();
    var albumID = $(".subMenuItemActive").parent().attr("albumId");
    Music.GetAlbumSongs(albumID, songsRetreived, onRetriveSongsFail);
    fillFooterLinks(0);
}

function showAlbumVideos() {
    var image = $(".subMenuItemActive").parent().attr("image");
    swapImage(image);
    albumsCleanUp();
    BeginRequestHandler();
    VideoService.GetVideos(currentAlbumId, albumVideoLoaded, onRetriveVideosFail);
    fillFooterLinks(2);
}

function albumPhotoSwapped() {
    GalleryService.GetPhotosByAlbumId(currentAlbumId, loadImages, loadImagesFail);
}

function fillSongsPlaceHolder(response, handler, cssClass) {
    $(".songsPlaceHolder").css("display", "block");
    $(".songsPlaceHolder ul").empty();
    $(".songsPlaceHolder ul").css("display", "block");
    $("#footerMenu a").css("display", "inline");
    var invertColors = ($(".subMenuItemActive").parent().attr("invertColors") == "true");
    if (invertColors)
        $(".songsPlaceHolder").addClass("songsPlaceHolderInverted")
    for (var i in response) {
        var name = response[i].Name;
        var source = response[i].Source;
        var image = "images/VideoImages/" + response[i].Image;
        var attributes = "path='" + source + "'";
        if (response[i].Image != null && typeof (response[i].Image) != "undefined") {
            attributes += " image='" + image + "'";
        }
        if (i == 7) {
            $("<br />").appendTo(".songsPlaceHolder ul");
            $("<li " + attributes + ">" + name + "</li>").attr("class", cssClass).appendTo(".songsPlaceHolder ul").mouseover(songOver).mouseout(songOut).animate({ marginLeft: "10px" }, 500).click(handler).wrap('<div style="float:left; clear:both; height:20px; margin-right:0px;">');
        }
        else {
            $("<li " + attributes + ">" + name + "</li>").attr("class", cssClass).appendTo(".songsPlaceHolder ul").mouseover(songOver).mouseout(songOut).animate({ marginLeft: "10px" }, 500).click(handler).wrap('<div style="float:left; margin-right:0px;">');
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

function albumVideoLoaded(response) {
    EndRequestHandler();
    fillSongsPlaceHolder(response, videoClicked, "videosLi");
}

function songOver(el) {
    $(el.toElement).css("text-decoration", "underline")
}

function songOut(el) {
    $(el.fromElement).css("text-decoration", "none")
}

function songClicked(attrs) {
    stopPromo();
    $("#flashContainer").empty();
    var source = $(attrs.target).attr("path")
    $("#flashContainer").flash({ src: "Embed/xspf_jukebox.swf", flashvars: { allowscriptaccess: "never", track_title: "title", track_url: "Songs/" + source, autoplay: true, repeat: false} });
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

function onRetriveAlbumsFail() {
    alert("albums fail");
}

function onRetriveSongsFail() {
    alert("songs fail");
}