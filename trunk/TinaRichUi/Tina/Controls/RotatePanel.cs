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

namespace Tina
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
            double num2 = 360.0 / base.Children.Count;
            double num3 = -(331.5 + (10 * this.Spacing));
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
                PlaneProjection projection = new PlaneProjection();
                double num8 = (num * num2) + num4;
                if (num8 > 360.0)
                {
                    num8 -= 360.0;
                }
                projection.CenterOfRotationZ = num3;
                projection.CenterOfRotationX = 0.5;
                projection.RotationY = num8;
                element.Projection = projection;
                double num9 = Math.Abs((double)(180.0 - num8)) / 180.0;
                double num10 = 10.0 * (1.0 - num9);
                double num11 = num9 + 0.5;
                DistanceEffect effect = new DistanceEffect();
                effect.Distance = num9;
                effect.MinOpacity = 0.25;
                element.Effect = effect;
                element.Arrange(finalRect);
                num++;
            }
            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement element in base.Children)
            {
                element.Measure(availableSize);
            }
            return new Size(double.IsPositiveInfinity(availableSize.Width) ? Application.Current.Host.Content.ActualWidth : availableSize.Width, double.IsPositiveInfinity(availableSize.Height) ? Application.Current.Host.Content.ActualHeight : availableSize.Height);
        }



    }
}
