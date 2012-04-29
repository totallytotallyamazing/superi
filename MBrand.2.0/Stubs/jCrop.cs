// jCrop.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace jQueryApi.jCrop
{
    [GlobalMethods, IgnoreNamespace]
    public static class jCrop
    {
        [ScriptName("$")]
        public static jCropObject Select(string selector) { return null; }
    }

    [Imported]
    public class jCropObject : jQueryObject
    {
        [ScriptName("Jcrop")]
        public jCropObject jCrop(jCropOptions options)
        {
            return null;
        }
    }

    [Imported, ScriptName("Object")]
    public class jCropOptions
    {
        public Action<jCropDimensions> OnSelect { get; set; }
        public Action<jCropDimensions> OnChange { get; set; }
        public Action<jCropDimensions> OnRelease { get; set; }

        public decimal AspectRatio { get; set; }
        public int[] MinSize { get; set; }
        public int[] MaxSize { get; set; }
        public int[] SetSelect { get; set; }
        public string BgColor { get; set; }
        public decimal BgOpacity { get; set; }
    }

    [Imported]
    public class jCropDimensions
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int W { get; set; }
        public int H { get; set; }
    }
}
