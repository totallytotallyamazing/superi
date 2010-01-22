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

namespace Tina.Controls.Pages
{
    public class PageGenerator
    {
        // Fields
        private Page _parent;

        // Methods
        public PageGenerator(Page parent)
        {
            this._parent = parent;
        }

        public string GetPageString(int pageNumber)
        {
            int num2;
            string str = string.Empty;
            string str2 = "black";
            int num = 180;
            if ((pageNumber < 0) || (pageNumber >= this._parent.GetPageCount()))
            {
                return str;
            }
            if (this._parent.GetPageForeground(pageNumber).ToLower() == str2)
            {
                str2 = "white";
            }
            string pageTitle = this._parent.GetPageTitle(pageNumber);
            string pageSubtitle = this._parent.GetPageSubtitle(pageNumber);
            if (string.IsNullOrEmpty(pageTitle) && string.IsNullOrEmpty(pageSubtitle))
            {
                num2 = 0;
            }
            else if (!string.IsNullOrEmpty(pageTitle) && !string.IsNullOrEmpty(pageSubtitle))
            {
                num2 = 40;
            }
            else
            {
                num2 = 0x18;
            }
            str = "<Canvas>";
            if (pageNumber == 0)
            {
                string str5 = ((str + "<Grid Width='420' Height='570'>") + "<Image Width='840' Height='570' Source='" + this._parent.GetPagePath(pageNumber) + "' Opacity='1' Stretch='None' HorizontalAlignment='Right' />") + "</Grid>";
                string str6 = str5 + "<TextBlock Canvas.Top='220' Canvas.Left='165' TextAlignment='Left' Text='" + this._parent.GetPageTitle(pageNumber) + "' FontFamily='Arial' FontSize='30' Foreground='" + this._parent.GetPageForeground(pageNumber) + "' />";
                str = str6 + "<TextBlock Canvas.Top='260' Canvas.Left='165' TextAlignment='Left' Text='" + this._parent.GetPageSubtitle(pageNumber) + "' FontFamily='Arial' FontSize='11' Foreground='" + this._parent.GetPageForeground(pageNumber) + "' />";
            }
            else if (Utils.IsOdd(pageNumber))
            {
                str = ((str + "<Grid Width='420' Height='570'>") + "<Image Width='420' Height='570' Source='" + this._parent.GetPagePath(pageNumber) + "' Opacity='1' Stretch='None' HorizontalAlignment='Left' />") + "</Grid>";
                if (num2 > 0)
                {
                    object obj2 = str;
                    string str7 = string.Concat(new object[] { obj2, "<Rectangle Width=\"", num, "\" Height=\"", num2, "\" Canvas.Left=\"-10\" Canvas.Top=\"31\" Fill=\"", str2, "\" RadiusX=\"9\" RadiusY=\"9\" Opacity=\".7\" ><Rectangle.Clip><RectangleGeometry Rect=\"10,0,", num - 10, ",", num2, "\" /></Rectangle.Clip></Rectangle>" });
                    string str8 = str7 + "<TextBlock Canvas.Top='35' Canvas.Left='35' TextAlignment='Left' Text='" + pageTitle + "' FontFamily='Trebuchet MS' FontSize='15' Foreground='" + this._parent.GetPageForeground(pageNumber) + "' />";
                    str = str8 + "<TextBlock Canvas.Top='55' Canvas.Left='35' TextAlignment='Left' Text='" + pageSubtitle + "' FontFamily='Trebuchet MS' FontSize='11' Foreground='" + this._parent.GetPageForeground(pageNumber) + "' />";
                }
            }
            else
            {
                str = ((str + "<Grid Width='420' Height='570'>") + "<Image Width='840' Height='570' Source='" + this._parent.GetPagePath(pageNumber) + "' Opacity='1' Stretch='None' HorizontalAlignment='Right' />") + "</Grid>";
                if (num2 > 0)
                {
                    object obj3 = str;
                    string str9 = string.Concat(new object[] { obj3, "<Rectangle Width=\"", num, "\" Height=\"", num2, "\" Canvas.Left=\"", (420 - num) + 10, "\" Canvas.Top=\"31\" Fill=\"", str2, "\" RadiusX=\"9\" RadiusY=\"9\" Opacity=\".7\" ><Rectangle.Clip><RectangleGeometry Rect=\"0,0,", num - 10, ",", num2, "\" /></Rectangle.Clip></Rectangle>" });
                    string str10 = str9 + "<TextBlock Canvas.Top='35' Canvas.Left='35' TextAlignment='Right' Text='" + this._parent.GetPageTitle(pageNumber) + "' Width='355' FontFamily='Trebuchet MS' FontSize='15' Foreground='" + this._parent.GetPageForeground(pageNumber) + "' />";
                    str = str10 + "<TextBlock Canvas.Top='55' Canvas.Left='35' TextAlignment='Right' Text='" + this._parent.GetPageSubtitle(pageNumber) + "' Width='355' FontFamily='Trebuchet MS' FontSize='11' Foreground='" + this._parent.GetPageForeground(pageNumber) + "' />";
                }
            }
            if ((pageNumber % 2) == 0)
            {
                str = str + "  <Path Data='M 0,0 h 420 v 570 h -420' Stroke='White' StrokeThickness='15'/>";
            }
            else
            {
                str = str + "  <Path Data='M 420,570 h -420 v -570 h 420' Stroke='White' StrokeThickness='15'/>";
            }
            if (pageNumber == 0)
            {
                str = (((str + "<Rectangle Height='570' Width='40' Stretch='Fill'>" + "  <Rectangle.Fill>") + "    <LinearGradientBrush StartPoint='0,0' EndPoint='1,0'>" + "      <GradientStop Color='#80202020' Offset='0'/>") + "      <GradientStop Color='#00A0A0A0' Offset='1'/>" + "    </LinearGradientBrush>") + "  </Rectangle.Fill>" + "</Rectangle>";
            }
            else if (pageNumber == (this._parent.GetPageCount() - 1))
            {
                str = (str + "<Rectangle Width='420' Height='22' Canvas.Left='0' Canvas.Top='528' Fill='Black' Opacity='0.5' />") + "<TextBlock Canvas.Top='528' Canvas.Left='35' TextAlignment='Left' Width='355' FontFamily='Verdana' FontSize='9' Foreground='White'>Adapted by <Run FontWeight='Bold' FontSize='9'>Pedro Fortes</Run> for <Run FontWeight='Bold' FontSize='9'>Silverlight 2.0</Run><LineBreak/>from PageTurn Silverlight 1.0 Demo</TextBlock>" + "<TextBlock Canvas.Top='528' Canvas.Left='35' TextAlignment='Right' Width='355' FontFamily='Verdana' FontSize='9' Foreground='White'>v2.10<LineBreak/>pedro.fortes@live.com</TextBlock>";
            }
            return (str + "</Canvas>");
        }
    }


}
