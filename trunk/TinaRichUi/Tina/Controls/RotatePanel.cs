﻿using System;
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
        public static readonly DependencyProperty SegmentLengthProperty = DependencyProperty.Register("SegmentLength", typeof(int), typeof(RotatePanel), new PropertyMetadata(0, new PropertyChangedCallback(RotatePanel.offsetChanged)));

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

        public int SegmentLength
        {
            get
            {
                return (int)base.GetValue(SegmentLengthProperty);
            }
            set
            {
                base.SetValue(SegmentLengthProperty, value);
            }
        }

        private double GetDegrees(double radians)
        {
            double result = radians*180/Math.PI;
            return result;
        }

        private double GetRadians(double degrees)
        {
            double result = degrees * Math.PI / 180;
            return result;
        }

        double EvaluateRadius(int width, int count)
        {
            double radians = (180.0 * (count - 2.0)) / (2.0 * count);
            double circumcircle = width / (2.0 * Math.Cos(GetRadians(radians)));
            double radius = circumcircle * Math.Sin(GetRadians(radians));
            return radius;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            int itemsCount = base.Children.Count;
            int currentIndex = 0;
            double itemAngle = 360.0 / itemsCount;
            double incircle = EvaluateRadius(SegmentLength, itemsCount);
            double zRadius = -(incircle + (10 * this.Spacing));
            double absoluteOffset = Math.Abs(this.Offset);
            if (absoluteOffset > 360.0)
            {
                int num5 = ((int)absoluteOffset) / 360;
                absoluteOffset = this.Offset - ((num5 - 1) * 360);
            }
            foreach (UIElement element in base.Children)
            {
                double x = (finalSize.Width - element.DesiredSize.Width) / 2.0;
                double y = (finalSize.Height - element.DesiredSize.Height) / 2.0;
                Size size = new Size(element.DesiredSize.Width, element.DesiredSize.Height);
                Rect finalRect = new Rect(new Point(x, y), size);
                PlaneProjection projection = new PlaneProjection();
                double num8 = (currentIndex * itemAngle) + absoluteOffset;
                if (num8 > 360.0)
                {
                    num8 -= 360.0;
                }
                projection.CenterOfRotationZ = zRadius;
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
                currentIndex++;
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
