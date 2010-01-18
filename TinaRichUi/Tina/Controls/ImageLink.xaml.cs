using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Tina
{
	public partial class ImageLink : UserControl
	{
        public static DependencyProperty ImageSourceProperty = DependencyProperty.RegisterAttached("ImageSource", typeof(DependencyProperty), typeof(ImageLink), new PropertyMetadata(null));

        public ImageSource ImageSource { get; set; }

		public ImageLink()
		{
			// Required to initialize variables
			InitializeComponent();
		}
	}
}