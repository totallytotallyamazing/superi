using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace Tina
{
    [ContentProperty("Child")]
	public partial class SmylSong : UserControl 
	{
        public static readonly DependencyProperty ChildProperty = DependencyProperty.Register("Child", typeof(UIElement), typeof(SmylSong), null); 
 
        public UIElement Child
        {
            get { return (UIElement)this.GetValue(ChildProperty); }
            set
            {
                this.SetValue(ChildProperty, value);
                this.content.Content = value;
            }
        }


        public SmylSong()
		{
			// Required to initialize variables
			InitializeComponent();
		}
		
		public void Activate()
		{
			VisualStateManager.GoToState(this, "Active", true);
		}
		
		public void Deactivate()
		{
			VisualStateManager.GoToState(this, "Passive", true);
		}
	}
}