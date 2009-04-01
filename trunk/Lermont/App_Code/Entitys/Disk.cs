using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Disk
/// </summary>
public class Disk : Book
{

    #region Constructors
    public Disk()
        : base()
    {
        TypeId = 2;
    }

    public Disk(int Id):base()
    {
        
        TypeId = 2;
    }

    public Disk(DataRow dr):base()
    {
        TypeId = 2;
    }
    #endregion



}
