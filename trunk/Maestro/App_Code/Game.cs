using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Superi.Features;

/// <summary>
/// Summary description for Game
/// </summary>
public partial class Game
{
    public Resource HostComments
    {
        get { return new Resource(HostCommentsTextID); }
    }

    public Resource TeamComments
    {
        get { return new Resource(TeamCommentsTextID); }
    }

    public Resource HostFaults
    {
        get { return new Resource(HostFaultsTextID); }
    }

    public Resource TeamFaults
    {
        get { return new Resource(TeamFaultsTextID); }
    }
}
