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
    public static class Utils
    {
        // Methods
        public static string GetTwoDigitInt(int number)
        {
            return string.Format("{0:00}", number);
        }

        public static bool IsEven(int intValue)
        {
            return ((intValue & 1) == 0);
        }

        public static bool IsOdd(int intValue)
        {
            return ((intValue & 1) == 1);
        }
    }


}
