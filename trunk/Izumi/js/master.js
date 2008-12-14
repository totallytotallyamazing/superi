// JScript File

        
        function menuDivOut(el)
        {
            el.style.backgroundImage='';
        }
        
        function displayLangTip(id, text)
        {
            var td = document.getElementById(id);
            td.style.color='white';
            //td.innerHTML = text;
        }
        
        function hideLangTip(id)
        {
            var td = document.getElementById(id);
            td.style.color='#520101';
            //td.innerHTML = '';  
        }
        
        function handle(delta) {
            if (delta < 0)
            {
                speed = 20;
		        movedownWheel();
		        speed=5;
		    }
            else
            {
                speed = 20;
		        moveupWheel();
		        speed=5;
		    }
        }
        
        function wheel(event){
        var delta = 0;
        if (!event) /* For IE. */
                event = window.event;
        if (event.wheelDelta) { /* IE/Opera. */
                delta = event.wheelDelta/120;
                /** In Opera 9, delta differs in sign as compared to IE.
                 */
                if (window.opera)
                        delta = delta;
        } else if (event.detail) { /** Mozilla case. */
                /** In Mozilla, sign of delta is different than in IE.
                 * Also, delta is multiple of 3.
                 */
                delta = -event.detail/3;
        }
        /** If delta is nonzero, handle it.
         * Basically, delta is now positive if wheel was scrolled up,
         * and negative, if wheel was scrolled down.
         */
        if (delta)
                handle(delta);
        /** Prevent default actions caused by mouse wheel.
         * That might be ugly, but we handle scrolls somehow
         * anyway, so don't bother here..
         */
        if (event.preventDefault)
                event.preventDefault();
	event.returnValue = false;
    }
    
    function ccOver()
    {
        var contentContainer = document.getElementById('contentContainer');
        if (contentContainer.addEventListener)
        /** DOMMouseScroll is for mozilla. */
        contentContainer.addEventListener('DOMMouseScroll', wheel, false);
        /** IE/Opera. */
        contentContainer.onmousewheel = document.onmousewheel = wheel;
    }
    
    function ccOut()
    {
        var contentContainer = document.getElementById('contentContainer');
        if (contentContainer.addEventListener)
        /** DOMMouseScroll is for mozilla. */
        contentContainer.removeEventListener('DOMMouseScroll', wheel, false);
        /** IE/Opera. */
        contentContainer.onmousewheel = document.onmousewheel = null;
    }