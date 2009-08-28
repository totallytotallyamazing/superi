﻿Type.registerNamespace("AjaxControlToolkit.Animation");var $AA=AjaxControlToolkit.Animation;$AA.registerAnimation=function(b,a){if(a&&(a===$AA.Animation||a.inheritsFrom&&a.inheritsFrom($AA.Animation))){if(!$AA.__animations)$AA.__animations={};$AA.__animations[b.toLowerCase()]=a;a.play=function(){var b=new a;a.apply(b,arguments);b.initialize();var c=Function.createDelegate(b,function(){b.remove_ended(c);c=null;b.dispose()});b.add_ended(c);b.play()}}else throw Error.argumentType("type",a,$AA.Animation,AjaxControlToolkit.Resources.Animation_InvalidBaseType)};$AA.buildAnimation=function(a,c){if(!a||a==="")return null;var b;a="("+a+")";if(!Sys.Debug.isDebug)try{b=Sys.Serialization.JavaScriptSerializer.deserialize(a)}catch(d){}else b=Sys.Serialization.JavaScriptSerializer.deserialize(a);return $AA.createAnimation(b,c)};$AA.createAnimation=function(c,l){var g="obj";if(!c||!c.AnimationName)throw Error.argument(g,AjaxControlToolkit.Resources.Animation_MissingAnimationName);var b=$AA.__animations[c.AnimationName.toLowerCase()];if(!b)throw Error.argument("type",String.format(AjaxControlToolkit.Resources.Animation_UknownAnimationName,c.AnimationName));var d=new b;if(l)d.set_target(l);if(c.AnimationChildren&&c.AnimationChildren.length)if($AA.ParentAnimation.isInstanceOfType(d))for(var k=0;k<c.AnimationChildren.length;k++){var m=$AA.createAnimation(c.AnimationChildren[k]);if(m)d.add(m)}else throw Error.argument(g,String.format(AjaxControlToolkit.Resources.Animation_ChildrenNotAllowed,b.getName()));var h=b.__animationProperties;if(!h){b.__animationProperties={};b.resolveInheritance();for(var j in b.prototype)if(j.startsWith("set_"))b.__animationProperties[j.substr(4).toLowerCase()]=j;delete b.__animationProperties["id"];h=b.__animationProperties}for(var e in c){var f=e.toLowerCase();if(f=="animationname"||f=="animationchildren")continue;var i=c[e],a=h[f];if(a&&String.isInstanceOfType(a)&&d[a])if(!Sys.Debug.isDebug)try{d[a](i)}catch(n){}else d[a](i);else if(f.endsWith("script")){a=h[f.substr(0,e.length-6)];if(a&&String.isInstanceOfType(a)&&d[a])d.DynamicProperties[a]=i;else if(Sys.Debug.isDebug)throw Error.argument(g,String.format(AjaxControlToolkit.Resources.Animation_NoDynamicPropertyFound,e,e.substr(0,e.length-5)))}else if(Sys.Debug.isDebug)throw Error.argument(g,String.format(AjaxControlToolkit.Resources.Animation_NoPropertyFound,e))}return d};$AA.Animation=function(d,c,e){var b=null,a=this;$AA.Animation.initializeBase(a);a._duration=1;a._fps=25;a._target=b;a._tickHandler=b;a._timer=b;a._percentComplete=0;a._percentDelta=b;a._owner=b;a._parentAnimation=b;a.DynamicProperties={};if(d)a.set_target(d);if(c)a.set_duration(c);if(e)a.set_fps(e)};$AA.Animation.prototype={dispose:function(){var a=this;if(a._timer){a._timer.dispose();a._timer=null}a._tickHandler=null;a._target=null;$AA.Animation.callBaseMethod(a,"dispose")},play:function(){var a=this;if(!a._owner){var b=true;if(!a._timer){b=false;if(!a._tickHandler)a._tickHandler=Function.createDelegate(a,a._onTimerTick);a._timer=new Sys.Timer;a._timer.add_tick(a._tickHandler);a.onStart();a._timer.set_interval(1e3/a._fps);a._percentDelta=100/(a._duration*a._fps);a._updatePercentComplete(0,true)}a._timer.set_enabled(true);a.raisePropertyChanged("isPlaying");if(!b)a.raisePropertyChanged("isActive")}},pause:function(){var a=this;if(!a._owner)if(a._timer){a._timer.set_enabled(false);a.raisePropertyChanged("isPlaying")}},stop:function(b){var a=this;if(!a._owner){var c=a._timer;a._timer=null;if(c){c.dispose();if(a._percentComplete!==100){a._percentComplete=100;a.raisePropertyChanged("percentComplete");if(b||b===undefined)a.onStep(100)}a.onEnd();a.raisePropertyChanged("isPlaying");a.raisePropertyChanged("isActive")}}},onStart:function(){var a=this;a.raiseStarted();for(var property in a.DynamicProperties)try{a[property](eval(a.DynamicProperties[property]))}catch(ex){if(Sys.Debug.isDebug)throw ex}},onStep:function(a){this.setValue(this.getAnimatedValue(a));this.raiseStep()},onEnd:function(){this.raiseEnded()},getAnimatedValue:function(){throw Error.notImplemented()},setValue:function(){throw Error.notImplemented()},interpolate:function(a,c,b){return a+(c-a)*(b/100)},_onTimerTick:function(){this._updatePercentComplete(this._percentComplete+this._percentDelta,true)},_updatePercentComplete:function(a,c){var b=this;if(a>100)a=100;b._percentComplete=a;b.raisePropertyChanged("percentComplete");if(c)b.onStep(a);if(a===100)b.stop(false)},setOwner:function(a){this._owner=a},raiseStarted:function(){var a=this.get_events().getHandler("started");if(a)a(this,Sys.EventArgs.Empty)},add_started:function(a){this.get_events().addHandler("started",a)},remove_started:function(a){this.get_events().removeHandler("started",a)},raiseEnded:function(){var a=this.get_events().getHandler("ended");if(a)a(this,Sys.EventArgs.Empty)},add_ended:function(a){this.get_events().addHandler("ended",a)},remove_ended:function(a){this.get_events().removeHandler("ended",a)},raiseStep:function(){var a=this.get_events().getHandler("step");if(a)a(this,Sys.EventArgs.Empty)},add_step:function(a){this.get_events().addHandler("step",a)},remove_step:function(a){this.get_events().removeHandler("step",a)},get_target:function(){var a=this;if(!a._target&&a._parentAnimation)return a._parentAnimation.get_target();return a._target},set_target:function(a){if(this._target!=a){this._target=a;this.raisePropertyChanged("target")}},set_animationTarget:function(c){var b=null,a=$get(c);if(a)b=a;else{var d=$find(c);if(d){a=d.get_element();if(a)b=a}}if(b)this.set_target(b);else throw Error.argument("id",String.format(AjaxControlToolkit.Resources.Animation_TargetNotFound,c))},get_duration:function(){return this._duration},set_duration:function(b){var a=this;b=a._getFloat(b);if(a._duration!=b){a._duration=b;a.raisePropertyChanged("duration")}},get_fps:function(){return this._fps},set_fps:function(b){var a=this;b=a._getInteger(b);if(a.fps!=b){a._fps=b;a.raisePropertyChanged("fps")}},get_isActive:function(){return this._timer!==null},get_isPlaying:function(){return this._timer!==null&&this._timer.get_enabled()},get_percentComplete:function(){return this._percentComplete},_getBoolean:function(a){if(String.isInstanceOfType(a))return Boolean.parse(a);return a},_getInteger:function(a){if(String.isInstanceOfType(a))return parseInt(a);return a},_getFloat:function(a){if(String.isInstanceOfType(a))return parseFloat(a);return a},_getEnum:function(a,b){if(String.isInstanceOfType(a)&&b&&b.parse)return b.parse(a);return a}};$AA.Animation.registerClass("AjaxControlToolkit.Animation.Animation",Sys.Component);$AA.registerAnimation("animation",$AA.Animation);$AA.ParentAnimation=function(d,c,e,a){$AA.ParentAnimation.initializeBase(this,[d,c,e]);this._animations=[];if(a&&a.length)for(var b=0;b<a.length;b++)this.add(a[b])};$AA.ParentAnimation.prototype={initialize:function(){var a=this;$AA.ParentAnimation.callBaseMethod(a,"initialize");if(a._animations)for(var c=0;c<a._animations.length;c++){var b=a._animations[c];if(b&&!b.get_isInitialized)b.initialize()}},dispose:function(){this.clear();this._animations=null;$AA.ParentAnimation.callBaseMethod(this,"dispose")},get_animations:function(){return this._animations},add:function(b){var a=this;if(a._animations){if(b)b._parentAnimation=a;Array.add(a._animations,b);a.raisePropertyChanged("animations")}},remove:function(a){if(this._animations){if(a)a.dispose();Array.remove(this._animations,a);this.raisePropertyChanged("animations")}},removeAt:function(c){var a=this;if(a._animations){var b=a._animations[c];if(b)b.dispose();Array.removeAt(a._animations,c);a.raisePropertyChanged("animations")}},clear:function(){var a=this;if(a._animations){for(var b=a._animations.length-1;b>=0;b--){a._animations[b].dispose();a._animations[b]=null}Array.clear(a._animations);a._animations=[];a.raisePropertyChanged("animations")}}};$AA.ParentAnimation.registerClass("AjaxControlToolkit.Animation.ParentAnimation",$AA.Animation);$AA.registerAnimation("parent",$AA.ParentAnimation);$AA.ParallelAnimation=function(c,b,d,a){$AA.ParallelAnimation.initializeBase(this,[c,b,d,a])};$AA.ParallelAnimation.prototype={add:function(a){$AA.ParallelAnimation.callBaseMethod(this,"add",[a]);a.setOwner(this)},onStart:function(){$AA.ParallelAnimation.callBaseMethod(this,"onStart");var b=this.get_animations();for(var a=0;a<b.length;a++)b[a].onStart()},onStep:function(c){var b=this.get_animations();for(var a=0;a<b.length;a++)b[a].onStep(c)},onEnd:function(){var b=this.get_animations();for(var a=0;a<b.length;a++)b[a].onEnd();$AA.ParallelAnimation.callBaseMethod(this,"onEnd")}};$AA.ParallelAnimation.registerClass("AjaxControlToolkit.Animation.ParallelAnimation",$AA.ParentAnimation);$AA.registerAnimation("parallel",$AA.ParallelAnimation);$AA.SequenceAnimation=function(e,d,f,c,b){var a=this;$AA.SequenceAnimation.initializeBase(a,[e,d,f,c]);a._handler=null;a._paused=false;a._playing=false;a._index=0;a._remainingIterations=0;a._iterations=b!==undefined?b:1};$AA.SequenceAnimation.prototype={dispose:function(){this._handler=null;$AA.SequenceAnimation.callBaseMethod(this,"dispose")},stop:function(){var a=this;if(a._playing){var b=a.get_animations();if(a._index<b.length){b[a._index].remove_ended(a._handler);for(var c=a._index;c<b.length;c++)b[c].stop()}a._playing=false;a._paused=false;a.raisePropertyChanged("isPlaying");a.onEnd()}},pause:function(){var a=this;if(a.get_isPlaying()){var b=a.get_animations()[a._index];if(b!=null)b.pause();a._paused=true;a.raisePropertyChanged("isPlaying")}},play:function(){var c="isPlaying",a=this,d=a.get_animations();if(!a._playing){a._playing=true;if(a._paused){a._paused=false;var e=d[a._index];if(e!=null){e.play();a.raisePropertyChanged(c)}}else{a.onStart();a._index=0;var b=d[a._index];if(b){b.add_ended(a._handler);b.play();a.raisePropertyChanged(c)}else a.stop()}}},onStart:function(){var a=this;$AA.SequenceAnimation.callBaseMethod(a,"onStart");a._remainingIterations=a._iterations-1;if(!a._handler)a._handler=Function.createDelegate(a,a._onEndAnimation)},_onEndAnimation:function(){var a=this,b=a.get_animations(),c=b[a._index++];if(c)c.remove_ended(a._handler);if(a._index<b.length){var e=b[a._index];e.add_ended(a._handler);e.play()}else if(a._remainingIterations>=1||a._iterations<=0){a._remainingIterations--;a._index=0;var d=b[0];d.add_ended(a._handler);d.play()}else a.stop()},onStep:function(){throw Error.invalidOperation(AjaxControlToolkit.Resources.Animation_CannotNestSequence)},onEnd:function(){this._remainingIterations=0;$AA.SequenceAnimation.callBaseMethod(this,"onEnd")},get_isActive:function(){return true},get_isPlaying:function(){return this._playing&&!this._paused},get_iterations:function(){return this._iterations},set_iterations:function(b){var a=this;b=a._getInteger(b);if(a._iterations!=b){a._iterations=b;a.raisePropertyChanged("iterations")}},get_isInfinite:function(){return this._iterations<=0}};$AA.SequenceAnimation.registerClass("AjaxControlToolkit.Animation.SequenceAnimation",$AA.ParentAnimation);$AA.registerAnimation("sequence",$AA.SequenceAnimation);$AA.SelectionAnimation=function(c,b,d,a){$AA.SelectionAnimation.initializeBase(this,[c,b,d,a]);this._selectedIndex=-1;this._selected=null};$AA.SelectionAnimation.prototype={getSelectedIndex:function(){throw Error.notImplemented()},onStart:function(){var a=this;$AA.SelectionAnimation.callBaseMethod(a,"onStart");var b=a.get_animations();a._selectedIndex=a.getSelectedIndex();if(a._selectedIndex>=0&&a._selectedIndex<b.length){a._selected=b[a._selectedIndex];if(a._selected){a._selected.setOwner(a);a._selected.onStart()}}},onStep:function(a){if(this._selected)this._selected.onStep(a)},onEnd:function(){var a=this;if(a._selected){a._selected.onEnd();a._selected.setOwner(null)}a._selected=null;a._selectedIndex=null;$AA.SelectionAnimation.callBaseMethod(a,"onEnd")}};$AA.SelectionAnimation.registerClass("AjaxControlToolkit.Animation.SelectionAnimation",$AA.ParentAnimation);$AA.registerAnimation("selection",$AA.SelectionAnimation);$AA.ConditionAnimation=function(d,c,e,b,a){$AA.ConditionAnimation.initializeBase(this,[d,c,e,b]);this._conditionScript=a};$AA.ConditionAnimation.prototype={getSelectedIndex:function(){var selected=-1;if(this._conditionScript&&this._conditionScript.length>0)try{selected=eval(this._conditionScript)?0:1}catch(ex){}return selected},get_conditionScript:function(){return this._conditionScript},set_conditionScript:function(a){if(this._conditionScript!=a){this._conditionScript=a;this.raisePropertyChanged("conditionScript")}}};$AA.ConditionAnimation.registerClass("AjaxControlToolkit.Animation.ConditionAnimation",$AA.SelectionAnimation);$AA.registerAnimation("condition",$AA.ConditionAnimation);$AA.CaseAnimation=function(d,c,e,b,a){$AA.CaseAnimation.initializeBase(this,[d,c,e,b]);this._selectScript=a};$AA.CaseAnimation.prototype={getSelectedIndex:function(){var selected=-1;if(this._selectScript&&this._selectScript.length>0)try{var result=eval(this._selectScript);if(result!==undefined)selected=result}catch(ex){}return selected},get_selectScript:function(){return this._selectScript},set_selectScript:function(a){if(this._selectScript!=a){this._selectScript=a;this.raisePropertyChanged("selectScript")}}};$AA.CaseAnimation.registerClass("AjaxControlToolkit.Animation.CaseAnimation",$AA.SelectionAnimation);$AA.registerAnimation("case",$AA.CaseAnimation);$AA.FadeEffect=function(){throw Error.invalidOperation()};$AA.FadeEffect.prototype={FadeIn:0,FadeOut:1};$AA.FadeEffect.registerEnum("AjaxControlToolkit.Animation.FadeEffect",false);$AA.FadeAnimation=function(g,f,h,e,d,c,b){var a=this;$AA.FadeAnimation.initializeBase(a,[g,f,h]);a._effect=e!==undefined?e:$AA.FadeEffect.FadeIn;a._max=c!==undefined?c:1;a._min=d!==undefined?d:0;a._start=a._min;a._end=a._max;a._layoutCreated=false;a._forceLayoutInIE=b===undefined||b===null?true:b;a._currentTarget=null;a._resetOpacities()};$AA.FadeAnimation.prototype={_resetOpacities:function(){var a=this;if(a._effect==$AA.FadeEffect.FadeIn){a._start=a._min;a._end=a._max}else{a._start=a._max;a._end=a._min}},_createLayout:function(){var a=this,b=a._currentTarget;if(b){a._originalWidth=$common.getCurrentStyle(b,"width");var c=$common.getCurrentStyle(b,"height");a._originalBackColor=$common.getCurrentStyle(b,"backgroundColor");if((!a._originalWidth||a._originalWidth==""||a._originalWidth=="auto")&&(!c||c==""||c=="auto"))b.style.width=b.offsetWidth+"px";if(!a._originalBackColor||a._originalBackColor==""||a._originalBackColor=="transparent"||a._originalBackColor=="rgba(0, 0, 0, 0)")b.style.backgroundColor=$common.getInheritedBackgroundColor(b);a._layoutCreated=true}},onStart:function(){var a=this;$AA.FadeAnimation.callBaseMethod(a,"onStart");a._currentTarget=a.get_target();a.setValue(a._start);if(a._forceLayoutInIE&&!a._layoutCreated&&Sys.Browser.agent==Sys.Browser.InternetExplorer)a._createLayout()},getAnimatedValue:function(a){return this.interpolate(this._start,this._end,a)},setValue:function(a){if(this._currentTarget)$common.setElementOpacity(this._currentTarget,a)},get_effect:function(){return this._effect},set_effect:function(b){var a=this;b=a._getEnum(b,$AA.FadeEffect);if(a._effect!=b){a._effect=b;a._resetOpacities();a.raisePropertyChanged("effect")}},get_minimumOpacity:function(){return this._min},set_minimumOpacity:function(b){var a=this;b=a._getFloat(b);if(a._min!=b){a._min=b;a._resetOpacities();a.raisePropertyChanged("minimumOpacity")}},get_maximumOpacity:function(){return this._max},set_maximumOpacity:function(b){var a=this;b=a._getFloat(b);if(a._max!=b){a._max=b;a._resetOpacities();a.raisePropertyChanged("maximumOpacity")}},get_forceLayoutInIE:function(){return this._forceLayoutInIE},set_forceLayoutInIE:function(b){var a=this;b=a._getBoolean(b);if(a._forceLayoutInIE!=b){a._forceLayoutInIE=b;a.raisePropertyChanged("forceLayoutInIE")}},set_startValue:function(a){a=this._getFloat(a);this._start=a}};$AA.FadeAnimation.registerClass("AjaxControlToolkit.Animation.FadeAnimation",$AA.Animation);$AA.registerAnimation("fade",$AA.FadeAnimation);$AA.FadeInAnimation=function(e,d,f,c,b,a){$AA.FadeInAnimation.initializeBase(this,[e,d,f,$AA.FadeEffect.FadeIn,c,b,a])};$AA.FadeInAnimation.prototype={onStart:function(){var a=this;$AA.FadeInAnimation.callBaseMethod(a,"onStart");if(a._currentTarget)a.set_startValue($common.getElementOpacity(a._currentTarget))}};$AA.FadeInAnimation.registerClass("AjaxControlToolkit.Animation.FadeInAnimation",$AA.FadeAnimation);$AA.registerAnimation("fadeIn",$AA.FadeInAnimation);$AA.FadeOutAnimation=function(e,d,f,c,b,a){$AA.FadeOutAnimation.initializeBase(this,[e,d,f,$AA.FadeEffect.FadeOut,c,b,a])};$AA.FadeOutAnimation.prototype={onStart:function(){var a=this;$AA.FadeOutAnimation.callBaseMethod(a,"onStart");if(a._currentTarget)a.set_startValue($common.getElementOpacity(a._currentTarget))}};$AA.FadeOutAnimation.registerClass("AjaxControlToolkit.Animation.FadeOutAnimation",$AA.FadeAnimation);$AA.registerAnimation("fadeOut",$AA.FadeOutAnimation);$AA.PulseAnimation=function(c,b,d,h,g,f,e){var a=this;$AA.PulseAnimation.initializeBase(a,[c,b,d,null,h!==undefined?h:3]);a._out=new $AA.FadeOutAnimation(c,b,d,g,f,e);a.add(a._out);a._in=new $AA.FadeInAnimation(c,b,d,g,f,e);a.add(a._in)};$AA.PulseAnimation.prototype={get_minimumOpacity:function(){return this._out.get_minimumOpacity()},set_minimumOpacity:function(b){var a=this;b=a._getFloat(b);a._out.set_minimumOpacity(b);a._in.set_minimumOpacity(b);a.raisePropertyChanged("minimumOpacity")},get_maximumOpacity:function(){return this._out.get_maximumOpacity()},set_maximumOpacity:function(b){var a=this;b=a._getFloat(b);a._out.set_maximumOpacity(b);a._in.set_maximumOpacity(b);a.raisePropertyChanged("maximumOpacity")},get_forceLayoutInIE:function(){return this._out.get_forceLayoutInIE()},set_forceLayoutInIE:function(b){var a=this;b=a._getBoolean(b);a._out.set_forceLayoutInIE(b);a._in.set_forceLayoutInIE(b);a.raisePropertyChanged("forceLayoutInIE")},set_duration:function(a){var b=this;a=b._getFloat(a);$AA.PulseAnimation.callBaseMethod(b,"set_duration",[a]);b._in.set_duration(a);b._out.set_duration(a)},set_fps:function(a){var b=this;a=b._getInteger(a);$AA.PulseAnimation.callBaseMethod(b,"set_fps",[a]);b._in.set_fps(a);b._out.set_fps(a)}};$AA.PulseAnimation.registerClass("AjaxControlToolkit.Animation.PulseAnimation",$AA.SequenceAnimation);$AA.registerAnimation("pulse",$AA.PulseAnimation);$AA.PropertyAnimation=function(e,c,f,d,b){var a=this;$AA.PropertyAnimation.initializeBase(a,[e,c,f]);a._property=d;a._propertyKey=b;a._currentTarget=null};$AA.PropertyAnimation.prototype={onStart:function(){$AA.PropertyAnimation.callBaseMethod(this,"onStart");this._currentTarget=this.get_target()},setValue:function(c){var a=this,b=a._currentTarget;if(b&&a._property&&a._property.length>0)if(a._propertyKey&&a._propertyKey.length>0&&b[a._property])b[a._property][a._propertyKey]=c;else b[a._property]=c},getValue:function(){var a=this,c=a.get_target();if(c&&a._property&&a._property.length>0){var b=c[a._property];if(b){if(a._propertyKey&&a._propertyKey.length>0)return b[a._propertyKey];return b}}return null},get_property:function(){return this._property},set_property:function(a){if(this._property!=a){this._property=a;this.raisePropertyChanged("property")}},get_propertyKey:function(){return this._propertyKey},set_propertyKey:function(a){if(this._propertyKey!=a){this._propertyKey=a;this.raisePropertyChanged("propertyKey")}}};$AA.PropertyAnimation.registerClass("AjaxControlToolkit.Animation.PropertyAnimation",$AA.Animation);$AA.registerAnimation("property",$AA.PropertyAnimation);$AA.DiscreteAnimation=function(e,c,f,d,b,a){$AA.DiscreteAnimation.initializeBase(this,[e,c,f,d,b]);this._values=a&&a.length?a:[]};$AA.DiscreteAnimation.prototype={getAnimatedValue:function(a){var b=Math.floor(this.interpolate(0,this._values.length-1,a));return this._values[b]},get_values:function(){return this._values},set_values:function(a){if(this._values!=a){this._values=a;this.raisePropertyChanged("values")}}};$AA.DiscreteAnimation.registerClass("AjaxControlToolkit.Animation.DiscreteAnimation",$AA.PropertyAnimation);$AA.registerAnimation("discrete",$AA.DiscreteAnimation);$AA.InterpolatedAnimation=function(f,d,g,a,b,c,e){$AA.InterpolatedAnimation.initializeBase(this,[f,d,g,a!==undefined?a:"style",b]);this._startValue=c;this._endValue=e};$AA.InterpolatedAnimation.prototype={get_startValue:function(){return this._startValue},set_startValue:function(b){var a=this;b=a._getFloat(b);if(a._startValue!=b){a._startValue=b;a.raisePropertyChanged("startValue")}},get_endValue:function(){return this._endValue},set_endValue:function(b){var a=this;b=a._getFloat(b);if(a._endValue!=b){a._endValue=b;a.raisePropertyChanged("endValue")}}};$AA.InterpolatedAnimation.registerClass("AjaxControlToolkit.Animation.InterpolatedAnimation",$AA.PropertyAnimation);$AA.registerAnimation("interpolated",$AA.InterpolatedAnimation);$AA.ColorAnimation=function(g,d,h,f,b,c,e){var a=this;$AA.ColorAnimation.initializeBase(a,[g,d,h,f,b,c,e]);a._start=null;a._end=null;a._interpolateRed=false;a._interpolateGreen=false;a._interpolateBlue=false};$AA.ColorAnimation.prototype={onStart:function(){var a=this;$AA.ColorAnimation.callBaseMethod(a,"onStart");a._start=$AA.ColorAnimation.getRGB(a.get_startValue());a._end=$AA.ColorAnimation.getRGB(a.get_endValue());a._interpolateRed=a._start.Red!=a._end.Red;a._interpolateGreen=a._start.Green!=a._end.Green;a._interpolateBlue=a._start.Blue!=a._end.Blue},getAnimatedValue:function(b){var a=this,e=a._start.Red,d=a._start.Green,c=a._start.Blue;if(a._interpolateRed)e=Math.round(a.interpolate(e,a._end.Red,b));if(a._interpolateGreen)d=Math.round(a.interpolate(d,a._end.Green,b));if(a._interpolateBlue)c=Math.round(a.interpolate(c,a._end.Blue,b));return $AA.ColorAnimation.toColor(e,d,c)},set_startValue:function(a){if(this._startValue!=a){this._startValue=a;this.raisePropertyChanged("startValue")}},set_endValue:function(a){if(this._endValue!=a){this._endValue=a;this.raisePropertyChanged("endValue")}}};$AA.ColorAnimation.getRGB=function(a){if(!a||a.length!=7)throw String.format(AjaxControlToolkit.Resources.Animation_InvalidColor,a);return {Red:parseInt(a.substr(1,2),16),Green:parseInt(a.substr(3,2),16),Blue:parseInt(a.substr(5,2),16)}};$AA.ColorAnimation.toColor=function(f,d,e){var c=f.toString(16),b=d.toString(16),a=e.toString(16);if(c.length==1)c="0"+c;if(b.length==1)b="0"+b;if(a.length==1)a="0"+a;return "#"+c+b+a};$AA.ColorAnimation.registerClass("AjaxControlToolkit.Animation.ColorAnimation",$AA.InterpolatedAnimation);$AA.registerAnimation("color",$AA.ColorAnimation);$AA.LengthAnimation=function(g,d,h,f,b,c,e,a){$AA.LengthAnimation.initializeBase(this,[g,d,h,f,b,c,e]);this._unit=a!=null?a:"px"};$AA.LengthAnimation.prototype={getAnimatedValue:function(b){var a=this,c=a.interpolate(a.get_startValue(),a.get_endValue(),b);return Math.round(c)+a._unit},get_unit:function(){return this._unit},set_unit:function(a){if(this._unit!=a){this._unit=a;this.raisePropertyChanged("unit")}}};$AA.LengthAnimation.registerClass("AjaxControlToolkit.Animation.LengthAnimation",$AA.InterpolatedAnimation);$AA.registerAnimation("length",$AA.LengthAnimation);$AA.MoveAnimation=function(d,c,e,f,h,g,i){var b=null,a=this;$AA.MoveAnimation.initializeBase(a,[d,c,e,b]);a._horizontal=f?f:0;a._vertical=h?h:0;a._relative=g===undefined?true:g;a._horizontalAnimation=new $AA.LengthAnimation(d,c,e,"style","left",b,b,i);a._verticalAnimation=new $AA.LengthAnimation(d,c,e,"style","top",b,b,i);a.add(a._verticalAnimation);a.add(a._horizontalAnimation)};$AA.MoveAnimation.prototype={onStart:function(){var a=this;$AA.MoveAnimation.callBaseMethod(a,"onStart");var b=a.get_target();a._horizontalAnimation.set_startValue(b.offsetLeft);a._horizontalAnimation.set_endValue(a._relative?b.offsetLeft+a._horizontal:a._horizontal);a._verticalAnimation.set_startValue(b.offsetTop);a._verticalAnimation.set_endValue(a._relative?b.offsetTop+a._vertical:a._vertical)},get_horizontal:function(){return this._horizontal},set_horizontal:function(b){var a=this;b=a._getFloat(b);if(a._horizontal!=b){a._horizontal=b;a.raisePropertyChanged("horizontal")}},get_vertical:function(){return this._vertical},set_vertical:function(b){var a=this;b=a._getFloat(b);if(a._vertical!=b){a._vertical=b;a.raisePropertyChanged("vertical")}},get_relative:function(){return this._relative},set_relative:function(b){var a=this;b=a._getBoolean(b);if(a._relative!=b){a._relative=b;a.raisePropertyChanged("relative")}},get_unit:function(){this._horizontalAnimation.get_unit()},set_unit:function(b){var a=this,c=a._horizontalAnimation.get_unit();if(c!=b){a._horizontalAnimation.set_unit(b);a._verticalAnimation.set_unit(b);a.raisePropertyChanged("unit")}}};$AA.MoveAnimation.registerClass("AjaxControlToolkit.Animation.MoveAnimation",$AA.ParallelAnimation);$AA.registerAnimation("move",$AA.MoveAnimation);$AA.ResizeAnimation=function(d,c,e,h,g,f){var b=null,a=this;$AA.ResizeAnimation.initializeBase(a,[d,c,e,b]);a._width=h;a._height=g;a._horizontalAnimation=new $AA.LengthAnimation(d,c,e,"style","width",b,b,f);a._verticalAnimation=new $AA.LengthAnimation(d,c,e,"style","height",b,b,f);a.add(a._horizontalAnimation);a.add(a._verticalAnimation)};$AA.ResizeAnimation.prototype={onStart:function(){var a=this;$AA.ResizeAnimation.callBaseMethod(a,"onStart");var b=a.get_target();a._horizontalAnimation.set_startValue(b.offsetWidth);a._verticalAnimation.set_startValue(b.offsetHeight);a._horizontalAnimation.set_endValue(a._width!==null&&a._width!==undefined?a._width:b.offsetWidth);a._verticalAnimation.set_endValue(a._height!==null&&a._height!==undefined?a._height:b.offsetHeight)},get_width:function(){return this._width},set_width:function(b){var a=this;b=a._getFloat(b);if(a._width!=b){a._width=b;a.raisePropertyChanged("width")}},get_height:function(){return this._height},set_height:function(b){var a=this;b=a._getFloat(b);if(a._height!=b){a._height=b;a.raisePropertyChanged("height")}},get_unit:function(){this._horizontalAnimation.get_unit()},set_unit:function(b){var a=this,c=a._horizontalAnimation.get_unit();if(c!=b){a._horizontalAnimation.set_unit(b);a._verticalAnimation.set_unit(b);a.raisePropertyChanged("unit")}}};$AA.ResizeAnimation.registerClass("AjaxControlToolkit.Animation.ResizeAnimation",$AA.ParallelAnimation);$AA.registerAnimation("resize",$AA.ResizeAnimation);$AA.ScaleAnimation=function(i,g,j,c,e,h,f,d){var b=null,a=this;$AA.ScaleAnimation.initializeBase(a,[i,g,j]);a._scaleFactor=c!==undefined?c:1;a._unit=e!==undefined?e:"px";a._center=h;a._scaleFont=f;a._fontUnit=d!==undefined?d:"pt";a._element=b;a._initialHeight=b;a._initialWidth=b;a._initialTop=b;a._initialLeft=b;a._initialFontSize=b};$AA.ScaleAnimation.prototype={getAnimatedValue:function(a){return this.interpolate(1,this._scaleFactor,a)},onStart:function(){var a=this;$AA.ScaleAnimation.callBaseMethod(a,"onStart");a._element=a.get_target();if(a._element){a._initialHeight=a._element.offsetHeight;a._initialWidth=a._element.offsetWidth;if(a._center){a._initialTop=a._element.offsetTop;a._initialLeft=a._element.offsetLeft}if(a._scaleFont)a._initialFontSize=parseFloat($common.getCurrentStyle(a._element,"fontSize"))}},setValue:function(b){var a=this;if(a._element){var e=Math.round(a._initialWidth*b),d=Math.round(a._initialHeight*b);a._element.style.width=e+a._unit;a._element.style.height=d+a._unit;if(a._center){a._element.style.top=a._initialTop+Math.round((a._initialHeight-d)/2)+a._unit;a._element.style.left=a._initialLeft+Math.round((a._initialWidth-e)/2)+a._unit}if(a._scaleFont){var c=a._initialFontSize*b;if(a._fontUnit=="px"||a._fontUnit=="pt")c=Math.round(c);a._element.style.fontSize=c+a._fontUnit}}},onEnd:function(){var b=null,a=this;a._element=b;a._initialHeight=b;a._initialWidth=b;a._initialTop=b;a._initialLeft=b;a._initialFontSize=b;$AA.ScaleAnimation.callBaseMethod(a,"onEnd")},get_scaleFactor:function(){return this._scaleFactor},set_scaleFactor:function(b){var a=this;b=a._getFloat(b);if(a._scaleFactor!=b){a._scaleFactor=b;a.raisePropertyChanged("scaleFactor")}},get_unit:function(){return this._unit},set_unit:function(a){if(this._unit!=a){this._unit=a;this.raisePropertyChanged("unit")}},get_center:function(){return this._center},set_center:function(b){var a=this;b=a._getBoolean(b);if(a._center!=b){a._center=b;a.raisePropertyChanged("center")}},get_scaleFont:function(){return this._scaleFont},set_scaleFont:function(b){var a=this;b=a._getBoolean(b);if(a._scaleFont!=b){a._scaleFont=b;a.raisePropertyChanged("scaleFont")}},get_fontUnit:function(){return this._fontUnit},set_fontUnit:function(a){if(this._fontUnit!=a){this._fontUnit=a;this.raisePropertyChanged("fontUnit")}}};$AA.ScaleAnimation.registerClass("AjaxControlToolkit.Animation.ScaleAnimation",$AA.Animation);$AA.registerAnimation("scale",$AA.ScaleAnimation);$AA.Action=function(b,a,c){$AA.Action.initializeBase(this,[b,a,c]);if(a===undefined)this.set_duration(0)};$AA.Action.prototype={onEnd:function(){this.doAction();$AA.Action.callBaseMethod(this,"onEnd")},doAction:function(){throw Error.notImplemented()},getAnimatedValue:function(){},setValue:function(){}};$AA.Action.registerClass("AjaxControlToolkit.Animation.Action",$AA.Animation);$AA.registerAnimation("action",$AA.Action);$AA.EnableAction=function(c,b,d,a){$AA.EnableAction.initializeBase(this,[c,b,d]);this._enabled=a!==undefined?a:true};$AA.EnableAction.prototype={doAction:function(){var a=this.get_target();if(a)a.disabled=!this._enabled},get_enabled:function(){return this._enabled},set_enabled:function(b){var a=this;b=a._getBoolean(b);if(a._enabled!=b){a._enabled=b;a.raisePropertyChanged("enabled")}}};$AA.EnableAction.registerClass("AjaxControlToolkit.Animation.EnableAction",$AA.Action);$AA.registerAnimation("enableAction",$AA.EnableAction);$AA.HideAction=function(c,a,d,b){$AA.HideAction.initializeBase(this,[c,a,d]);this._visible=b};$AA.HideAction.prototype={doAction:function(){var a=this.get_target();if(a)$common.setVisible(a,this._visible)},get_visible:function(){return this._visible},set_visible:function(a){if(this._visible!=a){this._visible=a;this.raisePropertyChanged("visible")}}};$AA.HideAction.registerClass("AjaxControlToolkit.Animation.HideAction",$AA.Action);$AA.registerAnimation("hideAction",$AA.HideAction);$AA.StyleAction=function(c,b,e,a,d){$AA.StyleAction.initializeBase(this,[c,b,e]);this._attribute=a;this._value=d};$AA.StyleAction.prototype={doAction:function(){var a=this.get_target();if(a)a.style[this._attribute]=this._value},get_attribute:function(){return this._attribute},set_attribute:function(a){if(this._attribute!=a){this._attribute=a;this.raisePropertyChanged("attribute")}},get_value:function(){return this._value},set_value:function(a){if(this._value!=a){this._value=a;this.raisePropertyChanged("value")}}};$AA.StyleAction.registerClass("AjaxControlToolkit.Animation.StyleAction",$AA.Action);$AA.registerAnimation("styleAction",$AA.StyleAction);$AA.OpacityAction=function(c,a,d,b){$AA.OpacityAction.initializeBase(this,[c,a,d]);this._opacity=b};$AA.OpacityAction.prototype={doAction:function(){var a=this.get_target();if(a)$common.setElementOpacity(a,this._opacity)},get_opacity:function(){return this._opacity},set_opacity:function(b){var a=this;b=a._getFloat(b);if(a._opacity!=b){a._opacity=b;a.raisePropertyChanged("opacity")}}};$AA.OpacityAction.registerClass("AjaxControlToolkit.Animation.OpacityAction",$AA.Action);$AA.registerAnimation("opacityAction",$AA.OpacityAction);$AA.ScriptAction=function(c,a,d,b){$AA.ScriptAction.initializeBase(this,[c,a,d]);this._script=b};$AA.ScriptAction.prototype={doAction:function(){try{eval(this._script)}catch(ex){}},get_script:function(){return this._script},set_script:function(a){if(this._script!=a){this._script=a;this.raisePropertyChanged("script")}}};$AA.ScriptAction.registerClass("AjaxControlToolkit.Animation.ScriptAction",$AA.Action);$AA.registerAnimation("scriptAction",$AA.ScriptAction);
if(typeof(Sys)!=='undefined')Sys.Application.notifyScriptLoaded();
