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
using System.Windows.Media.Effects;

namespace Tina
{
    public class DistanceEffect : CustomEffect
    {
        // Fields
        public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register("Distance", typeof(double), typeof(DistanceEffect), new PropertyMetadata(1.0, ShaderEffect.PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty MinOpacityProperty = DependencyProperty.Register("MinOpacity", typeof(double), typeof(DistanceEffect), new PropertyMetadata(0.0, ShaderEffect.PixelShaderConstantCallback(1)));
        private static PixelShader pixelShader = new PixelShader();

        // Methods
        static DistanceEffect()
        {
            pixelShader.UriSource = new Uri("/Tina;component/Distance.ps", UriKind.RelativeOrAbsolute);
        }

        public DistanceEffect()
        {
            base.PixelShader = pixelShader;
            base.UpdateShaderValue(CustomEffect.InputProperty);
            base.UpdateShaderValue(DistanceProperty);
            base.UpdateShaderValue(MinOpacityProperty);
        }

        // Properties
        public double Distance
        {
            get
            {
                return (double)base.GetValue(DistanceProperty);
            }
            set
            {
                base.SetValue(DistanceProperty, value);
            }
        }

        public double MinOpacity
        {
            get
            {
                return (double)base.GetValue(MinOpacityProperty);
            }
            set
            {
                base.SetValue(MinOpacityProperty, value);
            }
        }
    }


}
