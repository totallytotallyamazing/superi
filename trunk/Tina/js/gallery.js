function loadImages(result) {
    $(".gallery_unstyled").empty();
    $(".galleryPlaceHolder").css("display", "block");
    for(var i in result)
        createThumbnail(result[i].Picture, result[i].Title);
    prepareGallery();
}

function createThumbnail(picture, imageTitle) {
    $("<img />").attr({src: "images/Gallery/" + picture, title: imageTitle}).wrap("<li>").appendTo(".gallery_unstyled");
}

function prepareGallery() {

    //$('.gallery_unstyled').addClass('gallery'); // adds new class name to maintain degradability

    $('#galleryUL').galleria({
        history: true, // activates the history object for bookmarking, back-button etc.
        clickNext: true, // helper for making the image clickable
        insert: '#largeImage', // the containing selector for our main image
        onImage: imageProcessor,
        onThumb: thumbnailProcessor
    });
}

function imageProcessor(image, caption, thumb) {

    // fade in the image & caption
    if (!($.browser.mozilla && navigator.appVersion.indexOf("Win") != -1)) { // FF/Win fades large images terribly slow
        image.css('display', 'none').fadeIn(1000);
    }
    caption.css('display', 'none').fadeIn(1000);

    // fetch the thumbnail container
    var _li = thumb.parents('li');

    // fade out inactive thumbnail
    _li.siblings().children('img.selected').fadeTo(500, 0.3);

    // fade in active thumbnail
    thumb.fadeTo('fast', 1).addClass('selected');

    // add a title for the clickable image
    image.attr('title', 'Следующий >>');
}

function thumbnailProcessor(thumb) {

    // fetch the thumbnail container
    var _li = thumb.parents('li');

    // if thumbnail is active, fade all the way.
    var _fadeTo = _li.is('.active') ? '1' : '0.3';

    // fade in the thumbnail when finnished loading
    thumb.css({ display: 'none', opacity: _fadeTo }).fadeIn(1500);

    // hover effects
//    thumb.hover(
//					function() { thumb.fadeTo('fast', 1); },
//					function() { _li.not('.active').children('img').fadeTo('fast', 0.3); } // don't fade out if the parent is active
//				)
}

function loadImagesFail() { 
    
}