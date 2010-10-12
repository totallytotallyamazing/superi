using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace Shop.Models
{
    public class ProfileCommon : ProfileBase
    {
        private ProfileBase profile;

        public virtual string Name
        {
            get { return (string)profile.GetPropertyValue("Name"); }
            set { profile.SetPropertyValue("Name", value); }
        }

        public virtual string Phone
        {
            get { return (string)profile.GetPropertyValue("Phone"); }
            set { profile.SetPropertyValue("Phone", value); }
        }

        public virtual string DeliveryAddress
        {
            get { return (string)profile.GetPropertyValue("DeliveryAddress"); }
            set { profile.SetPropertyValue("DeliveryAddress", value); }
        }

        public virtual string Subway
        {
            get { return (string)profile.GetPropertyValue("Subway"); }
            set { profile.SetPropertyValue("Subway", value); }
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
