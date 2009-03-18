function loadImages(result) {
    EndRequestHandler();
    loadAlbums();
    $(".thumbs center").empty();
    $(".galleryPlaceHolder").css("display", "block");
    var hasResults = false;
    for (var i in result) {
        hasResults = true;
        createThumbnail(result[i].Picture, result[i].Title, result[i].Thumbnail);
    }

	if (hasResults)
	    startGallery();
}

function loadAlbums() {
    $("#subMenu ul").empty();
    BeginRequestHandler();
    Music.GetAlbums(photoAlbumsProcessed, onRetriveAlbumsFail);
}

function photoAlbumsProcessed(response) {
    EndRequestHandler();
    appendSubMenuItem(createMenuItem("Имидж", photoAlbumClicked).attr({ albumId: 0, image: "images/photo.jpg" }));
    for (var i in response) {
        $.preloadImages("images/albumimages/" + response[i].Image);
        appendSubMenuItem(createMenuItem(response[i].Name + "(" + response[i].Year + ")", photoAlbumClicked).attr({ albumId: response[i].ID, image: "images/albumimages/" + response[i].PhotoImage }));
    }
    $("[albumId='" + currentAlbumId + "'] a").toggleClass("subMenuItemActive");
    updateSubMenuClickHandlers(photoAlbumClicked);
}

function photoAlbumClicked(attrs) {
    cleanUp();
    updateSubMenuStyles();
    $(attrs.target).attr("class", "subMenuItemActive");
    var albumID = $(".subMenuItemActive").parent().attr("albumId");
    updateSubMenuClickHandlers(photoAlbumClicked);
    BeginRequestHandler();
    swapImage($(attrs.target).parent().attr("image"), photoImageSwapped);
}

function photoImageSwapped() {
    var albumID = $(".subMenuItemActive").parent().attr("albumId");
    currentAlbumId = +albumID;
    GalleryService.GetPhotosByAlbumId(currentAlbumId, loadImages, loadImagesFail);
}

function createThumbnail(picture, imageTitle, thumbnail) {
    $(galleryItemHtml.replace("%picture%", picture).replace("%thumbnail%", thumbnail).replace("%caption%", imageTitle)).appendTo(".thumbs center");
}

function startGallery() {
    $("a.thumb").fancybox({ 'overlayShow': true });
    $("a.thumb img").bind("load", function(el) {
        var pdt = $(".galleryPlaceHolder").height() / 2 - $(".thumbs").height() / 2;
        if (pdt > 0)
            $(".thumbs").css("padding-top", pdt);
        else
            $(".thumbs").css("padding-top", 0);
        $(el.target).fadeTo("fast", 0.6);
    })
    .bind("mouseover", function(el) { $(el.target).fadeTo("fast", 1); })
    .bind("mouseout", function(el) { $(el.target).fadeTo("fast", 0.6); })

}

function loadImagesFail() {
    alert("galleryFail");
}

var galleryItemHtml =  '<li>' +
							'<a rel="group" class="thumb" href="MakeThumbnail.aspx?dim=600&file=%picture%">' +
							'	<img src="MakeThumbnail.aspx?dim=80&file=%thumbnail%" alt="%caption%" />' +
							'</a>' +
						'</li>';
