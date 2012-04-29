// BxSlider.cs
//

using System;
using System.Collections.Generic;
using jQueryApi;
using System.Runtime.CompilerServices;

namespace jQueryApi.BxSlider
{
    [GlobalMethods]
    public static class BxSlider
    {
        [ScriptName("$")]
        public static BxSliderObject Select(string selector) { return null; }
    }

    [Imported]
    public class BxSliderObject : jQueryObject
    {
        public BxSliderObject BxSlider() { return null; }

        [AlternateSignature] 
        public BxSliderObject BxSlider(SliderOptions options) { return null; }

        public void GoToPreviousSlide() { }
        
        public void GoToNextSlide() { }

        public void GoToSlide(int index) { }

        public void GoToFirstSlide() { }

        public void GoToLastSlide() { }

        public int GetCurrentSlide() { return 0; }

        public int GetSlideCount() { return 0; }

        public void StopShow() { }

        public void StartShow() { }

        public void StopTicker() { }

        public void StartTicker() { }

        public void DestroyShow() { }

        public void ReloadShow() { }
    }
}

