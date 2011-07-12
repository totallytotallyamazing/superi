using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Subscribers
    {
        public static bool IsSubscribed
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["subscribe"] != null)
                {
                    return true;

                }
                return false;
            }
        }
    }
}