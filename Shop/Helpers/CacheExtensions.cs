using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Models;
using System.Web.Caching;
using System.Web.Security;

namespace Shop.Helpers
{
    public static class CacheExtensions
    {
        public static ProfileCommon GetProfile(this Cache cache)
        {
            ProfileCommon result = null;
            if(HttpContext.Current.Request.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser(true);
                result = ProfileCommon.Create(user.UserName);
                if (cache["profileCommon_" + user.UserName] == null)
                {
                    cache.Add("profileCommon_" + user.UserName, result, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(1), CacheItemPriority.Default, null);
                }
            }
            return result;
        }
    }
}
