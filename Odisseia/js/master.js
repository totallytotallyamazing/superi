// JScript File

        function setBackgroundImage(el, src)
        {
            el.style.backgroundImage='url("images/'+ src +'")';
        }


        function switchClass(el, className)
        {
            el.className = className;
        }
        
        function menuDivOut(el)
        {
            el.setAttribute("class", "menuDiv");
            el.className = 'menuDiv';
        }
        
        function menuDivOver(el)
        {
            el.setAttribute("class", "menuDivOver");
            el.className = 'menuDivOver';
        }
        
        function imgMouse(el, src)
        {
            el.src=src;
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
    
    
function getAbsolutePos(el) {
	var SL = 0, ST = 0;
	var is_div = /^div$/i.test(el.tagName);
	if (is_div && el.scrollLeft)
		SL = el.scrollLeft;
	if (is_div && el.scrollTop)
		ST = el.scrollTop;
	//	alert(ST);
	var r = { x: el.offsetLeft - SL, y: el.offsetTop - ST };
    if (el.offsetParent) {
		var tmp = this.getAbsolutePos(el.offsetParent);
		r.x += tmp.x;
		r.y += tmp.y;
	}
	return r;
}

function opacity(id, opacStart, opacEnd, millisec) {
    //speed for each frame
    var speed = Math.round(millisec / 100);
    var timer = 0;

    //determine the direction for the blending, if start and end are the same nothing happens
    if (opacStart > opacEnd) {
        for (i = opacStart; i >= opacEnd; i--) {
            setTimeout("changeOpac(" + i + ",'" + id + "')", (timer * speed));
            timer++;
        }
    } else if (opacStart < opacEnd) {
        for (i = opacStart; i <= opacEnd; i++) {
            setTimeout("changeOpac(" + i + ",'" + id + "')", (timer * speed));
            timer++;
        }
    }
}

//change the opacity for different browsers
function changeOpac(opacity, id) {
    var object = document.getElementById(id).style;
    object.opacity = (opacity / 100);
    object.MozOpacity = (opacity / 100);
    object.KhtmlOpacity = (opacity / 100);
    object.filter = "alpha(opacity=" + opacity + ")";
} 