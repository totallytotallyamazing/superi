using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace Zamov.Models
{
    public class ProfileCommon : ProfileBase
    {
        private ProfileBase profile;

        public virtual string FirstName
        {
            get { return (string)profile.GetPropertyValue("FirstName"); }
            set { profile.SetPropertyValue("FirstName", value); }
        }

        public virtual string LastName
        {
            get { return (string)profile.GetPropertyValue("LastName"); }
            set { profile.SetPropertyValue("LastName", value); }
        }

        public virtual string Phone
        {
            get { return (string)profile.GetPropertyValue("Phone"); }
            set { profile.SetPropertyValue("Phone", value); }
        }

        public virtual bool DealerEmployee
        {
            get 
            { 
                bool result = false;
                object profileProperty = profile.GetPropertyValue("DealerEmployee");
                if (profileProperty != null)
                    result = Convert.ToBoolean(profileProperty);
                return result;
            }
            set { profile.SetPropertyValue("DealerEmployee", value); }
        }

        public virtual int DealerId
        {
            get 
            {
                int result = int.MinValue;
                object profileProperty = profile.GetPropertyValue("DealerId");
                if (profileProperty != null)
                    result = Convert.ToInt32(profileProperty);
                return result;
            }
            set { profile.SetPropertyValue("DealerId", value); }
        }

        protected ProfileCommon(ProfileBase profile)
        {
            this.profile = profile;
        }

        public static new ProfileCommon Create(string userName)
        {
            return new ProfileCommon(ProfileBase.Create(userName));
        }

        public override void Save()
        {
            profile.Save();
        }

        public override System.Configuration.SettingsProviderCollection Providers
        {
            get
            {
                return profile.Providers;
            }
        }

        public override System.Configuration.SettingsPropertyValueCollection PropertyValues
        {
            get
            {
                return profile.PropertyValues;
            }
        }

        public override object this[string propertyName]
        {
            get
            {
                return profile[propertyName];
            }
            set
            {
                profile[propertyName] = value;
            }
        }

        public override System.Configuration.SettingsContext Context
        {
            get
            {
                return profile.Context;
            }
        }
    }
}
