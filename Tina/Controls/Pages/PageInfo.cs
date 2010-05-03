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
using System.Runtime.CompilerServices;

namespace Tina.Controls.Pages
{
public class PageInfo
{
    // Fields
    private Canvas canvas;
    private string foreground;
    private string path;
    private string subtitle;
    private string title;

    // Properties
    public Canvas Canvas
    {
        
        get
        {
            return this.canvas;
        }
        internal 
        set
        {
            this.canvas = value;
        }
    }

    public string Foreground
    {
        [CompilerGenerated]
        get
        {
            return this.foreground;
        }
        internal 
        set
        {
            this.foreground = value;
        }
    }

    public string Path
    {
        get
        {
            return this.path;
        }
        internal
        set
        {
            this.path = value;
        }
    }

    public string Subtitle
    {
        get
        {
            return this.subtitle;
        }
        internal
        set
        {
            this.subtitle = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        internal
        set
        {
            this.title = value;
        }
    }
}


}
