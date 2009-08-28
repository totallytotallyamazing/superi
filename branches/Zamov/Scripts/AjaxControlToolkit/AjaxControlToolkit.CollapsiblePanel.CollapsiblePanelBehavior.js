﻿Type.registerNamespace("AjaxControlToolkit");AjaxControlToolkit.CollapsiblePanelExpandDirection=function(){throw Error.invalidOperation()};AjaxControlToolkit.CollapsiblePanelExpandDirection.prototype={Horizontal:0,Vertical:1};AjaxControlToolkit.CollapsiblePanelExpandDirection.registerEnum("AjaxControlToolkit.CollapsiblePanelExpandDirection",false);AjaxControlToolkit.CollapsiblePanelBehavior=function(c){var b=null,a=this;AjaxControlToolkit.CollapsiblePanelBehavior.initializeBase(a,[c]);a._collapsedSize=0;a._expandedSize=0;a._scrollContents=b;a._collapsed=false;a._expandControlID=b;a._collapseControlID=b;a._textLabelID=b;a._collapsedText=b;a._expandedText=b;a._imageControlID=b;a._expandedImage=b;a._collapsedImage=b;a._suppressPostBack=b;a._autoExpand=b;a._autoCollapse=b;a._expandDirection=AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical;a._collapseClickHandler=b;a._expandClickHandler=b;a._panelMouseEnterHandler=b;a._panelMouseLeaveHandler=b;a._childDiv=b;a._animation=b};AjaxControlToolkit.CollapsiblePanelBehavior.prototype={initialize:function(){var g="SuppressPostBack",a=this;AjaxControlToolkit.CollapsiblePanelBehavior.callBaseMethod(a,"initialize");var b=a.get_element();a._animation=new AjaxControlToolkit.Animation.LengthAnimation(b,.25,10,"style",null,0,0,"px");if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical)a._animation.set_propertyKey("height");else if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Horizontal)a._animation.set_propertyKey("width");a._animation.add_ended(Function.createDelegate(a,a._onAnimateComplete));if(a._suppressPostBack==null)if(b.tagName=="INPUT"&&b.type=="checkbox"){a._suppressPostBack=false;a.raisePropertyChanged(g)}else if(b.tagName=="A"){a._suppressPostBack=true;a.raisePropertyChanged(g)}var c=AjaxControlToolkit.CollapsiblePanelBehavior.callBaseMethod(a,"get_ClientState");if(c&&c!=""){var f=Boolean.parse(c);if(a._collapsed!=f){a._collapsed=f;a.raisePropertyChanged("Collapsed")}}a._setupChildDiv();if(a._collapsed)a._setTargetSize(a._getCollapsedSize());else a._setTargetSize(a._getExpandedSize());a._setupState(a._collapsed);if(a._collapseControlID==a._expandControlID){a._collapseClickHandler=Function.createDelegate(a,a.togglePanel);a._expandClickHandler=null}else{a._collapseClickHandler=Function.createDelegate(a,a.collapsePanel);a._expandClickHandler=Function.createDelegate(a,a.expandPanel)}if(a._autoExpand){a._panelMouseEnterHandler=Function.createDelegate(a,a._onMouseEnter);$addHandler(b,"mouseover",a._panelMouseEnterHandler)}if(a._autoCollapse){a._panelMouseLeaveHandler=Function.createDelegate(a,a._onMouseLeave);$addHandler(b,"mouseout",a._panelMouseLeaveHandler)}if(a._collapseControlID){var d=$get(a._collapseControlID);if(!d)throw Error.argument("CollapseControlID",String.format(AjaxControlToolkit.Resources.CollapsiblePanel_NoControlID,a._collapseControlID));else $addHandler(d,"click",a._collapseClickHandler)}if(a._expandControlID)if(a._expandClickHandler){var e=$get(a._expandControlID);if(!e)throw Error.argument("ExpandControlID",String.format(AjaxControlToolkit.Resources.CollapsiblePanel_NoControlID,a._expandControlID));else $addHandler(e,"click",a._expandClickHandler)}},dispose:function(){var b=null,a=this,e=a.get_element();if(a._collapseClickHandler){var c=a._collapseControlID?$get(a._collapseControlID):b;if(c)$removeHandler(c,"click",a._collapseClickHandler);a._collapseClickHandler=b}if(a._expandClickHandler){var d=a._expandControlID?$get(a._expandControlID):b;if(d)$removeHandler(d,"click",a._expandClickHandler);a._expandClickHandler=b}if(a._panelMouseEnterHandler)$removeHandler(e,"mouseover",a._panelMouseEnterHandler);if(a._panelMouseLeaveHandler)$removeHandler(e,"mouseout",a._panelMouseLeaveHandler);if(a._animation){a._animation.dispose();a._animation=b}AjaxControlToolkit.CollapsiblePanelBehavior.callBaseMethod(a,"dispose")},togglePanel:function(a){this._toggle(a)},expandPanel:function(a){this._doOpen(a)},collapsePanel:function(a){this._doClose(a)},_checkCollapseHide:function(){if(this._collapsed&&this._getTargetSize()==0){var a=this.get_element(),b=$common.getCurrentStyle(a,"display");if(!a.oldDisplay&&b!="none"){a.oldDisplay=b;a.style.display="none"}return true}return false},_doClose:function(b){var a=this,c=new Sys.CancelEventArgs;a.raiseCollapsing(c);if(c.get_cancel())return;if(a._animation){a._animation.stop();a._animation.set_startValue(a._getTargetSize());a._animation.set_endValue(a._getCollapsedSize());a._animation.play()}a._setupState(true);if(a._suppressPostBack)if(b&&b.preventDefault)b.preventDefault();else{if(event)event.returnValue=false;return false}},_doOpen:function(d){var c="display",a=this,e=new Sys.CancelEventArgs;a.raiseExpanding(e);if(e.get_cancel())return;if(a._animation){a._animation.stop();var b=a.get_element();if(a._checkCollapseHide()&&$common.getCurrentStyle(b,c,b.style.display)){if(b.oldDisplay)b.style.display=b.oldDisplay;else if(b.style.removeAttribute)b.style.removeAttribute(c);else b.style.removeProperty(c);b.oldDisplay=null}a._animation.set_startValue(a._getTargetSize());a._animation.set_endValue(a._getExpandedSize());a._animation.play()}a._setupState(false);if(a._suppressPostBack)if(d&&d.preventDefault)d.preventDefault();else{if(event)event.returnValue=false;return false}},_onAnimateComplete:function(){var a=this,b=a.get_element();if(!a._collapsed&&!a._expandedSize)if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical)if(a._childDiv.offsetHeight<=b.offsetHeight){b.style.height="auto";a.raisePropertyChanged("TargetHeight")}else a._checkCollapseHide();else if(a._childDiv.offsetWidth<=b.offsetWidth){b.style.width="auto";a.raisePropertyChanged("TargetWidth")}else a._checkCollapseHide();else a._checkCollapseHide();if(a._collapsed){a.raiseCollapseComplete();a.raiseCollapsed(Sys.EventArgs.Empty)}else{a.raiseExpandComplete();a.raiseExpanded(new Sys.EventArgs)}},_onMouseEnter:function(a){if(this._autoExpand)this.expandPanel(a)},_onMouseLeave:function(a){if(this._autoCollapse)this.collapsePanel(a)},_getExpandedSize:function(){var a=this;if(a._expandedSize)return a._expandedSize;if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical)return a._childDiv.offsetHeight;else if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Horizontal)return a._childDiv.offsetWidth},_getCollapsedSize:function(){if(this._collapsedSize)return this._collapsedSize;return 0},_getTargetSize:function(){var b=this,a;if(b._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical)a=b.get_TargetHeight();else if(b._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Horizontal)a=b.get_TargetWidth();if(a===undefined)a=0;return a},_setTargetSize:function(b){var a=this,d=a._collapsed||a._expandedSize,c=a.get_element();if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical)if(d||b<c.offsetHeight)a.set_TargetHeight(b);else{c.style.height="auto";a.raisePropertyChanged("TargetHeight")}else if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Horizontal)if(d||b<c.offsetWidth)a.set_TargetWidth(b);else{c.style.width="auto";a.raisePropertyChanged("TargetWidth")}a._checkCollapseHide()},_setupChildDiv:function(){var f="px",d="auto",h="hidden",g="scroll",c="",a=this,e=a._getTargetSize(),b=a.get_element();a._childDiv=b.cloneNode(false);a._childDiv.id=c;a._childDiv.style.visibility="visible";while(b.hasChildNodes()){var i=b.childNodes[0];i=b.removeChild(i);a._childDiv.appendChild(i)}b.style.padding=c;b.style.border=c;if(a._scrollContents){if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical){b.style.overflowY=g;a._childDiv.style.overflowY=c}else{b.style.overflowX=g;a._childDiv.style.overflowX=c}if(Sys.Browser.agent==Sys.Browser.Safari||Sys.Browser.agent==Sys.Browser.Opera){b.style.overflow=g;a._childDiv.style.overflow=c}}else{if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical){b.style.overflowY=h;a._childDiv.style.overflowY=c}else{b.style.overflowX=h;a._childDiv.style.overflowX=c}if(Sys.Browser.Agent==Sys.Browser.Safari||Sys.Browser.Agent==Sys.Browser.Opera){b.style.overflow=h;a._childDiv.style.overflow=c}}a._childDiv.style.position=c;a._childDiv.style.margin=c;if(e==a._collapsedSize)if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical)a._childDiv.style.height=d;else if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Horizontal)a._childDiv.style.width=d;b.appendChild(a._childDiv);b.style.visibility="visible";if(a._collapsed)e=a._getCollapsedSize();else e=a._getExpandedSize();if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical){b.style.height=e+f;if(!a._expandedSize)b.style.height=d;else b.style.height=a._expandedSize+f;a._childDiv.style.height=d}else if(a._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Horizontal){b.style.width=e+f;if(!a._expandedSize)b.style.width=d;else b.style.width=a._expandedSize+f;a._childDiv.style.width=d}},_setupState:function(d){var a=this;if(d){if(a._textLabelID&&a._collapsedText){var c=$get(a._textLabelID);if(c)c.innerHTML=a._collapsedText}if(a._imageControlID&&a._collapsedImage){var b=$get(a._imageControlID);if(b&&b.src){b.src=a._collapsedImage;if(a._expandedText||a._collapsedText)b.title=a._collapsedText}}}else{if(a._textLabelID&&a._expandedText){var c=$get(a._textLabelID);if(c)c.innerHTML=a._expandedText}if(a._imageControlID&&a._expandedImage){var b=$get(a._imageControlID);if(b&&b.src){b.src=a._expandedImage;if(a._expandedText||a._collapsedText)b.title=a._expandedText}}}if(a._collapsed!=d){a._collapsed=d;a.raisePropertyChanged("Collapsed")}AjaxControlToolkit.CollapsiblePanelBehavior.callBaseMethod(a,"set_ClientState",[a._collapsed.toString()])},_toggle:function(a){if(this.get_Collapsed())return this.expandPanel(a);else return this.collapsePanel(a)},add_collapsing:function(a){this.get_events().addHandler("collapsing",a)},remove_collapsing:function(a){this.get_events().removeHandler("collapsing",a)},raiseCollapsing:function(b){var a=this.get_events().getHandler("collapsing");if(a)a(this,b)},add_collapsed:function(a){this.get_events().addHandler("collapsed",a)},remove_collapsed:function(a){this.get_events().removeHandler("collapsed",a)},raiseCollapsed:function(b){var a=this.get_events().getHandler("collapsed");if(a)a(this,b)},add_collapseComplete:function(a){this.get_events().addHandler("collapseComplete",a)},remove_collapseComplete:function(a){this.get_events().removeHandler("collapseComplete",a)},raiseCollapseComplete:function(){var a=this.get_events().getHandler("collapseComplete");if(a)a(this,Sys.EventArgs.Empty)},add_expanding:function(a){this.get_events().addHandler("expanding",a)},remove_expanding:function(a){this.get_events().removeHandler("expanding",a)},raiseExpanding:function(b){var a=this.get_events().getHandler("expanding");if(a)a(this,b)},add_expanded:function(a){this.get_events().addHandler("expanded",a)},remove_expanded:function(a){this.get_events().removeHandler("expanded",a)},raiseExpanded:function(b){var a=this.get_events().getHandler("expanded");if(a)a(this,b)},add_expandComplete:function(a){this.get_events().addHandler("expandComplete",a)},remove_expandComplete:function(a){this.get_events().removeHandler("expandComplete",a)},raiseExpandComplete:function(){var a=this.get_events().getHandler("expandComplete");if(a)a(this,Sys.EventArgs.Empty)},get_TargetHeight:function(){return this.get_element().offsetHeight},set_TargetHeight:function(a){this.get_element().style.height=a+"px";this.raisePropertyChanged("TargetHeight")},get_TargetWidth:function(){return this.get_element().offsetWidth},set_TargetWidth:function(a){this.get_element().style.width=a+"px";this.raisePropertyChanged("TargetWidth")},get_Collapsed:function(){return this._collapsed},set_Collapsed:function(b){var a=this;if(a.get_isInitialized()&&a.get_element()&&b!=a.get_Collapsed())a.togglePanel();else{a._collapsed=b;a.raisePropertyChanged("Collapsed")}},get_CollapsedSize:function(){return this._collapsedSize},set_CollapsedSize:function(a){if(this._collapsedSize!=a){this._collapsedSize=a;this.raisePropertyChanged("CollapsedSize")}},get_ExpandedSize:function(){return this._expandedSize},set_ExpandedSize:function(a){if(this._expandedSize!=a){this._expandedSize=a;this.raisePropertyChanged("ExpandedSize")}},get_CollapseControlID:function(){return this._collapseControlID},set_CollapseControlID:function(a){if(this._collapseControlID!=a){this._collapseControlID=a;this.raisePropertyChanged("CollapseControlID")}},get_ExpandControlID:function(){return this._expandControlID},set_ExpandControlID:function(a){if(this._expandControlID!=a){this._expandControlID=a;this.raisePropertyChanged("ExpandControlID")}},get_ScrollContents:function(){return this._scrollContents},set_ScrollContents:function(a){if(this._scrollContents!=a){this._scrollContents=a;this.raisePropertyChanged("ScrollContents")}},get_SuppressPostBack:function(){return this._suppressPostBack},set_SuppressPostBack:function(a){if(this._suppressPostBack!=a){this._suppressPostBack=a;this.raisePropertyChanged("SuppressPostBack")}},get_TextLabelID:function(){return this._textLabelID},set_TextLabelID:function(a){if(this._textLabelID!=a){this._textLabelID=a;this.raisePropertyChanged("TextLabelID")}},get_ExpandedText:function(){return this._expandedText},set_ExpandedText:function(a){if(this._expandedText!=a){this._expandedText=a;this.raisePropertyChanged("ExpandedText")}},get_CollapsedText:function(){return this._collapsedText},set_CollapsedText:function(a){if(this._collapsedText!=a){this._collapsedText=a;this.raisePropertyChanged("CollapsedText")}},get_ImageControlID:function(){return this._imageControlID},set_ImageControlID:function(a){if(this._imageControlID!=a){this._imageControlID=a;this.raisePropertyChanged("ImageControlID")}},get_ExpandedImage:function(){return this._expandedImage},set_ExpandedImage:function(a){if(this._expandedImage!=a){this._expandedImage=a;this.raisePropertyChanged("ExpandedImage")}},get_CollapsedImage:function(){return this._collapsedImage},set_CollapsedImage:function(a){if(this._collapsedImage!=a){this._collapsedImage=a;this.raisePropertyChanged("CollapsedImage")}},get_AutoExpand:function(){return this._autoExpand},set_AutoExpand:function(a){if(this._autoExpand!=a){this._autoExpand=a;this.raisePropertyChanged("AutoExpand")}},get_AutoCollapse:function(){return this._autoCollapse},set_AutoCollapse:function(a){if(this._autoCollapse!=a){this._autoCollapse=a;this.raisePropertyChanged("AutoCollapse")}},get_ExpandDirection:function(){return this._expandDirection==AjaxControlToolkit.CollapsiblePanelExpandDirection.Vertical},set_ExpandDirection:function(a){if(this._expandDirection!=a){this._expandDirection=a;this.raisePropertyChanged("ExpandDirection")}}};AjaxControlToolkit.CollapsiblePanelBehavior.registerClass("AjaxControlToolkit.CollapsiblePanelBehavior",AjaxControlToolkit.BehaviorBase);
if(typeof(Sys)!=='undefined')Sys.Application.notifyScriptLoaded();
