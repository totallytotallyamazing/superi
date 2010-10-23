using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;

namespace Shop.Models
{
    public static class EFExtensions
    {
        public static int GetReferenceId(this EntityReference reference)
        {
            return Convert.ToInt32(reference.EntityKey.EntityKeyValues.First(r => r.Key == "Id").Value);
        }
    }
}