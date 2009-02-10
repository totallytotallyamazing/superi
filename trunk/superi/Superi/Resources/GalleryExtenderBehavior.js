
Type.registerNamespace('Superi.CustomControls');

Superi.CustomControls.GalleryExtender = function(element) {
    Superi.CustomControls.GalleryExtender.initializeBase(this, [element]);

    //Properties
    this.imagePlaceHolderID = null;
    this.cssClass = null;
    this.fadeInCaption = null;
    this.fadeInImage = null;
    this.fadeInThumbnailsOnLoad = null;
    this.fadeOutInactiveThumbnails = null;
    this.fadeInActiveThumbnail = null;
    this.enableHistory = null;
    this.nextImageOnClick = null;
    this.nextImageCaption = null;
    this.useHoverEffects = null;
}

Superi.CustomControls.GalleryExtender.prototype = {
    initialize: function() {
        Superi.CustomControls.GalleryExtender.callBaseMethod(this, 'initialize');
        var e = this.get_element();

        $(document).ready(function() {

            $(e).addClass(this.cssClass); // adds new class name to maintain degradability

            $(e).galleria({
                history: true, // activates the history object for bookmarking, back-button etc.
                clickNext: true, // helper for making the image clickable
                insert: '#' + imagePlaceHolderID, // the containing selector for our main image
                onImage: this._onImage,
                onThumb: this._onThumb
            });
        });


    },

    _onImage: function(image, caption, thumb) {

        // fade in the image & caption
        if (this.fadeInImage) {
            if (!($.browser.mozilla && navigator.appVersion.indexOf("Win") != -1)) { // FF/Win fades large images terribly slow
                image.css('display', 'none').fadeIn(1000);
            }
        }

        if (this.fadeInCaption) {
            caption.css('display', 'none').fadeIn(1000);
        }

        // fetch the thumbnail container
        var _li = thumb.parents('li');

        // fade out inactive thumbnail
        if (this.fadeOutInactiveThumbnails) {
            _li.siblings().children('img.selected').fadeTo(500, 0.3);
        }

        // fade in active thumbnail
        if (this.fadeInActiveThumbnail) {
            thumb.fadeTo('fast', 1).addClass('selected');
        }

        // add a title for the clickable image
        if (this.nextImageOnClick) {
            image.attr('title', this.nextImageCaption);
            image.attr('alt', this.nextImageCaption);
        }
    },

    _onThumb: function(thumb) { // thumbnail effects goes here

        // fetch the thumbnail container
        var _li = thumb.parents('li');

        // if thumbnail is active, fade all the way.
        var _fadeTo = _li.is('.active') ? '1' : '0.3';

        // fade in the thumbnail when finnished loading
        if (this.fadeInThumbnailsOnLoad) {
            thumb.css({ display: 'none', opacity: _fadeTo }).fadeIn(1500);
        }

        // hover effects
        if (this.useHoverEffects) {
            thumb.hover(
					function() { thumb.fadeTo('fast', 1); },
					function() { _li.not('.active').children('img').fadeTo('fast', 0.3); } // don't fade out if the parent is active
				)
        }
    },

    set_imagePlaceHolderID: function(value) {
        if (this.imagePlaceHolderID != value) {
            this.imagePlaceHolderID = value;
            this.raisePropertyChanged('imagePlaceHolderID');
        } 
    }

}

Superi.CustomControls.GalleryExtender.registerClass('Superi.CustomControls.GalleryExtender', Sys.UI.Control);
