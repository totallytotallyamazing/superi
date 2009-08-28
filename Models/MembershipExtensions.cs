using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Zamov.Models
{
    public static class MembershipExtensions
    {
        public static int[] GetOnlineDealers()
        {
            int[] result = null;
            using (MembershipStorage context = new MembershipStorage())
            {
                DateTime verificationTime = DateTime.Now.ToUniversalTime().AddMinutes(-3);
                var profiles = (from
                                    user in context.aspnet_Users.Include("aspnet_Roles").Include("aspnet_Profile")
                                where
                                    user.LastActivityDate> verificationTime
                                    && user.aspnet_Roles.Where(r => r.RoleName == "Dealers").Count() > 0
                                select
                                    new
                                    {
                                        PropertyNames = user.aspnet_Profile.PropertyNames,
                                        PropertyValues = user.aspnet_Profile.PropertyValuesString
                                    });

                result = new int[profiles.Count()];
                int i = 0;
                foreach (var item in profiles)
                {
                    result[i] = ExtractDealerId(item.PropertyNames, item.PropertyValues);
                    i++;
                }
            }
            return result;
        }

        private static int ExtractDealerId(string propertyNames, string propertyValues)
        {
            string[] properties = propertyNames.Split(':');
            int endPosition = int.Parse(properties[3]);
            return int.Parse(propertyValues.Substring(0, endPosition));
        }
    }
}
