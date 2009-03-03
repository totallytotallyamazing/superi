﻿function loadImages(result) {
    EndRequestHandler();
    loadAlbums();
    $(".thumbs").empty();
    $(".galleryPlaceHolder").css("display", "block");
    var hasResults = false;
    for (var i in result) {
        hasResults = true;
        createThumbnail(result[i].Picture, result[i].Title, result[i].Thumbnail);
    }
    $('#thumbs ul.thumbs li').css('opacity', onMouseOutOpacity)
				.hover(
					function() {
					    $(this).not('.selected').fadeTo('fast', 1.0);
					},
					function() {
					    $(this).not('.selected').fadeTo('fast', onMouseOutOpacity);
					}
				);
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
//    if (historyCallback) {
//        $("[albumId='" + photoAlbumId + "'] a").toggleClass("subMenuItemActive");
//        photoAlbumId = 0;
//        historyCallback = false;
//    }
//    else
        $("[albumId='" + currentAlbumId + "'] a").toggleClass("subMenuItemActive");
    updateSubMenuClickHandlers(photoAlbumClicked);
}

function photoAlbumClicked(attrs) {
    cleanUp();
    updateSubMenuStyles();
    $(attrs.target).attr("class", "subMenuItemActive");
    var albumID = $(".subMenuItemActive").parent().attr("albumId");
//    $.history({ section: "photo", albumId: 0, photoAlbumId: albumID, videoId: 0 });
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
    $(galleryItemHtml.replace("%picture%", picture).replace("%thumbnail%", thumbnail).replace("%caption%", imageTitle)).appendTo(".thumbs");
}

var onMouseOutOpacity = 0.67;


function startGallery() {
    var galleryAdv = $('#gallery').galleriffic('#thumbs', {
        delay: 2000,
        numThumbs: 21,
        preloadAhead: 10,
        enableTopPager: true,
        enableBottomPager: true,
        imageContainerSel: '#slideshow',
        controlsContainerSel: '#controls',
        captionContainerSel: '',
        loadingContainerSel: '',
        renderSSControls: false,
        renderNavControls: false,
        playLinkText: '',
        pauseLinkText: '',
        prevLinkText: '',
        nextLinkText: '',
        nextPageLinkText: '&rsaquo;',
        prevPageLinkText: '&lsaquo;',
        enableHistory: false,
        autoStart: false,
        onChange: function(prevIndex, nextIndex) {
            $('#thumbs ul.thumbs').children()
							.eq(prevIndex).fadeTo('fast', onMouseOutOpacity).end()
							.eq(nextIndex).fadeTo('fast', 1.0);
        },
        onTransitionOut: function(callback) {
            $('#slideshow, #caption').fadeOut('fast', callback);
        },
        onTransitionIn: function() {
            $('#slideshow, #caption').fadeIn('fast');
        },
        onPageTransitionOut: function(callback) {
            $('#thumbs ul.thumbs').fadeOut('fast', callback);
        },
        onPageTransitionIn: function() {
            $('#thumbs ul.thumbs').fadeIn('fast');
        }
    });
    galleryAdv.css("display", "block");
}

function loadImagesFail() {
    alert("galleryFail");
}

var galleryItemHtml =  '<li>' +
							'<a class="thumb" href="MakeThumbnail.aspx?dim=510&file=%picture%" title="%caption%">' +
							'	<img src="MakeThumbnail.aspx?dim=75&file=%thumbnail%" alt="%caption%" />' +
							'</a>' +
						'</li>';
