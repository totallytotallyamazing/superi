// ClientLibrary.js
//


Type.registerNamespace('ClientLibrary');

////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.PlayerState

ClientLibrary.PlayerState = function() { 
    /// <field name="playing" type="Number" integer="true" static="true">
    /// </field>
    /// <field name="paused" type="Number" integer="true" static="true">
    /// </field>
    /// <field name="stopped" type="Number" integer="true" static="true">
    /// </field>
};
ClientLibrary.PlayerState.prototype = {
    playing: 0, 
    paused: 1, 
    stopped: 2
}
ClientLibrary.PlayerState.registerEnum('ClientLibrary.PlayerState', false);


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.ILoadableComponent

ClientLibrary.ILoadableComponent = function() { 
};
ClientLibrary.ILoadableComponent.prototype = {
    onLoad : null
}
ClientLibrary.ILoadableComponent.registerInterface('ClientLibrary.ILoadableComponent');


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.AjaxEventStub

ClientLibrary.AjaxEventStub = function ClientLibrary_AjaxEventStub() {
}
ClientLibrary.AjaxEventStub.prototype = {
    
    preventDefault: function ClientLibrary_AjaxEventStub$preventDefault() {
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.AjaxOptions

ClientLibrary.AjaxOptions = function ClientLibrary_AjaxOptions() {
    /// <field name="confirm" type="String">
    /// </field>
    /// <field name="url" type="String">
    /// </field>
    /// <field name="httpMethod" type="String">
    /// </field>
    /// <field name="updateTargetId" type="String">
    /// </field>
    /// <field name="loadingElementId" type="String">
    /// </field>
    /// <field name="onBegin" type="String">
    /// </field>
    /// <field name="onComplete" type="Sys.Mvc.AsyncRequestHandler">
    /// </field>
    /// <field name="onSuccess" type="Sys.Mvc.AsyncRequestHandler">
    /// </field>
    /// <field name="onFailure" type="Sys.Mvc.AsyncRequestHandler">
    /// </field>
    /// <field name="insertionMode" type="Sys.Mvc.InsertionMode">
    /// </field>
}
ClientLibrary.AjaxOptions.prototype = {
    confirm: null,
    url: null,
    httpMethod: null,
    updateTargetId: null,
    loadingElementId: null,
    onBegin: null,
    onComplete: null,
    onSuccess: null,
    onFailure: null,
    insertionMode: 0
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.AlbumExtender

ClientLibrary.AlbumExtender = function ClientLibrary_AlbumExtender() {
    /// <field name="_currentId$2" type="String">
    /// </field>
    /// <field name="_currentSlider$2" type="Jquery.JQuery">
    /// </field>
    ClientLibrary.AlbumExtender.initializeBase(this);
}
ClientLibrary.AlbumExtender.prototype = {
    _currentId$2: '',
    _currentSlider$2: null,
    
    contentUpdated: function ClientLibrary_AlbumExtender$contentUpdated(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        jQuery('#content').css('padding', '0');
        ClientLibrary.AudioPlayer.get_instance().add_playerPositionCanged(Function.createDelegate(this, this._playerPositionCanged$2));
        ClientLibrary.AudioPlayer.get_instance().add_songChanged(Function.createDelegate(this, this._songChanged$2));
        this._initializePlayers$2();
        ClientLibrary.AlbumExtender.callBaseMethod(this, 'contentUpdated', [ sender, e ]);
    },
    
    _songChanged$2: function ClientLibrary_AlbumExtender$_songChanged$2(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        this._openCurrentSong$2();
    },
    
    _playerPositionCanged$2: function ClientLibrary_AlbumExtender$_playerPositionCanged$2(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="ClientLibrary.PlayerListenerEventArgs">
        /// </param>
        this._currentSlider$2.slider('option', 'value', e.get_playedPercentAbsolute());
    },
    
    contentUpdating: function ClientLibrary_AlbumExtender$contentUpdating(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        jQuery('#content').css('padding', '');
        ClientLibrary.AudioPlayer.get_instance().remove_playerPositionCanged(Function.createDelegate(this, this._playerPositionCanged$2));
        ClientLibrary.AudioPlayer.get_instance().remove_songChanged(Function.createDelegate(this, this._songChanged$2));
        ClientLibrary.AlbumExtender.callBaseMethod(this, 'contentUpdating', [ sender, e ]);
        this.dispose();
    },
    
    _initializePlayers$2: function ClientLibrary_AlbumExtender$_initializePlayers$2() {
        var options = {};
        options['max'] = 100;
        options['range'] = 'min';
        options['animate'] = false;
        options['slide'] = Function.createDelegate(this, this._slide$2);
        jQuery('.song .player').slider(options);
        jQuery('.songTitle').click(Function.createDelegate(this, this._titleClick$2));
        this._openCurrentSong$2();
    },
    
    _openCurrentSong$2: function ClientLibrary_AlbumExtender$_openCurrentSong$2() {
        var songs = ClientLibrary.AudioPlayer.get_instance().get_songs();
        if (ClientLibrary.AudioPlayer.get_instance().get_state() === ClientLibrary.PlayerState.playing) {
            var song = songs[ClientLibrary.AudioPlayer.get_instance().get_currentSong()];
            var id = song['id'];
            jQuery('.player').not('.player[rel=\'' + id + '\']').hide();
            this._currentSlider$2 = jQuery('.player[rel=\'' + id + '\']').show();
            this._currentSlider$2.slider('option', 'value', 0);
            this._currentId$2 = id;
        }
    },
    
    _slide$2: function ClientLibrary_AlbumExtender$_slide$2(rawEvent, ui) {
        /// <param name="rawEvent" type="Object">
        /// </param>
        /// <param name="ui" type="Object">
        /// </param>
        /// <returns type="Object"></returns>
        ClientLibrary.AudioPlayer.get_instance().playHead(ui.value);
        jQuery('a').blur();
        return null;
    },
    
    _titleClick$2: function ClientLibrary_AlbumExtender$_titleClick$2(rawEvent, ui) {
        /// <param name="rawEvent" type="Object">
        /// </param>
        /// <param name="ui" type="Object">
        /// </param>
        /// <returns type="Object"></returns>
        var evt = rawEvent;
        var element = evt.target;
        var id = element.getAttribute('rel');
        if (id !== this._currentId$2) {
            var songs = ClientLibrary.AudioPlayer.get_instance().get_songs();
            var length = songs.length;
            for (var i = 0; i < length; i++) {
                var song = songs[i];
                if (song['id'] === id) {
                    ClientLibrary.AudioPlayer.get_instance().set_currentSong(i);
                    ClientLibrary.AudioPlayer.get_instance().changeSong(song['url']);
                    ClientLibrary.AudioPlayer.get_instance().play();
                    break;
                }
            }
            jQuery('.player').not('.player[rel=\'' + id + '\']').hide();
            this._currentSlider$2 = jQuery('.player[rel=\'' + id + '\']').show();
            this._currentSlider$2.slider('option', 'value', 0);
            this._currentId$2 = id;
        }
        else {
            ClientLibrary.AudioPlayer.get_instance().stop();
            jQuery('.player').hide();
        }
        return null;
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.PlayerListenerEventArgs

ClientLibrary.PlayerListenerEventArgs = function ClientLibrary_PlayerListenerEventArgs() {
    /// <field name="_loadPercent$1" type="Number" integer="true">
    /// </field>
    /// <field name="_playedPercentRelative$1" type="Number" integer="true">
    /// </field>
    /// <field name="_playedPercentAbsolute$1" type="Number" integer="true">
    /// </field>
    /// <field name="_playedTime$1" type="Number" integer="true">
    /// </field>
    /// <field name="_totalTime$1" type="Number" integer="true">
    /// </field>
    ClientLibrary.PlayerListenerEventArgs.initializeBase(this);
}
ClientLibrary.PlayerListenerEventArgs.prototype = {
    _loadPercent$1: 0,
    _playedPercentRelative$1: 0,
    _playedPercentAbsolute$1: 0,
    _playedTime$1: 0,
    _totalTime$1: 0,
    
    get_loadPercent: function ClientLibrary_PlayerListenerEventArgs$get_loadPercent() {
        /// <value type="Number" integer="true"></value>
        return this._loadPercent$1;
    },
    set_loadPercent: function ClientLibrary_PlayerListenerEventArgs$set_loadPercent(value) {
        /// <value type="Number" integer="true"></value>
        this._loadPercent$1 = value;
        return value;
    },
    
    get_playedPercentRelative: function ClientLibrary_PlayerListenerEventArgs$get_playedPercentRelative() {
        /// <value type="Number" integer="true"></value>
        return this._playedPercentRelative$1;
    },
    set_playedPercentRelative: function ClientLibrary_PlayerListenerEventArgs$set_playedPercentRelative(value) {
        /// <value type="Number" integer="true"></value>
        this._playedPercentRelative$1 = value;
        return value;
    },
    
    get_playedPercentAbsolute: function ClientLibrary_PlayerListenerEventArgs$get_playedPercentAbsolute() {
        /// <value type="Number" integer="true"></value>
        return this._playedPercentAbsolute$1;
    },
    set_playedPercentAbsolute: function ClientLibrary_PlayerListenerEventArgs$set_playedPercentAbsolute(value) {
        /// <value type="Number" integer="true"></value>
        this._playedPercentAbsolute$1 = value;
        return value;
    },
    
    get_playedTime: function ClientLibrary_PlayerListenerEventArgs$get_playedTime() {
        /// <value type="Number" integer="true"></value>
        return this._playedTime$1;
    },
    set_playedTime: function ClientLibrary_PlayerListenerEventArgs$set_playedTime(value) {
        /// <value type="Number" integer="true"></value>
        this._playedTime$1 = value;
        return value;
    },
    
    get_totalTime: function ClientLibrary_PlayerListenerEventArgs$get_totalTime() {
        /// <value type="Number" integer="true"></value>
        return this._totalTime$1;
    },
    set_totalTime: function ClientLibrary_PlayerListenerEventArgs$set_totalTime(value) {
        /// <value type="Number" integer="true"></value>
        this._totalTime$1 = value;
        return value;
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.AudioPlayer

ClientLibrary.AudioPlayer = function ClientLibrary_AudioPlayer(element) {
    /// <param name="element" type="Object" domElement="true">
    /// </param>
    /// <field name="_instance$2" type="ClientLibrary.AudioPlayer" static="true">
    /// </field>
    /// <field name="_currentSong$2" type="Number" integer="true">
    /// </field>
    /// <field name="_state$2" type="ClientLibrary.PlayerState">
    /// </field>
    ClientLibrary.AudioPlayer.initializeBase(this, [ element ]);
    ClientLibrary.AudioPlayer._instance$2 = this;
}
ClientLibrary.AudioPlayer.get_instance = function ClientLibrary_AudioPlayer$get_instance() {
    /// <value type="ClientLibrary.AudioPlayer"></value>
    return ClientLibrary.AudioPlayer._instance$2;
}
ClientLibrary.AudioPlayer.prototype = {
    _currentSong$2: 0,
    _state$2: 0,
    
    get_state: function ClientLibrary_AudioPlayer$get_state() {
        /// <value type="ClientLibrary.PlayerState"></value>
        return this._state$2;
    },
    set_state: function ClientLibrary_AudioPlayer$set_state(value) {
        /// <value type="ClientLibrary.PlayerState"></value>
        this._state$2 = value;
        return value;
    },
    
    get_currentSong: function ClientLibrary_AudioPlayer$get_currentSong() {
        /// <value type="Number" integer="true"></value>
        return this._currentSong$2;
    },
    set_currentSong: function ClientLibrary_AudioPlayer$set_currentSong(value) {
        /// <value type="Number" integer="true"></value>
        this._currentSong$2 = value;
        return value;
    },
    
    get_songs: function ClientLibrary_AudioPlayer$get_songs() {
        /// <value type="Array"></value>
        return getSongs();
    },
    
    add_playerPositionCanged: function ClientLibrary_AudioPlayer$add_playerPositionCanged(value) {
        /// <param name="value" type="Function" />
        this.get_events().addHandler('positionChanged', value);
    },
    remove_playerPositionCanged: function ClientLibrary_AudioPlayer$remove_playerPositionCanged(value) {
        /// <param name="value" type="Function" />
        this.get_events().removeHandler('positionChanged', value);
    },
    
    add_songChanged: function ClientLibrary_AudioPlayer$add_songChanged(value) {
        /// <param name="value" type="Function" />
        this.get_events().addHandler('songChanged', value);
    },
    remove_songChanged: function ClientLibrary_AudioPlayer$remove_songChanged(value) {
        /// <param name="value" type="Function" />
        this.get_events().removeHandler('songChanged', value);
    },
    
    get_progressChangedHandler: function ClientLibrary_AudioPlayer$get_progressChangedHandler() {
        /// <value type="Jquery.PlayerProgressChangeCallback"></value>
        return Function.createDelegate(this, this._progressChanged$2);
    },
    
    _progressChanged$2: function ClientLibrary_AudioPlayer$_progressChanged$2(loadPercent, playedPercentRelative, playedPercentAbsolute, playedTime, totalTime) {
        /// <param name="loadPercent" type="Number" integer="true">
        /// </param>
        /// <param name="playedPercentRelative" type="Number" integer="true">
        /// </param>
        /// <param name="playedPercentAbsolute" type="Number" integer="true">
        /// </param>
        /// <param name="playedTime" type="Number" integer="true">
        /// </param>
        /// <param name="totalTime" type="Number" integer="true">
        /// </param>
        var handler = this.get_events().getHandler('positionChanged');
        if (handler != null) {
            var args = new ClientLibrary.PlayerListenerEventArgs();
            args.set_loadPercent(loadPercent);
            args.set_playedPercentRelative(playedPercentRelative);
            args.set_playedPercentAbsolute(playedPercentAbsolute);
            args.set_playedTime(playedTime);
            args.set_totalTime(totalTime);
            handler(this, args);
        }
    },
    
    initialize: function ClientLibrary_AudioPlayer$initialize() {
        ClientLibrary.AudioPlayer.callBaseMethod(this, 'initialize');
        this.get_element().style.height = '0px';
    },
    
    onLoad: function ClientLibrary_AudioPlayer$onLoad() {
        /// <summary>
        /// Member of ILoadableComponent. Occurs after page is loaded.
        /// </summary>
        this._initializePlayer$2();
        this._initializeControls$2();
    },
    
    _initializePlayer$2: function ClientLibrary_AudioPlayer$_initializePlayer$2() {
        var options = new Jquery.JPlayerOptions();
        options.ready = Function.createDelegate(this, this._playerReady$2);
        options.volume = 100;
        options.swfPath = '/Scripts';
        jQuery(this.get_element()).jPlayer(options).onProgressChange(this.get_progressChangedHandler());
    },
    
    _initializeControls$2: function ClientLibrary_AudioPlayer$_initializeControls$2() {
        jQuery('#playerPresentation .controls a').click(Function.createDelegate(this, this._controlClick$2));
    },
    
    _setInitialControlState$2: function ClientLibrary_AudioPlayer$_setInitialControlState$2() {
        ((jQuery('a[rel=\'prev\']'))[0]).className = 'disabled';
        if (this.get_songs() == null || this.get_songs().length === 0) {
            jQuery('#playerPresentation .controls a').addClass('disabled');
        }
        else if (this.get_songs().length === 1) {
            jQuery('a[rel=\'next\']').addClass('disabled');
        }
    },
    
    _updateNavigationState$2: function ClientLibrary_AudioPlayer$_updateNavigationState$2() {
        if (this.get_songs().length <= this._currentSong$2 + 1) {
            jQuery('a[rel=\'next\']').addClass('disabled');
            jQuery('a[rel=\'prev\']').removeClass('disabled');
        }
        if (this._currentSong$2 === 0) {
            jQuery('a[rel=\'prev\']').addClass('disabled');
            jQuery('a[rel=\'next\']').removeClass('disabled');
        }
        if (this._currentSong$2 > 0) {
            jQuery('a[rel=\'prev\']').removeClass('disabled');
        }
        if (this.get_songs().length > this._currentSong$2 + 1) {
            jQuery('a[rel=\'next\']').removeClass('disabled');
        }
    },
    
    _controlClick$2: function ClientLibrary_AudioPlayer$_controlClick$2(rawEvent, stub) {
        /// <param name="rawEvent" type="Object">
        /// </param>
        /// <param name="stub" type="Object">
        /// </param>
        /// <returns type="BasicCallback"></returns>
        var evt = rawEvent;
        var srcElement = evt.srcElement;
        if (srcElement == null) {
            srcElement = evt.target;
        }
        var target = (srcElement.tagName === 'IMG') ? srcElement.parentNode : srcElement;
        var disabled = target.className === 'disabled';
        if (!disabled) {
            var operation = target.getAttribute('rel');
            switch (operation) {
                case 'play':
                    this.play();
                    break;
                case 'pause':
                    this.pause();
                    break;
                case 'prev':
                    this._prev$2();
                    break;
                case 'next':
                    this._next$2();
                    break;
            }
        }
        return null;
    },
    
    _playerReady$2: function ClientLibrary_AudioPlayer$_playerReady$2() {
        this._setInitialControlState$2();
        if (this.get_songs() != null && this.get_songs().length > 0) {
            var firstSong = this.get_songs()[0];
            (jQuery(this.get_element())).setFile(firstSong['url']).play();
            this._updateSongTitle$2(firstSong['name'], firstSong['album']);
            jQuery('a[rel=\'play\']').addClass('disabled');
        }
    },
    
    changeSong: function ClientLibrary_AudioPlayer$changeSong(url) {
        /// <param name="url" type="String">
        /// </param>
        (jQuery(this.get_element())).setFile(url);
    },
    
    playHead: function ClientLibrary_AudioPlayer$playHead(percentOfLoaded) {
        /// <param name="percentOfLoaded" type="Number" integer="true">
        /// </param>
        (jQuery(this.get_element())).playHead(percentOfLoaded);
    },
    
    play: function ClientLibrary_AudioPlayer$play() {
        (jQuery(this.get_element())).play();
        jQuery('a[rel=\'play\']').addClass('disabled');
        jQuery('a[rel=\'pause\']').removeClass('disabled');
        this.set_state(ClientLibrary.PlayerState.playing);
    },
    
    pause: function ClientLibrary_AudioPlayer$pause() {
        (jQuery(this.get_element())).pause();
        jQuery('a[rel=\'play\']').removeClass('disabled');
        jQuery('a[rel=\'pause\']').addClass('disabled');
        this.set_state(ClientLibrary.PlayerState.paused);
    },
    
    stop: function ClientLibrary_AudioPlayer$stop() {
        (jQuery(this.get_element())).stop();
        jQuery('a[rel=\'play\'], a[rel=\'pause\']').toggleClass('disabled');
        this.set_state(ClientLibrary.PlayerState.stopped);
    },
    
    _next$2: function ClientLibrary_AudioPlayer$_next$2() {
        this._currentSong$2++;
        this._updateNavigationState$2();
        var song = this.get_songs()[this._currentSong$2];
        this.changeSong(song['url']);
        this._updateSongTitle$2(song['name'], song['album']);
        this.play();
        var handler = this.get_events().getHandler('songChanged');
        if (handler != null) {
            handler(this, new Sys.EventArgs());
        }
    },
    
    _prev$2: function ClientLibrary_AudioPlayer$_prev$2() {
        this._currentSong$2--;
        this._updateNavigationState$2();
        var song = this.get_songs()[this._currentSong$2];
        this.changeSong(song['url']);
        this._updateSongTitle$2(song['name'], song['album']);
        this.play();
        var handler = this.get_events().getHandler('songChanged');
        if (handler != null) {
            handler(this, new Sys.EventArgs());
        }
    },
    
    _updateSongTitle$2: function ClientLibrary_AudioPlayer$_updateSongTitle$2(name, album) {
        /// <param name="name" type="String">
        /// </param>
        /// <param name="album" type="String">
        /// </param>
        document.getElementById('playerSongName').innerHTML = name;
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.CssHelper

ClientLibrary.CssHelper = function ClientLibrary_CssHelper() {
}
ClientLibrary.CssHelper.addCss = function ClientLibrary_CssHelper$addCss(path, cssKey) {
    /// <param name="path" type="String">
    /// </param>
    /// <param name="cssKey" type="String">
    /// </param>
    var query = jQuery('<link rel=\'Stylesheet\'>').attr('href', path);
    query = query.attr('key', cssKey);
    query.appendTo('#content');
}
ClientLibrary.CssHelper.removeCss = function ClientLibrary_CssHelper$removeCss(key) {
    /// <param name="key" type="String">
    /// </param>
    jQuery('link[key=\'' + key + '\']').remove(null);
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.GalleryExtender

ClientLibrary.GalleryExtender = function ClientLibrary_GalleryExtender() {
    /// <field name="_contentUpdating$2" type="Sys.EventHandler">
    /// </field>
    /// <field name="_contentUpdated$2" type="Sys.EventHandler">
    /// </field>
    /// <field name="_serializedIdArray$2" type="String">
    /// </field>
    /// <field name="_lastId$2" type="String">
    /// </field>
    ClientLibrary.GalleryExtender.initializeBase(this);
}
ClientLibrary.GalleryExtender.update = function ClientLibrary_GalleryExtender$update() {
    jQuery.fancybox.close();
    ClientLibrary.PageManager.get_current().goToUrl('/Gallery');
}
ClientLibrary.GalleryExtender.prototype = {
    _contentUpdating$2: null,
    _contentUpdated$2: null,
    _serializedIdArray$2: null,
    
    get_serializedIdArray: function ClientLibrary_GalleryExtender$get_serializedIdArray() {
        /// <value type="String"></value>
        return this._serializedIdArray$2;
    },
    set_serializedIdArray: function ClientLibrary_GalleryExtender$set_serializedIdArray(value) {
        /// <value type="String"></value>
        this._serializedIdArray$2 = value;
        return value;
    },
    
    get__galleryIds$2: function ClientLibrary_GalleryExtender$get__galleryIds$2() {
        /// <value type="Array" elementType="Number" elementInteger="true"></value>
        if (this.get_serializedIdArray() !== '') {
            return Sys.Serialization.JavaScriptSerializer.deserialize(this.get_serializedIdArray());
        }
        else {
            return null;
        }
    },
    
    _initializeAdminArea$2: function ClientLibrary_GalleryExtender$_initializeAdminArea$2() {
        if (ClientLibrary.PageManager.get_current().get_isAuthenticated()) {
            var options = new Jquery.FancyBoxOptions();
            options.width = 200;
            options.height = 150;
            options.hideOnContentClick = false;
            options.hideOnOverlayClick = false;
            options.autoDimensions = false;
            options.autoScale = false;
            options.padding = 10;
            jQuery('.adminLink').fancybox(options);
            jQuery('.adminConfirmLink').click(Function.createDelegate(this, this._confirmClick$2));
            jQuery('.photoSession img').mouseover(Function.createDelegate(this, this._galleryItemMouseOver$2));
            var oldDiv = document.getElementById('bodyImageDeleteFrame');
            if (oldDiv != null) {
                document.body.removeChild(oldDiv);
            }
            var imageDeleteFrame = document.getElementById('imageDeleteFrame');
            imageDeleteFrame.id = 'bodyImageDeleteFrame';
            document.body.appendChild(imageDeleteFrame);
        }
    },
    
    _lastId$2: '[id]',
    
    _galleryItemMouseOver$2: function ClientLibrary_GalleryExtender$_galleryItemMouseOver$2(rawEvent, stub) {
        /// <param name="rawEvent" type="Object">
        /// </param>
        /// <param name="stub" type="Object">
        /// </param>
        /// <returns type="Object"></returns>
        var evt = rawEvent;
        var target = evt.target;
        var imageId = target.getAttribute('rel');
        var left = jQuery(target).offset().left;
        var top = jQuery(target).offset().top;
        var imageDeleteFrame = document.getElementById('bodyImageDeleteFrame');
        imageDeleteFrame.style.left = left + 'px';
        imageDeleteFrame.style.top = top + 'px';
        imageDeleteFrame.style.display = 'block';
        var anchor = imageDeleteFrame.children[0];
        anchor.href = anchor.href.replace(this._lastId$2, imageId);
        this._lastId$2 = imageId;
        return null;
    },
    
    _confirmClick$2: function ClientLibrary_GalleryExtender$_confirmClick$2(rawEvent, stub) {
        /// <param name="rawEvent" type="Object">
        /// </param>
        /// <param name="stub" type="Object">
        /// </param>
        /// <returns type="Object"></returns>
        var evt = rawEvent;
        var element = evt.srcElement;
        if (confirm('\u0412\u044b \u0443\u0432\u0435\u0440\u0435\u043d\u044b?')) {
            var options = new ClientLibrary.AjaxOptions();
            options.onSuccess = Function.createDelegate(this, function(context) {
                ClientLibrary.PageManager.get_current().goToUrl('/Gallery');
            });
            ClientLibrary.PageManager.asyncRequest(element.href, 'GET', '', element, options);
        }
        evt.returnValue = false;
        evt.stopPropagation();
        return false;
    },
    
    _clearAdminHandlers$2: function ClientLibrary_GalleryExtender$_clearAdminHandlers$2() {
        jQuery('.adminConfirmLink').unbind('click', null);
        jQuery('.photoSession img').unbind('mouseover', null);
    },
    
    contentUpdated: function ClientLibrary_GalleryExtender$contentUpdated(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        if (this.get__galleryIds$2() != null) {
            jQuery('.photoSession').fancybox(null);
            var length = this.get__galleryIds$2().length;
            for (var i = 0; i < length; i++) {
                var controlId = '#carousel_' + this.get__galleryIds$2()[i];
                var config = new Jquery.JCarouselConfig();
                config.scroll = 1;
                jQuery(controlId).jcarousel(null);
            }
        }
        jQuery('#content').css('padding', '0');
        this._initializeAdminArea$2();
    },
    
    contentUpdating: function ClientLibrary_GalleryExtender$contentUpdating(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        jQuery('#content').css('padding', '');
        this._clearAdminHandlers$2();
        this.dispose();
        ClientLibrary.GalleryExtender.callBaseMethod(this, 'contentUpdating', [ sender, e ]);
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.ComponentLoader

ClientLibrary.ComponentLoader = function ClientLibrary_ComponentLoader() {
    ClientLibrary.ComponentLoader.initializeBase(this);
}
ClientLibrary.ComponentLoader.prototype = {
    
    initialize: function ClientLibrary_ComponentLoader$initialize() {
        window.setTimeout(Function.createDelegate(this, this._pageLoaded$1), 1000);
    },
    
    _pageLoaded$1: function ClientLibrary_ComponentLoader$_pageLoaded$1() {
        var components = Sys.Application.getComponents();
        var length = components.length;
        for (var i = 0; i < length; i++) {
            if (ClientLibrary.ILoadableComponent.isInstanceOfType(components[i])) {
                (components[i]).onLoad();
            }
        }
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.PageExtender

ClientLibrary.PageExtender = function ClientLibrary_PageExtender() {
    /// <field name="_contentUpdating$1" type="Sys.EventHandler">
    /// </field>
    /// <field name="_contentUpdated$1" type="Sys.EventHandler">
    /// </field>
    ClientLibrary.PageExtender.initializeBase(this);
}
ClientLibrary.PageExtender.prototype = {
    _contentUpdating$1: null,
    _contentUpdated$1: null,
    
    initialize: function ClientLibrary_PageExtender$initialize() {
        this._contentUpdating$1 = Function.createDelegate(this, this.contentUpdating);
        this._contentUpdated$1 = Function.createDelegate(this, this.contentUpdated);
        ClientLibrary.PageManager.get_current().add_contentUpdating(this._contentUpdating$1);
        ClientLibrary.PageManager.get_current().add_contentUpdated(this._contentUpdated$1);
    },
    
    contentUpdated: function ClientLibrary_PageExtender$contentUpdated(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
    },
    
    contentUpdating: function ClientLibrary_PageExtender$contentUpdating(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        ClientLibrary.PageManager.get_current().remove_contentUpdated(this._contentUpdated$1);
        ClientLibrary.PageManager.get_current().remove_contentUpdating(this._contentUpdating$1);
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.PhotoSessionExtender

ClientLibrary.PhotoSessionExtender = function ClientLibrary_PhotoSessionExtender() {
    ClientLibrary.PhotoSessionExtender.initializeBase(this);
}
ClientLibrary.PhotoSessionExtender.prototype = {
    
    contentUpdated: function ClientLibrary_PhotoSessionExtender$contentUpdated(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        $('a.photoSession').fancybox();;
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.PageManager

ClientLibrary.PageManager = function ClientLibrary_PageManager() {
    /// <field name="_instanse$1" type="ClientLibrary.PageManager" static="true">
    /// </field>
    /// <field name="_linkNavigation$1" type="Boolean">
    /// </field>
    /// <field name="_asyncRequestHandler$1" type="Sys.Mvc.AsyncRequestHandler">
    /// </field>
    ClientLibrary.PageManager.initializeBase(this);
}
ClientLibrary.PageManager.get_current = function ClientLibrary_PageManager$get_current() {
    /// <value type="ClientLibrary.PageManager"></value>
    return ClientLibrary.PageManager._instanse$1;
}
ClientLibrary.PageManager.asyncRequest = function ClientLibrary_PageManager$asyncRequest(url, verb, body, triggerElement, ajaxOptions) {
    /// <param name="url" type="String">
    /// </param>
    /// <param name="verb" type="String">
    /// </param>
    /// <param name="body" type="String">
    /// </param>
    /// <param name="triggerElement" type="Object" domElement="true">
    /// </param>
    /// <param name="ajaxOptions" type="Object">
    /// </param>
    Sys.Mvc.MvcHelpers.$1(url, verb, body, triggerElement, ajaxOptions);
}
ClientLibrary.PageManager.prototype = {
    _linkNavigation$1: false,
    _asyncRequestHandler$1: null,
    
    get_isAuthenticated: function ClientLibrary_PageManager$get_isAuthenticated() {
        /// <value type="Boolean"></value>
        if(typeof(window.IsAuthenticated) !=='undefined' && IsAuthenticated)return true;
        return false;
    },
    
    add_contentUpdated: function ClientLibrary_PageManager$add_contentUpdated(value) {
        /// <param name="value" type="Function" />
        this.get_events().addHandler('contentUpdated', value);
    },
    remove_contentUpdated: function ClientLibrary_PageManager$remove_contentUpdated(value) {
        /// <param name="value" type="Function" />
        this.get_events().removeHandler('contentUpdated', value);
    },
    
    add_contentUpdating: function ClientLibrary_PageManager$add_contentUpdating(value) {
        /// <param name="value" type="Function" />
        this.get_events().addHandler('contentUpdating', value);
    },
    remove_contentUpdating: function ClientLibrary_PageManager$remove_contentUpdating(value) {
        /// <param name="value" type="Function" />
        this.get_events().removeHandler('contentUpdating', value);
    },
    
    goToUrl: function ClientLibrary_PageManager$goToUrl(url) {
        /// <param name="url" type="String">
        /// </param>
        var state = {};
        state['url'] = url;
        this._restoreSateFromHistory$1(state);
    },
    
    _createHistoryPoint$1: function ClientLibrary_PageManager$_createHistoryPoint$1(target, options) {
        /// <param name="target" type="Object" domElement="true">
        /// </param>
        /// <param name="options" type="ClientLibrary.AjaxOptions">
        /// </param>
        var result = {};
        result['url'] = target.getAttribute('href');
        Sys.Application.addHistoryPoint(result);
    },
    
    _restoreSateFromHistory$1: function ClientLibrary_PageManager$_restoreSateFromHistory$1(state) {
        /// <param name="state" type="Object">
        /// </param>
        this._ivokeUpdating$1();
        this._killAsyncAnchors$1();
        var options = new ClientLibrary.AjaxOptions();
        options.updateTargetId = 'content';
        options.insertionMode = Sys.Mvc.InsertionMode.replace;
        if (this._asyncRequestHandler$1 == null) {
            this._asyncRequestHandler$1 = Function.createDelegate(this, this.asyncRequestCompleted);
        }
        options.onComplete = this._asyncRequestHandler$1;
        if (state['url'] != null) {
            var url = state['url'];
            ClientLibrary.PageManager.asyncRequest(url, 'post', '', null, options);
            this._updateMenuSelection$1(url);
        }
        else {
            ClientLibrary.PageManager.asyncRequest('/Home/IndexContent', 'post', '', null, options);
            this._updateMenuSelection$1('*');
        }
    },
    
    _initializeMenuAnchors$1: function ClientLibrary_PageManager$_initializeMenuAnchors$1() {
        var menuContainer = document.getElementById('menuContainer');
        var menuAnchors = menuContainer.getElementsByTagName('a');
        this._initializeAsyncAnchors$1(menuAnchors);
    },
    
    _initializePageAnchors$1: function ClientLibrary_PageManager$_initializePageAnchors$1() {
        var anchors = ClientLibrary.Utils.getElementsByAttribute(document.getElementById('content'), 'a', 'rel', 'async', null);
        this._initializeAsyncAnchors$1(anchors);
    },
    
    _initializeAsyncAnchors$1: function ClientLibrary_PageManager$_initializeAsyncAnchors$1(anchors) {
        /// <param name="anchors" type="Array">
        /// </param>
        for (var i = 0; i < anchors.length; i++) {
            var anchor = anchors[i];
            $addHandler(anchor, 'click', Function.createDelegate(this, this._menuItemClicked$1));
        }
        var logoLink = document.getElementById('logo').getElementsByTagName('a')[0];
        $addHandler(logoLink, 'click', Function.createDelegate(this, this._menuItemClicked$1));
    },
    
    _killAsyncAnchors$1: function ClientLibrary_PageManager$_killAsyncAnchors$1() {
        var anchors = ClientLibrary.Utils.getElementsByAttribute(document.getElementById('content'), 'a', 'rel', 'async', null);
        for (var i = 0; i < anchors.length; i++) {
            var anchor = anchors[i];
            $clearHandlers(anchor);
        }
    },
    
    _ivokeUpdating$1: function ClientLibrary_PageManager$_ivokeUpdating$1() {
        var handler = this.get_events().getHandler('contentUpdating');
        if (handler != null) {
            handler(this, new Sys.EventArgs());
        }
    },
    
    _invokeUpdated$1: function ClientLibrary_PageManager$_invokeUpdated$1() {
        var handler = this.get_events().getHandler('contentUpdated');
        if (handler != null) {
            handler(this, new Sys.EventArgs());
        }
    },
    
    _updateMenuSelection$1: function ClientLibrary_PageManager$_updateMenuSelection$1(url) {
        /// <param name="url" type="String">
        /// </param>
        var comparer = Function.createDelegate(this, function(a, b) {
            return (b.indexOf(a) > -1 && b.indexOf(a) < 1);
        });
        var target = ClientLibrary.Utils.getElementsByAttribute(document.getElementById('menuContainer'), 'a', 'href', url, comparer)[0];
        if (target != null) {
            target = target.parentNode;
        }
        var items = jQuery('#menuContainer div');
        if (target != null) {
            items = items.not(target);
            Sys.UI.DomElement.addCssClass(target, 'current');
            Sys.UI.DomElement.removeCssClass(target, 'hover');
        }
        items.removeClass('current');
    },
    
    _createPageExtenders$1: function ClientLibrary_PageManager$_createPageExtenders$1() {
        var scripts = document.getElementById('content').getElementsByTagName('script');
        for (var i = 0; i < scripts.length; i++) {
            var script = scripts[i];
            if (script != null) {
                eval(script.innerHTML);
                if (script.getAttribute('src') != null) {
                    var newScript = document.createElement('script');
                    newScript.type = 'text/javascript';
                    newScript.src = script.getAttribute('src');
                    document.getElementById('content').appendChild(newScript);
                }
            }
        }
    },
    
    _application_Navigate$1: function ClientLibrary_PageManager$_application_Navigate$1(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.HistoryEventArgs">
        /// </param>
        if (!this._linkNavigation$1) {
            this._restoreSateFromHistory$1(e.get_state());
        }
    },
    
    _menuItemClicked$1: function ClientLibrary_PageManager$_menuItemClicked$1(e) {
        /// <param name="e" type="Sys.UI.DomEvent">
        /// </param>
        this._ivokeUpdating$1();
        this._killAsyncAnchors$1();
        var options = new ClientLibrary.AjaxOptions();
        options.updateTargetId = 'content';
        options.insertionMode = Sys.Mvc.InsertionMode.replace;
        if (this._asyncRequestHandler$1 == null) {
            this._asyncRequestHandler$1 = Function.createDelegate(this, this.asyncRequestCompleted);
        }
        options.onComplete = this._asyncRequestHandler$1;
        var target = (e.target.tagName === 'A') ? e.target : e.target.parentNode;
        var url = target.getAttribute('href');
        this._updateMenuSelection$1(url);
        this._linkNavigation$1 = true;
        this._createHistoryPoint$1(target, options);
        Sys.Mvc.AsyncHyperlink.handleClick(target, e, options);
    },
    
    asyncRequestCompleted: function ClientLibrary_PageManager$asyncRequestCompleted(param) {
        /// <param name="param" type="Sys.Mvc.AjaxContext">
        /// </param>
        this._linkNavigation$1 = false;
        window.setTimeout(Function.createDelegate(this, this._createPageExtenders$1), 200);
        window.setTimeout(Function.createDelegate(this, this._invokeUpdated$1), 400);
        window.setTimeout(Function.createDelegate(this, this._initializePageAnchors$1), 400);
    },
    
    initialize: function ClientLibrary_PageManager$initialize() {
        ClientLibrary.PageManager._instanse$1 = this;
        ClientLibrary.PageManager.callBaseMethod(this, 'initialize');
        Sys.Application.set_enableHistory(true);
        Sys.Application.add_navigate(Function.createDelegate(this, this._application_Navigate$1));
    },
    
    _initializeMainMenu$1: function ClientLibrary_PageManager$_initializeMainMenu$1() {
        this._initializeMenuAnchors$1();
        var arr = jQuery('.menuItem').not('.current');
        for (var i = 0; i < arr.length; i++) {
            var elem = arr[i];
            $addHandler(elem.getElementsByTagName('a')[0], 'mouseover', Function.createDelegate(this, function(e) {
                if (e.target.className !== 'current') {
                    Sys.UI.DomElement.addCssClass(e.target.parentNode, 'hover');
                }
            }));
            $addHandler(elem.getElementsByTagName('a')[0], 'mouseout', Function.createDelegate(this, function(e) {
                if (e.target.className !== 'current') {
                    Sys.UI.DomElement.removeCssClass(e.target.parentNode, 'hover');
                }
            }));
        }
    },
    
    onLoad: function ClientLibrary_PageManager$onLoad() {
        this._initializeMainMenu$1();
        this._initializePageAnchors$1();
        this._invokeUpdated$1();
    }
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.Utils

ClientLibrary.Utils = function ClientLibrary_Utils() {
}
ClientLibrary.Utils.getElementsByAttribute = function ClientLibrary_Utils$getElementsByAttribute(parent, tagName, attributeName, attributeValue, comparer) {
    /// <param name="parent" type="Object" domElement="true">
    /// </param>
    /// <param name="tagName" type="String">
    /// </param>
    /// <param name="attributeName" type="String">
    /// </param>
    /// <param name="attributeValue" type="String">
    /// </param>
    /// <param name="comparer" type="ClientLibrary.AttributeComparer">
    /// </param>
    /// <returns type="Array"></returns>
    var result = [];
    var currentResultIndex = 0;
    if (parent == null) {
        parent = document.documentElement;
    }
    if (tagName == null) {
        tagName = '*';
    }
    var startElements = parent.getElementsByTagName(tagName);
    for (var i = 0; i < startElements.length; i++) {
        var current = startElements[i];
        var attribute = current.getAttribute(attributeName);
        if (attribute != null) {
            var attributesEqual = false;
            if (comparer != null) {
                attributesEqual = comparer(attribute.toString(), attributeValue);
            }
            else {
                attributesEqual = (attribute.toString() === attributeValue);
            }
            if (attributesEqual) {
                result[currentResultIndex] = current;
                currentResultIndex++;
            }
        }
    }
    return result;
}


////////////////////////////////////////////////////////////////////////////////
// ClientLibrary.VideoExtender

ClientLibrary.VideoExtender = function ClientLibrary_VideoExtender() {
    /// <field name="_current$2" type="Object" domElement="true">
    /// </field>
    ClientLibrary.VideoExtender.initializeBase(this);
}
ClientLibrary.VideoExtender.prototype = {
    _current$2: null,
    
    contentUpdated: function ClientLibrary_VideoExtender$contentUpdated(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        ClientLibrary.VideoExtender.callBaseMethod(this, 'contentUpdated', [ sender, e ]);
        this._init$2();
    },
    
    contentUpdating: function ClientLibrary_VideoExtender$contentUpdating(sender, e) {
        /// <param name="sender" type="Object">
        /// </param>
        /// <param name="e" type="Sys.EventArgs">
        /// </param>
        this._cleanup$2();
        ClientLibrary.VideoExtender.callBaseMethod(this, 'contentUpdating', [ sender, e ]);
        this.dispose();
    },
    
    _init$2: function ClientLibrary_VideoExtender$_init$2() {
        ClientLibrary.AudioPlayer.get_instance().pause();
        jQuery('#content').css('padding', '0');
        jQuery('#clipThumbnails .thumbnail').click(Function.createDelegate(this, this._click$2));
        jQuery('#clipThumbnails .thumbnail').mouseover(Function.createDelegate(this, this._thumbnailOver$2));
        jQuery('#clipThumbnails .thumbnail').mouseout(Function.createDelegate(this, this._thumbnailOut$2));
        jQuery('#clipThumbnails .thumbnail').eq(0).click();
    },
    
    _cleanup$2: function ClientLibrary_VideoExtender$_cleanup$2() {
        jQuery('#content').css('padding', '');
        jQuery('#clipThumbnails .thumbnail').unbind('click', null).unbind('mouseover', null).unbind('mouseout', null);
        ClientLibrary.AudioPlayer.get_instance().play();
    },
    
    _thumbnailOver$2: function ClientLibrary_VideoExtender$_thumbnailOver$2(rawEvent, ui) {
        /// <param name="rawEvent" type="Object">
        /// </param>
        /// <param name="ui" type="Object">
        /// </param>
        /// <returns type="Object"></returns>
        var target = rawEvent.target;
        jQuery(target).addClass('hover');
        return null;
    },
    
    _thumbnailOut$2: function ClientLibrary_VideoExtender$_thumbnailOut$2(rawEvent, ui) {
        /// <param name="rawEvent" type="Object">
        /// </param>
        /// <param name="ui" type="Object">
        /// </param>
        /// <returns type="Object"></returns>
        var target = rawEvent.target;
        jQuery(target).removeClass('hover');
        return null;
    },
    
    _click$2: function ClientLibrary_VideoExtender$_click$2(rawEvent, ui) {
        /// <param name="rawEvent" type="Object">
        /// </param>
        /// <param name="ui" type="Object">
        /// </param>
        /// <returns type="Object"></returns>
        debugger;
        var target = rawEvent.target;
        if (target.tagName !== 'DIV') {
            target = target.parentNode;
        }
        jQuery(target).unbind('mouseover', null).unbind('click', null).removeClass('hover').addClass('current');
        var title = jQuery(target).children('p.title').html();
        var description = jQuery(target).children('p.clipDescription').html();
        jQuery('#clipDetails h1').html(title);
        jQuery('#clipDetails p').html(description);
        var source = (target.getElementsByTagName('input')[0]).value;
        jQuery('#clip').fadeTo('slow', 10, Function.createDelegate(this, function(a, b) {
            jQuery('#clip').html(source);
            jQuery('#clip').fadeIn('slow', null);
            return null;
        }));
        jQuery(this._current$2).removeClass('current').mouseover(Function.createDelegate(this, this._thumbnailOver$2)).click(Function.createDelegate(this, this._click$2));
        this._current$2 = target;
        return null;
    }
}


Type.registerNamespace('Jquery');

////////////////////////////////////////////////////////////////////////////////
// Jquery.FancyBoxOptions

Jquery.FancyBoxOptions = function Jquery_FancyBoxOptions() {
    /// <field name="padding" type="Object">
    /// </field>
    /// <field name="margin" type="Object">
    /// </field>
    /// <field name="width" type="Object">
    /// </field>
    /// <field name="height" type="Object">
    /// </field>
    /// <field name="opacity" type="Boolean">
    /// </field>
    /// <field name="modal" type="Boolean">
    /// </field>
    /// <field name="cyclic" type="Boolean">
    /// </field>
    /// <field name="autoScale" type="Boolean">
    /// </field>
    /// <field name="autoDimensions" type="Boolean">
    /// </field>
    /// <field name="centerOnScroll" type="Boolean">
    /// </field>
    /// <field name="hideOnOverlayClick" type="Boolean">
    /// </field>
    /// <field name="hideOnContentClick" type="Boolean">
    /// </field>
    /// <field name="overlayShow" type="Boolean">
    /// </field>
    /// <field name="overlayOpacity" type="Number">
    /// </field>
    /// <field name="overlayColor" type="String">
    /// </field>
    /// <field name="scrolling" type="String">
    /// </field>
}
Jquery.FancyBoxOptions.prototype = {
    padding: null,
    margin: null,
    width: null,
    height: null,
    opacity: false,
    modal: false,
    cyclic: false,
    autoScale: true,
    autoDimensions: true,
    centerOnScroll: false,
    hideOnOverlayClick: true,
    hideOnContentClick: true,
    overlayShow: true,
    overlayOpacity: 0.3,
    overlayColor: null,
    scrolling: null
}


////////////////////////////////////////////////////////////////////////////////
// Jquery.JCarouselConfig

Jquery.JCarouselConfig = function Jquery_JCarouselConfig() {
    /// <field name="vertical" type="Boolean">
    /// </field>
    /// <field name="start" type="Object">
    /// </field>
    /// <field name="offset" type="Object">
    /// </field>
    /// <field name="size" type="Object">
    /// </field>
    /// <field name="scroll" type="Object">
    /// </field>
    /// <field name="wrap" type="String">
    /// </field>
    /// <field name="animation" type="Object">
    /// </field>
}
Jquery.JCarouselConfig.prototype = {
    vertical: false,
    start: null,
    offset: null,
    size: null,
    scroll: null,
    wrap: null,
    animation: null
}


////////////////////////////////////////////////////////////////////////////////
// Jquery.JPlayerOptions

Jquery.JPlayerOptions = function Jquery_JPlayerOptions() {
    /// <field name="ready" type="Callback">
    /// </field>
    /// <field name="swfPath" type="String">
    /// </field>
    /// <field name="cssPrefix" type="String">
    /// </field>
    /// <field name="volume" type="Number" integer="true">
    /// </field>
    /// <field name="playerProgressChange" type="Jquery.PlayerProgressChangeCallback">
    /// </field>
}
Jquery.JPlayerOptions.prototype = {
    ready: null,
    swfPath: null,
    cssPrefix: null,
    volume: 0,
    playerProgressChange: null
}


ClientLibrary.AjaxEventStub.registerClass('ClientLibrary.AjaxEventStub');
ClientLibrary.AjaxOptions.registerClass('ClientLibrary.AjaxOptions');
ClientLibrary.PageExtender.registerClass('ClientLibrary.PageExtender', Sys.Component);
ClientLibrary.AlbumExtender.registerClass('ClientLibrary.AlbumExtender', ClientLibrary.PageExtender);
ClientLibrary.PlayerListenerEventArgs.registerClass('ClientLibrary.PlayerListenerEventArgs', Sys.EventArgs);
ClientLibrary.AudioPlayer.registerClass('ClientLibrary.AudioPlayer', Sys.UI.Control, ClientLibrary.ILoadableComponent);
ClientLibrary.CssHelper.registerClass('ClientLibrary.CssHelper');
ClientLibrary.GalleryExtender.registerClass('ClientLibrary.GalleryExtender', ClientLibrary.PageExtender);
ClientLibrary.ComponentLoader.registerClass('ClientLibrary.ComponentLoader', Sys.Component);
ClientLibrary.PhotoSessionExtender.registerClass('ClientLibrary.PhotoSessionExtender', ClientLibrary.PageExtender);
ClientLibrary.PageManager.registerClass('ClientLibrary.PageManager', Sys.Component, ClientLibrary.ILoadableComponent);
ClientLibrary.Utils.registerClass('ClientLibrary.Utils');
ClientLibrary.VideoExtender.registerClass('ClientLibrary.VideoExtender', ClientLibrary.PageExtender);
Jquery.FancyBoxOptions.registerClass('Jquery.FancyBoxOptions');
Jquery.JCarouselConfig.registerClass('Jquery.JCarouselConfig');
Jquery.JPlayerOptions.registerClass('Jquery.JPlayerOptions');
ClientLibrary.AudioPlayer._instance$2 = null;
ClientLibrary.PageManager._instanse$1 = null;

// ---- Do not remove this footer ----
// This script was generated using Script# v0.5.5.0 (http://projects.nikhilk.net/ScriptSharp)
// -----------------------------------
