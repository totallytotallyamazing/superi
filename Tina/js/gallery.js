function loadImages(result) {
    
    if (currentAlbumId <= 0)
        loadAlbums();
    else {
        $(".songsPlaceHolder ul").empty();
        $(".songsPlaceHolder ul").css("display", "none");
    }
    $(".thumbs center").empty();
    $(".galleryPlaceHolder").css("display", "block");
    var hasResults = false;
    for (var i in result) {
        hasResults = true;
        createThumbnail(result[i].Picture, result[i].Title, result[i].Thumbnail);
    }
    if (hasResults) {
        GalleryService.GetPageNumber(currentAlbumId, photoPageNumberRetrieved, photoPagesFailed);
        startGallery();
    }
    else {
        EndRequestHandler();
    }
}

function photoPageNumberRetrieved(response) {
    EndRequestHandler();
    if (response > 1) {
        initGalleryPages(response);
    }
}

function initGalleryPages(pageCount) {
    $("#galleryPages center").empty().css("display", "block");
    for (var i = 1; i <= pageCount; i++) {
        if (i - 1 !== currentGalleryPage)
            $("<a>").html('<img src="images/page.png" alt="'+i+'" />').appendTo("#galleryPages center").click(galleryPageChanged).css("cursor", "pointer");
        else
            $("<span>").addClass("current").html('<img src="images/currentPage.png" alt="' + i + '" />').appendTo("#galleryPages center");
    }
}

function galleryPageChanged(elem) {
    BeginRequestHandler();
    currentGalleryPage = +$(elem.target).attr("alt") - 1;
    GalleryService.GetPhotosPage(currentAlbumId, currentGalleryPage, loadImages, loadImagesFail);
}

function loadAlbums() {
    $("#subMenu ul").empty();
    appendSubMenuItem(createMenuItem("Имидж", photoAlbumClicked).attr({ albumId: 0, image: "images/photo.jpg" }));
    appendSubMenuItem(createMenuItem("Галерея", photoAlbumClicked).attr({ albumId: -1, image: "images/photo.jpg" }));
    $("[albumId='" + currentAlbumId + "'] a").toggleClass("subMenuItemActive");
    updateSubMenuClickHandlers(photoAlbumClicked);
}

function photoAlbumsProcessed(response) {
    EndRequestHandler();
    appendSubMenuItem(createMenuItem("Имидж", photoAlbumClicked).attr({ albumId: 0, image: "images/photo.jpg" }));
    appendSubMenuItem(createMenuItem("Галерея", photoAlbumClicked).attr({ albumId: -1, image: "images/photo.jpg" }));
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
    $("#fancy_close").mouseover(function() { $("#fancy_close").css("background-image", "url(images/fancybox/fancyCloseboxOver.png)") })
    $("#fancy_close").mouseout(function() { $("#fancy_close").css("background-image", "url(images/fancybox/fancyClosebox.png)") })
}

function loadImagesFail() {
    alert("galleryFail");
}

function photoPagesFailed() {
    alert("pages failed");
}

var galleryItemHtml =  '<li>' +
							'<a rel="group" class="thumb" href="MakeThumbnail.aspx?dim=600&file=%picture%">' +
							'	<img src="MakeThumbnail.aspx?dim=80&file=%thumbnail%" alt="%caption%" />' +
							'</a>' +
						'</li>';
