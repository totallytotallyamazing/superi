

function processAlbums(response) {
    for (var i in response) {
        $.preloadImages("images/albumimages/" + response[i].Image);
            appendSubMenuItem(createMenuItem(response[i].Name + "(" + response[i].Year + ")", subMenuItemClicked).attr({ albumId: response[i].ID, image: "images/albumimages/" + response[i].Image }));
    }
}

function subMenuItemClicked(attrs) {
    cleanUp();
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
    $(".songsPlaceHolder").css("display", "block");
    $(".songsPlaceHolder ul").css("display", "block");
    $("#footerMenu a").css("display", "inline");
    for (var i in response) {
        var name = response[i].Name;
        var source = response[i].Source;
        $("<li path='" + source + "'>" + name + "</li>").appendTo(".songsPlaceHolder ul").animate({ marginLeft: "10px" }, 500).click(songClicked).wrap('<div style="float:left; margin-right:10px;">');
    }
}

function songClicked(attrs){
    $("#flashContainer").empty();
    var source = $(attrs.target).attr("path")
    $("#flashContainer").flash({ src: "Embed/xspf_jukebox.swf", flashvars: {allowscriptaccess: "never", track_title: "title", track_url: "Songs/" + source, autoplay: true, repeat: false} });
    resetSongs(attrs.target);
    $(attrs.target).unbind("click", songClicked).bind("click", stopPlaying).parent().css("background", "transparent url(images/playShadow.png)");
    $(attrs.target).parent().unbind("click", songClicked);
}

function stopPlaying(attrs) {
    $("#flashContainer").empty();
    $(attrs.target).unbind("click", stopPlaying).bind("click", songClicked).parent().css("background", "transparent");
}

function resetSongs(el) {
    $(".songsPlaceHolder ul div li").unbind("click", stopPlaying).unbind("click", songClicked).click(songClicked).parent().css("background", "transparent");
}

function showAlbumPhoto() {
    currentAlbumId = $(".subMenuItemActive").parent().attr("albumId");
    $("[section='photo']").click();
}

function showAlbumVideo() { 
    
}

function onRetriveAlbumsFail() {
    alert("albums fail");
}

function onRetriveSongsFail() {
    alert("songs fail");
}