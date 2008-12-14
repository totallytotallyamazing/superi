var mousePosition = { x: 0, y: 0 }

function getMousePosition(ev){
		   //var pos = { x: 0, y: 0 };
		  
		   if ( ev ) 
		   {
			  if ( typeof(ev.pageX) == 'number' ) //M, O
			  {
				 mousePosition.x = ev.pageX; 
				 mousePosition.y = ev.pageY;
			  }
			  else 
			  	if ( typeof(ev.clientX) == 'number' ) //IE
				{ 
					 mousePosition.x = ev.clientX;
					 mousePosition.y = ev.clientY;
					 if ( document.body && ( document.body.scrollTop || document.body.scrollLeft ) && !( window.opera || window.debug || navigator.vendor == 'KDE' ) )
					 {
						mousePosition.x += document.body.scrollLeft; 
						mousePosition.y += document.body.scrollTop;
					 }
				     else 
					     if ( document.documentElement && ( document.documentElement.scrollTop || document.documentElement.scrollLeft ) && !( window.opera || window.debug || navigator.vendor == 'KDE' ) ) 
						 {
							mousePosition.x += document.documentElement.scrollLeft; 
							mousePosition.y += document.documentElement.scrollTop;
						 }
			    }//if ( typeof(ev.clientX) == 'number' ) 
		   }// if ( ev ) 
   //return pos;
}; //fun