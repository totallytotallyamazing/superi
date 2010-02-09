using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Tina.Controls
{
    public class RotatePanel : Panel
    {
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(double), typeof(RotatePanel), new PropertyMetadata(0.0, new PropertyChangedCallback(RotatePanel.offsetChanged)));
        public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register("Spacing", typeof(int), typeof(RotatePanel), new PropertyMetadata(0, new PropertyChangedCallback(RotatePanel.offsetChanged)));


        private static void offsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as RotatePanel).InvalidateArrange();
        }

        public double Offset
        {
            get
            {
                return (double)base.GetValue(OffsetProperty);
            }
            set
            {
                base.SetValue(OffsetProperty, Math.Floor(value));
            }
        }

        public int Spacing
        {
            get
            {
                return (int)base.GetValue(SpacingProperty);
            }
            set
            {
                base.SetValue(SpacingProperty, value);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            int num = 0;
            int num2 = 360 / base.Children.Count;
            double num3 = -(150 + (10 * this.Spacing));
            double num4 = Math.Abs(this.Offset);
            if (num4 > 360.0)
            {
                int num5 = ((int)num4) / 360;
                num4 = this.Offset - ((num5 - 1) * 360);
            }
            foreach (UIElement element in base.Children)
            {
                double x = (finalSize.Width - element.DesiredSize.Width) / 2.0;
                double y = (finalSize.Height - element.DesiredSize.Height) / 2.0;
                Size size = new Size(element.DesiredSize.Width, element.DesiredSize.Height);
                Rect finalRect = new Rect(new Point(x, y), size);

                element.Arrange(finalRect);
                num++;
            }
            return finalSize;
        }

    }
}
