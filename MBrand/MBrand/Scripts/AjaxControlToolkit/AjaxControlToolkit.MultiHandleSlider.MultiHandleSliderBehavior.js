﻿Type.registerNamespace("AjaxControlToolkit");AjaxControlToolkit._MultiHandleSliderDragDropInternal=function(){AjaxControlToolkit._MultiHandleSliderDragDropInternal.initializeBase(this);this._instance=null};AjaxControlToolkit._MultiHandleSliderDragDropInternal.prototype={_getInstance:function(){var a=this;a._instance=new AjaxControlToolkit.GenericDragDropManager;a._instance.initialize();a._instance.add_dragStart(Function.createDelegate(a,a._raiseDragStart));a._instance.add_dragStop(Function.createDelegate(a,a._raiseDragStop));return a._instance}};AjaxControlToolkit._MultiHandleSliderDragDropInternal.registerClass("AjaxControlToolkit._MultiHandleSliderDragDropInternal",AjaxControlToolkit._DragDropManager);AjaxControlToolkit.DragDrop=new AjaxControlToolkit._MultiHandleSliderDragDropInternal;AjaxControlToolkit.MultiHandleInnerRailStyle=function(){};AjaxControlToolkit.MultiHandleInnerRailStyle.prototype={AsIs:0,SlidingDoors:1};AjaxControlToolkit.MultiHandleInnerRailStyle.registerEnum("AjaxControlToolkit.MultiHandleInnerRailStyle",false);AjaxControlToolkit.SliderOrientation=function(){};AjaxControlToolkit.SliderOrientation.prototype={Horizontal:0,Vertical:1};AjaxControlToolkit.SliderOrientation.registerEnum("AjaxControlToolkit.SliderOrientation",false);AjaxControlToolkit.MultiHandleSliderBehavior=function(e){var d=true,c=false,b=null,a=this;AjaxControlToolkit.MultiHandleSliderBehavior.initializeBase(a,[e]);a._minimum=b;a._maximum=b;a._orientation=AjaxControlToolkit.SliderOrientation.Horizontal;a._cssClass=b;a._multiHandleSliderTargets=b;a._length=150;a._steps=0;a._enableHandleAnimation=c;a._showInnerRail=c;a._showHoverStyle=c;a._showDragStyle=c;a._raiseChangeOnlyOnMouseUp=d;a._innerRailStyle=AjaxControlToolkit.MultiHandleInnerRailStyle.AsIs;a._enableInnerRangeDrag=c;a._enableRailClick=d;a._isReadOnly=c;a._increment=1;a._enableKeyboard=d;a._enableMouseWheel=d;a._tooltipText="";a._boundControlID=b;a._handleCssClass=b;a._handleImageUrl=b;a._handleImage=b;a._railCssClass=b;a._decimals=0;a._textBox=b;a._wrapper=b;a._outer=b;a._inner=b;a._handleData=b;a._handleAnimationDuration=.02;a._handles=0;a._innerDragFlag=c;a._isVertical=c;a._selectStartHandler=b;a._mouseUpHandler=b;a._mouseOutHandler=b;a._keyDownHandler=b;a._mouseWheelHandler=b;a._mouseOverHandler=b;a._animationPending=c;a._selectStartPending=c;a._initialized=c;a._handleUnderDrag=b;a._innerDrag=c;a._blockInnerClick=c};AjaxControlToolkit.MultiHandleSliderBehavior.prototype={initialize:function(){var a=this;AjaxControlToolkit.MultiHandleSliderBehavior.callBaseMethod(a,"initialize");if(a._boundControlID&&!a._multiHandleSliderTargets)a._multiHandleSliderTargets=[{ControlID:a._boundControlID,HandleCssClass:a._handleCssClass,HandleImageUrl:a._handleImageUrl,Decimals:a._decimals}];a._handles=a._multiHandleSliderTargets?a._multiHandleSliderTargets.length:0;if(a._handles===0){var b=document.createElement("INPUT");b.id="boundless";b.style.display="none";b.value=a.get_minimum();document.forms[0].appendChild(b);a._multiHandleSliderTargets=[{ControlID:b.id,HandleCssClass:a._handleCssClass,HandleImageUrl:a._handleImageUrl,Decimals:a._decimals}];a._boundControlID=b.id;a._handles=1}a._isVertical=a._orientation===AjaxControlToolkit.SliderOrientation.Vertical;a._resolveNamingContainer();a._createWrapper();a._createOuterRail();a._createHandles();a._createInnerRail();a._setRailStyles();if(a._length)if(!a._cssClass&&a._innerRailStyle!==AjaxControlToolkit.MultiHandleInnerRailStyle.SlidingDoors)if(a._isVertical)a._outer.style.height=a._length+"px";else a._outer.style.width=a._length+"px";a._build();a._enforceElementPositioning();a._initializeSlider()},dispose:function(){var a=this;a._disposeHandlers();a._disposeMultiHandleSliderTargets();if(a._enableHandleAnimation&&a._handleAnimation)a._handleAnimation.dispose();AjaxControlToolkit.MultiHandleSliderBehavior.callBaseMethod(a,"dispose")},get_SliderInitialized:function(){return this._initialized},getValue:function(b){var a=$get(this._multiHandleSliderTargets[b].ControlID);return a.value},setValue:function(c,d){var a=this,b=$get(a._multiHandleSliderTargets[c].ControlID);if(b){a.beginUpdate();a._setMultiHandleSliderTargetValue(b,a._getNearestStepValue(d));a.endUpdate()}},get_values:function(){var b=[this._handles];for(var a=0;a<this._handles;a++){var c=this._multiHandleSliderTargets[a];b[a]=c.value}return b.join(",")},_build:function(){var a=this;a._textBox=a.get_element();a._textBox.parentNode.insertBefore(a._wrapper,a._textBox);a._wrapper.appendChild(a._outer);if(a._inner&&a._showInnerRail)a._outer.appendChild(a._inner);a._textBox.style.display="none"},_calculateInnerRailOffset:function(c){var a=this,d=a._isVertical?a._inner.style.top:a._inner.style.left,b=a._isVertical?c.offsetY:c.offsetX;b+=parseInt(d,10);return b},_calculateClick:function(a){var b=this,h=b._getOuterBounds(),c=b._handleData[0],g=b._getBoundsInternal(c);c=b._calculateClosestHandle(a);var d=g.width/2,e=h.width-d;a=a<d?d:a>e?e:a;var f=$get(c.multiHandleSliderTargetID);b._calculateMultiHandleSliderTargetValue(f,a,true);$common.tryFireEvent(b.get_element(),"change")},_calculateClosestHandle:function(h){var a=this,c=a._handleData[0],d=[a._handles],k=a._getOuterBounds();for(var b=0;b<a._handles;b++){var e=a._handleData[b],n=a._getBoundsInternal(e),o=a._isVertical?e.offsetTop:n.x-k.x;d[b]=Math.abs(o-h)}var i=d[0];for(b=0;b<a._handles;b++){var l=d[b];if(l<i){e=a._handleData[b];i=l;c=e}}if(a._innerDrag){var j=Array.indexOf(a._handleData,c),g=Sys.UI.DomElement.getLocation(c),m=a._isVertical?g.y:g.x-k.x;if(m>=h+d[j]){var f=a._handleData[j-1];if(f)c=f}}return c},_calculateMultiHandleSliderTargetValue:function(f,w,D){var l=true,a=this,c,j,e=a._minimum,d=a._maximum;if(a._handleUnderDrag&&!f){h=a._handleUnderDrag;f=$get(a._handleUnderDrag.multiHandleSliderTargetID);if(a._innerDrag){var y=Array.indexOf(a._handleData,h);c=a._handleData[y+1];if(!c)c=a._handleData[y-1];j=$get(c.multiHandleSliderTargetID)}}var h=f.Handle,b=f.value;if(b&&!D){if(typeof b!=="number")try{b=parseFloat(b)}catch(H){b=Number.NaN}if(isNaN(b))b=a._minimum;val=Math.max(Math.min(b,d),e)}else{var k=a._getBoundsInternal(h),o=a._getOuterBounds(),p=w?w-k.width/2:k.x-o.x,F=o.width-k.width,E=p/F;val=Math.max(Math.min(b,d),e);val=p===0?e:p===o.width-k.width?d:e+E*(d-e)}if(a._steps>0)val=a._getNearestStepValue(val);val=Math.max(Math.min(val,d),e);var t=[],v=[],n=0,q=0,m,z=l;for(var i=0;i<a._handles;i++){var I=a._multiHandleSliderTargets[i];if(!I.ControlID.match(f.id))if(z){t[n]=a._multiHandleSliderTargets[i];n++}else{v[q]=a._multiHandleSliderTargets[i];q++}else z=false}if(n>0){var B=parseFloat($get(t[n-1].ControlID).value);val=Math.max(val,B);m=val===B}if(q>0){var A=parseFloat($get(v[0].ControlID).value);val=Math.min(val,A);m=val===A}if(c){var G=val-parseFloat(b),u=parseFloat(j.value),g=u+G,x=Array.indexOf(a._handleData,c)+1;if(x<a._multiHandleSliderTargets.length)var r=a._multiHandleSliderTargets[x].ControlID;if(r)var s=$get(r);if(s)var C=s.value;if(g>(C||d)){g=u;val=b;m=l}}if(!m&&(Math.max(val,d)===d&&Math.min(val,e)===e)){a.beginUpdate();val=Math.max(Math.min(val,d),e);a._setMultiHandleSliderTargetValue(f,val);if(c)a._setMultiHandleSliderTargetValue(j,g);a.endUpdate()}else{a.beginUpdate();if(a._handles===1)a._setMultiHandleSliderTargetValue(f,val);else{f.value=val;h.Value=val;a._setHandlePosition(h,l)}if(c){j.value=g;c.Value=g;a._setHandlePosition(c,l)}a.endUpdate()}return val},_cancelDrag:function(){if(AjaxControlToolkit.MultiHandleSliderBehavior.DropPending===this){AjaxControlToolkit.MultiHandleSliderBehavior.DropPending=null;if(this._selectStartPending)$removeHandler(document,"selectstart",this._selectStartHandler)}},_createHandles:function(){var j="handle_horizontal",i="handle_vertical",a=this;for(var b=0;b<a._handles;b++){var p=a.get_id()+"_handle_"+b,g=a._isVertical,d="",e="",f="";if(a._handles===1&&a._handleImageUrl)var m="<img id='"+a.get_id()+"_handleImage' src='"+a._handleImageUrl+"' alt='' />";var o="<a id='"+p+"' ",s=m?m:"",q="><div>"+s+"</div></a>";a._outer.innerHTML+=o+q}a._handleData=[a._handles];for(b=0;b<a._handles;b++){var r=a._cssClass?a._cssClass:"ajax__multi_slider_default",c=a._multiHandleSliderTargets[b].HandleCssClass;if(c||a._cssClass){d=c?c+" ":a._cssClass+" ";e=d;f=d;var l=c,k=c;d=!c?d+a._isVertical?i:j:d+c;e=!k?e+a._isVertical?"handle_vertical_hover":"handle_horizontal_hover":e+k;f=!l?f+a._isVertical?"handle_vertical_down":"handle_horizontal_down":f+l}a._handleCallbacks={mouseover:Function.createCallback(a._onShowHover,{vertical:g,custom:e}),mouseout:Function.createCallback(a._onHideHover,{vertical:g,custom:d}),mousedown:Function.createCallback(a._onShowDrag,{vertical:g,custom:f}),mouseup:Function.createCallback(a._onHideDrag,{vertical:g,custom:d})};a._handleData[b]=a._outer.childNodes[b];a._handleData[b].style.overflow="hidden";$addHandlers(a._handleData[b],a._handleCallbacks);c=a._multiHandleSliderTargets[b].HandleCssClass;if(c){Sys.UI.DomElement.addCssClass(a._handleData[b],r);Sys.UI.DomElement.addCssClass(a._handleData[b],c)}else a._handleData[b].className=a._isVertical?i:j;if(a._multiHandleSliderTargets){var n=a._multiHandleSliderTargets[b].ControlID;a._handleData[b].multiHandleSliderTargetID=n}a._handleData[b].style.left="0px";a._handleData[b].style.top="0px";if(a._steps<1){if(a._enableHandleAnimation){var h=new AjaxControlToolkit.Animation.LengthAnimation(a._handleData[b],a._handleAnimationDuration,100,"style");h.add_ended(Function.createDelegate(a,a._onAnimationEnded));h.add_step(Function.createDelegate(a,a._onAnimationStep));a._handleData[b].Animation=h}}else a._enableHandleAnimation=false}},_createInnerRail:function(){var a=this;if(a._handles>1&&a._showInnerRail){a._inner=document.createElement("DIV");a._inner.id=a.get_id()+"_inner";a._inner.style.outline="none";a._inner.tabIndex=-1}},_createOuterRail:function(){var a=this;a._outer=document.createElement("DIV");a._outer.id=a.get_id()+"_outer";a._outer.style.outline="none";a._outer.tabIndex=-1},_createWrapper:function(){this._wrapper=document.createElement("DIV");this._wrapper.style.position="relative";this._wrapper.style.outline="none"},_disposeHandlers:function(){var b=null,a=this;if(!a._isReadOnly){$removeHandler(document,"mouseup",a._mouseUpHandler);$removeHandler(document,"mouseout",a._mouseOutHandler);if(a._outer){if(a._outer.addEventListener)a._outer.removeEventListener("DOMMouseScroll",a._mouseWheelHandler,false);else a._outer.detachEvent("onmousewheel",a._mouseWheelHandler);$common.removeHandlers(a._outer,a._outerDelegates)}for(var c=0;c<a._handles;c++){if(a._handleDelegates)$common.removeHandlers(a._handleData[c],a._handleDelegates);if(a._handleCallbacks)$clearHandlers(a._handleData[c])}a._handleDelegates=b;a._handleCallbacks=b;if(a._inner&&a._showInnerRail&&a._innerDelegates)$common.removeHandlers(a._inner,a._innerDelegates);a._selectStartHandler=b;a._mouseUpHandler=b;a._mouseOutHandler=b;a._mouseWheelHandler=b;a._mouseOverHandler=b;a._keyDownHandler=b}},_disposeMultiHandleSliderTargets:function(){if(this._multiHandleSliderTargets)for(var b=0;b<this._handles;b++){var a=this._multiHandleSliderTargets[b],c=a&&a.nodeName==="INPUT";if(c){$removeHandler(a,"change",a.ChangeHandler);$removeHandler(a,"keypress",a.KeyPressHandler);a.ChangeHandler=null;a.KeyPressHandler=null}}},_ensureBinding:function(a){if(a){var b=a.value;if(b>=this._minimum||b<=this._maximum){var c=a&&a.nodeName==="INPUT";if(c)a.value=b;else if(a)a.innerHTML=b}}},_enforceElementPositioning:function(){var b=this,a={position:b.get_element().style.position,top:b.get_element().style.top,right:b.get_element().style.right,bottom:b.get_element().style.bottom,left:b.get_element().style.left};if(a.position!=="")b._wrapper.style.position=a.position;if(a.top!=="")b._wrapper.style.top=a.top;if(a.right!=="")b._wrapper.style.right=a.right;if(a.bottom!=="")b._wrapper.style.bottom=a.bottom;if(a.left!=="")b._wrapper.style.left=a.left},_getNearestStepValue:function(b){var a=this;if(a._steps===0)return b;var c=a._maximum-a._minimum;if(c===0)return b;if(a._steps-1!==0)var d=c/(a._steps-1);else return b;return Math.round(b/d)*d},_getStepValues:function(){var a=this,c=[a._steps],e=a._maximum-a._minimum,d=e/(a._steps-1);c[0]=a._minimum;for(var b=1;b<a._steps;b++)c[b]=a._minimum+d*b;return c},_handleSlide:function(b){var a=this,e=b?0:a._handles-1,f=b?1:0,g=b?a._handles:a._handles-1,c=a._handleData[e].multiHandleSliderTargetID;if(a._slideMultiHandleSliderTarget(c,b))for(var d=f;d<g;d++){c=a._handleData[d].multiHandleSliderTargetID;a._slideMultiHandleSliderTarget(c,b)}a._initializeInnerRail()},_initializeDragHandle:function(b){var a=b.DragHandle=document.createElement("DIV");a.style.position="absolute";a.style.width="1px";a.style.height="1px";a.style.overflow="hidden";a.style.background="none";document.forms[0].appendChild(b.DragHandle)},_initializeHandlers:function(){var a=this;if(!a._isReadOnly){a._selectStartHandler=Function.createDelegate(a,a._onSelectStart);a._mouseUpHandler=Function.createDelegate(a,a._onMouseUp);a._mouseOutHandler=Function.createDelegate(a,a._onMouseOut);a._mouseWheelHandler=Function.createDelegate(a,a._onMouseWheel);a._mouseOverHandler=Function.createDelegate(a,a._onMouseOver);a._keyDownHandler=Function.createDelegate(a,a._onKeyDown);$addHandler(document,"mouseup",a._mouseUpHandler);$addHandler(document,"mouseout",a._mouseOutHandler);a._handleDelegates={mousedown:Function.createDelegate(a,a._onMouseDown),dragstart:Function.createDelegate(a,a._IEDragDropHandler),drag:Function.createDelegate(a,a._IEDragDropHandler),dragEnd:Function.createDelegate(a,a._IEDragDropHandler)};for(var b=0;b<a._handles;b++)$addHandlers(a._handleData[b],a._handleDelegates);if(a._outer){if(a._enableMouseWheel)if(a._outer.addEventListener)a._outer.addEventListener("DOMMouseScroll",a._mouseWheelHandler,false);else a._outer.attachEvent("onmousewheel",a._mouseWheelHandler);a._outerDelegates={click:Function.createDelegate(a,a._onOuterRailClick),mouseover:Function.createDelegate(a,a._mouseOverHandler),keydown:Function.createDelegate(a,a._keyDownHandler)};$addHandlers(a._outer,a._outerDelegates)}if(a._inner&&a._showInnerRail){a._innerDelegates={click:Function.createDelegate(a,a._onInnerRailClick),mousedown:Function.createDelegate(a,a._onMouseDownInner),mouseup:Function.createDelegate(a,a._onMouseUpInner),mouseout:Function.createDelegate(a,a._onMouseOutInner),mousemove:Function.createDelegate(a,a._onMouseMoveInner),dragStart:Function.createDelegate(a,a._IEDragDropHandler),drag:Function.createDelegate(a,a._IEDragDropHandler),dragEnd:Function.createDelegate(a,a._IEDragDropHandler)};$addHandlers(a._inner,a._innerDelegates)}}},_initializeHandles:function(){var a=this,e=a.get_ClientState();if(e)var d=e.split(",",a._handles);for(var c=0;c<a._handles;c++){var b=a._handleData[c],f=a._multiHandleSliderTargets[c].Decimals;if(d)b.Value=parseFloat(d[c]);a._initializeMultiHandleSliderTarget(b.multiHandleSliderTargetID,f,b);a._initializeHandleValue(b);a._setHandlePosition(b,true);a._initializeDragHandle(b)}},_initializeHandleValue:function(b){if(!b.Value){try{var a=$get(b.multiHandleSliderTargetID),d=a&&a.nodeName==="INPUT",c=parseFloat(d?a.value:a.innerHTML)}catch(e){c=Number.NaN}if(isNaN(c)){b.Value=this._minimum;if(d)a.value=b.Value;else a.innerHTML=b.Value}else b.Value=c}},_initializeInnerRail:function(){var c="px",a=this;if(a._inner&&a._showInnerRail){var h=0,i=a._handles-1,f=a._handleData[h],e=a._handles>1?a._handleData[i]:null;if(e){var g=parseInt(a._getBoundsInternal(f).width,10),b=parseInt(a._isVertical?f.style.top:f.style.left,10),d=parseInt(a._isVertical?e.style.top:e.style.left,10),j=parseInt(a._multiHandleSliderTargets[h].Offset,10),k=parseInt(a._multiHandleSliderTargets[i].Offset,10);b+=j;d+=k;if(a._isVertical){a._inner.style.top=b+c;a._inner.style.height=d+g-b+c}else{a._inner.style.left=b+c;a._inner.style.width=d+g-b+c}if(a._innerRailStyle===AjaxControlToolkit.MultiHandleInnerRailStyle.SlidingDoors)a._inner.style.backgroundPosition=a._isVertical?"0 -"+b+c:"-"+b+"px 0"}}},_initializeMultiHandleSliderTarget:function(d,e,c){var b=this;if(d){var a=$get(d);if(c.Value)a.value=c.Value;a.Handle=c;a.Decimals=e;a.OldValue=a.value;a.onchange="setValue(this, "+a.value+")";if(!a.Decimals)a.Decimals=0;var f=a&&a.nodeName==="INPUT";if(f){a.KeyPressHandler=Function.createDelegate(b,b._onMultiHandleSliderTargetKeyPressed);a.ChangeHandler=Function.createDelegate(b,b._onMultiHandleSliderTargetChange);$addHandler(a,"keypress",a.KeyPressHandler);$addHandler(a,"change",a.ChangeHandler)}}},_initializeSlider:function(){var a=this;AjaxControlToolkit.DragDrop.registerDropTarget(a);a._initializeHandles();a._initializeHandlers();a._initializeInnerRail();a._initialized=true;a._raiseEvent("load")},_resetDragHandle:function(b){var a=$common.getBounds(b);$common.setLocation(b.DragHandle,{x:a.x,y:a.y})},_resolveNamingContainer:function(){var a=this;if(a._multiHandleSliderTargets&&!a._boundControlID){var c=a._clientStateFieldID.lastIndexOf(a._id),d=a._clientStateFieldID.substring(0,c);for(var b=0;b<a._handles;b++)a._multiHandleSliderTargets[b].ControlID=d+a._multiHandleSliderTargets[b].ControlID}},_saveState:function(){var a=this,c=[a._handles];for(var b=0;b<a._handles;b++)c[b]=$get(a._multiHandleSliderTargets[b].ControlID).value;a.set_ClientState(c.join(","))},_setHandlePosition:function(b,k){var f="width",a=this,h=a._minimum,j=a._maximum,g=b.Value,m=a._enableHandleAnimation&&a._animationPending&&k,c=a._getBoundsInternal(b),d=a._getOuterBounds();if(c.width<=0&&d.width<=0){c.width=parseInt($common.getCurrentStyle(b,f),10);d.width=parseInt($common.getCurrentStyle(a._outer,f),10);if(c.width<=0||d.width<=0)throw Error.argument(f,AjaxControlToolkit.Resources.MultiHandleSlider_CssHeightWidthRequired)}var n=j-h,l=(g-h)/n,e=Math.round(l*(d.width-c.width)),i=g===h?0:g===j?d.width-c.width:e;if(m){b.Animation.set_startValue(c.x-d.x);b.Animation.set_endValue(i);b.Animation.set_propertyKey(a._isVertical?"top":"left");b.Animation.play();a._animationPending=false}else{e=i+"px";if(a._isVertical)b.style.top=e;else b.style.left=e}},_setRailStyles:function(){var e="inner_rail_horizontal",d="inner_rail_vertical",a=this;if(!a._inner&&a._railCssClass){a._outer.className=a._railCssClass;return}var b=a._cssClass?a._cssClass:"ajax__multi_slider_default";Sys.UI.DomElement.addCssClass(a.get_element(),b);Sys.UI.DomElement.addCssClass(a._outer,b);Sys.UI.DomElement.addCssClass(a._wrapper,b);if(a._inner){Sys.UI.DomElement.addCssClass(a._inner,b);var c=a._isVertical?"outer_rail_vertical":"outer_rail_horizontal",f=a._isVertical?d:e;Sys.UI.DomElement.addCssClass(a._outer,c);Sys.UI.DomElement.addCssClass(a._inner,f)}else{c=a._isVertical?d:e;Sys.UI.DomElement.addCssClass(a._outer,c)}},_setMultiHandleSliderTargetValue:function(b,f){var a=this,d=b.OldValue,c=f;if(d===c&&a._isReadOnly)b.value=d;else{if(!a.get_isUpdating())c=a._calculateMultiHandleSliderTargetValue(b);b.value=c.toFixed(b.Decimals);a._ensureBinding(b);if(!Number.isInstanceOfType(b.value))try{b.value=parseFloat(b.value)}catch(g){b.value=Number.NaN}if(a._tooltipText){var e=b.Handle;e.alt=e.title=String.format(a._tooltipText,b.value)}if(a._initialized){b.Handle.Value=c;a._setHandlePosition(b.Handle,true);if(a._handles===1)a.get_element().value=c;if(b.value!==d){b.OldValue=b.value;a._initializeInnerRail();if(a._innerDrag)a._blockInnerClick=true;a._raiseEvent("valueChanged");if(a.get_isUpdating())if(!a._raiseChangeOnlyOnMouseUp)$common.tryFireEvent(a.get_element(),"change")}}}a._saveState()},_setValueFromMultiHandleSliderTarget:function(b){var a=this;a.beginUpdate();if(b)if(!a._isReadOnly){if(a._handles===1&&a._steps>0)a._setMultiHandleSliderTargetValue(b,b.value);a._calculateMultiHandleSliderTargetValue(b)}else a._setMultiHandleSliderTargetValue(b,b.OldValue);a.endUpdate()},_slideMultiHandleSliderTarget:function(i,g){var b=this,d=$get(i),j=d.value,c,a;if(b._steps>0){var e=b._getStepValues(),f=b._getNearestStepValue(j);c=f;if(g){for(a=b._steps-1;a>-1;a--)if(e[a]<f){c=e[a];break}}else for(a=0;a<b._steps;a++)if(e[a]>f){c=e[a];break}}else{var h=parseFloat(d.value);c=g?h-parseFloat(b._increment):h+parseFloat(b._increment)}d.value=c;b._setValueFromMultiHandleSliderTarget(d);return d.value==c},_startDragDrop:function(a){this._resetDragHandle(a);this._handleUnderDrag=a;AjaxControlToolkit.DragDrop.startDragDrop(this,a.DragHandle,null)},_onAnimationEnded:function(){this._initializeInnerRail()},_onAnimationStep:function(){this._initializeInnerRail()},_onHideDrag:function(b,a){this.className=a.custom&&a.custom.length>0?a.custom:a.vertical?"handle_vertical":"handle_horizontal"},_onHideHover:function(b,a){this.className=a.custom&&a.custom.length>0?a.custom:a.vertical?"ajax__multi_slider_default handle_vertical":"ajax__multi_slider_default handle_horizontal"},_onInnerRailClick:function(b){var a=this;if(a._enableRailClick){var c=b.target;if(c===a._inner&&!a._blockInnerClick){a._animationPending=true;a._onInnerRailClicked(b)}else a._blockInnerClick=false}},_onInnerRailClicked:function(b){var a=this._calculateInnerRailOffset(b);this._calculateClick(a)},_onKeyDown:function(d){var a=false;if(this._enableKeyboard){var c=new Sys.UI.DomEvent(d),b=a;switch(c.keyCode||c.rawEvent.keyCode){case Sys.UI.Key.up:case Sys.UI.Key.left:if(!b){this._handleSlide(true);c.preventDefault();b=true}return a;case Sys.UI.Key.down:case Sys.UI.Key.right:if(!b){this._handleSlide(a);c.preventDefault();b=true}return a;default:return a}}},_onMouseOver:function(){this._outer.focus()},_onMouseWheel:function(b){var a=0;if(b.wheelDelta){a=b.wheelDelta/120;if(Sys.Browser.agent===Sys.Browser.Opera)a=-a}else if(b.detail)a=-b.detail/3;if(a)this._handleSlide(a<=0);if(b.preventDefault)b.preventDefault();return false},_onMouseUp:function(a){window._event=a;a.preventDefault();this._cancelDrag()},_onMouseOut:function(a){window._event=a;a.preventDefault();this._outer.blur();if(this._handleUnderDrag)this._cancelDrag()},_onMouseOutInner:function(a){window._event=a;a.preventDefault();this._inner.blur();if(this._innerDrag)this._cancelDrag()},_onMouseDown:function(b){var a=this;window._event=b;b.preventDefault();if(!AjaxControlToolkit.MultiHandleSliderBehavior.DropPending){AjaxControlToolkit.MultiHandleSliderBehavior.DropPending=a;$addHandler(document,"selectstart",a._selectStartHandler);a._selectStartPending=true;var c=b.target;a._startDragDrop(c)}},_onMouseDownInner:function(a){window._event=a;a.preventDefault();if(this._enableInnerRangeDrag)if(!this._innerDragFlag)this._innerDragFlag=true},_onMouseUpInner:function(){if(this._enableInnerRangeDrag)this._innerDragFlag=false},_onMouseMoveInner:function(b){var a=this;window._event=b;b.preventDefault();if(a._enableInnerRangeDrag)if(!a._innerDrag&&a._innerDragFlag){a._innerDragFlag=false;if(!AjaxControlToolkit.MultiHandleSliderBehavior.DropPending){AjaxControlToolkit.MultiHandleSliderBehavior.DropPending=a;$addHandler(document,"selectstart",a._selectStartHandler);a._selectStartPending=true;a._innerDrag=true;var d=a._calculateInnerRailOffset(b),c=a._calculateClosestHandle(d);a._startDragDrop(c)}}},_onMultiHandleSliderTargetChange:function(a){this._animationPending=true;var b=a.target;this._setValueFromMultiHandleSliderTarget(b);this._initializeInnerRail();a.preventDefault()},_onMultiHandleSliderTargetKeyPressed:function(c){var a=new Sys.UI.DomEvent(c);if(a.charCode===13){this._animationPending=true;var b=a.target;this._setValueFromMultiHandleSliderTarget(b);this._initializeInnerRail();a.preventDefault()}},_onOuterRailClick:function(b){var a=this;if(a._enableRailClick){var c=b.target;if(c===a._outer){a._animationPending=true;a._onOuterRailClicked(b)}}},_onOuterRailClicked:function(a){var b=this._isVertical?a.offsetY:a.offsetX;this._calculateClick(b)},_onShowDrag:function(b,a){this.className=a.custom&&a.custom.length>0?a.custom:a.vertical?"ajax__multi_slider_default handle_vertical_down":"ajax__multi_slider_default handle_horizontal_down"},_onShowHover:function(b,a){this.className=a.custom&&a.custom.length>0?a.custom:a.vertical?"ajax__multi_slider_default handle_vertical_hover":"ajax__multi_slider_default handle_horizontal_hover"},get_dragDataType:function(){return "HTML"},getDragData:function(){return this._handleUnderDrag},get_dragMode:function(){return AjaxControlToolkit.DragMode.Move},onDragStart:function(){this._resetDragHandle(this._handleUnderDrag);this._raiseEvent("dragStart")},onDrag:function(){var a=this,c=a._getBoundsInternal(a._handleUnderDrag.DragHandle),e=a._getBoundsInternal(a._handleUnderDrag),d=a._getOuterBounds(),b;if(a._isVertical)b={y:c.x-d.x,x:0};else b={x:c.x-d.x,y:0};$common.setLocation(a._handleUnderDrag,b);a._calculateMultiHandleSliderTargetValue(null,null,true);if(a._steps>1)a._setHandlePosition(a._handleUnderDrag,false);a._raiseEvent("drag")},onDragEnd:function(){var a=this;a._initializeInnerRail();if(a._raiseChangeOnlyOnMouseUp)$common.tryFireEvent(a.get_element(),"change");a._innerDrag=false;a._handleUnderDrag=null;a._raiseEvent("dragEnd")},get_dropTargetElement:function(){return document.forms[0]},canDrop:function(b,a){return a=="HTML"},drop:Function.emptyMethod,onDragEnterTarget:Function.emptyMethod,onDragLeaveTarget:Function.emptyMethod,onDragInTarget:Function.emptyMethod,_IEDragDropHandler:function(a){a.preventDefault()},_onSelectStart:function(a){a.preventDefault();return false},_getOuterBounds:function(){return this._getBoundsInternal(this._outer)},_getInnerBounds:function(){return this._getBoundsInternal(this._inner)},_getBoundsInternal:function(b){var a=$common.getBounds(b);if(this._isVertical)a={x:a.y,y:a.x,height:a.width,width:a.height,right:a.right,left:a.left,bottom:a.bottom,location:{x:a.y,y:a.x},size:{width:a.height,height:a.width}};else a={x:a.x,y:a.y,height:a.height,width:a.width,right:a.right,left:a.left,bottom:a.bottom,location:{x:a.x,y:a.y},size:{width:a.width,height:a.height}};return a},_raiseEvent:function(c,a){var b=this.get_events().getHandler(c);if(b){if(!a)a=Sys.EventArgs.Empty;b(this,a)}},get_Value:function(){var a=$get(this._boundControlID);return a.value?a.value:0},set_Value:function(c){var a=this,b=$get(a._multiHandleSliderTargets[0].ControlID);a.beginUpdate();a._setMultiHandleSliderTargetValue(b,a._getNearestStepValue(c));a.endUpdate();$common.tryFireEvent(b,"change")},get_minimum:function(){return this._minimum},set_minimum:function(a){if(a!==this._minimum){this._minimum=a;this.raisePropertyChanged("minimum")}},get_maximum:function(){return this._maximum},set_maximum:function(a){if(a!==this._maximum){this._maximum=a;this.raisePropertyChanged("maximum")}},get_length:function(){return this._length},set_length:function(a){if(a!==this._length){this._length=a;this.raisePropertyChanged("length")}},get_steps:function(){return this._steps},set_steps:function(c){var a=this,b=a._steps;a._steps=Math.abs(c);a._steps=a._steps===1?2:a._steps;if(b!==a._steps)a.raisePropertyChanged("steps")},get_orientation:function(){return this._isVertical},set_orientation:function(a){if(a!==this._isVertical){this._orientation=a;this.raisePropertyChanged("orientation")}},get_enableHandleAnimation:function(){return this._enableHandleAnimation},set_enableHandleAnimation:function(a){if(a!==this._enableHandleAnimation){this._enableHandleAnimation=a;this.raisePropertyChanged("enableHandleAnimation")}},get_handleAnimationDuration:function(){return this._handleAnimationDuration},set_handleAnimationDuration:function(a){if(a!==this._handleAnimationDuration){this._handleAnimationDuration=a;this.raisePropertyChanged("handleAnimationDuration")}},get_raiseChangeOnlyOnMouseUp:function(){return this._raiseChangeOnlyOnMouseUp},set_raiseChangeOnlyOnMouseUp:function(a){if(a!==this._raiseChangeOnlyOnMouseUp){this._raiseChangeOnlyOnMouseUp=a;this.raisePropertyChanged("raiseChangeOnlyOnMouseUp")}},get_showInnerRail:function(){return this._showInnerRail},set_showInnerRail:function(a){if(a!==this._showInnerRail){this._showInnerRail=a;this.raisePropertyChanged("showInnerRail")}},get_showHandleHoverStyle:function(){return this._showHoverStyle},set_showHandleHoverStyle:function(a){if(a!==this._showHoverStyle){this._showHoverStyle=a;this.raisePropertyChanged("showHoverStyle")}},get_showHandleDragStyle:function(){return this._showDragStyle},set_showHandleDragStyle:function(a){if(a!==this._showDragStyle){this._showDragStyle=a;this.raisePropertyChanged("showDragStyle")}},get_innerRailStyle:function(){return this._innerRailStyle},set_innerRailStyle:function(a){if(a!==this._innerRailStyle){this._innerRailStyle=a;this.raisePropertyChanged("innerRailStyle")}},get_enableInnerRangeDrag:function(){return this._enableInnerRangeDrag},set_enableInnerRangeDrag:function(a){if(a!==this._enableInnerRangeDrag){this._enableInnerRangeDrag=a;this.raisePropertyChanged("allowInnerRangeDrag")}},get_enableRailClick:function(){return this._enableRailClick},set_enableRailClick:function(a){if(a!==this._enableRailClick){this._enableRailClick=a;this.raisePropertyChanged("allowRailClick")}},get_isReadOnly:function(){return this._isReadOnly},set_isReadOnly:function(a){if(a!==this._isReadOnly){this._isReadOnly=a;this.raisePropertyChanged("isReadOnly")}},get_enableKeyboard:function(){return this._enableKeyboard},set_enableKeyboard:function(a){if(a!==this._enableKeyboard){this._enableKeyboard=a;this.raisePropertyChanged("enableKeyboard")}},get_enableMouseWheel:function(){return this._enableMouseWheel},set_enableMouseWheel:function(a){if(a!==this._enableMouseWheel){this._enableMouseWheel=a;this.raisePropertyChanged("enableMouseWheel")}},get_increment:function(){return this._increment},set_increment:function(a){if(a!==this._increment){this._increment=a;this.raisePropertyChanged("increment")}},get_tooltipText:function(){return this._tooltipText},set_tooltipText:function(a){if(a!==this._tooltipText){this._tooltipText=a;this.raisePropertyChanged("tooltipText")}},get_multiHandleSliderTargets:function(){return this._multiHandleSliderTargets},set_multiHandleSliderTargets:function(a){if(a!==this._multiHandleSliderTargets){this._multiHandleSliderTargets=a;this.raisePropertyChanged("multiHandleSliderTargets")}},get_cssClass:function(){return this._cssClass},set_cssClass:function(a){if(a!==this._cssClass){this._cssClass=a;this.raisePropertyChanged("cssClass")}},get_boundControlID:function(){return this._boundControlID},set_boundControlID:function(b){var a=this;a._boundControlID=b;if(a._boundControlID)a._boundControl=$get(a._boundControlID);else a._boundControl=null},get_handleCssClass:function(){return this._handleCssClass},set_handleCssClass:function(a){this._handleCssClass=a},get_handleImageUrl:function(){return this._handleImageUrl},set_handleImageUrl:function(a){this._handleImageUrl=a},get_railCssClass:function(){return this._railCssClass},set_railCssClass:function(a){this._railCssClass=a},get_decimals:function(){return this._decimals},set_decimals:function(a){this._decimals=a},add_load:function(a){this.get_events().addHandler("load",a)},remove_load:function(a){this.get_events().removeHandler("load",a)},add_dragStart:function(a){this.get_events().addHandler("dragStart",a)},remove_dragStart:function(a){this.get_events().removeHandler("dragStart",a)},add_drag:function(a){this.get_events().addHandler("drag",a)},remove_drag:function(a){this.get_events().removeHandler("drag",a)},add_dragEnd:function(a){this.get_events().addHandler("dragEnd",a)},remove_dragEnd:function(a){this.get_events().removeHandler("dragEnd",a)},add_valueChanged:function(a){this.get_events().addHandler("valueChanged",a)},remove_valueChanged:function(a){this.get_events().removeHandler("valueChanged",a)}};AjaxControlToolkit.MultiHandleSliderBehavior.DropPending=null;AjaxControlToolkit.MultiHandleSliderBehavior.registerClass("AjaxControlToolkit.MultiHandleSliderBehavior",AjaxControlToolkit.BehaviorBase);
if(typeof(Sys)!=='undefined')Sys.Application.notifyScriptLoaded();