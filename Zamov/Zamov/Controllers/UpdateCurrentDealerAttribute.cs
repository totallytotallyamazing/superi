using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zamov.Models;

namespace Zamov.Controllers
{
    public class UpdateCurrentDealerAttribute : FilterAttribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser(false);
                if (Roles.IsUserInRole(user.UserName, "Dealers"))
                {
                    ProfileCommon profile = ProfileCommon.Create(user.UserName);
                    SystemSettings.CurrentDealer = profile.DealerId;
                }
            }
        }
    }
}
