using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Dev.Helpers
{
    public static class DevSession
    {
        private static HttpSessionState session = HttpContext.Current.Session;
    }
}
