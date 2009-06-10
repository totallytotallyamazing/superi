using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Zamov.Models
{
    public partial class ZamovStorage
    {
        public void DeleteTranslations(global::System.Int32 itemId, global::System.Int32 translationItemTypeId)
        { 
            ObjectParameter itemIdParameter;
            itemIdParameter = new ObjectParameter("ItemId", itemId);
            ObjectParameter translationItemTypeIdParameter = new ObjectParameter("ItemId", translationItemTypeId);;
            base.ExecuteFunction<IEntityWithChangeTracker>("DeleteTranslations", itemIdParameter, translationItemTypeIdParameter);
        }
    }
}
