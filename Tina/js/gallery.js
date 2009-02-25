function loadImages(result) {
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
        loadingContainerSel: '#loading',
        renderSSControls: true,
        renderNavControls: true,
        playLinkText: 'Слайдшоу',
        pauseLinkText: 'Пауза',
        prevLinkText: '&lsaquo; Назад',
        nextLinkText: 'Вперед &rsaquo;',
        nextPageLinkText: '&rsaquo;',
        prevPageLinkText: '&lsaquo;',
        enableHistory: true,
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
