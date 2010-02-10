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
    public class CustomEffect : ShaderEffect
    {
        // Fields
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(CustomEffect), 0);

        // Properties
        public Brush Input
        {
            get
            {
                return (Brush)base.GetValue(InputProperty);
            }
            set
            {
                base.SetValue(InputProperty, value);
            }
        }
    }

 

}
