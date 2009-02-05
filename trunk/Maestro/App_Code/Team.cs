using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Superi.Features;

/// <summary>
/// Summary description for Team
/// </summary>
public partial class Team
{
    public Resource Names
    {
        get { return new Resource(NameTextId.Value); }
    }

    public Resource Descriptions
    {
        get { return new Resource(DescriptionTextId.Value); }
    }
}
