using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Superi.Features;

/// <summary>
/// Summary description for Video
/// </summary>
public partial class Video
{
    public Resource Titles
    {
        get { return new Resource(TitleTextID.Value); }
    }
}
