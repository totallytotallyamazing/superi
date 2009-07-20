using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zamov.Controllers
{
    public class CacheController : Controller
    {
        protected Cache Cache { get { return Zamov.Controllers.Cache.UniqueInstance; } }
    }
}
