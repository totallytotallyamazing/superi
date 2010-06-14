using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Shop.Models
{
    [MetadataType(typeof(ProductAttributeValueValidation))]
    public partial class ProductAttributeValue
    {
    }

    public class ProductAttributeValueValidation
    {
        [Required(ErrorMessage="Укажите порядок")]
        [DisplayName("Номер по порядку")]
        public int SortOrder { get; set; }

        [Required(ErrorMessage="Укажите значение")]
        [DisplayName("Значение")]
        public string Value { get; set; }
    }
}
