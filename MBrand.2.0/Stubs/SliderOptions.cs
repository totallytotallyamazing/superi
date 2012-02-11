using System.Runtime.CompilerServices;

namespace jQueryApi.BxSlider
{
	#region Enums
	[NamedValues]
	public enum SliderDirection
	{
		Next, Prev
	}

	[NamedValues]
	public enum SliderMode
	{
		Horizontal, Vertical, Fade
	}

	[NamedValues]
	public enum PagerType
	{
		Full, Short
	}

	[NamedValues]
	public enum PagerLocation
	{
		Bottom, Top
	}
	#endregion

	public delegate void BxSlideDelegate(int currentSlideNumber, int totalSlideQty, int currentSlideHtmlObject);

	[ScriptName("Object")]
	public class SliderOptions
	{

		#region General
		[IntrinsicProperty]
		public SliderMode Mode { get; set; }
		[IntrinsicProperty]
		public int Speed { get; set; }
		[IntrinsicProperty]
		public bool InfiniteLoop { get; set; }
		[IntrinsicProperty]
		public bool Controls { get; set; }
		[IntrinsicProperty]
		public string PrevText { get; set; }
		[IntrinsicProperty]
		public string PrevImage { get; set; }
		[IntrinsicProperty]
		public string PrevSelector { get; set; }
		[IntrinsicProperty]
		public string NextText { get; set; }
		[IntrinsicProperty]
		public string NextImage { get; set; }
		[IntrinsicProperty]
		public string NextSelector { get; set; }
		[IntrinsicProperty]
		public int StartingSlide { get; set; }
		[IntrinsicProperty]
		public bool RandomStart { get; set; }
		[IntrinsicProperty]
		public bool HideControlOnEnd { get; set; }
		[IntrinsicProperty]
		public bool Captions { get; set; }
		[IntrinsicProperty]
		public string CaptionsSelector { get; set; }
		[IntrinsicProperty]
		public string WrapperClass { get; set; }
		[IntrinsicProperty]
		public string Easing { get; set; }

		#endregion

		#region Auto
		[IntrinsicProperty]
		public bool Auto { get; set; }
		[IntrinsicProperty]
		public int Pause { get; set; }
		[IntrinsicProperty]
		public bool AutoControls { get; set; }
		[IntrinsicProperty]
		public string AutoControlsSelector { get; set; }
		[IntrinsicProperty]
		public string StartText { get; set; }
		[IntrinsicProperty]
		public string StartImage { get; set; }
		[IntrinsicProperty]
		public string StopText { get; set; }
		[IntrinsicProperty]
		public string StopImage { get; set; }
		[IntrinsicProperty]
		public int AutoDelay { get; set; }
		[IntrinsicProperty]
		public SliderDirection AutoDirection { get; set; }
		[IntrinsicProperty]
		public bool AutoHover { get; set; }
		[IntrinsicProperty]
		public bool AutoStart { get; set; }
		#endregion

		#region Pager
		[IntrinsicProperty]
		public bool Pager { get; set; }
		[IntrinsicProperty]
		public PagerType PagerType { get; set; }
		[IntrinsicProperty]
		public string PagerSelector { get; set; }
		[IntrinsicProperty]
		public PagerLocation PagerLocation { get; set; }
		[IntrinsicProperty]
		public string PagerShortSeparator { get; set; }
		[IntrinsicProperty]
		public string PagerActiveClass { get; set; }
		#endregion

		#region Multiple Display
		[IntrinsicProperty, ScriptName("displaySlideQty")]
		public int DisplaySlideQuantity { get; set; }
		[IntrinsicProperty, ScriptName("moveSlideQty")]
		public int MoveSlideQuantity { get; set; }
		#endregion

		#region Ticker
		[IntrinsicProperty]
		public bool Ticker { get; set; }
		[IntrinsicProperty]
		public int TickerSpeed { get; set; }
		[IntrinsicProperty]
		public SliderDirection TickerDirection { get; set; }
		[IntrinsicProperty]
		public bool TickerHover { get; set; }
		#endregion

		#region Callbacks
		[IntrinsicProperty]
		public BxSlideDelegate OnFirstSlide { get; set; }
		[IntrinsicProperty]
		public BxSlideDelegate OnLastSlide { get; set; }
		[IntrinsicProperty]
		public BxSlideDelegate OnPrevSlide { get; set; }
		[IntrinsicProperty]
		public BxSlideDelegate OnNextSlide { get; set; }
		[IntrinsicProperty]
		public BxSlideDelegate OnBeforeSlide { get; set; }
		[IntrinsicProperty]
		public BxSlideDelegate OnAfterSlide { get; set; }
		#endregion    
	}
}