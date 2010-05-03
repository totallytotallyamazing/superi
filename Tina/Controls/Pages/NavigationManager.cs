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
    public class NavigationManager
    {
        // Fields
        private double _currX1;
        private int _nextOddPage;
        private int _numPages;
        private double _pageAnimationDelta;
        private double _pageAnimationTarget;
        private string _pageAnimationType;
        private Page _parent;
        private double _previousMouseMovePosition;
        private Storyboard _timer;
        private bool _trackMovement;

        // Methods
        public NavigationManager(int maxNumPages, Page parent)
        {
            this._parent = parent;
            this._numPages = maxNumPages;
            this._timer = (Storyboard)parent.FindName("timerStoryboard");
            this._timer.Completed += new EventHandler(this.Timer_Completed);
            this._pageAnimationType = "none";
            this._pageAnimationDelta = 0.0;
            this._pageAnimationTarget = 0.0;
            this._trackMovement = false;
            this._previousMouseMovePosition = 0.0;
            this._currX1 = 880.0;
            this._nextOddPage = 1;
        }

        public void BeginPageAnimation(string type)
        {
            if ((type == "showFold") && (this._nextOddPage <= this._numPages))
            {
                this._pageAnimationType = "showFold";
                this._pageAnimationTarget = 840.0;
                this._pageAnimationDelta = 5.0;
                this._timer.Begin();
            }
            if (type == "hideFold")
            {
                this._pageAnimationType = "hideFold";
                this._pageAnimationTarget = 880.0;
                this._pageAnimationDelta = Math.Abs((double)(this._currX1 - this._pageAnimationTarget));
                this._timer.Begin();
            }
            else if (type == "finishTurn")
            {
                if (this._nextOddPage <= this._numPages)
                {
                    this._pageAnimationType = "finishTurn";
                    this._pageAnimationDelta = 10.0;
                    this._pageAnimationTarget = 460.0;
                    this._timer.Begin();
                }
            }
            else if (type == "none")
            {
                this._pageAnimationType = "none";
                this._pageAnimationDelta = 0.0;
                this._pageAnimationTarget = 0.0;
            }
        }

        public void JumpToPage(int newOddPage)
        {
            this.BeginPageAnimation("none");
            if (this._nextOddPage != (newOddPage + 2))
            {
                if (this._nextOddPage <= (newOddPage + 2))
                {
                    while ((this._nextOddPage < (newOddPage + 2)) && (this._nextOddPage <= this._numPages))
                    {
                        this._currX1 = 460.0;
                        this.UpdateScene(this._nextOddPage, this._currX1 - 460.0);
                        this._nextOddPage += 2;
                    }
                    if (this._nextOddPage <= this._numPages)
                    {
                        this._currX1 = 880.0;
                        this.UpdateScene(this._nextOddPage, this._currX1 - 460.0);
                        this.BeginPageAnimation("showFold");
                    }
                }
                else
                {
                    if (this._nextOddPage > this._numPages)
                    {
                        this._nextOddPage -= 2;
                    }
                    while ((this._nextOddPage > (newOddPage + 2)) && (this._nextOddPage >= 1))
                    {
                        this._currX1 = 880.0;
                        this.UpdateScene(this._nextOddPage, this._currX1 - 460.0);
                        this._nextOddPage -= 2;
                    }
                    if (this._nextOddPage >= 1)
                    {
                        this._currX1 = 880.0;
                        this.UpdateScene(this._nextOddPage, this._currX1 - 460.0);
                    }
                    else
                    {
                        this._nextOddPage = 1;
                    }
                    this.BeginPageAnimation("showFold");
                }
            }
        }

        public void newOddPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Canvas)sender).CaptureMouse();
            this._trackMovement = true;
            this._previousMouseMovePosition = e.GetPosition(null).X;
            if (("page0" + Utils.GetTwoDigitInt(this._nextOddPage)) != ((Canvas)sender).Name)
            {
                if (this._nextOddPage <= this._numPages)
                {
                    this.BeginPageAnimation("hideFold");
                }
                else
                {
                    this.OnAnimationComplete("hideFold");
                }
            }
            else
            {
                this._pageAnimationType = "none";
            }
        }

        public void newOddPage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((Canvas)sender).ReleaseMouseCapture();
            this._trackMovement = false;
            if (this._currX1 < 600.0)
            {
                this.BeginPageAnimation("finishTurn");
            }
            else
            {
                this.BeginPageAnimation("showFold");
            }
        }

        public void newOddPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._trackMovement && (this._pageAnimationType == "none"))
            {
                double num = (e.GetPosition(null).X - this._previousMouseMovePosition) * 0.7;
                this._previousMouseMovePosition = e.GetPosition(null).X;
                this._currX1 = Math.Min(880.0, Math.Max((double)460.0, (double)(this._currX1 + num)));
                this.UpdateScene(this._nextOddPage, this._currX1 - 460.0);
            }
            else if (this._trackMovement)
            {
                this._previousMouseMovePosition = e.GetPosition(null).X;
            }
        }

        private void OnAnimationComplete(string type)
        {
            if (type == "showFold")
            {
                this._pageAnimationType = "none";
            }
            else if (type == "hideFold")
            {
                this._currX1 = 460.0;
                this._nextOddPage -= 2;
                this._pageAnimationType = "none";
            }
            else if (type == "finishTurn")
            {
                this._currX1 = 880.0;
                this._nextOddPage += 2;
                this._pageAnimationType = "none";
                this.BeginPageAnimation("showFold");
            }
        }

        private void Timer_Completed(object sender, EventArgs e)
        {
            if (this._pageAnimationType != "none")
            {
                if ((this._currX1 - this._pageAnimationTarget) == 0.0)
                {
                    this.OnAnimationComplete(this._pageAnimationType);
                }
                else
                {
                    if (Math.Abs((double)(this._currX1 - this._pageAnimationTarget)) < this._pageAnimationDelta)
                    {
                        this._currX1 = this._pageAnimationTarget;
                    }
                    else if (this._currX1 < this._pageAnimationTarget)
                    {
                        this._currX1 += this._pageAnimationDelta;
                    }
                    else
                    {
                        this._currX1 -= this._pageAnimationDelta;
                    }
                    this._timer.Begin();
                }
                if (this._nextOddPage <= this._numPages)
                {
                    this.UpdateScene(this._nextOddPage, this._currX1 - 460.0);
                }
            }
        }

        private void UpdateScene(int oddPageNumber, double x1)
        {
            Canvas pageCanvas = this._parent.GetPageCanvas(oddPageNumber);
            Canvas canvas2 = this._parent.GetPageCanvas(oddPageNumber - 1);
            LineSegment segment = (LineSegment)pageCanvas.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber) + "Point1");
            LineSegment segment2 = (LineSegment)pageCanvas.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber) + "Point2");
            LineSegment segment3 = (LineSegment)pageCanvas.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber) + "Point3");
            RotateTransform transform = (RotateTransform)pageCanvas.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber) + "Rotate");
            TranslateTransform transform2 = (TranslateTransform)pageCanvas.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber) + "Translate");
            Rectangle rectangle1 = (Rectangle)pageCanvas.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber) + "FoldShadow");
            RotateTransform transform3 = (RotateTransform)pageCanvas.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber) + "FoldShadowRotate");
            TranslateTransform transform4 = (TranslateTransform)pageCanvas.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber) + "FoldShadowTranslate");
            Image image = (Image)this._parent.FindName("shadowBehindPage01");
            Image image2 = (Image)this._parent.FindName("shadowBehindPageNN");
            LineSegment segment4 = (LineSegment)canvas2.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber - 1) + "Point1");
            LineSegment segment5 = (LineSegment)canvas2.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber - 1) + "Point2");
            LineSegment segment6 = (LineSegment)canvas2.FindName("page" + Utils.GetTwoDigitInt(oddPageNumber - 1) + "Point3");
            Polygon polygon = (Polygon)this._parent.FindName("shadowOnEvenPage");
            double num = 0.21428571428571427 * x1;
            segment4.Point = new Point(x1, 570.0);
            PointCollection points = new PointCollection();
            points.Add(new Point(x1, 570.0));
            points.Add(new Point(Math.Min((double)(x1 + 30.0), (double)420.0), 570.0));
            double num2 = 90.0 - num;
            double num3 = x1 - (Math.Cos((num * 3.1415926535897931) / 180.0) * (420.0 - x1));
            double num4 = Math.Sin((num * 3.1415926535897931) / 180.0) * (420.0 - x1);
            transform.Angle = num;
            transform2.X = 420.0 + num3;
            transform2.Y = -1.0 * num4;
            double num5 = (420.0 - num3) / Math.Cos((num2 * 3.1415926535897931) / 180.0);
            if (num5 >= 570.0)
            {
                double num7;
                double num8;
                double num6 = num4 + (Math.Sin((num2 * 3.1415926535897931) / 180.0) * 570.0);
                if (num6 > 570.0)
                {
                    num7 = (num6 - 570.0) / Math.Sin((num * 3.1415926535897931) / 180.0);
                    num8 = (num3 + (Math.Cos((num2 * 3.1415926535897931) / 180.0) * 570.0)) + ((num6 - 570.0) / Math.Tan((num * 3.1415926535897931) / 180.0));
                }
                else
                {
                    num7 = 420.0;
                    num8 = 0.0;
                }
                segment.Point = new Point(0.0, 0.0);
                segment2.Point = new Point(num7, 0.0);
                double num9 = 90.0 - (57.295779513082323 * Math.Atan(570.0 / ((420.0 - x1) - num7)));
                transform3.Angle = -1.0 * num9;
                int num10 = 40;
                transform4.X = (num7 - (20.0 * Math.Cos((num9 * 3.1415926535897931) / 180.0))) - (num10 * Math.Cos(((90.0 - num9) * 3.1415926535897931) / 180.0));
                transform4.Y = (20.0 * Math.Sin((num9 * 3.1415926535897931) / 180.0)) - (num10 * Math.Sin(((90.0 - num9) * 3.1415926535897931) / 180.0));
                segment5.Point = new Point(num8, 0.0);
                segment6.Point = new Point(num8, 0.0);
                points.Add(new Point(Math.Min((double)(num8 + 10.0), (double)420.0), 0.0));
                points.Add(new Point(num8, 0.0));
            }
            else
            {
                double num12;
                segment.Point = new Point(0.0, 570.0 - num5);
                segment2.Point = new Point(0.0, 570.0 - num5);
                double y = (570.0 - num4) - ((420.0 - num3) * Math.Tan((num2 * 3.1415926535897931) / 180.0));
                segment5.Point = new Point(420.0, y);
                segment6.Point = new Point(420.0, 0.0);
                points.Add(new Point(420.0, y));
                points.Add(new Point(420.0, y));
                if (x1 != 420.0)
                {
                    num12 = 90.0 - (57.295779513082323 * Math.Atan(num5 / (420.0 - x1)));
                }
                else
                {
                    num12 = 0.0;
                }
                transform3.Angle = -1.0 * num12;
                transform4.X = -20.0 * Math.Cos((num12 * 3.1415926535897931) / 180.0);
                transform4.Y = (570.0 - num5) + (20.0 * Math.Sin((num12 * 3.1415926535897931) / 180.0));
            }
            segment3.Point = new Point(420.0 - x1, 570.0);
            polygon.Points = points;
            if (oddPageNumber == this._numPages)
            {
                if (x1 < 380.0)
                {
                    if (x1 > 300.0)
                    {
                        image2.Opacity = 0.8 * ((x1 - 300.0) / 80.0);
                    }
                    else
                    {
                        image2.Opacity = 0.0;
                    }
                }
                else
                {
                    image2.Opacity = 0.8;
                }
            }
            if (x1 < 15.0)
            {
                polygon.Opacity = 0.25 * (x1 / 15.0);
                if (oddPageNumber > 1)
                {
                    image.Opacity = 0.8;
                }
                else
                {
                    image.Opacity = 0.8 - (0.8 * (x1 / 15.0));
                }
            }
            else
            {
                polygon.Opacity = 0.25;
                if (oddPageNumber > 1)
                {
                    image.Opacity = 0.8;
                }
                else
                {
                    image.Opacity = 0.0;
                }
            }
        }
    }


}
